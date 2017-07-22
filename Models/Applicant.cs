using System.ComponentModel.DataAnnotations;

namespace ApplyOnline.DataAccessLayer
{
    public class Applicant
    {
        [Key]
        public int PkApplicantId { get; set; }
        public string FirstName { get; set; }
    }
}