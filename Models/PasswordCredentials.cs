using System.ComponentModel.DataAnnotations;

namespace ApplyOnline.Models
{
    public class PasswordCredential
    {

        [Key]
        public int PkLoginId { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string New_Password { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        [MaxLength(10)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("New_Password", ErrorMessage = "The Password and Confirmation Password do not match.")]
        public string ConfirmPassword { get; set; }



    }
}