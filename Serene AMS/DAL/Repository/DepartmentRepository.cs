using Serene_AMS.DAL.Interface;
using Serene_AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serene_AMS.DAL.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private SqlEntities context;

        public DepartmentRepository()
        {
            context = new SqlEntities();

        }
        public DepartmentRepository(SqlEntities context)
        {
            context = this.context;
        }


        public void Add(tblDepartment obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int departmentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tblDepartment> GetAll()
        {
            return context.tblDepartments;
        }

        public tblDepartment GetById(int departmentId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(tblDepartment obj)
        {
            throw new NotImplementedException();
        }
    }
}