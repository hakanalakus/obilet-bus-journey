using Microsoft.AspNetCore.Mvc;
using OBilet.HttpClient;
using OBilet.HttpClient.BusLocations;
using OBilet.HttpClient.Journeys;
using OBilet.HttpClient.Sessions;
using OBilet.Web.Core.CurrentUser;
using OBilet.Web.Core.Session;
using OBilet.Web.Dto;
using OBilet.Web.Models;
using System.Diagnostics;

namespace OBilet.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly OBiletHttpClient _obiletHttpClient;
    private readonly ISessionInfoProvider _sessionInfoProvider;
    private readonly ICurrentUser _currentUser;

    public HomeController(ILogger<HomeController> logger,
        OBiletHttpClient oBiletHttpClient,
        ISessionInfoProvider sessionInfoProvider,
        ICurrentUser currentUser)
    {
        _logger = logger;
        _obiletHttpClient = oBiletHttpClient;
        _sessionInfoProvider = sessionInfoProvider;
        _currentUser = currentUser;

    }

    public IActionResult Index()
    {
        return View(new IndexViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> IndexAsync(IndexViewModel model)
    {
        if(!ModelState.IsValid)
            return View(model);

        var journeyInfo = await _obiletHttpClient.Journey.GetJourneysAsync(new GetJourneysRequest
        {
            Data = new JourneyData
            {
                DepartureDate = model.Date.Value,
                DestinationId = model.DestinationId.Value,
                OriginId = model.SourceId.Value
            },
            Date = DateTime.Now,
            DeviceSession = _sessionInfoProvider.Get<SessionInfo>(SessionKeyConsts.OBiletApiSession),
            Language = "tr-TR"
        });

        if(journeyInfo == null || journeyInfo.Data == null)
            return View("Journey", new JourneyViewModel());

        var viewModel = new JourneyViewModel
        {
            Origin = journeyInfo.Data.FirstOrDefault()?.Origin,
            Destination = journeyInfo.Data.FirstOrDefault()?.Destination,
            JourneyInfos = journeyInfo.Data.Select(x => new JourneyInfoDto
            {
                PartnerName = x.PartnerName,
                DepartureStop = x.Journey?.OriginStop,
                ArrivalStop = x.Journey?.DestinationStop,
                DepartureTime = x.Journey?.DepartureTime,
                ArrivalTime = x.Journey?.ArrivalTime,
                Price = x.Journey?.InternetPrice
            }).ToList()
        };

        return View("Journey", viewModel);

    }


    [HttpGet]
    public async Task<IActionResult> GetBusLocationsAsync([FromQuery] string q)
    {
        var locations = await _obiletHttpClient.Location.GetBusLocationsAsync(new GetBusLocationsRequest
        {
            Data = q,
            Date = DateTime.Now,
            Language = "tr-TR",
            DeviceSession = _sessionInfoProvider.Get<SessionInfo>(SessionKeyConsts.OBiletApiSession)
        });

        var result = locations?.Data?.Select(x => new SelectItemDto
        {
            Text = x.Name,
            Id = x.Id
        }).ToList() ?? new List<SelectItemDto>();

        return Json(new Select2Dto
        {
            Results = result
        });
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
