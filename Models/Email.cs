using System.ComponentModel.DataAnnotations;

namespace ApplyOnline.Models
{
    public class Email
    {

        public string Recipient { get; set; }

        [Required]
        [Display(Name = "Your Email Address")]
        [EmailAddress]
        public string SentFrom { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Enquiry Message | Content")]
        public string Message { get; set; }



    }
}