using System.ComponentModel.DataAnnotations;
namespace AllRightConsultant.Models
{
    public class District
    {
        public int Id { get; set; }
        [Required]
        public int DistrictName { get; set; }
    }
}
