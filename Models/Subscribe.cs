using ApplyOnline.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplyOnline.Models
{

    public class Subscribe
    {

        [Key]
        public int PkSubscriberId { get; set; }

        [Required]
        [Display(Name = "Your First Name")]
        [RegularExpression("^[a-zA-Z][a-zA-Z\\s]+$")]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Your Last Name")]
        [RegularExpression("^[a-zA-Z][a-zA-Z\\s]+$")]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Your Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Gender")]
        public int FkGenderId { get; set; }
        [ForeignKey("FkGenderId")]
        public Gender Gender { get; set; }
    }
}