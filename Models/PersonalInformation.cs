using ApplyOnline.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplyOnline.DataAccessLayer
{
    public class PersonalInformation
    {
        [Key]
        public int PkApplicantId { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [RegularExpression("^[a-zA-Z][a-zA-Z\\s]+$")]// No numerics are allowed
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }


        [Display(Name = "Middle Name")]
        [RegularExpression("^[a-zA-Z][a-zA-Z\\s]+$")]
        public string MiddleName { get; set; }


        [Display(Name = "Last Name")]
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("^[a-zA-Z][a-zA-Z\\s]+$")]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        public int FkGenderId { get; set; }
        [ForeignKey("FkGenderId")]
        public Gender Gender { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Identity Number")]
        public string IdNumber { get; set; }

        [Display(Name = "Nationality")]
        public int FkNationalityId { get; set; }
        [ForeignKey("FkNationalityId")]
        public Nationality Nationality { get; set; }


        [Display(Name = "Population")]
        public int FkPopulationId { get; set; }
        [ForeignKey("FkPopulationId")]
        public Population Population { get; set; }

        [Required]
        //[Phone]
        [Display(Name = "Contact Number")]
        public int CellNumber { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [EmailAddress]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }


        [Required]
        [Display(Name = "Driver's Licence")]
        public string DriversLicence { get; set; }

        [Display(Name = "Marital Status")]
        public int FkMaritalStatusId { get; set; }
        [ForeignKey("FkMaritalStatusId")]
        public MaritalStatus MaritalStatus { get; set; }

        [Required]
        [Display(Name = "Home Language")]
        public string HomeLanguage { get; set; }

        [Required]
        [Display(Name = "Prefereferd Language")]
        public string PreferedCL { get; set; }


        [Display(Name = "Other Language 1")]
        public string FisrtOtherLanguage { get; set; }



        [Display(Name = "Other Language 2")]
        public string SecondOtherLanguage { get; set; }



        [Display(Name = "Other Language 3")]
        public string ThirdOtherLanguage { get; set; }



        public bool IsDeleted { get; set; }



        [Display(Name = "Application Field")]
        public int FkApplicationFieldId { get; set; }
        [ForeignKey("FkApplicationFieldId")]
        public virtual ApplicationField ApplicationField { get; set; }


        [Required]
        [Display(Name = "Application Type")]
        public int FkApplicationTypeId { get; set; }
        [ForeignKey("FkApplicationTypeId")]
        public virtual ApplicationType ApplicationType { get; set; }


        [Required]
        [MinLength(6)]
        public string Username { get; set; }

        [Required]
        [MaxLengthAttribute]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string New_Password { get; set; }


        [MaxLengthAttribute]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("New_Password", ErrorMessage = "The Password and Confirmation Password do not match.")]
        public string ConfirmPassword { get; set; }


        public List<WorkExprience> WorkExperiences { get; set; }
        public List<Qualification> Qualifications { get; set; }
        public List<MediaFiles> MediaFile { get; set; }
        public List<Reference> References { get; set; }
        public List<ResetPasswordRequest> ResetPasswordRequests { get; set; }


    }




}