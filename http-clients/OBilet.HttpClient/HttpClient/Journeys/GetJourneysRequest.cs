using OBilet.HttpClient.Abstracts;
using System;
using System.Text.Json.Serialization;

namespace OBilet.HttpClient.Journeys
{
    public class GetJourneysRequest:BaseRequest<JourneyData>
    {
    }

    public class JourneyData 
    {
        [JsonPropertyName("origin-id")]
        public int OriginId { get; set; }

        [JsonPropertyName("destination-id")]
        public int DestinationId { get; set; }

        [JsonPropertyName("departure-date")]
        public DateTime DepartureDate { get; set; }
    }

}
