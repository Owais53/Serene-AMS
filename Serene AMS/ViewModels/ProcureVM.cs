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
        public int SlId { set; get; }
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int TypeId { get; set; }
        public string DocType { get; set; }
        [Required]
        public int Docnumberfrom { get; set; }
        [Required]
        public int DocnumberTo { get; set; }
        public int DocPofrom { get; set; }
        public int DocPoto { get; set; }
    }
}