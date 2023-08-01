using System.ComponentModel.DataAnnotations;
namespace AllRightConsultant.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        public int CityName { get; set; }
    }
}
