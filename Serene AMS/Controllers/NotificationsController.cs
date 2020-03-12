using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Serene_AMS.Controllers
{
    public class NotificationsController : Controller
    {
        public JsonResult GetReqNoti()
        {
            ReqList obj = new ReqList();
            DataSet ds = obj.Show_Reqnotidata();
            List<RequestVM> listreq = new List<RequestVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listreq.Add(new RequestVM
                {
                    CityName = dr["CityName"].ToString(),
                    RequestId = Convert.ToInt32(dr["RequestId"]),
                    EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                    EmployeeName = dr["EmployeeName"].ToString(),
                    DateofRequest = Convert.ToDateTime(dr["DateofRequest"]),
                    RequestType = dr["RequestType"].ToString(),
                    Position = dr["Position"].ToString()

                });
            }
            return Json(listreq, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetReqNotires()
        {
            ReqList obj = new ReqList();
            DataSet ds = obj.Show_Reqnotidata1();
            List<RequestVM> listreq = new List<RequestVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listreq.Add(new RequestVM
                {
                    CityName = dr["CityName"].ToString(),
                    RequestId = Convert.ToInt32(dr["RequestId"]),
                    EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                    EmployeeName = dr["EmployeeName"].ToString(),
                    DateofRequest = Convert.ToDateTime(dr["DateofRequest"]),
                    RequestType = dr["RequestType"].ToString(),
                    Position = dr["Position"].ToString(),
                    Status = dr["Status"].ToString()
                });
            }
            return Json(listreq, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEmpProres()
        {
            ReqList obj = new ReqList();
            DataSet ds = obj.Show_Emppronoti();
            List<PositionVM> listpro = new List<PositionVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listpro.Add(new PositionVM
                {
                    Position = dr["Position"].ToString(),
                    Experience = dr["Experience"].ToString(),
                    EmployeeId=Convert.ToInt32(dr["EmployeeId"])

                   
                });
            }
            return Json(listpro, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetReqNoticount()
        {
            ReqList obj = new ReqList();
            DataSet ds = obj.Show_Reqnoticounts();
            List<RequestVM> listreq = new List<RequestVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listreq.Add(new RequestVM
                {
                    count = Convert.ToInt32(dr["Totalcount"])
                });
            }
            return Json(listreq, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetReqNoticountres()
        {
            ReqList obj = new ReqList();
            DataSet ds = obj.Show_Reqnoticount1();
            List<RequestVM> listreq = new List<RequestVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listreq.Add(new RequestVM
                {
                    count = Convert.ToInt32(dr["NotiCount"])
                });
            }
            return Json(listreq, JsonRequestBehavior.AllowGet);
        }
        public bool SendEmail(string toEmail, string subject, string emailbody)
        {
            try
            {
                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailbody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public ActionResult UpdateSeen(RequestVM model)
        {
            IStructuredetailRepository obj = new StructuredetailRepository();
            obj.updateseen(Convert.ToInt32(model.RequestId));
            obj.Save();

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateSeenPromotion(PositionVM model)
        {
            IStructuredetailRepository obj = new StructuredetailRepository();
            obj.updateseenPro(Convert.ToInt32(model.EmployeeId));
            obj.Save();

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Promotions()
        {
            IStructuredetailRepository repo = new StructuredetailRepository();
            var deplist = repo.Getdep().ToList();

            SelectList list = new SelectList(deplist, "DepartmentId", "DepartmentName");
            ViewBag.getdep1list = list;

            return View();
        }
        public ActionResult GetempposList(int? Id)
        {
            IStructuredetailRepository repo = new StructuredetailRepository();
            IDepartmentRepository deprepo = new DepartmentRepository();

            var data = (from emp in repo.Getemp()
                        join pos in repo.Getpos() on emp.PositionId equals pos.Id
                        select new
                        {
                            emp.EmployeeId,
                            emp.EmployeeName,
                            emp.PositionId,
                            emp.CityName,
                            emp.Contact,
                            emp.Email,
                            emp.DateofBirth,
                            emp.Gender,
                            pos.Position,
                            pos.Experience


                        }).Where(x=>x.PositionId==Id).Select(c => new PositionVM()
                        {
                            EmployeeName = c.EmployeeName,
                            EmployeeId = (int)c.EmployeeId,
                            Gender = c.Gender,
                            Experience = c.Experience,
                            CityName = c.CityName,
                            Contact = c.Contact,
                            Email = c.Email,
                            DateofBirth = (DateTime)c.DateofBirth,
                            PositionId = (int)c.PositionId,
                            Position = c.Position


                        });

            return Json(data, JsonRequestBehavior.AllowGet);

        }
        public ActionResult RemoveTable(int? Id)
        {
            IStructuredetailRepository repo = new StructuredetailRepository();
            IDepartmentRepository deprepo = new DepartmentRepository();

            var data = (from emp in repo.Getemp()
                        join pos in repo.Getpos() on emp.PositionId equals pos.Id
                        select new
                        {
                            emp.EmployeeId,
                            emp.EmployeeName,
                            emp.PositionId,
                            emp.CityName,
                            emp.Contact,
                            emp.Email,
                            emp.DateofBirth,
                            emp.Gender,
                            pos.Position,
                            pos.Experience


                        }).Where(x => x.PositionId != Id).Select(c => new PositionVM()
                        {
                            EmployeeName = c.EmployeeName,
                            EmployeeId = (int)c.EmployeeId,
                            Gender = c.Gender,
                            Experience = c.Experience,
                            CityName = c.CityName,
                            Contact = c.Contact,
                            Email = c.Email,
                            DateofBirth = (DateTime)c.DateofBirth,
                            PositionId = (int)c.PositionId,
                            Position = c.Position


                        });

            return Json(data, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetEmployeeforpro(int? Id)
        {

            IStructuredetailRepository repo = new StructuredetailRepository();
            

            var data = (from emp in repo.Getemp()
                        join pos in repo.Getpos() on emp.PositionId equals pos.Id
                        select new
                        {
                            emp.EmployeeId,
                            emp.EmployeeName,
                            emp.PositionId,
                            emp.CityName,
                            emp.Contact,
                            emp.Email,
                            emp.DateofBirth,
                            emp.Gender,
                            pos.Position,
                            pos.Experience,
                            emp.DepartmentId,
                            pos.JobLevel


                        }).Where(x => x.EmployeeId == Id).Select(c => new PositionVM()
                        {
                            EmployeeName = c.EmployeeName,
                            EmployeeId = (int)c.EmployeeId,
                            Gender = c.Gender,
                            Experience = c.Experience,
                            CityName = c.CityName,
                            Contact = c.Contact,
                            Email = c.Email,
                            DateofBirth = (DateTime)c.DateofBirth,
                            PositionId = (int)c.PositionId,
                            Position = c.Position,
                            JobLevel=(int)c.JobLevel,
                            DepartmentId=(int)c.DepartmentId


                        }).FirstOrDefault();

            
            return PartialView("EmployeePromotionPartial",data);
        }
        public ActionResult GetPositionbyposId(int? Id,int? depid,int? joblevel)
        {
            IStructuredetailRepository obj = new StructuredetailRepository();
            var Data = (from pos in obj.Getpos()
                        select new
                        {
                            pos.Id,
                            pos.DepartmentId,
                            pos.JobLevel,
                            pos.Position
                           


                        }).Where(x => x.Id != Id).Where(a => a.DepartmentId == depid && a.JobLevel > joblevel).Select(x=> new PositionVM { Id=x.Id,Position=x.Position});


            return Json(Data, JsonRequestBehavior.AllowGet);

        }
        public ActionResult EmployeePositionUpdate(PositionVM model)
        {
            IStructuredetailRepository repo = new StructuredetailRepository();

            repo.updatepos(model.EmployeeId,model.posidtopro);
            repo.Save();
            repo.updateempdetailpro(model.EmployeeId);
            repo.Save();


            TempData["SuccessMessage11"] = "Success";
            return Json(new { success=true},JsonRequestBehavior.AllowGet);
        }
        public ActionResult EmployeeSalaryUpdate(PositionVM model)
        {
            IStructuredetailRepository repo = new StructuredetailRepository();
            var SalaryCheck = repo.Getpos().Where(x => x.BasicPay > model.Employeesalary).FirstOrDefault();
            if (SalaryCheck == null)
            {
                repo.setProEmpsalary(model.EmployeeId, model.Employeesalary);
                repo.Save();
                bool result = false;
                result = SendEmail(model.Email, "Promotion Letter", " <p>"+model.Description+"</p>");


                TempData["SuccessMessage21"] = "Success";
                return Json(new { result,success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                TempData["ErrorMessage21"] = "Salary can not be less than " +model.BasicPay+ " for Employee of " +model.Position+ " Position";
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            
        }


        public ActionResult SetPromotedEmployeeSalary()
        {
            return View();
        }
        public ActionResult GetPromotedEmployeesList()
        {
            IStructuredetailRepository repo = new StructuredetailRepository();

            var Data = (from emp in repo.Getemp()
                        join empdetail in repo.Getempdet() on emp.EmployeeId equals empdetail.EmployeeId
                        join pos in repo.Getpos() on emp.PositionId equals pos.Id
                        select new
                        {
                            emp.EmployeeId,
                            emp.EmployeeName,
                            empdetail.DateofPromotion,
                            empdetail.IsSalaryset,
                            pos.Position,
                            pos.BasicPay

                        }).Where(a => a.IsSalaryset == false).ToList();

            return Json(new { data=Data},JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPromotedEmpSalary(int? Id)
        {

            IStructuredetailRepository repo = new StructuredetailRepository();

            var data = (from emp in repo.Getemp()
                        join pos in repo.Getpos() on emp.PositionId equals pos.Id
                        select new
                        {
                            emp.EmployeeId,
                            emp.EmployeeName,
                            emp.PositionId,        
                            pos.Position,
                            pos.BasicPay,
                            pos.Experience,
                            emp.Email
                                      

                        }).Where(x => x.EmployeeId == Id).Select(c => new PositionVM()
                        {
                            EmployeeName = c.EmployeeName,
                            EmployeeId = (int)c.EmployeeId,
                            PositionId = (int)c.PositionId,
                            Position = c.Position,
                            BasicPay=(decimal)c.BasicPay,
                            Description="Congratulations, "+c.EmployeeName+" based on your Performance and "+c.Experience+" Experience You have Been Promoted to "+c.Position+" Position and your Basic Salary is increased to "+c.BasicPay+". Regards",
                            Email=c.Email
                          

                        }).FirstOrDefault();


            return PartialView("EmployeePromotionSalaryPartial", data);
        }
        [HttpGet]
        public ActionResult PromotionDetails(int? Id)
        {
            IStructuredetailRepository repo = new StructuredetailRepository();

            var Data = (from emp in repo.Getemp()
                        join empdet in repo.Getempdet() on emp.EmployeeId equals empdet.EmployeeId
                        join pos in repo.Getpos() on emp.PositionId equals pos.Id
                        select new
                        {
                            emp.EmployeeId,
                            emp.EmployeeName,
                            emp.PositionId,
                            pos.Position,
                            empdet.EmployeeSalary,
                            empdet.DateofPromotion


                        }).Where(x => x.EmployeeId == Id).Select(c => new PositionVM()
                        {
                            EmployeeName = c.EmployeeName,
                            EmployeeId=(int)c.EmployeeId,
                            Position = c.Position,
                            Employeesalary = (decimal)c.EmployeeSalary,
                            DateofPromotion=(DateTime)c.DateofPromotion


                        }).FirstOrDefault();



            return View(Data);
        }

    }
}
