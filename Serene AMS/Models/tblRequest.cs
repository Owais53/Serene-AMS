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
    
    public partial class tblRequest
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public string RequestType { get; set; }
        public Nullable<System.DateTime> DateofRequest { get; set; }
        public string Status { get; set; }
        public string Respondedby { get; set; }
        public Nullable<System.DateTime> ResponseDate { get; set; }
    
        public virtual tblRequestdetail tblRequestdetail { get; set; }
    }
}
