using OBilet.HttpClient;
using OBilet.HttpClient.Sessions;
using OBilet.Web.Core.CurrentUser;
using OBilet.Web.Core.Session;

namespace OBilet.Web.Middlewares
{
    public class OBiletApiSessionBuilderMiddleware(ISessionInfoProvider sessionInfoProvider,
        OBiletHttpClient oBiletHttpClient,
        ICurrentUser currentUser,
        ILogger<OBiletApiSessionBuilderMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                _ = await sessionInfoProvider.GetOrSetAsync<SessionInfo>(SessionKeyConsts.OBiletApiSession, async () =>
                {
                    var response = await oBiletHttpClient.Session.GetSessionAsync(new GetSessionRequest
                    {
                        Browser = new BrowserInfo { Name = currentUser.UserAgent, Version = currentUser.UserAgentVersion },
                        Connection = new HttpClient.Sessions.ConnectionInfo { IpAddress = currentUser.IPAddress, Port = "123" },
                        Type = 1
                    });

                    return response.Data;
                });

                await next(context);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Api session could not be created.");
                throw;
            }

        }
    }
}
