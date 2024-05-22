using OBilet.HttpClient.Abstracts;
using System.Text.Json.Serialization;

namespace OBilet.HttpClient.Sessions
{
    public class GetSessionResponse:BaseResponse<SessionInfo>
    {
    }

    public class SessionInfo 
    {
        [JsonPropertyName("session-id")]
        public string SessionId { get; set; }

        [JsonPropertyName("device-id")]
        public string DeviceId { get; set; }
    }
}
