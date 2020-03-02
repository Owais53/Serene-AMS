using Newtonsoft.Json;
using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
using Serene_AMS.Infrastructure;
using Serene_AMS.Models;
using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
        public ActionResult Apply(int? id)
        {
            IStructuredetailRepository obj = new StructuredetailRepository();
            var Data = obj.GetVacancies()
                .Select(x=> new ApplyVM { VacancyId=x.VacancyId,Appliedfor=x.VacancyName})
                .Where(x => x.VacancyId == id).FirstOrDefault();


            return View(Data);
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

                        var addmethod = objrepo.AddApplicant(model.VacancyId,model.ApplicantName, model.Phone, model.Email, model.Dob, model.Gender,model.Appliedfor, model.Address, fileName);
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
        [CustomAuthorize("Recruitment Officer", "Admin")]
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
        [CustomAuthorize("Recruitment Officer")]
        public ActionResult GetCandidates(int? id)
        {
            IRepository obj = new ApplicantRepository();
            var candidates = obj.GetById(Convert.ToInt32(id)) ?? new tblApplicant();
            return PartialView("Marksupload",candidates);
        }
        
        public ActionResult GetCandidate1(int? id)
        {
            IRepository obj = new ApplicantRepository();
            
            var result = (from d in obj.GetAll()                    
                      where d.ApplicationId == id
                      select new
                      {
                         d.ApplicationId

                      }).Select(c => new tblApplicant()
                      {
                          ApplicationId = (int)(c.ApplicationId)
                          
                      }).FirstOrDefault();

            return View("ViewMarks",result);
        }
        public ActionResult GetApproval(int? id)
        {
            IRepository obj = new ApplicantRepository();
            IStructuredetailRepository repo = new StructuredetailRepository();
            IDepartmentRepository deprepo = new DepartmentRepository();
            var ap = (from d in obj.GetAll()
                       join s in repo.GetVacancies() on d.VacancyId equals s.VacancyId
                       join dep in deprepo.GetAll() on s.DepartmentId equals dep.DepartmentId
                       join pos in repo.Getpos() on s.PositionId equals pos.Id
                       where d.ApplicationId == id
                       select new
                       {
                          
                      
                           d.ApplicantName,
                           d.Gender,
                           s.DepartmentId,
                           s.PositionId,
                           d.Dob,
                           d.Phone,
                           d.Email,
                           d.Address,
                           d.ApplicationId,
                           dep.DepartmentName,
                           pos.Position


                       }).Select(c => new CandidateEmployeeVM()
                       {
                           ApplicationId = (int)(c.ApplicationId),                           
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


            return PartialView("ApproveApplicantPartial",ap);
        }
        public ActionResult GetSlCandidates(int? id)
        {
            IRepository obj = new ApplicantRepository();
            IStructuredetailRepository repo = new StructuredetailRepository();
            IDepartmentRepository deprepo = new DepartmentRepository();
            var Emp = (from d in obj.GetAll()
                      join s in repo.GetVacancies() on d.VacancyId equals s.VacancyId
                      join dep in deprepo.GetAll() on s.DepartmentId equals dep.DepartmentId
                      join pos in repo.Getpos() on s.PositionId equals pos.Id
                      where d.ApplicationId == id
                      select new
                      {
                          
                          d.ApplicantName,
                          d.Gender,
                          s.DepartmentId,
                          s.PositionId,
                          d.Dob,
                          d.Phone,
                          d.Email,
                          d.Address,
                          d.ApplicationId,
                          dep.DepartmentName,
                          pos.Position
                       

                      }).Select(c => new CandidateEmployeeVM()
                      {
                          ApplicationId =(int)(c.ApplicationId),
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
        public ActionResult GetConfirmation(int? id)
        {
            IRepository obj = new ApplicantRepository();
            IStructuredetailRepository repo = new StructuredetailRepository();
            IDepartmentRepository deprepo = new DepartmentRepository();

            var Data = (from d in obj.GetAll()
                        join s in repo.GetVacancies() on d.VacancyId equals s.VacancyId
                        where d.ApplicationId == id
                        select new
                        {

                            d.ApplicantName,
                            d.Gender,
                            s.DepartmentId,
                            s.PositionId,
                            d.Dob,
                            d.Phone,
                            d.Email,
                            d.Address,
                            d.ApplicationId,
                            d.JoiningDate,
                            s.CityName
                            

                        }).Select(c => new CandidateEmployeeVM()
                        {
                            ApplicationId = (int)(c.ApplicationId),
                            EmployeeName = c.ApplicantName,
                            Gender = c.Gender,
                            DepartmentId = (int)(c.DepartmentId),
                            PositionId = (int)c.PositionId,
                            DateofBirth = (DateTime)c.Dob,
                            Contact = c.Phone,
                            Email = c.Email,
                            Address = c.Address,
                            JoiningDate=(Nullable<DateTime>)c.JoiningDate,
                            CityName=c.CityName

                        }).FirstOrDefault();

            return PartialView("ConfirmEmployeePartial",Data);
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
            objrepo.updatetohired(model.ApplicationId);
            objrepo.Save();

            var add = objrepo.AddEmployee(model.CityName,model.EmployeeName,model.Gender,model.DepartmentId,model.DateofBirth,model.Contact,model.Email,model.Address,model.PositionId);
            objrepo.Addemp(add);
            objrepo.Save();

            var add1 = objrepo.AddempDetail(add.EmployeeId,(Nullable<DateTime>)model.JoiningDate);
            objrepo.Addempdetail(add1);
            objrepo.Save();

           

            TempData["SuccessMessage25"] = "Success";
            return Json(new { success = true, message = "Employee Hired" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult updateappointstatus(CandidateEmployeeVM model)
        {
            IRepository objrepo = new ApplicantRepository();
            objrepo.statusappoint(model.ApplicationId);
            objrepo.Save();
        
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult JoindSalary(CandidateEmployeeVM model)
        {

            IRepository objrepo = new ApplicantRepository();
          
            objrepo.UpdateEmp(model.ApplicationId,model.JoiningDate,model.Salary);
            objrepo.Save();


            TempData["SuccessMessage25"] = "Success";
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
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

        [CustomAuthorize("Recruitment Officer", "Admin")]
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
     
        public ActionResult Approve(CandidateEmployeeVM model)
        {
            IRepository objrepo = new ApplicantRepository();
            objrepo.Update(model.ApplicationId);
            objrepo.Save();
            
            bool result = false;
            result = SendEmail(model.Email, "Application Approved", " <p>Hi " + model.EmployeeName + ",<br/><br/>This is to Inform you that your Application for " + model.Position + " Position in " + model.DepartmentName + " Department has been accepted because " + model.desc + "<br/><br/>Regards " + model.CompanyName + " </p>");

            TempData["UpdateMessage00"] = "Approved Successfully";
            return Json(new { result, success = true }, JsonRequestBehavior.AllowGet);


        }
        public ActionResult Reject(int id)
        {
            IRepository objrepo = new ApplicantRepository();
            objrepo.Update1(id);
            objrepo.Save();
            TempData["UpdateMessage"] = "Rejected Successfully";
            return View("ViewApplications");
        }
        [CustomAuthorize("Recruitment Officer", "Admin")]
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
        public ActionResult GetIdonConfirm(int? id)
        {
            IRepository obj = new ApplicantRepository();
            IStructuredetailRepository repo = new StructuredetailRepository();
            IDepartmentRepository deprepo = new DepartmentRepository();

            var result = (from d in obj.GetAll()
                          join s in repo.GetVacancies() on d.VacancyId equals s.VacancyId
                          join dep in deprepo.GetAll() on s.DepartmentId equals dep.DepartmentId
                          where d.ApplicationId == id
                          select new
                          {
                              d.ApplicationId,
                              d.Email,
                              d.Appliedfor,
                              dep.DepartmentName,
                              d.ApplicantName

                          }).Select(c => new CandidateEmployeeVM()
                          {
                              ApplicationId = (int)(c.ApplicationId),
                              Email = c.Email,
                              Position = c.Appliedfor,
                              DepartmentName = c.DepartmentName,
                              EmployeeName = c.ApplicantName

                          }).FirstOrDefault();


            return PartialView("ConfirmPartial",result);
        }
        
        public ActionResult PostStatus(CandidateEmployeeVM model,FormCollection form)
        {
            IRepository repo = new ApplicantRepository();

            var time = form["gettime"];
                repo.update4(Convert.ToInt32(model.ApplicationId),model.interviewdate);
                repo.Save();

                bool result = false;
                result = SendEmail(model.Email, "Interview", " <p>Hi " + model.EmployeeName + ",<br/><br/>This is to Inform you that you that you have been called for Interview on " + model.interviewdate + time + " at HeadOffice  for Position of " + model.Position + " Position in " + model.DepartmentName + "<br/><br/>Regards </p>");

                TempData["UpdateMessage100"] = "Mail Sent to Candidate";
                return Json(new { result,success = true, message = "Employee Hired" }, JsonRequestBehavior.AllowGet);
           


        }

        public ActionResult GetMarksList()
        {
            IRepository obj = new ApplicantRepository();

            var Data = obj.GetAll().Select(a=>new tblApplicant { ApplicantName=a.ApplicantName,Phone=a.Phone,Email=a.Email,Gender=a.Gender,Marks=a.Marks,Submittedon=a.Submittedon,TestStatus=a.TestStatus,ApplicationId=a.ApplicationId,Status=a.Status}).Where(x=>x.Status == "Approved").Where(x => x.TestStatus == "Pass").ToList();


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
                        join a in objrepo.GetAll() on u.DepartmentId equals a.DepartmentId
                        join b in repo.Getpos() on u.PositionId equals b.Id
                        select new
                        {
            
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
            HrmsEntities entities = new HrmsEntities();
            IRepository repo = new ApplicantRepository();
            var date = DateTime.Today.GetDateTimeFormats();
            var today = DateTime.Now;
            var tommorrow = DateTime.Now.AddDays(1).Date;
            var Data = entities.tblApplicants.Where(x => x.Status == "Called for Interview" && DbFunctions.TruncateTime(x.InterviewDate) == DbFunctions.TruncateTime(today) || DbFunctions.TruncateTime(x.InterviewDate)== DbFunctions.TruncateTime(tommorrow))
                .AsEnumerable()
                .Select(x => new { x.ApplicantName,x.Phone,x.Email,x.Appliedfor,x.Status,x.ApplicationId,x.InterviewDate}).ToList();
            

            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }

        [CustomAuthorize("Recruitment Manager", "Admin")]
        [HttpGet]
        public ActionResult CreateVacancy()
        {
            IStructuredetailRepository objstructureRepository = new StructuredetailRepository();
            var deplist = objstructureRepository.Getdep().ToList();
           
            SelectList list = new SelectList(deplist, "DepartmentId", "DepartmentName");
            ViewBag.getdep1list = list;


            var levellist = new SelectList(new[]
           {
                new {ID="1",Name="1"},
                new {ID="2",Name="2"},
                new {ID="3",Name="3"},
                new {ID="4",Name="4"},
                new {ID="5",Name="5"}
            },
            "Name", "Name", "1"
             );
            ViewBag.getlevellist = levellist;

            var city = new SelectList(new[]
            {
                new {ID="1",Name="Karachi"},
                new {ID="2",Name="Lahore"},
                new {ID="3",Name="Islamabad"}

            },
           "Name", "Name", "1"
            );
            ViewBag.getcitylist = city;

            return View();
            
           
        }
        public JsonResult GetPositionbyId(int Id)
        {
            HrmsEntities db = new HrmsEntities();
            IStructuredetailRepository repoobj = new StructuredetailRepository();
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.tblPositions.Where(p => p.DepartmentId == Id).Select(x=> new { x.Id,x.Position}), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateVacancy(VacancyVM model, HttpPostedFileBase postedFile1,FormCollection form)
        {
            IStructuredetailRepository repo = new StructuredetailRepository();
            var city = new SelectList(new[]
           {
                    new {ID="1",Name="Karachi"},
                    new {ID="2",Name="Lahore"},
                    new {ID="3",Name="Islamabad"}
                   },
               "Name", "Name", "1"
           );
            ViewBag.getcitylist = city;


            var deplist = repo.Getdep().ToList();

            SelectList list = new SelectList(deplist, "DepartmentId", "DepartmentName");
            ViewBag.getdep1list = list;


            var levellist = new SelectList(new[]
           {
                    new {ID="1",Name="1"},
                    new {ID="2",Name="2"},
                    new {ID="3",Name="3"},
                    new {ID="4",Name="4"},
                    new {ID="5",Name="5"}
                   },
            "Name", "Name", "1"
             );
            ViewBag.getlevellist = levellist;



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
                             
                       string fileName1 = Guid.NewGuid() + Path.GetExtension(postedFile1.FileName);
                        postedFile1.SaveAs(Path.Combine(Server.MapPath("~/TestPaper"), fileName1));

                        var AddVacant = repo.Addvac( model.VacancyName,model.CityName,model.PositionId, model.DepartmentId, model.RequiredQualification, model.JobLevel, model.MarksCriteria, fileName1);
                        repo.Addvacant(AddVacant);
                        repo.Save();


                     TempData["SuccessMessage11"] = "Vacancy Created";

                  
                
            }
            return View();

        }
        [CustomAuthorize("Admin")]
        public ActionResult ViewVacancy()
        {
            return View();
        }
        [CustomAuthorize("DGM", "Admin")]
        public ActionResult ViewShortlistedcandidate()
        {
            return View();
        }
        public JsonResult get_jobdata()
        {
            JobListing obj = new JobListing();
            DataSet ds = obj.Show_Jobdata();
            List<tblVacancy> listvac = new List<tblVacancy>();

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                listvac.Add(new tblVacancy
                {
                    VacancyId = Convert.ToInt32(dr["VacancyId"]),
                    VacancyName =dr["VacancyName"].ToString(),
                    CityName = dr["CityName"].ToString(),
                    JobLevel = Convert.ToInt32(dr["JobLevel"])

                });
            }
            return Json(listvac, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Home()
        {

            return View();
        }
        public ActionResult GetDetails(int? id)
        {
            IStructuredetailRepository repo = new StructuredetailRepository();
            IDepartmentRepository deprepo = new DepartmentRepository();

            var data = (from d in repo.GetVacancies()
                          join dep in deprepo.GetAll() on d.DepartmentId equals dep.DepartmentId
                          where d.VacancyId == id
                          select new
                          {
                              d.VacancyId,
                              d.VacancyName,
                              d.JobLevel,
                              dep.DepartmentName,
                              d.CityName,
                              d.RequiredQualification

                          }).Select(c => new VacancyVM()
                          {
                              VacancyId=c.VacancyId,
                              JobLevel = (int)(c.JobLevel),                            
                              VacancyName = c.VacancyName,
                              CityName=c.CityName,
                              DepartmentName = c.DepartmentName,
                              RequiredQualification= c.RequiredQualification

                          }).FirstOrDefault();


            return PartialView("JobDetailsPartial", data);

        }
    }
}