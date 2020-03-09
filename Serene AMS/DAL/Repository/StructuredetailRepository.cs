using Serene_AMS.DAL.Interface;
using Serene_AMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serene_AMS.DAL.Repository
{
    public class StructuredetailRepository : IStructuredetailRepository
    {
        private HrmsEntities context;

        public StructuredetailRepository()
        {
            context = new HrmsEntities();
        }
        public StructuredetailRepository(HrmsEntities context)
        {
            context = this.context;
        }

       
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        
        public IEnumerable<tblPosition> Getpos()
        {
            return context.tblPositions;
        }

        public IEnumerable<tblDepartment> validation(string dep)
        {
            return context.tblDepartments.Where(x=>x.DepartmentName == dep);
        }

        public IEnumerable<tblPosition> validation1(string pos)
        {
            return context.tblPositions.Where(x => x.Position == pos);
        }
        public IEnumerable<tblPosition> validation2(int level)
        {
            return context.tblPositions.Where(x => x.JobLevel == level);
        }
      
        public IEnumerable<tblVacancy> GetPostion(int id)
        {
            var rd = (from d in context.tblVacancies
                      where d.PositionId == id
                      select new
                      {
                          d.PositionId

                      }).Select(c => new tblVacancy()
                      {
                          PositionId = c.PositionId

                      });


            return rd;
        }
        

        public void Save()
        {
            context.SaveChanges();
        }
        public IEnumerable<tblVacancydetail> Get()
        {
            return context.tblVacancydetails;
        }
       

        public IEnumerable<tblRole> Getroles()
        {
            return context.tblRoles;
        }
        public IEnumerable<tblDepartment> Getdep()
        {
            return context.tblDepartments;
        }
        public void Add(tblPosition obj)
        {
            context.tblPositions.Add(obj);
        }
        public tblPosition Addpos(int depid, int joblevel, string position, decimal basicpay, decimal Incometax,string exp)
        {
            var pos = new tblPosition()
            {
               DepartmentId = depid,
               JobLevel = joblevel,
               Position = position,
               BasicPay = basicpay,
               IncomeTax = Incometax,
               Experience=exp+ " Years",

            };

            return pos;
        }
        public tblVacancy Addvac(string vacname,string cityname, int posid, int depid, string qualification, int joblevel,int marks, string test)
        {

            var vac = new tblVacancy()
            {
             
                VacancyName = vacname,
                CityName=cityname,
                PositionId =posid,
                DepartmentId=depid,
                RequiredQualification=qualification,
                JobLevel=Convert.ToInt32(joblevel),
                CreationDate=DateTime.Now,
                MarksCriteria=marks,
                Testpaper=test,

            };

            return vac;
        }
        public void Addvacant(tblVacancy obj)
        {
            context.tblVacancies.Add(obj);
        }
        public IEnumerable<tblVacancy> GetVacancies()
        {
            return context.tblVacancies;
        }

        public IEnumerable<tblVacancy> GetPosition(int id)
        {
            throw new NotImplementedException();
        }

       

        public void updateseats(int posid, int sid, int positionid, int structid)
        {
            var obj = context.tblVacancies.Where(x => x.PositionId == positionid);
            
            context.Entry(obj).State = EntityState.Modified;

        }

        public tblRequest Addreqt(int Employeeid, int posid,string citytrans, string ReasonofReq)
        {
            var addreq = new tblRequest()
            {
                EmployeeId=Employeeid,
                PositionId=posid,
                CitytoTranser=citytrans,
                RequestType ="Transfer",
                DateofRequest=DateTime.Now,
                Status="Pending",
                ReasonofRequest=ReasonofReq,
                AuthorizedRole="DGM",
                IsSeen=false,
            };
            return addreq;
        }

        public void AddReq(tblRequest obj)
        {
            context.tblRequests.Add(obj);
        }

        public IEnumerable<tblRequest> GetReq()
        {
            return context.tblRequests;
        }

        public void updatetransapp(int empid, string city,int posid)
        {
            var obj = context.tblEmployees.Find(empid);
            obj.CityName = city;
            obj.PositionId = posid;
            context.Entry(obj).State = EntityState.Modified;

        }

        public void updatereqt(int reqid,string resby,string resreason)
        {
            var obj = context.tblRequests.Find(reqid);
            obj.Status = "Accepted";
            obj.Respondedby = resby;
            obj.ResponseDate = DateTime.Now;
            obj.ResponseReason = resreason;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void updatereqtrej(int reqid, string resby,string resreason)
        {
            var obj = context.tblRequests.Find(reqid);
            obj.Status = "Rejected";
            obj.Respondedby = resby;
            obj.ResponseDate = DateTime.Now;
            obj.ResponseReason = resreason;
            context.Entry(obj).State = EntityState.Modified;
        }

        public tblRequest Addreqtfordgm(int Employeeid, int posid, string citytrans, string ReasonofReq)
        {
            var addreq = new tblRequest()
            {
                EmployeeId = Employeeid,
                PositionId = posid,
                CitytoTranser = citytrans,
                RequestType = "Transfer",
                DateofRequest = DateTime.Now,
                Status = "Pending",
                ReasonofRequest = ReasonofReq,
                AuthorizedRole = "CEO",
                IsSeen=false,
            };
            return addreq;
        }

        public void updateseen(int reqid)
        {
            var obj = context.tblRequests.Find(reqid);
            obj.IsSeen = true;
            context.Entry(obj).State = EntityState.Modified;

        }

        public IEnumerable<tblEmployee> Getemp()
        {
            return context.tblEmployees;
        }

        public IEnumerable<tblEmployeeDetail> Getempdet()
        {
            return context.tblEmployeeDetails;
        }

        public void updatepos(int empid,int posid)
        {
            var obj = context.tblEmployees.Find(empid);
            obj.PositionId = posid;
            context.Entry(obj).State = EntityState.Modified;

        }

        public void updateempdetailpro(int empid)
        {
            var obj = context.tblEmployeeDetails.Find(empid);
            obj.DateofPromotion = DateTime.Now.Date;
            obj.IsSalaryset = false;
            obj.IsSeenPromotion = false;
           
            context.Entry(obj).State = EntityState.Modified;
        }

        public void setProEmpsalary(int empid, decimal salary)
        {
            var obj = context.tblEmployeeDetails.Find(empid);
            obj.EmployeeSalary = salary;
            obj.IsSalaryset = true;

            context.Entry(obj).State = EntityState.Modified;
        }
    }
}