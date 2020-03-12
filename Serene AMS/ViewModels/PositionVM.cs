using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Serene_AMS.ViewModels
{
    public class PositionVM
    {
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int JobLevel { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public decimal BasicPay { get; set; }
        [Required]
        public decimal IncomeTax { get; set; }
        [Required]
        public string Experience { get; set; }

        public string EmployeeName { get; set; }
        public string CityName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public int PositionId { get; set; }
        public string Gender { get; set; }
        public DateTime DateofBirth { get; set; }
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int posidtopro { get; set; }
        public decimal Employeesalary { get; set; }
        public DateTime DateofPromotion { get; set; }
        [Required]
        public int CasualLeave { get; set; }
        [Required]
        public int SickLeave { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
      

    }
}