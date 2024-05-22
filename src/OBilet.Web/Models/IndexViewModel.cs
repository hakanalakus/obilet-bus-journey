using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBilet.Web.Models
{
    public class IndexViewModel
    {
        [Required]
        [DisplayName("Source")]
        public int? SourceId { get; set; }

        [Required]
        [DisplayName("Destination")]
        public int? DestinationId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

    }
}
