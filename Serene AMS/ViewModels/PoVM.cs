using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serene_AMS.ViewModels
{
    public class PoVM
    {
        public string ItemName { get; set; }
        public int year { get; set; }
        public string month { get; set; }
        public int ReorderPoint { get; set; }
        public int AvailableStock { get; set; }
        public int QualityStock { get; set; }
        public decimal total { get; set; }

    }
}