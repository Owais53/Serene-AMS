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
                            join s in db.tblStructuredetails on e.Id equals s.Id
                            where u.UserName == model.UserName && u.Password == model.Password
                            select new
                            {
                                u.UserName,
                                u.UserId,
                                d.DepartmentName,
                                a.desc,
                                r.RoleName,
                                e.CompanyCode,
                                s.CompanyName,
                                e.CityCode,
                                s.CityName,
                                e.EmployeeName,
                                e.PositionId,
                                d.DepartmentId,
                                e.EmployeeId

                            }).FirstOrDefault();



                if (user != null)
                {
                    Session["UserName"] = user.UserName;
                    Session["UserId"] = user.UserId;
                    Session["DepartmentName"] = user.DepartmentName;
                    Session["RoleName"] = user.RoleName;
                    Session["isAdmin"] = user.desc;
                    Session["CompanyName"] = user.CompanyName;
                    Session["CityName"] = user.CityName;
                    Session["CompanyCode"] = user.CompanyCode;
                    Session["CityCode"] = user.CityCode;
                    Session["Employeename"] = user.EmployeeName;
                    Session["Position"] = user.PositionId;
                    Session["DepartmentId"] = user.DepartmentId;
                    Session["EmployeeId"] = user.EmployeeId;

                    
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewBag.Text = "Invalid UserName or Password";
;                   

                }
            }
            else
            {
                ViewBag.Text = "User is not Active.Please Login Again.";
            }

            return View();
        }
    }
}