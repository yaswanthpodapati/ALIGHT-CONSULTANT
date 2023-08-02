using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AllRightConsultant.Models
{
    public class ProjectWork
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkId { get; set; }

        [Required]
        [DisplayName("Work Name")]
        public string? WorkName { get; set; }

        [DisplayName("Work Unique Code")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? WorkUniqueCode { get; set; }

        [DisplayName("Project Type Nature")]
        public int ProjectTypeNatureID { get; set; }
        [ForeignKey("ProjectTypeNatureID")]  //Foreign Key  
        [ValidateNever]
        public ProjectTypeNature? ProjectTypeNature { get; set; } //Drop Down List

        [Required]
        [DisplayName("Project Site Address")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ProjectSiteAddress { get; set; }

        [Required]
        [DisplayName("Street Name")]
        public string? StreetName { get; set; }

        [DisplayName("District")]
        public int DistrictID { get; set; }
        [ForeignKey("DistrictID")]  //Foreign Key  
        [ValidateNever]
        public District? District { get; set; }//Drop Down List

        [DisplayName("Taluka")]
        public int Taluka_ID { get; set; }
        [ForeignKey("Taluka_ID")]  //Foreign Key  
        [ValidateNever]
        public Taluka? Taluka { get; set; }//Drop Down List

        [DisplayName("City")]
        public int CityID { get; set; }
        [ForeignKey("CityID")]  //Foreign Key  
        [ValidateNever]
        public City? City { get; set; }//Drop Down List

        [DisplayName("Village")]
        public int Village_ID { get; set; }
        [ForeignKey("Village_ID")]  //Foreign Key  
        [ValidateNever]
        public Village? Village { get; set; }//Drop Down List

        [Required]
        [DisplayName("Sanction Date")]
        public DateTime SanctionDate { get; set; }

        [Required]
        [DisplayName("Total Estimated Cost")]
        [Column(TypeName = "decimal(18, 2)")]  //  precision and scale 
        public decimal Total_Estimated_Cost { get; set; }
        public decimal LaborCess { get; internal set; }
    }
}
