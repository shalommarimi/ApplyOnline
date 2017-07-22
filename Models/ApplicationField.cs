using System.ComponentModel.DataAnnotations;

namespace ApplyOnline.Models
{
    public class ApplicationField
    {
        [Key]
        public int PkApplicationFieldId { get; set; }

        [Required]
        [Display(Name = "Field Name")]
        public string FieldName { get; set; }

        [Required]
        [Display(Name = "Field Code")]
        public string FieldCode { get; set; }
    }
}