using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Serene_AMS.Models;
using Serene_AMS.ViewModel;

namespace Serene_AMS.DAL.Repository
{
    public class EmployeeRepository : Interface.IEmployeeRepository
    {

       private HrmsEntities context;

        public EmployeeRepository()
        {
            context = new HrmsEntities();

        }
        public EmployeeRepository(HrmsEntities context)
        {
            context = this.context;
        }

        public void Add(tblEmployee obj)
        {
            context.tblEmployees.Add(obj);
        }

        public void Delete(int employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tblEmployee> GetAll()
        {
            return context.tblEmployees;
        }
        public IEnumerable<tblPosition> Getpos()
        {
            return context.tblPositions;
        }

        public tblEmployee GetById(int employeeId)
        {
            throw new NotImplementedException();
        }

       

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int employeeid,int userid)
        {
            if (employeeid != null && userid != null)
            {

                tblEmployee employee = context.tblEmployees.Single(x => x.EmployeeId == employeeid);

                employee.UserId = userid;
            }
            else
            {
                return;
            }
        }

        public tblPositionLeavetype Addleavepos(int posid, int casualleave, int sickleave)
        {
            var addleave = new tblPositionLeavetype()
            {
               PositionId=posid,
               CasualLeave=casualleave,
               SickLeave=sickleave,
            };
            return addleave;
        }

        public void Addleave(tblPositionLeavetype obj)
        {
            context.tblPositionLeavetypes.Add(obj);
        }

        public IEnumerable<tblPositionLeavetype> Getleave()
        {
            return context.tblPositionLeavetypes;
        }

        public void Updateleave(int posid, int casualleave, int sickleave)
        {
            var obj = context.tblPositionLeavetypes.Find(posid);
            obj.CasualLeave = casualleave;
            obj.SickLeave = sickleave;
            context.Entry(obj).State = EntityState.Modified;

        }

        public tblRequest AddReql(int empid, int posid, DateTime FromDate, DateTime ToDate, string ReasonofReq,string leavetype)
        {
            var addreq = new tblRequest()
            {
                EmployeeId = empid,
                PositionId = posid,
                RequestType = "Leave",
                DateofRequest = DateTime.Now,
                FromDate=FromDate,
                ToDate=ToDate,
                Status = "Pending",
                ReasonofRequest = ReasonofReq,
                LeaveType=leavetype,
                AuthorizedRole = "Hr Manager",
                IsSeen = false,
            };
            return addreq;
        }

        public void AddLeaveReq(tblRequest obj)
        {
            context.tblRequests.Add(obj);
        }

        public void updateleaveforemp(int EmployeeId,int casualleave,int sickleave)
        {
            var obj = context.tblEmployeeLeaves1.Where(x => x.EmployeeId == EmployeeId).FirstOrDefault();
            obj.CasualLeave = casualleave;
            obj.SickLeave = sickleave;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void updatecasualleaveleft(int EmployeeId)
        {
            var obj = context.tblEmployeeLeaves1.Where(x => x.EmployeeId == EmployeeId).FirstOrDefault();
            obj.CasualLeave = obj.CasualLeave-1;
            if (obj.CasualLeave == 0)
            {
                obj.CasualLeave = obj.CasualLeave;
            }

            context.Entry(obj).State = EntityState.Modified;
        }
        public void updatesickleaveleft(int EmployeeId)
        {
            var obj = context.tblEmployeeLeaves1.Where(x => x.EmployeeId == EmployeeId).FirstOrDefault();
            obj.SickLeave=obj.SickLeave-1;
            if (obj.SickLeave == 0)
            {
                obj.SickLeave = obj.SickLeave;
            }

            context.Entry(obj).State = EntityState.Modified;
        }

        public IEnumerable<tblEmployeeLeaves> GetEmpLeaves()
        {
            return context.tblEmployeeLeaves1;
        }
    }
}