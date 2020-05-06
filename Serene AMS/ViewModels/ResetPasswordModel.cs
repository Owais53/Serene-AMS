using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Serene_AMS.ViewModels
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage ="New Password required",AllowEmptyStrings =false)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Compare("NewPassword",ErrorMessage ="New Password and confirm password does not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        public string ResetCode { get; set; }

    }
}