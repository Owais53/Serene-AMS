using Serene_AMS.Models;
using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Serene_AMS.Controllers
{
    public class AccountController : Controller
    {

        private  HrmsEntities db = new HrmsEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tblUser model)
        {
            var isActive = db.tblUsers.Where(x => x.IsActive == 1)
                   .Where(a => a.UserName == model.UserName && a.Password == model.Password).FirstOrDefault();
            
            if (isActive != null)
            {

                var user = (from u in db.tblUsers
                            join d in db.tblDepartments on u.DepartmentId equals d.DepartmentId
                            join a in db.tblAdminchecks on u.AdminId equals a.AdminId
                            join r in db.tblRoles on u.RoleId equals r.Id
                            join e in db.tblEmployees on u.EmployeeId equals e.EmployeeId
                            where u.UserName == model.UserName && u.Password == model.Password
                            select new
                            {
                                u.UserName,
                                u.UserId,
                                d.DepartmentName,
                                a.desc,
                                r.RoleName,
                                e.EmployeeName,
                                e.PositionId,
                                d.DepartmentId,
                                e.EmployeeId,
                                e.CityName
                                

                            }).FirstOrDefault();

                var user1 = (from u in db.tblUsers
                            join d in db.tblDepartments on u.DepartmentId equals d.DepartmentId
                            join a in db.tblAdminchecks on u.AdminId equals a.AdminId
                            join r in db.tblRoles on u.RoleId equals r.Id
                            join e in db.tblEmployees on u.EmployeeId equals e.EmployeeId
                            join req in db.tblRequests on e.EmployeeId equals req.EmployeeId
                            where u.UserName == model.UserName && u.Password == model.Password
                            select new
                            {
                                u.UserName,
                                u.UserId,
                                d.DepartmentName,
                                a.desc,
                                r.RoleName,
                                e.EmployeeName,
                                e.PositionId,
                                d.DepartmentId,
                                e.EmployeeId,
                                e.CityName,
                                req.RequestId

                            }).FirstOrDefault();

                if (user1 == null)
                {



                    if (user != null)
                    {
                        Session["UserName"] = user.UserName;
                        Session["UserId"] = user.UserId;
                        Session["DepartmentName"] = user.DepartmentName;
                        Session["RoleName"] = user.RoleName;
                        Session["isAdmin"] = user.desc;
                        Session["Employeename"] = user.EmployeeName;
                        Session["Position"] = user.PositionId;
                        Session["DepartmentId"] = user.DepartmentId;
                        Session["EmployeeId"] = user.EmployeeId;
                        Session["CityName"] = user.CityName;
                        Session["RequestId"] = 0;


                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ViewBag.Text = "Invalid UserName or Password";
                        

                    }
                }
                else
                {
                    Session["UserName"] = user1.UserName;
                    Session["UserId"] = user1.UserId;
                    Session["DepartmentName"] = user1.DepartmentName;
                    Session["RoleName"] = user1.RoleName;
                    Session["isAdmin"] = user1.desc;
                    Session["Employeename"] = user1.EmployeeName;
                    Session["Position"] = user1.PositionId;
                    Session["DepartmentId"] = user1.DepartmentId;
                    Session["EmployeeId"] = user1.EmployeeId;
                    Session["RequestId"] = user1.RequestId;
                    Session["CityName"] = user1.CityName;
                   
                    return RedirectToAction("Index", "Home");

                }
            }
            else
            {
                ViewBag.Text = "User is not Active or Invalid UserName or Password.Please Login Again.";
            }

            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session["UserName"] = string.Empty;
            Session["UserId"] = string.Empty;
            Session["DepartmentName"] = string.Empty;
            Session["RoleName"] = string.Empty;
            Session["isAdmin"] = string.Empty;
            Session["CompanyName"] = string.Empty;
            Session["CityName"] = string.Empty;
            Session["Employeename"] = string.Empty;
            Session["Position"] = string.Empty;
            Session["DepartmentId"] = string.Empty;
            Session["EmployeeId"] = string.Empty;


            return RedirectToAction("Login", "Account");
        }
        [NonAction]
        public void SendVerificationLinkEmail(string emailID,string activationCode,string emailfor)
        {
            var verifyUrl = "/Account/" + emailfor + "/" +activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("owaismumtaz96@gmail.com", "AMS");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "9248133abc";

            string subject = "";
            string body = "";
            if(emailfor=="Reset Password")
            {
                subject = "Reset Password";
                body = "Hi,<br/><br/>We got request for reset your account password.Please click on the below link to reset your password"+
                    "<br/><br/><a href="+link+">Reset Password Link</a>";
            }
            var smtp = new SmtpClient
            {
                Host="smtp.gmail.com",
                Port=587,
                EnableSsl=true,
                DeliveryMethod=SmtpDeliveryMethod.Network,
                UseDefaultCredentials=false,
                Credentials=new NetworkCredential(fromEmail.Address,fromEmailPassword)
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = "Reset Password",
                Body = "Hi,<br/><br/>We got request for reset your account password.Please click on the below link to reset your password" +
                    "<br/><br/><a href=" + link + ">Reset Password Link</a>",
                IsBodyHtml = true

            })
           smtp.Send(message);
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(string EmailID,string UserName)
        {
            bool status = false;

            var account = (from user in db.tblUsers
                           join emp in db.tblEmployees on user.EmployeeId equals emp.EmployeeId
                           where emp.Email == EmailID && user.UserName==UserName
                           select new
                           {
                               emp.Email,
                               emp.EmployeeId
                               
                               
                           }).FirstOrDefault();
            if (account != null)
            {
                string resetCode = Guid.NewGuid().ToString();
                SendVerificationLinkEmail(account.Email, resetCode, "ResetPassword");
                var getuser = db.tblUsers.Where(x => x.EmployeeId == account.EmployeeId).FirstOrDefault();
                if (getuser != null)
                {
                    getuser.ResetPasswordCode = resetCode;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    TempData["Success"] = "Password reset link sent to your Email";
                }
            }
            else
            {
                TempData["Error"] = "Account not found";
            }
                           
            return View();
        }
        public ActionResult ResetPassword(string id)
        {
            var user = db.tblUsers.Where(x => x.ResetPasswordCode == id).FirstOrDefault();
            if (user != null)
            {
                ResetPasswordModel model = new ResetPasswordModel();
                model.ResetCode = id;              
                return View(model);
                
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.tblUsers.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                if (user != null)
                {
                    user.Password =model.NewPassword;
                    user.ResetPasswordCode = "";
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    TempData["Success"] = "Password changed successfully";
                    return RedirectToAction("Login");
                   
                }
            }
            else
            {
                TempData["Error"] = "Someting invalid";
            }

            return View(model);
        }

    }
}
