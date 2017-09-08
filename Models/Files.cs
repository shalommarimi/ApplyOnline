using ApplyOnline.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ApplyOnline.Models
{
    public class Files
    {
        [Key]
        public int PkPictureId { get; set; }

        [Display(Name = "Upload Picture")]
        public string ImagePath { get; set; }

        public int FkApplicantId { get; set; }
        [ForeignKey("FkApplicantId")]
        public PersonalInformation PersonalInformations { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

    }
}