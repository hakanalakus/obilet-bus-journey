using OBilet.Web.Dto;

namespace OBilet.Web.Models
{
    public class JourneyViewModel
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime? Date { get; set; }

        public List<JourneyInfoDto> JourneyInfos { get; set; }

        public JourneyViewModel()
        {
            JourneyInfos = new List<JourneyInfoDto>();
        }

    }
}
