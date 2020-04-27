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
    
    public partial class tblItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblItem()
        {
            this.tblPurchaseitems = new HashSet<tblPurchaseitem>();
            this.tblStocks = new HashSet<tblStock>();
        }
    
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public Nullable<int> TypeId { get; set; }
        public string StorageLocation { get; set; }
        public Nullable<int> ReorderPoint { get; set; }
        public Nullable<decimal> ItemPrice { get; set; }
        public Nullable<int> Availablestock { get; set; }
        public Nullable<int> Qualityinspectionstock { get; set; }
        public Nullable<int> IsConsumable { get; set; }
    
        public virtual tblItemType tblItemType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchaseitem> tblPurchaseitems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblStock> tblStocks { get; set; }
    }
}
