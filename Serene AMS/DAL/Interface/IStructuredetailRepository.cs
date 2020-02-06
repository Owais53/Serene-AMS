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
        IEnumerable<tblVacancy> GetstructId(int id);
        IEnumerable<tblVacancy> GetPosition(int id);

      
        void Addvacant(tblVacancy obj);
        void Add(tblPosition obj);
        
        tblPosition Addpos(int depid, string joblevel, string position, decimal basicpay, decimal Incometax);
        tblVacancy Addvac(int structid,string vacname,int comcode,int citycode,int posid,int depid,int noofvacant,string qualification,string joblevel,int marks,string test);
        void updateseats(int posid,int sid,int positionid,int structid);

        void Delete(int Id);

        void Save();



    }
}
