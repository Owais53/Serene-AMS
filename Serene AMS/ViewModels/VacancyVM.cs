using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Serene_AMS.ViewModels
{
    public class VacancyVM
    {
        public int StructureId { get; set; }
        public string VacancyName { get; set; }
        
        public int CompanyCode { get; set; }
        
        public int CityCode { get; set; }
        
        public int DepartmentId { get; set; }
        
        public int PositionId { get; set; }

        public int NoofVacancy { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string RequiredQualification { get; set; }
        public string Experience { get; set; }
        public DateTime CreationDate { get; set; }
        public int MarksCriteria { get; set; }
        public string Testpaper { get; set; }
        public string CompanyName { get; set; }
        public string CityName { get; set; }
        public string DepartmentName { get; set; }
        public string Position { get; set; }
        public DateTime SeatAvailablityDate { get; set; }
        public int Availableseats { get; set; }
        public int Id { get; set; }
        public string JobLevel { get; set; }



    }
}