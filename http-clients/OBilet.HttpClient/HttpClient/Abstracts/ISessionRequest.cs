using OBilet.HttpClient.Sessions;
using System.Text.Json.Serialization;

namespace OBilet.HttpClient.Abstracts
{
    public interface ISessionRequest
    {
        [JsonPropertyName("device-session")]
        SessionInfo DeviceSession { get; set; }
    }
}
