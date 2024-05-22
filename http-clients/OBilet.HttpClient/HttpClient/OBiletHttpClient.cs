using OBilet.HttpClient.BusLocations;
using OBilet.HttpClient.Journeys;
using OBilet.HttpClient.Sessions;

namespace OBilet.HttpClient
{
    public class OBiletHttpClient
    {
        public SessionClient Session { get; }

        public BusLocationClient Location { get; }

        public JourneyClient Journey { get; }


        public OBiletHttpClient(System.Net.Http.HttpClient httpClient)
        {
            Session = new SessionClient(httpClient);
            Location = new BusLocationClient(httpClient);
            Journey = new JourneyClient(httpClient);
        }

    }
}
