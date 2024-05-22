using OBilet.HttpClient.Abstracts;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OBilet.HttpClient.BusLocations
{
    public class GetBusLocationsResponse:BaseResponse<List<LocationInfo>>
    {
    }

    public class LocationInfo 
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("parent-id")]
        public int ParentId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("city-id")]
        public int CityId { get; set; }

        [JsonPropertyName("country-id")]
        public int CountryId { get; set; }

        [JsonPropertyName("keywords")]
        public string Keywords { get; set; }
    }

}
