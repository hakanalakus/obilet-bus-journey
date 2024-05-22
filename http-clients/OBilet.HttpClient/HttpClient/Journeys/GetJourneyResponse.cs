using OBilet.HttpClient.Abstracts;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OBilet.HttpClient.Journeys
{
    public class GetJourneyResponse:BaseResponse<List<JourneyInfo>>
    {
    }

    public class JourneyInfo 
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("partner-name")]
        public string PartnerName { get; set; }

        [JsonPropertyName("bus-type")]
        public string BusType { get; set; }

        [JsonPropertyName("total-seats")]
        public int TotalSeats { get; set; }

        [JsonPropertyName("available-seats")]
        public int AvailableSets { get; set; }

        [JsonPropertyName("origin-location")]
        public string Origin { get; set; }

        [JsonPropertyName("destination-location")]
        public string Destination { get; set; }

        [JsonPropertyName("journey")]
        public JourneyDetail Journey { get; set; }

    }

    public class JourneyDetail 
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("internet-price")]
        public float InternetPrice { get; set; }

        [JsonPropertyName("origin")]
        public string OriginStop { get; set; }

        [JsonPropertyName("destination")]
        public string DestinationStop { get; set; }

        [JsonPropertyName("departure")]
        public DateTime DepartureTime { get; set; }

        [JsonPropertyName("arrival")]
        public DateTime ArrivalTime { get; set; }
    }

}
