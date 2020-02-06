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
        
        tblApplicant AddApplicant(string name,string phone,string email,DateTime dob,string gender,string address,string cv);

        tblEmployee AddEmployee(int sid,int coc,int cic,string empname,string gender,int depid,DateTime dob,string contact,string email,string address,int posid);

        void updatetohired(int ApplicationId);
        void Update(int ApplicationId);
        void Update1(int ApplicationId);
        void Delete(int ApplicationId);
        void update2(int Applicationid,int Marks);
        void update3(int Applicationid, int Marks);
        void update4(int Applicationid);
        void Addemp(tblEmployee obj);
        void Addempdetail(tblEmployeeDetail obj);
        IEnumerable<tblVacancy> Getmarkscriteria(int vacantid);

        void Save();

    }
}
