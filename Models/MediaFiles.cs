using ApplyOnline.DataAccessLayer;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ApplyOnline.Models
{
    public class MediaFiles
    {
        public int PkPuictureId { get; set; }
        public Image Picture { get; set; }

        public int FkApplicantId { get; set; }
        [ForeignKey("FkApplicantId")]
        public PersonalInformation PersonalInformations { get; set; }

    }
}