using ApplyOnline.DataAccessLayer;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplyOnline.Models
{
    public class ResetPasswordRequest
    {
        [Key]
        public int PkRequestId { get; set; }
        public Guid RequestGUID { get; set; }

        public int FkApplicantId { get; set; }
        [ForeignKey("FkApplicantId")]
        public PersonalInformation PersonalInformations { get; set; }
    }
}