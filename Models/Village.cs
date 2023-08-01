using System.ComponentModel.DataAnnotations;
namespace AllRightConsultant.Models
{
    public class Village
    {
        public int Id { get; set; }
        [Required]
        public int VillageName { get; set; }
    }
}
