using Newtonsoft.Json;
using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
using Serene_AMS.Models;
using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Serene_AMS.Controllers
{
    public class RecruitmentController : Controller
    {
        [HttpGet]
        public ActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apply(ApplyVM model,HttpPostedFileBase postedFile)
        {
            IRepository objrepo = new ApplicantRepository();

           
                if (postedFile == null)
                {
                    ModelState.AddModelError("CustomError", "Please select CV");
                    return View();
                }

                else if (!(postedFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" || postedFile.ContentType == "application/pdf"))
                {
                    ModelState.AddModelError("CustomError", "Only .docx and .pdf file allowed");
                    return View();
                }
                else if (postedFile != null)
                {
                    if (ModelState.IsValid)
                    {
                        string fileName = Guid.NewGuid() + Path.GetExtension(postedFile.FileName);
                        postedFile.SaveAs(Path.Combine(Server.MapPath("~/CV"), fileName));

                        var addmethod = objrepo.AddApplicant(model.ApplicantName, model.Phone, model.Email, model.Dob, model.Gender, model.Address, fileName);
                        objrepo.Add(addmethod);
                        objrepo.Save();
                        if (addmethod != null)
                        {
                            TempData["SuccessMessage1"] = "Your Application has been Submitted";
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage1"] = "Data not added";
                    }
                }
            
           
                return View();
        }

        public ActionResult ViewApplications()
        {
            return View();
        }
        public ActionResult GetApplicantList()
        {
            IRepository obj = new ApplicantRepository();

            var Data = obj.GetAll().Select(x=> new tblApplicant { ApplicantName = x.ApplicantName, Phone = x.Phone, Email = x.Email, Dob = x.Dob, Gender = x.Gender, Status = x.Status, Submittedon = x.Submittedon, CV = x.CV, ApplicationId = x.ApplicationId }).Where(x=>x.Status == "Pending").ToList();


            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetCandidateList()
        {
            IRepository obj = new ApplicantRepository();

            var Data = obj.GetAll().Select(x=> new tblApplicant { ApplicantName=x.ApplicantName,Phone=x.Phone,Email=x.Email,Dob=x.Dob,Gender=x.Gender,Status=x.Status,Submittedon=x.Submittedon,CV=x.CV,ApplicationId=x.ApplicationId }).Where(x=>x.Status == "Approved").ToList();
            
            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetCandidates(int? id)
        {
            IRepository obj = new ApplicantRepository();
            var candidates = obj.GetById(Convert.ToInt32(id)) ?? new tblApplicant();
            return PartialView("Marksupload",candidates);
        }
        public ActionResult GetSlCandidates(int? id)
        {
            IRepository obj = new ApplicantRepository();
            IStructuredetailRepository repo = new StructuredetailRepository();
            IDepartmentRepository deprepo = new DepartmentRepository();
            var Emp = (from d in obj.GetAll()
                      join s in repo.GetVacancies() on d.VacancyId equals s.VacancyId
                      join p in repo.GetAll() on s.StructureId equals p.Id
                      join dep in deprepo.GetAll() on s.DepartmentId equals dep.DepartmentId
                      join pos in repo.Getpos() on s.PositionId equals pos.Id
                      where d.ApplicationId == id
                      select new
                      {
                          s.CompanyCode,
                          s.CityCode,
                          d.ApplicantName,
                          d.Gender,
                          s.DepartmentId,
                          s.PositionId,
                          d.Dob,
                          d.Phone,
                          d.Email,
                          d.Address,
                          p.Id,
                          d.ApplicationId,
                          dep.DepartmentName,
                          pos.Position
                       

                      }).Select(c => new CandidateEmployeeVM()
                      {
                          ApplicationId =(int)(c.ApplicationId),
                          StructureId = (int)(c.Id),
                          CompanyCode = (int)(c.CompanyCode),
                          CityCode = (int)(c.CityCode),
                          EmployeeName = c.ApplicantName,
                          Gender = c.Gender,
                          DepartmentId = (int)(c.DepartmentId),
                          DepartmentName = c.DepartmentName,
                          PositionId = (int)c.PositionId,
                          DateofBirth = (DateTime)c.Dob,
                          Contact = c.Phone,
                          Email = c.Email,
                          Address = c.Address,
                          Position = c.Position



                      }).FirstOrDefault();


            return PartialView("HireEmployee",Emp);
        }
        public ActionResult UploadMarks(tblApplicant obj)
        {
            IRepository repo = new ApplicantRepository();
            var passingmarks = repo.Getmarkscriteria(Convert.ToInt32(obj.VacancyId)).Select(a => a.MarksCriteria).SingleOrDefault();

            if (ModelState.IsValid)
            {
                if (obj.ApplicationId > 0)
                {
                    if(obj.Marks >= passingmarks)
                    {
                        TempData["UpdateMessage3"] = "Uploaded Successfully";
                        repo.update2(obj.ApplicationId, Convert.ToInt32(obj.Marks));
                        repo.Save();
                    }
                    else if(obj.Marks < passingmarks)
                    {
                        TempData["UpdateMessage3"] = "Uploaded Successfully";
                        repo.update3(obj.ApplicationId, Convert.ToInt32(obj.Marks));
                        repo.Save();
                    }
                   
                }
                else
                {
                    repo.Add(obj);
                }
                 repo.Save();
                return Json(new { success = true, message = "Marks Uploaded Successfully" }, JsonRequestBehavior.AllowGet);

            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult employeehire(CandidateEmployeeVM model)
        {
            IRepository objrepo = new ApplicantRepository();
            var add = objrepo.AddEmployee(model.StructureId,model.CompanyCode,model.CityCode,model.EmployeeName,model.Gender,model.DepartmentId,model.DateofBirth,model.Contact,model.Email,model.Address,model.PositionId);
            objrepo.Addemp(add);
            objrepo.Save();

            objrepo.updatetohired(model.ApplicationId);
            objrepo.Save();

            bool result = false;
            result = SendEmail(model.Email,"Appointment Letter", " <p>Hi " + model.EmployeeName + ",<br/>This is to Inform you that you have been hired as a " + model.Position + " in " + model.DepartmentName + " Department<br/>Regards</p>");


            return Json(new {result, success = true, message = "Employee Hired" }, JsonRequestBehavior.AllowGet);
        }
        public bool SendEmail(string toEmail,string subject,string emailbody)
        {
            try {
                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com",587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail,toEmail,subject,emailbody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);

                return true;
            }
            catch(Exception ex) {

                return false;
            }
        }
        [HttpGet]
        public ActionResult ViewCandidate(int id=0)
        {
            IRepository obj = new ApplicantRepository();
            if (id == 0)
            {
                return View(new tblApplicant());
            }
            else
            {
                var Applicationid = obj.GetAll().Where(x => x.ApplicationId == id).FirstOrDefault();

                return View(Applicationid);
            }
        }
     
        public ActionResult Approve(int id)
        {
            IRepository objrepo = new ApplicantRepository();
            objrepo.Update(id);
            objrepo.Save();
            TempData["UpdateMessage"] = "Approved Successfully";
            return View("ViewApplications");
            
            
        }
        public ActionResult Reject(int id)
        {
            IRepository objrepo = new ApplicantRepository();
            objrepo.Update1(id);
            objrepo.Save();
            TempData["UpdateMessage"] = "Rejected Successfully";
            return View("ViewApplications");
        }
        public ActionResult ViewMarks()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetStatus(int id = 0)
        {
            IRepository obj = new ApplicantRepository();
            if(id == 0)
            {
                return View("ViewMarks", new tblApplicant());
            }
            else
            {
                return View("ViewMarks", obj.GetAll().Where(x=>x.ApplicationId == id).FirstOrDefault<tblApplicant>());
            }
           
        }
        
        public ActionResult PostStatus(int id,tblApplicant form)
        {
            IRepository repo = new ApplicantRepository();

            if (form.Status == "Select")
            {
                return View("ViewMarks");
            }
            else
            {
                repo.update4(Convert.ToInt32(id));
                repo.Save();
            }

            return View("ViewMarks");

        }

        public ActionResult GetMarksList()
        {
            IRepository obj = new ApplicantRepository();

            var Data = obj.GetAll().Select(a=>new tblApplicant { ApplicantName=a.ApplicantName,Phone=a.Phone,Email=a.Email,Gender=a.Gender,Marks=a.Marks,Submittedon=a.Submittedon,TestStatus=a.TestStatus,ApplicationId=a.ApplicationId}).Where(x => x.TestStatus == "Pass").Where(x=>x.Status=="Approved").ToList();


            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AvailableVacancy()
        {
            return View();
        }
        public ActionResult GetvacList()
        {
            IStructuredetailRepository repo = new StructuredetailRepository();
            IDepartmentRepository objrepo = new DepartmentRepository();

            var Data = (from u in repo.Get()
                        join r in repo.GetAll() on u.StructureId equals r.Id
                        join a in objrepo.GetAll() on u.DepartmentId equals a.DepartmentId
                        join b in repo.Getpos() on u.PositionId equals b.Id
                        select new
                        {
                            r.CompanyName,
                            r.CityName,
                            a.DepartmentName,
                            b.Position,
                            u.Availableseats,
                            u.Id,
                            
                        }).ToList();

            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Getcreatedvaclist()
        {
            IStructuredetailRepository repo = new StructuredetailRepository();
            IDepartmentRepository objrepo = new DepartmentRepository();

            var Data = (from u in repo.GetVacancies()
                        join a in objrepo.GetAll() on u.DepartmentId equals a.DepartmentId
                        join b in repo.Getpos() on u.PositionId equals b.Id
                        select new
                        {
                           
                            a.DepartmentName,
                            b.Position,
                            u.JobLevel,
                            u.MarksCriteria,
                            u.Testpaper,
                            

                        }).ToList();

            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetslcanList()
        {
            IRepository repo = new ApplicantRepository();

            var Data = (from u in repo.GetAll()
                        where u.Status == "Called for Interview"
                        select new
                        {
                            u.ApplicantName,
                            u.Phone,
                            u.Email,
                            u.Appliedfor,
                            u.Status,
                            u.ApplicationId,

                        }).ToList();

            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult CreateVacancy(int id = 0)
        {
            if(id == 0)
            {
                return View(new VacancyVM());
            }
            else
            {
                IStructuredetailRepository objrepo = new StructuredetailRepository();
                IDepartmentRepository deprepo = new DepartmentRepository();

                var rd = (from d in objrepo.Get()
                          join s in objrepo.GetAll() on d.StructureId equals s.Id
                          join pos in objrepo.Getpos() on d.PositionId equals pos.Id                         
                          join dep in deprepo.GetAll() on d.DepartmentId equals dep.DepartmentId
                          where d.Id == id
                          select new
                          {

                              s.Id,
                              d.CompanyCode,
                              d.CityCode,
                              s.CityName,
                              s.CompanyName,
                              d.DepartmentId,
                              dep.DepartmentName,
                              d.PositionId,
                              pos.Position,
                              pos.JobLevel,
                              d.Availableseats
                    


                          }).Select(c => new VacancyVM()
                          {
                              StructureId=(int)(c.Id),
                              CompanyCode = (int)(c.CompanyCode),
                              CityCode = (int)(c.CityCode),
                              CityName = c.CityName,
                              CompanyName = c.CompanyName,
                              DepartmentId = (int)(c.DepartmentId),
                              DepartmentName = c.DepartmentName,
                              PositionId = (int)c.PositionId,
                              Position = c.Position,                             
                              JobLevel = c.JobLevel,
                              Availableseats = (int)c.Availableseats
                             


                          }).FirstOrDefault();

                return View(rd);
            }
           
        }
        [HttpPost]
        public ActionResult CreateVacancy(VacancyVM model, HttpPostedFileBase postedFile1)
        {
            IStructuredetailRepository repo = new StructuredetailRepository();
            var structid = repo.GetstructId(model.StructureId).FirstOrDefault();
            var Positionid = repo.GetPosition(model.PositionId).FirstOrDefault();

            if (postedFile1 == null)
            {
                ModelState.AddModelError("CustomError", "Please select Test");
                
            }

            else if (!(postedFile1.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" || postedFile1.ContentType == "application/pdf"))
            {
                ModelState.AddModelError("CustomError", "Only .docx and .pdf file allowed");
                return View();
            }
            else if (postedFile1 != null)
            {
              

                    if (ModelState.IsValid)
                    {
                        string fileName1 = Guid.NewGuid() + Path.GetExtension(postedFile1.FileName);
                        postedFile1.SaveAs(Path.Combine(Server.MapPath("~/TestPaper"), fileName1));

                        var AddVacant = repo.Addvac(model.StructureId, model.Position, model.CompanyCode, model.CityCode, model.PositionId, model.DepartmentId, model.Availableseats, model.RequiredQualification, model.JobLevel, model.MarksCriteria, fileName1);
                        repo.Addvacant(AddVacant);
                        repo.Save();
                        TempData["SuccessMessage11"] = "Vacancy Created";
                    }
                    else
                    {
                        ModelState.AddModelError("CustomError", "ViewModel not Valid");
                    }
                
            }
            return View();

        }
        public ActionResult ViewVacancy()
        {
            return View();
        }
        public ActionResult ViewShortlistedcandidate()
        {
            return View();
        } 
        public ActionResult Home()
        {
            return View();
        }

    }
}