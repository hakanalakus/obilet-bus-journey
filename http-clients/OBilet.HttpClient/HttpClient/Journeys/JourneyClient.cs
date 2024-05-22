using OBilet.HttpClient.Abstracts;
using System.Threading;
using System.Threading.Tasks;

namespace OBilet.HttpClient.Journeys
{
    public class JourneyClient : BaseHttpClient
    {
        public JourneyClient(System.Net.Http.HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<GetJourneyResponse> GetJourneysAsync(GetJourneysRequest input, CancellationToken cancellationToken = default) 
        {
            return PostAsync<GetJourneyResponse,GetJourneysRequest>("journey/getbusjourneys",input,cancellationToken);
        }
    }
}
