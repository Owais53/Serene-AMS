//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Serene_AMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblGrItemsPrice
    {
        public int id { get; set; }
        public Nullable<int> DocumentNo { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<int> DeliveredQuantity { get; set; }
        public Nullable<decimal> ItemPrice { get; set; }
        public Nullable<int> PartialDeliveredQuantity { get; set; }
        public Nullable<int> ReturnQuantity { get; set; }
        public Nullable<int> MissingQuantity { get; set; }
        public Nullable<int> ApprovedQuantity { get; set; }
        public string Approved { get; set; }
    }
}
