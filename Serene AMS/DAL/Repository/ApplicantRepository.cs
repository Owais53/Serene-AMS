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

        private HrmsEntities context;

        public ApplicantRepository()
        {
            context = new HrmsEntities();

        }
        public ApplicantRepository(HrmsEntities context)
        {
            context = this.context;
        }
        public void Add(tblApplicant obj)
        {
            context.tblApplicants.Add(obj);
        }
        public tblApplicant AddApplicant(int vacid,string name, string phone, string email, DateTime dob, string gender,string Appliedfor, string address, string cv)
        {

            var addapplicant = new tblApplicant()
            {
                VacancyId = vacid,
                ApplicantName = name,
                Phone = phone,
                Email = email,
                Dob = dob,
                Gender = gender,
                Appliedfor=Appliedfor,
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
        public void update4(int Applicationid,DateTime date)
        {
           
            var obj = context.tblApplicants.Find(Applicationid);
            obj.Status = "Called for Interview";
            obj.InterviewDate = date;
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
        public void UpdateEmp(int Applicationid, Nullable<DateTime> joindate, decimal salary)
        {
            var obj = context.tblApplicants.Find(Applicationid);
            obj.JoiningDate = joindate;
            obj.Salary = salary;
            context.Entry(obj).State = EntityState.Modified;

        }
        public tblEmployee AddEmployee(string city,string empname, string gender, int depid, DateTime dob, string contact, string email, string address, int posid)
        {
            var addemp = new tblEmployee()
            {
                CityName=city,
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

       

        public tblEmployeeDetail AddempDetail(int empid, Nullable<DateTime> joiningdate,decimal salary)
        {
            var adddetail = new tblEmployeeDetail()
            {
                EmployeeId = empid,
                EmployeeStatus = "Active",
                Dateofjoining = joiningdate,
                IsSalaryset=true,
                EmployeeSalary=salary,
            };
            return adddetail;
        }

        public void statusappoint(int Applicationid)
        {
            var obj = context.tblApplicants.Find(Applicationid);
            obj.Status = "Appointment Rejected";
            context.Entry(obj).State = EntityState.Modified;

        }

        public tblEmployeeLeaves Addempidinempleave(int empid)
        {
            var add = new tblEmployeeLeaves()
            {
                EmployeeId = empid
            };
            return add;
        }

        public void Addempidleave(tblEmployeeLeaves obj)
        {
            context.tblEmployeeLeaves.Add(obj);
        }
    }

}