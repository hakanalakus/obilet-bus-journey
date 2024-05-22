using System;
using System.Text.Json.Serialization;

namespace OBilet.HttpClient.Abstracts
{
    public abstract class BaseResponse<TData>
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        public TData Data { get; set; }

        [JsonPropertyName("correlation-id")]
        public Guid CorrelationId { get; set; }
    }
}
