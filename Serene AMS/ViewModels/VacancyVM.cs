using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serene_AMS.ViewModels
{
    public class VacancyVM
    {
        public int StructureId { get; set; }
        public string VacancyName { get; set; }
        
        public int CompanyCode { get; set; }
        public int VacancyId { get; set; }
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
        public int JobLevel { get; set; }

        public int? depart { get; set; }
        public int? position { get; set; }

        public IEnumerable<SelectListItem> Departments
        {
            get
            {
                return Enumerable.Range(2000, 12).Select(x => new SelectListItem
                {
                    Value = x.ToString(),
                    Text = x.ToString()

                });
            }
        }



    }
}