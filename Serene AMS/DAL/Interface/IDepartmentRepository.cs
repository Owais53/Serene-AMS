using Serene_AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serene_AMS.DAL.Interface
{
    public interface IDepartmentRepository
    {
        IEnumerable<tblDepartment> GetAll();

       
        tblDepartment GetById(int departmentId);

        void Add(tblDepartment obj);

        void Update(tblDepartment obj);

        void Delete(int departmentId);

        void Save();


    }
}
