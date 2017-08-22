using ApplyOnline.DataAccessLayer;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplyOnline.Models
{
    public class MaritalStatus
    {
        [Key]
        public int PkMaritalStatusId { get; set; }
        public string MaritalStatusValue { get; set; }
        public List<PersonalInformation> Applicant { get; set; }
    }
}