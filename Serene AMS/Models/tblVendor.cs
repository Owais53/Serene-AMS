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
    
    public partial class tblVendor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblVendor()
        {
            this.tblDocuments = new HashSet<tblDocument>();
        }
    
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string Contact { get; set; }
        public string ItemType { get; set; }
        public string Address { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDocument> tblDocuments { get; set; }
    }
}
