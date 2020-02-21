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
        IEnumerable<tblPosition> validation2(string level);
        IEnumerable<tblVacancydetail> Get();
        IEnumerable<tblVacancy> GetVacancies();
        IEnumerable<tblRequest> GetReq();

        IEnumerable<tblVacancy> GetPosition(int id);

      
        void Addvacant(tblVacancy obj);
        void Add(tblPosition obj);
        
        tblPosition Addpos(int depid, string joblevel, string position, decimal basicpay, decimal Incometax);
        tblVacancy Addvac(string vacname,string cityname,int posid,int depid,string qualification,int joblevel,int marks,string test);
        void updatetransapp(int empid, string city,int posid);
       
        void updatereqt(int reqid,string resby);
        void updatereqtrej(int reqid, string resby);
        void updateseats(int posid,int sid,int positionid,int structid);
        tblRequest Addreqt(int Employeeid, int posid,string citytrans,string ReasonofReq);
        void AddReq(tblRequest obj);
        void Delete(int Id);

        void Save();



    }
}
