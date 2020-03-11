using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
using Serene_AMS.Models;
using Serene_AMS.ViewModel;
using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serene_AMS.Controllers
{
    public class AdminController : Controller
    {
        public HrmsEntities db = new HrmsEntities();

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

        [HttpGet]
        public ActionResult Position()
        {
            IStructuredetailRepository objstructureRepository = new StructuredetailRepository();
            var deplist = objstructureRepository.Getdep().ToList();

            SelectList list = new SelectList(deplist, "DepartmentId", "DepartmentName");
            ViewBag.getdeplist = list;

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
            return View();
        }
        [HttpPost]
        public ActionResult Position(PositionVM obj,FormCollection form)
        {
            IStructuredetailRepository objstructureRepository = new StructuredetailRepository();
            var deplist = objstructureRepository.Getdep().ToList();
            var depname = form["txtname"];
           
            var check = objstructureRepository.validation(depname).FirstOrDefault();
            var check1 = objstructureRepository.validation1(obj.Position).FirstOrDefault();
            var check3 = objstructureRepository.validation2(obj.JobLevel).FirstOrDefault();

            if (check !=null && check1 != null && check3 != null || check3 == null && check1 != null)
            {
                SelectList list = new SelectList(deplist, "DepartmentId", "DepartmentName");
                ViewBag.getdeplist = list;
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

                TempData["ErrorMessage9"] = "Position " + obj.Position + " Already Exists";
            }
            else
            {
              
                    SelectList list = new SelectList(deplist, "DepartmentId", "DepartmentName");
                    ViewBag.getdeplist = list;
                    var levellist = new SelectList(new[]
                    {
                new {ID="1",Name="Low"},
                new {ID="2",Name="Medium"},
                new {ID="3",Name="High"}
                },
                    "Name", "Name", "1"
                    );
                    ViewBag.getlevellist = levellist;


                    var add = objstructureRepository.Addpos(Convert.ToInt32(obj.DepartmentId), obj.JobLevel, obj.Position, Convert.ToDecimal(obj.BasicPay), Convert.ToDecimal(obj.IncomeTax),obj.Experience);
                    objstructureRepository.Add(add);
                    objstructureRepository.Save();

                    TempData["SuccessMessage9"] = "Position Created Sucessfully";
                    return RedirectToAction("ViewPosition", "Admin");
                  
            }
           
            return View();
        }
        public ActionResult ViewPosition()
        {
            return View();
        }
        public ActionResult GetPosList()
        {
            IDepartmentRepository objdepartmentRepository = new DepartmentRepository();
            IStructuredetailRepository objstructrepo = new StructuredetailRepository();


            var Data = (from pos in objstructrepo.Getpos()                       
                        join dep in objdepartmentRepository.GetAll() on pos.DepartmentId equals dep.DepartmentId
                        select new
                        {
                            
                           
                            dep.DepartmentName,
                            pos.JobLevel,
                            pos.Position,
                            pos.Id

                        }).ToList();

            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult LeavesonPosition()
        {
            IStructuredetailRepository objstructureRepository = new StructuredetailRepository();
            var deplist = objstructureRepository.Getdep().ToList();

            SelectList list = new SelectList(deplist, "DepartmentId", "DepartmentName");
            ViewBag.getdeplist = list;

            return View();
        }
        [HttpPost]
        public ActionResult LeavesonPosition(PositionVM model)
        {
            IStructuredetailRepository objstructureRepository = new StructuredetailRepository();
            IEmployeeRepository obj = new EmployeeRepository();
            var deplist = objstructureRepository.Getdep().ToList();

            var add=obj.Addleavepos(model.PositionId,model.CasualLeave,model.SickLeave);
            obj.Addleave(add);
            obj.Save();


            SelectList list = new SelectList(deplist, "DepartmentId", "DepartmentName");
            ViewBag.getdeplist = list;


            TempData["SuccessMessage11"] = "Leaves Assigned to Position Sucessfully";
            return View();
        }

    }
}