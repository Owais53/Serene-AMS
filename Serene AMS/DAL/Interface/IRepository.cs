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

        void Update();

        void Delete(int ApplicationId);

        void Save();

    }
}
