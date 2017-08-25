using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplyOnline.DataAccessLayer
{
    public class Gender
    {
        [Key]
        public int PkGenderId { get; set; }
        public string GenderValue { get; set; }
        public List<PersonalInformation> Applicant { get; set; }
        // public List<Subscribe> Subscriber { get; set; }

    }


}
