using ApplyOnline.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplyOnline.Models
{
    public class Reference
    {
        [Key]
        public int PkReferenceId { get; set; }

        [Display(Name = "Company")]
        [RegularExpression("^[a-zA-Z][a-zA-Z\\s]+$")]
        public string RefCompany { get; set; }

        [Display(Name = "Contact Person")]
        [RegularExpression("^[a-zA-Z][a-zA-Z\\s]+$")]
        public string ContactPerson { get; set; }


        [Display(Name = "Tel|Cell Phone")]
        public string RefContact { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string RefEmail { get; set; }


        public int FkApplicantId { get; set; }
        [ForeignKey("FkApplicantId")]
        public PersonalInformation PersonalInformations { get; set; }

    }
}