using System;
using System.Collections.Generic;
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
    }
}