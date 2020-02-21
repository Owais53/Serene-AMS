using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Serene_AMS.ViewModels
{
    public class RequestVM
    {
        public int RequestId { get; set; }
        public int positionid { get; set; }
        public int Positionsid { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string ReasonofRequest { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
        public DateTime DateofRequest { get; set; }
        public string CityName { get; set; }
       public string Position { get; set; }
        public string RequestType { get; set; }
        public int count { get; set; }
        public string DepartmentName { get; set; }
        public string PositiontoTransfer { get; set; }
        public string CitytoTransfer { get; set; }
        public string Status { get; set; }

    }
}