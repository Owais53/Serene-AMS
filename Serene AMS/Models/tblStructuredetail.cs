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
    
    public partial class tblStructuredetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblStructuredetail()
        {
            this.tblEmployees = new HashSet<tblEmployee>();
        }
    
        public int Id { get; set; }
        public int CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public Nullable<int> CityCode { get; set; }
        public string CityName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEmployee> tblEmployees { get; set; }
    }
}
