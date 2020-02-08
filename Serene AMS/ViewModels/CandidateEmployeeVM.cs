using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Serene_AMS.ViewModels
{
    public class CandidateEmployeeVM
    {
        public int CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public int CityCode { get; set; }
        public string CityName { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public int PositionId { get; set; }
        public int VacancyId { get; set; }
        public int StructureId { get; set; }
        public string EmployeeStatus { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int ApplicationId { get; set; }
        public string Position { get; set; }
        public string DepartmentName { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string desc { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime interviewdate { get; set; }

    }
}