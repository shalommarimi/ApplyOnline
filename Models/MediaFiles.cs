using ApplyOnline.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplyOnline.Models
{
    public class MediaFiles
    {
        [Key]
        public int PkPuictureId { get; set; }
        // public Image Picture { get; set; }

        public int FkApplicantId { get; set; }
        [ForeignKey("FkApplicantId")]
        public PersonalInformation PersonalInformations { get; set; }

    }
}