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
    
    public partial class tblPosition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPosition()
        {
            this.tblEmployees = new HashSet<tblEmployee>();
        }
    
        public int Id { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public string JobLevel { get; set; }
        public string Position { get; set; }
        public Nullable<decimal> BasicPay { get; set; }
        public Nullable<decimal> IncomeTax { get; set; }
    
        public virtual tblDepartment tblDepartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEmployee> tblEmployees { get; set; }
    }
}
