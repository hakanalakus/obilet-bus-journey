using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OBilet.HttpClient.Abstracts
{
    public abstract class BaseHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public BaseHttpClient(System.Net.Http.HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<TOutput> PostAsync<TOutput, TInput>(string uri, TInput input, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync(uri, input, cancellationToken);
            var result = await response.Content.ReadFromJsonAsync<TOutput>();

            return result;
        }

        public async Task<TOutput> GetAsync<TOutput>(string uri, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetFromJsonAsync<TOutput>(uri, cancellationToken);
            return response;
        }
    }
}
