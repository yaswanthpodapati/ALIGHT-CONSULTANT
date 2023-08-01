using System.ComponentModel.DataAnnotations;
namespace AllRightConsultant.Models
{
    public class ProjectTypeNature
    {
        public int Id { get; set; }
        [Required]
        public int ProjectTypeNatureName { get; set; }
    }
}
