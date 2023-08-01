using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllRightConsultant.Models
{
    public class WorkLabourCess
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Auto generated
        public int WorkId { get; set; }   // Change this to int to match the primary key
        [ForeignKey("WorkId")]
        [ValidateNever]
        public ProjectWork? ProjectWork { get; set; } // Foreign Key  

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Auto generated
        public int MajorworkID { get; set; }

        [Required]
        [DisplayName("Financial Year")]
        public string? Financialyear { get; set; }

        [Required]
        [DisplayName("% Construction")]
        public decimal PerConstruction { get; set; }

        [Required]
        [DisplayName("Construction Cost")]
        public decimal ConstructionCost { get; set; }

        [Required]
        [DisplayName("1% Labour Cess")]
        public decimal Per1LabourCess { get; set; }
    }
}
