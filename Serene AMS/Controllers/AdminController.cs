using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
using Serene_AMS.Models;
using Serene_AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serene_AMS.Controllers
{
    public class AdminController : Controller
    {
        public SqlEntities db = new SqlEntities();

        [HttpGet]
        public ActionResult CreateUsers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUsers(EmployeeUserVM viewmodel)
        {
            IUserRepository objuserRepository = new UserRepository();
            IEmployeeRepository objemployeeRepository = new EmployeeRepository();
           

            var empid = objuserRepository.GetAll().Where(x => x.EmployeeId == viewmodel.EmployeeId).FirstOrDefault();
            var check = objuserRepository.GetAll().Where(a => a.UserName == viewmodel.UserName).FirstOrDefault();

           

             if (empid == null)
            {
                

                if (check == null && empid == null)
                {

                  var users =  objuserRepository.AddUser(viewmodel.UserName,viewmodel.Password,viewmodel.EmployeeId,viewmodel.DepartmentId);
                   objuserRepository.Add(users);
                    objuserRepository.Save();

                    if (users != null)
                    {
                        objemployeeRepository.Update(viewmodel.EmployeeId, users.UserId);
                        objemployeeRepository.Save();
                        TempData["SuccessMessage1"] = "User Created";
                    }

                }
                else 
                {
                    TempData["ErrorMessage1"] = "User with Name " + viewmodel.UserName + " already Exists";
                }
            }
            else if(empid != null)
            {
                TempData["ErrorMessage1"] = "User Already Exists with Name " + viewmodel.UserName + " or You have not selected from Employee List to Create Users";
            }
            else if (check != null && empid == null)
            {
                TempData["ErrorMessage1"] = "User with Name " + viewmodel.UserName + " already Exists";
            }


            return View();
            
        }
        public ActionResult GetEmployeeList()
        {
            IEmployeeRepository objemployeeRepository = new EmployeeRepository();
            IDepartmentRepository objdepartmentRepository = new DepartmentRepository();


            var Data = (from emp in objemployeeRepository.GetAll()
                        join dep in objdepartmentRepository.GetAll() on emp.DepartmentId equals dep.DepartmentId
                        where emp.UserId == null
                        select new
                        {
                            emp.EmployeeId,
                            emp.EmployeeName,
                            emp.DepartmentId,
                            dep.DepartmentName
                        }).ToList();


            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Assignroles()
        {
            IStructuredetailRepository objstructureRepository = new StructuredetailRepository();
            
            var rolelist = objstructureRepository.Getroles().ToList();

            SelectList list = new SelectList(rolelist, "Id", "RoleName");
            ViewBag.getrolelist = list;

            return View();
        }
        [HttpPost]
        public ActionResult Assignroles(EmployeeUserVM user, FormCollection form)
        {
            IStructuredetailRepository objstructureRepository = new StructuredetailRepository();
            IUserRepository objuserRepository = new UserRepository();


            var usercheck = objuserRepository.GetAll().Where(a => a.UserId == user.UserId).FirstOrDefault();
            if (usercheck != null)
            {
                var chkadmin = form["getadmin"];
                var adminId = Convert.ToInt32(chkadmin);

                objuserRepository.Update(user.RoleId,adminId,user.UserId);
                objuserRepository.Save();
                
                  if (chkadmin == null)
                    {
                        chkadmin = "0";
                    }
                 TempData["SuccessMessage1"] = "Role Assigned";        

                var rolelist = objstructureRepository.Getroles().ToList();
                SelectList list = new SelectList(rolelist, "Id", "RoleName");
                ViewBag.getrolelist = list;
            }
            else
            {
                var rolelist = objstructureRepository.Getroles().ToList();
                SelectList list = new SelectList(rolelist, "Id", "RoleName");
                ViewBag.getrolelist = list;

                TempData["ErrorMessage1"] = "Select from User List";

            }

            return View();
        }
        public ActionResult UserforroleList()
        {
            IUserRepository objuserRepository = new UserRepository();
            IEmployeeRepository objemployeeRepository = new EmployeeRepository();
            IDepartmentRepository objdepartmentRepository = new DepartmentRepository();

            var Data = (from user in objuserRepository.GetAll()
                        join emp in objemployeeRepository.GetAll() on user.EmployeeId equals emp.EmployeeId
                        join pos in objemployeeRepository.Getpos() on emp.PositionId equals pos.Id
                        join dep in objdepartmentRepository.GetAll() on user.DepartmentId equals dep.DepartmentId
                        where emp.UserId != null
                        select new
                        {
                            user.UserId,
                            user.UserName,
                            pos.Position,
                            dep.DepartmentName

                        }).ToList();

            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }

    }
}