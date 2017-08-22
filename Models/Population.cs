using ApplyOnline.DataAccessLayer;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplyOnline.Models
{
    public class Population
    {
        [Key]
        public int PkPopulationId { get; set; }
        public string PopulationValue { get; set; }
        public List<PersonalInformation> Applicant { get; set; }
    }
}