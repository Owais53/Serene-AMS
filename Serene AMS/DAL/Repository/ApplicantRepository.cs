using Serene_AMS.DAL.Interface;
using Serene_AMS.Models;
using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Serene_AMS.DAL.Repository
{
    public class ApplicantRepository : IRepository
    {

        private SqlEntities context;

        public ApplicantRepository()
        {
            context = new SqlEntities();

        }
        public ApplicantRepository(SqlEntities context)
        {
            context = this.context;
        }
        public void Add(tblApplicant obj)
        {
            context.tblApplicants.Add(obj);
        }
        public tblApplicant AddApplicant(string name, string phone, string email, DateTime dob, string gender, string address, string cv)
        {

            var addapplicant = new tblApplicant()
            {
                ApplicantName = name,
                Phone = phone,
                Email = email,
                Dob = dob,
                Gender = gender,
                Status = "Pending",
                Address = address,
                Submittedon = DateTime.Now.Date,
                CV = cv,
                TestStatus = "Pending",
            };

            return addapplicant;
        }

        public IEnumerable<tblApplicant> GetId(int applicationid, string email)
        {
            return context.tblApplicants.Where(x => x.ApplicationId == applicationid).Where(x=> x.Email == email);
        }
        public IEnumerable<tblApplicant> Getname(string applicantname,string email)
        {
            return context.tblApplicants.Where(x => x.ApplicantName == applicantname)
                .Where(x => x.Email == email);
        }  
        public void Delete(int ApplicationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tblApplicant> GetAll()
        {
            return context.tblApplicants;
        }


        public tblApplicant GetById(int ApplicationId)
        {
            var getid = context.tblApplicants.Find(ApplicationId);

            return getid;
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public void update2(int Applicationid,int Marks)
        {
            var obj = context.tblApplicants.Find(Applicationid);
            obj.Marks = Marks;
            obj.TestStatus = "Pass";
            context.Entry(obj).State = EntityState.Modified;
        }
        public void update3(int Applicationid, int Marks)
        {
            var obj = context.tblApplicants.Find(Applicationid);
            obj.Marks = Marks;
            obj.TestStatus = "Fail";
            context.Entry(obj).State = EntityState.Modified;
        }
        public void update4(int Applicationid)
        {
            var obj = context.tblApplicants.Find(Applicationid);
            obj.Status = "Called for Interview";
            context.Entry(obj).State = EntityState.Modified;
            
            
        }
        public void Update(int ApplicationId)
        {
            var obj = context.tblApplicants.Find(ApplicationId);
            obj.Status = "Approved";
            context.Entry(obj).State = EntityState.Modified;

        }
        public void Update1(int ApplicationId)
        {
            var obj = context.tblApplicants.Find(ApplicationId);
            obj.Status = "Rejected";
            context.Entry(obj).State = EntityState.Modified;

        }

        public tblEmployee AddEmployee(int sid, int coc, int cic, string empname, string gender, int depid, DateTime dob, string contact, string email, string address, int posid)
        {
            var addemp = new tblEmployee()
            {
                Id = sid,
                CompanyCode = coc,
                CityCode = Convert.ToString(cic),
                EmployeeName= empname,
                Gender = gender,
                DepartmentId = depid,
                DateofBirth = dob,
                Contact = contact,
                Email = email,
                Address = address,
                PositionId = posid,

            };
            return addemp;

        }

       

        public void Addemp(tblEmployee obj)
        {
            context.tblEmployees.Add(obj);
        }

        public void Addempdetail(tblEmployeeDetail obj)
        {
            context.tblEmployeeDetails.Add(obj);
        }

        public void updatetohired(int ApplicationId)
        {
            var obj = context.tblApplicants.Find(ApplicationId);
            obj.Status = "Hired";
            context.Entry(obj).State = EntityState.Modified;

        }

        public IEnumerable<tblVacancy> Getmarkscriteria(int vacantid)
        {
            return context.tblVacancies.Where(x => x.VacancyId == vacantid);
        }
    }

}