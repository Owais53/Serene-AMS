using Serene_AMS.Models;
using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serene_AMS.DAL.Interface
{
    public interface IRepository
    {
        IEnumerable<tblApplicant> GetAll();

        IEnumerable<tblApplicant> Getname(string applicantname, string email);
        
        void Add(tblApplicant obj);

        tblApplicant GetById(int ApplicationId);
        
        tblApplicant AddApplicant(int vacid,string name,string phone,string email,DateTime dob,string gender,string Appliedfor,string address,string cv);

        tblEmployee AddEmployee(string city,string empname,string gender,int depid,DateTime dob,string contact,string email,string address,int posid);
        tblEmployeeDetail AddempDetail(int empid, Nullable<DateTime> joiningdate,decimal salary);

        void updatetohired(int ApplicationId);
        
        void Update(int ApplicationId);
        void Update1(int ApplicationId);
        void Delete(int ApplicationId);
        void update2(int Applicationid,int Marks);
        void update3(int Applicationid, int Marks);
        void update4(int Applicationid,DateTime date);
        void Addemp(tblEmployee obj);
        void statusappoint(int Applicationid);
        void Addempdetail(tblEmployeeDetail obj);
        void UpdateEmp(int Applicationid, Nullable<DateTime> joindate, decimal salary);
        IEnumerable<tblVacancy> Getmarkscriteria(int vacantid);
        tblEmployeeLeaves Addempidinempleave(int empid);
        void Save();
        void Addempidleave(tblEmployeeLeaves obj);

    }
}
