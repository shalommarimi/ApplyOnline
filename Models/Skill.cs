using ApplyOnline.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplyOnline.Models
{
    public class Skill
    {
        [Key]
        public int PkSkillsId { get; set; }

        [Display(Name = "Skill Name")]
        public string SkillName { get; set; }


        [Display(Name = "Skill Level")]
        public int SkillLevel { get; set; }


        public int FkApplicantId { get; set; }
        [ForeignKey("FkApplicantId")]
        public PersonalInformation PersonalInformations { get; set; }
    }
}