using Serene_AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

    }
}