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
    
    public partial class tblDocument
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDocument()
        {
            this.tblDocDetails = new HashSet<tblDocDetail>();
            this.tblPurchases = new HashSet<tblPurchase>();
        }
    
        public int DocumentNo { get; set; }
        public string Docno { get; set; }
        public Nullable<int> DTypeId { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public string DocStatus { get; set; }
        public string Status { get; set; }
        public Nullable<int> VendorId { get; set; }
        public string ItemName { get; set; }
        public Nullable<int> PrReferenceNo { get; set; }
        public Nullable<System.DateTime> ItemRequestedDate { get; set; }
        public Nullable<int> POReferenceno { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<int> GRReferencenoforReturn { get; set; }
        public string Reasonofreturn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDocDetail> tblDocDetails { get; set; }
        public virtual tblDoctype tblDoctype { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchase> tblPurchases { get; set; }
    }
}
