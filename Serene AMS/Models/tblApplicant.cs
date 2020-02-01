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
    
    public partial class tblApplicant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblApplicant()
        {
            this.tblCandidates = new HashSet<tblCandidate>();
        }
    
        public int ApplicationId { get; set; }
        public Nullable<int> VacancyId { get; set; }
        public string ApplicantName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> Dob { get; set; }
        public string Gender { get; set; }
        public string Appliedfor { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string CV { get; set; }
        public Nullable<System.DateTime> Submittedon { get; set; }
        public Nullable<int> Marks { get; set; }
        public string TestStatus { get; set; }
    
        public virtual tblVacancy tblVacancy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCandidate> tblCandidates { get; set; }
    }
}
