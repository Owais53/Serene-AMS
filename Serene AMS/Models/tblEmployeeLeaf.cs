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
    
    public partial class tblEmployeeLeaf
    {
        public int Id { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<int> CasualLeave { get; set; }
        public Nullable<int> SickLeave { get; set; }
    
        public virtual tblEmployee tblEmployee { get; set; }
    }
}
