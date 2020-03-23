using Serene_AMS.Models;
using Serene_AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serene_AMS.DAL.Interface
{
    public interface IEmployeeRepository
    {
      

        IEnumerable<tblEmployee> GetAll();

        tblEmployee GetById(int employeeId);

        void Add(tblEmployee obj);

        void Update(int employeeid,int userid);

        IEnumerable<tblPosition> Getpos();

        IEnumerable<tblPositionLeavetype> Getleave();
        IEnumerable<tblEmployeeLeaves> GetEmpLeaves();
        void Delete(int employeeId);

        void Save();

        tblPositionLeavetype Addleavepos(int posid,int casualleave,int sickleave);
        void Addleave(tblPositionLeavetype obj);
        void Updateleave(int posid,int casualleave,int sickleave);
        tblRequest AddReql(int empid, int posid, DateTime FromDate, DateTime ToDate, string ReasonofReq,string leavetype);
        void AddLeaveReq(tblRequest obj);
        void updateleaveforemp(int EmployeeId,int casualleave,int sickleave);
        void updatecasualleaveleft(int EmployeeId);
        void updatesickleaveleft(int EmployeeId);

    }
}
