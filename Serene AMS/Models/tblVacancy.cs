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
    
    public partial class tblVacancy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblVacancy()
        {
            this.tblApplicants = new HashSet<tblApplicant>();
        }
    
        public int VacancyId { get; set; }
        public string VacancyName { get; set; }
        public string CityName { get; set; }
        public Nullable<int> PositionId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> NoofVacany { get; set; }
        public string RequiredQualification { get; set; }
        public Nullable<int> JobLevel { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<int> MarksCriteria { get; set; }
        public string Testpaper { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblApplicant> tblApplicants { get; set; }
        public virtual tblDepartment tblDepartment { get; set; }
    }
}
