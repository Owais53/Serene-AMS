using Serene_AMS.DAL.Interface;
using Serene_AMS.Models;
using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serene_AMS.DAL.Repository
{
    public class ApplicantRepository : IRepository
    {

        private SqlEntities context;

        public ApplicantRepository()
        {
            context = new SqlEntities();

        }
        public ApplicantRepository(SqlEntities context)
        {
            context = this.context;
        }
        public void Add(tblApplicant obj)
        {
            context.tblApplicants.Add(obj);
        }
        public tblApplicant AddApplicant(string name, string phone, string email, DateTime dob, string gender, string address, string cv)
        {

            var addapplicant = new tblApplicant()
            {
                ApplicantName = name,
                Phone = phone,
                Email = email,
                Dob = dob,
                Gender = gender,
                Status = "Pending",
                Address = address,
                CV = cv,
            };

            return addapplicant;
        }

        public IEnumerable<tblApplicant> GetId(int applicationid, string email)
        {
            return context.tblApplicants.Where(x => x.ApplicationId == applicationid).Where(x=> x.Email == email);
        }
        public IEnumerable<tblApplicant> Getname(string applicantname,string email)
        {
            return context.tblApplicants.Where(x => x.ApplicantName == applicantname)
                .Where(x => x.Email == email);
        }  
        public void Delete(int ApplicationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tblApplicant> GetAll()
        {
            return context.tblApplicants;
        }

        public tblApplicant GetById(int ApplicationId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}