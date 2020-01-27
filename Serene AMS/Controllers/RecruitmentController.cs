using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
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

            var name = objrepo.Getname(model.ApplicantName,model.Email);

            if (name == null)
            {
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
            }
            else
            {
                TempData["ErrorMessage1"] = "You have already Submitted Application";
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

            var Data = obj.GetAll().ToList();


            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);

        }
    }
}