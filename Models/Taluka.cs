using System.ComponentModel.DataAnnotations;
namespace AllRightConsultant.Models
{
    public class Taluka
    {
        public int Id { get; set; }
        [Required]
        public int TalukaName { get; set; }
    }
}
