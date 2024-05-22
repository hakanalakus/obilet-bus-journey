using OBilet.HttpClient.Abstracts;
using OBilet.HttpClient.BusLocations;
using System.Threading;
using System.Threading.Tasks;

namespace OBilet.HttpClient.BusLocations
{
    public class BusLocationClient : BaseHttpClient
    {
        public BusLocationClient(System.Net.Http.HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<GetBusLocationsResponse> GetBusLocationsAsync(GetBusLocationsRequest input, CancellationToken cancellationToken = default) 
        {
            return PostAsync<GetBusLocationsResponse,GetBusLocationsRequest>("location/getbuslocations",input,cancellationToken);
        }
    }
}
