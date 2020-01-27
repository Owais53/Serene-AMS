using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Serene_AMS.ViewModels
{
    public class ApplyVM
    {
        [Required]
        public string ApplicantName {get; set;}
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime Dob { get; set; }

        public string Gender { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public string Status { get; set; }
        public string Cv { get; set; }





    }
}