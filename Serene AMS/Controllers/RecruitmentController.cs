using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
using Serene_AMS.Models;
using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
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

            var Data = obj.GetAll().Where(x=>x.Status == "Pending").ToList();


            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetCandidateList()
        {
            IRepository obj = new ApplicantRepository();

            var Data = obj.GetAll().Where(x=>x.Status == "Approved").ToList();


            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetCandidates(int? id)
        {
            IRepository obj = new ApplicantRepository();
            var candidates = obj.GetById(Convert.ToInt32(id)) ?? new tblApplicant();
            return PartialView("Marksupload",candidates);
        }
        public ActionResult UploadMarks(tblApplicant obj)
        {
            IRepository repo = new ApplicantRepository();
            if (ModelState.IsValid)
            {
                if (obj.ApplicationId > 0)
                {
                    if(obj.Marks >= 60)
                    {
                        TempData["UpdateMessage3"] = "Uploaded Successfully";
                        repo.update2(obj.ApplicationId, Convert.ToInt32(obj.Marks));
                        repo.Save();
                    }
                    else if(obj.Marks < 60)
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

            var Data = obj.GetAll().Where(x => x.TestStatus == "Pass").ToList();


            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Home()
        {
            return View();
        }

    }
}