using ApplyOnline.DataAccessLayer;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplyOnline.Models
{
    public class Nationality
    {
        [Key]
        public int PkNationalityId { get; set; }
        public string NationalityValue { get; set; }
        public List<PersonalInformation> Applicant { get; set; }
    }
}