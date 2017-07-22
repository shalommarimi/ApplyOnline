using System.ComponentModel.DataAnnotations;

namespace ApplyOnline.Models
{
    public class ApplicationType
    {
        [Key]
        public int PkApplicationTypeId { get; set; }

        [Required]
        [Display(Name = "Application Type Name")]
        public string ApplicationTypeName { get; set; }
    }
}