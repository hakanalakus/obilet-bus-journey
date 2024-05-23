namespace OBilet.Web.Dto
{
    public class JourneyInfoDto
    {
        public string PartnerName { get; set; }
        public float? Price { get; set; }

        public string DepartureStop { get; set; }

        public DateTime? DepartureTime { get; set; }

        public string ArrivalStop { get; set; }

        public DateTime? ArrivalTime { get; set; }
    }
}
