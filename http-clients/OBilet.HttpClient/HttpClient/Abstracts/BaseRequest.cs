using OBilet.HttpClient.Sessions;
using System;
using System.Text.Json.Serialization;

namespace OBilet.HttpClient.Abstracts
{
    public abstract class BaseRequest<TData>:ISessionRequest
    {
        [JsonPropertyName("data")]
        public TData Data { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("device-session")]
        public SessionInfo DeviceSession { get; set; }
    }
}
