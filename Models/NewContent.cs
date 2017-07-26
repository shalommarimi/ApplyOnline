using System;
using System.ComponentModel.DataAnnotations;

namespace ApplyOnline.Models
{
    public class NewContent
    {
        [Key]
        public int PkPostEntryId { get; set; }
        [Required]

        [Display(Name = "News Caption")]
        public string PostSubject { get; set; }


        [Required]
        [Display(Name = "News Body")]
        public string PostBody { get; set; }

        [Required]
        [Display(Name = "Post Type")]
        public string PostType { get; set; }

        [Required]
        [Display(Name = "News Entry Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "", ApplyFormatInEditMode = true)]
        public DateTime PostEntryDate { get; set; }




    }


}