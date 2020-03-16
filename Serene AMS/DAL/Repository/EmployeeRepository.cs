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

        public tblRequest AddReql(int empid, int posid, DateTime FromDate, DateTime ToDate, string ReasonofReq)
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
                AuthorizedRole = "Hr Manager",
                IsSeen = false,
            };
            return addreq;
        }

        public void AddLeaveReq(tblRequest obj)
        {
            context.tblRequests.Add(obj);
        }

        public void updateleaveforemp(int empid,int casualleave,int sickleave)
        {
            var obj = context.tblEmployeeLeaves1.Find(empid);
            obj.CasualLeave = casualleave;
            obj.SickLeave = sickleave;
            context.Entry(obj).State = EntityState.Modified;
        }
    }
}