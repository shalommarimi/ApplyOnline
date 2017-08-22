using ApplyOnline.DataAccessLayer;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplyOnline.Models
{
    public class Nationality
    {
        [Key]
        public int PkNatonalId { get; set; }
        public string NationaityValue { get; set; }
        public List<PersonalInformation> Applicant { get; set; }
    }
}