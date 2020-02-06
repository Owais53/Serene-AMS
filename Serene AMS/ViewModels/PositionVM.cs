using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Serene_AMS.ViewModels
{
    public class PositionVM
    {
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string JobLevel { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public decimal BasicPay { get; set; }
        [Required]
        public decimal IncomeTax { get; set; }

    }
}