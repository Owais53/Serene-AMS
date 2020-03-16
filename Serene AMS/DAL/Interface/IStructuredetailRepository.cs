using Serene_AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Serene_AMS.DAL.Interface
{
    public interface IStructuredetailRepository
    {
       
        IEnumerable<tblPosition> Getpos();

       
        IEnumerable<tblRole> Getroles();

        IEnumerable<tblDepartment> Getdep();

        IEnumerable<tblDepartment> validation(string dep);
        IEnumerable<tblPosition> validation1(string pos);
        IEnumerable<tblPosition> validation2(int level);
        IEnumerable<tblVacancydetail> Get();
        IEnumerable<tblVacancy> GetVacancies();
        IEnumerable<tblRequest> GetReq();

        IEnumerable<tblVacancy> GetPosition(int id);
        IEnumerable<tblEmployee> Getemp();
        IEnumerable<tblEmployeeDetail> Getempdet();

        void Addvacant(tblVacancy obj);
        void Add(tblPosition obj);
        
        tblPosition Addpos(int depid, int joblevel, string position, decimal basicpay, decimal Incometax,string exp);
        tblVacancy Addvac(string vacname,string cityname,int posid,int depid,string qualification,int joblevel,int marks,string test);
        void updatetransapp(int empid, string city,int posid);
       
        void updatereqt(int reqid,string resby,string resreason);
        void updatereqtrej(int reqid, string resby,string resreason);
        void updateseats(int posid,int sid,int positionid,int structid);
        tblRequest Addreqt(int Employeeid, int posid,string citytrans,string ReasonofReq);
        tblRequest Addreqtfordgm(int Employeeid, int posid, string citytrans, string ReasonofReq);
        void updateseen(int reqid);
        void updateseenPro(int empid);
        void updatepos(int empid,int posid);
        void updateempdetailpro(int empid);
        void setProEmpsalary(int empid,decimal salary);
      
        void AddReq(tblRequest obj);
        void Delete(int Id);
        
        void Save();



    }
}
