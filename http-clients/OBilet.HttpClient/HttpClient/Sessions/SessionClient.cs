using OBilet.HttpClient.Abstracts;
using System.Threading;
using System.Threading.Tasks;

namespace OBilet.HttpClient.Sessions
{
    public class SessionClient : BaseHttpClient
    {

        public SessionClient(System.Net.Http.HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<GetSessionResponse> GetSessionAsync(GetSessionRequest input, CancellationToken cancellationToken = default)
        {
            return PostAsync<GetSessionResponse, GetSessionRequest>("client/getsession", input, cancellationToken);
        }

    }
}
