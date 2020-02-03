using Serene_AMS.DAL.Interface;
using Serene_AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serene_AMS.DAL.Repository
{
    public class StructuredetailRepository : IStructuredetailRepository
    {
        private SqlEntities context;

        public StructuredetailRepository()
        {
            context = new SqlEntities();
        }
        public StructuredetailRepository(SqlEntities context)
        {
            context = this.context;
        }

        public void Add(tblStructuredetail obj)
        {
            context.tblStructuredetails.Add(obj);
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tblStructuredetail> GetAll()
        {
            return context.tblStructuredetails;
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

        public tblStructuredetail GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(tblStructuredetail obj)
        {
            throw new NotImplementedException();
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
        public tblPosition Addpos(int depid, string joblevel, string position, decimal basicpay, decimal Incometax)
        {
            var pos = new tblPosition()
            {
               DepartmentId = depid,
               JobLevel = joblevel,
               Position = position,
               BasicPay = basicpay,
               IncomeTax = Incometax,

            };

            return pos;
        }

    }
}