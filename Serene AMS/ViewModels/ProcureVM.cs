using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Serene_AMS.ViewModels
{
    public class ProcureVM
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string StorageLocation { get; set; }
        [Required]
        public string ItemType { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int ReorderPoint { get; set; }
        [Required]
        public decimal ItemPrice { get; set; }

    }
}