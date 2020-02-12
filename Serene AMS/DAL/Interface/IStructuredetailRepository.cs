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
        IEnumerable<tblStructuredetail> GetAll();

        IEnumerable<tblPosition> Getpos();

        tblStructuredetail GetById(int Id);

        void Add(tblStructuredetail obj);

        void Update(tblStructuredetail obj);

        IEnumerable<tblRole> Getroles();

        IEnumerable<tblDepartment> Getdep();

        IEnumerable<tblDepartment> validation(string dep);
        IEnumerable<tblPosition> validation1(string pos);
        IEnumerable<tblPosition> validation2(string level);
        IEnumerable<tblVacancydetail> Get();
        IEnumerable<tblVacancy> GetVacancies();
        
        IEnumerable<tblVacancy> GetPosition(int id);

      
        void Addvacant(tblVacancy obj);
        void Add(tblPosition obj);
        
        tblPosition Addpos(int depid, string joblevel, string position, decimal basicpay, decimal Incometax);
        tblVacancy Addvac(string vacname,string cityname,int posid,int depid,string qualification,int joblevel,int marks,string test);
        void updateseats(int posid,int sid,int positionid,int structid);

        void Delete(int Id);

        void Save();



    }
}
