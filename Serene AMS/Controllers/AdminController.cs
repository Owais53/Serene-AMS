using Serene_AMS.DAL.Classes;
using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
using Serene_AMS.Models;
using Serene_AMS.ViewModel;
using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
        public ActionResult GetSlList()
        {
            IProcure obj = new Procure();

            var Data = (from Sl in obj.GetSL()
                        select new
                        {
                           Sl.City,
                           Sl.StorageLocation,
                           Sl.SLId
                        }).ToList();


            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetitemtypeList()
        {
            IProcure obj = new Procure();

            var Data = (from type in obj.Getitemtype()
                        select new
                        {
                           type.ItemType,
                           type.Id
                        }).ToList();


            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetitemList()
        {
            IProcure obj = new Procure();

            var Data = (from item in obj.Getitems()
                        join type in obj.Getitemtype() on item.TypeId equals type.Id
                        select new
                        {
                           type.ItemType,
                           item.ItemName,
                           item.StorageLocation,
                           item.ItemPrice,
                           item.ItemId

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
            var check = obj.Getleave().Where(x => x.PositionId == model.PositionId).FirstOrDefault();
            var deplist = objstructureRepository.Getdep().ToList();
            if (check == null)
            {
               
                var add = obj.Addleavepos(model.PositionId, model.CasualLeave, model.SickLeave);
                obj.Addleave(add);
                obj.Save();


                SelectList list = new SelectList(deplist, "DepartmentId", "DepartmentName");
                ViewBag.getdeplist = list;


                TempData["SuccessMessage11"] = "Leaves Assigned to Position Sucessfully";
            }
            else
            {
                obj.Updateleave(model.PositionId,model.CasualLeave,model.SickLeave);
                obj.Save();

                SelectList list = new SelectList(deplist, "DepartmentId", "DepartmentName");
                ViewBag.getdeplist = list;

                TempData["SuccessMessage11"] = "Leaves Updated Sucessfully";

            }
            return View();
        }
        [HttpGet]
        public ActionResult DefineEmployeeLeaves()
        {
            return View();
        }
       
        public ActionResult EmpforleaveList()
        {
            
            IEmployeeRepository objemployeeRepository = new EmployeeRepository();  

            var Data = (from emp in objemployeeRepository.GetAll()
                        select new
                        {
                          emp.EmployeeId,
                          emp.EmployeeName,
                          emp.PositionId,
                          emp.Contact,
                          emp.Email

                        }).ToList();

            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetEmpforLeaves(int? Id)
        {

            IEmployeeRepository objemployeeRepository = new EmployeeRepository();

            var Data = (from emp in objemployeeRepository.GetAll()
                        select new
                        {
                            emp.EmployeeId,
                            emp.EmployeeName,
                            emp.PositionId,
                            emp.Contact,
                            emp.Email
                           

                        }).Where(x=>x.EmployeeId==Id)
                        .Select(c => new PositionVM()
                        {
                            EmployeeId=c.EmployeeId,
                            EmployeeName=c.EmployeeName,
                            PositionId=(int)c.PositionId,
                            Contact=c.Contact,
                            Email=c.Email
                            

                        }).FirstOrDefault();


            return PartialView("EmployeeLeavePartial", Data);

        }
        public ActionResult PostEmpLeave(PositionVM model)
        {
            IEmployeeRepository obj = new EmployeeRepository();

            var checkcasualleavelimit = obj.Getleave().Where(x => x.PositionId == model.PositionId && x.CasualLeave >= model.CasualLeave).FirstOrDefault();
            var checksickleavelimit = obj.Getleave().Where(x => x.PositionId == model.PositionId && x.SickLeave >= model.SickLeave).FirstOrDefault();

            if (checkcasualleavelimit != null && checksickleavelimit != null)
            {
                obj.updateleaveforemp(model.EmployeeId,model.CasualLeave,model.SickLeave);
                obj.Save();
                TempData["SuccessMessage1"] = "Leaves Assigned to Employee";
            }
            else
            {
                TempData["ErrorMessage1"] = "Cannot Assign Leaves to more than Defined in Position";
            }
           
            return Json(new {  success = true }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult CreateStorageLocation()
        {
            var cityname = new SelectList(new[]
              {

                new {ID="1",Name="Lahore"},
                new {ID="2",Name="Islamabad"},
                 new {ID="2",Name="Karachi"}
                },
                "Name", "Name", "1"
              );
            ViewBag.getcitylist = cityname;
            return View();
        }
        [HttpPost]
        public ActionResult CreateStorageLocation(ProcureVM model)
        {
            IProcure obj = new Procure();

            var checkduplicate = obj.GetSL().Where(x => x.City == model.City && x.StorageLocation == model.StorageLocation).FirstOrDefault();

            if (checkduplicate == null)
            {
                var add = obj.AddSL(model.City, model.StorageLocation);
                obj.AddStore(add);
                obj.Save();
                var cityname = new SelectList(new[]
                {

                new {ID="1",Name="Lahore"},
                new {ID="2",Name="Islamabad"},
                 new {ID="2",Name="Karachi"}
                },
                  "Name", "Name", "1"
                );
                ViewBag.getcitylist = cityname;
               
                TempData["SuccessMessage1"] = "Successfully Created";
                return RedirectToAction("ViewStorageLoaction", "Admin");
            }
            else
            {
                var cityname = new SelectList(new[]
               {
                new {ID="1",Name="Lahore"},
                new {ID="2",Name="Islamabad"},
                new {ID="2",Name="Karachi"}
                },
                "Name", "Name", "1"
               );
                ViewBag.getcitylist = cityname;
                TempData["ErrorMessage1"] = "Storage Location" + model.StorageLocation + " already exists in City " + model.City + "";
            }
            return View();
        }
        [HttpGet]
        public ActionResult CreateItemType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateItemType(ProcureVM model)
        {
            IProcure obj = new Procure();

            var check = obj.Getitemtype().Where(x=>x.ItemType == model.ItemType).FirstOrDefault();

            if(check == null)
            {
                var add = obj.AddItemtype(model.ItemType);
                obj.AddTypes(add);
                obj.Save();
                TempData["SuccessMessage1"] = "Successfully Created";
            }
            else
            {
                TempData["ErrorMessage1"] = "ItemType"+ model.ItemType +" already exists";
            }
            return View();
        }
        [HttpGet]
        public ActionResult CreateItems()
        {
            IProcure obj = new Procure();
            var ItemType = obj.Getitemtype().ToList();
            SelectList list = new SelectList(ItemType, "Id", "ItemType");
            ViewBag.getItemtypelist = list;

            var SL = obj.GetSL().ToList();
            SelectList lists = new SelectList(SL, "StorageLocation", "StorageLocation");
            ViewBag.getSLlist = lists;


            return View();
        }

        [HttpPost]
        public ActionResult CreateItems(ProcureVM model)
        {
            IProcure obj = new Procure();
            SetDocNumber doc = new SetDocNumber();
            var ItemType = obj.Getitemtype().ToList();
            var SL = obj.GetSL().ToList();
           
            var valide = obj.Getitems().Where(x => x.ItemName == model.ItemName).FirstOrDefault();
            var validatetype = obj.Getitems().Where(x => x.TypeId == model.TypeId && x.ItemName == model.ItemName).FirstOrDefault();
            if (valide == null && validatetype == null)
            {
                SelectList list = new SelectList(ItemType, "Id", "ItemType");
                ViewBag.getItemtypelist = list;

                SelectList lists = new SelectList(SL, "StorageLocation", "StorageLocation");
                ViewBag.getSLlist = lists;
                
                  var add = obj.Additem(model.TypeId, model.ItemName, model.StorageLocation, model.ReorderPoint, model.ItemPrice);              
                    obj.Additems(add);
                    obj.Save();
                    TempData["SuccessMessage1"] = "Successfully Created";
              
            }
            else
            {
                SelectList list = new SelectList(ItemType, "ItemType", "ItemType");
                ViewBag.getItemtypelist = list;

                SelectList lists = new SelectList(SL, "StorageLocation", "StorageLocation");
                ViewBag.getSLlist = lists;
                TempData["ErrorMessage1"] = "Item" + model.ItemName + " already exists in Item Type " + model.ItemType + "";
            }
            return View();
        }
        public ActionResult ViewStorageLocation()
        {
            var cityname = new SelectList(new[]
             {
                new {ID="1",Name="Lahore"},
                new {ID="2",Name="Islamabad"},
                new {ID="2",Name="Karachi"}
                },
              "Name", "Name", "1"
             );
            ViewBag.getcitylist = cityname;
            return View();
        }
        public ActionResult ViewItemTypes()
        {
            return View();
        }
        public ActionResult ViewItems()
        {
            IProcure obj = new Procure();
            var ItemType = obj.Getitemtype().ToList();
            var SL = obj.GetSL().ToList();
            SelectList list = new SelectList(ItemType, "ItemType", "ItemType");
            ViewBag.getItemtypelist = list;

            SelectList lists = new SelectList(SL, "StorageLocation", "StorageLocation");
            ViewBag.getSLlist = lists;

            return View();
        }
        public ActionResult GetSLforEdit(int? id)
        {
            IProcure obj = new Procure();
            var ap = (from d in obj.GetSL()                     
                      where d.SLId == id
                      select new
                      {

                          d.SLId,
                          d.City,
                          d.StorageLocation
                        
                      }).Select(c => new ProcureVM()
                      {
                         SlId=c.SLId,
                         StorageLocation=c.StorageLocation



                      }).FirstOrDefault();

            var cityname = new SelectList(new[]
             {
                new {ID="1",Name="Lahore"},
                new {ID="2",Name="Islamabad"},
                new {ID="2",Name="Karachi"}
                },
              "Name", "Name", "1"
             );
            ViewBag.getcitylist = cityname;

            return PartialView("EditStorageLocationPartial", ap);
        }
        public ActionResult EditSL(ProcureVM model)
        {
            IProcure obj = new Procure();

            var cityname = new SelectList(new[]
             {
                new {ID="1",Name="Lahore"},
                new {ID="2",Name="Islamabad"},
                new {ID="2",Name="Karachi"}
                },
              "Name", "Name", "1"
             );
            ViewBag.getcitylist = cityname;
                obj.UpdateSL(model.SlId,model.City,model.StorageLocation);
                obj.Save();
                TempData["SuccessMessage1"] = "Successfully Updated";

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetItemTypes(int? id)
        {
            IProcure obj = new Procure();
            var ap = (from d in obj.Getitemtype()
                      where d.Id == id
                      select new
                      {
                         d.Id,
                         d.ItemType

                      }).Select(c => new ProcureVM()
                      {
                          Id = c.Id,
                          ItemType=c.ItemType



                      }).FirstOrDefault();

           
            return PartialView("EditItemTypePartial", ap);
        }
        public ActionResult GetDoctypeList()
        {
            IProcure obj = new Procure();
            var Data = (from d in obj.GetDoctypes()
                      select new
                      {
                          d.TypeId,
                          d.DocumentType,
                          d.DocumentName,
                          d.NumberRangefrom,
                          d.NumberRangeTo



                      }).ToList();

            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult EditItemType(ProcureVM model)
        {
            IProcure obj = new Procure();

           
            obj.UpdateItemType(model.Id, model.ItemType);
            obj.Save();
            TempData["SuccessMessage1"] = "Successfully Updated";

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetItems(int? id)
        {
            IProcure obj = new Procure();
            var ap = (from d in obj.Getitems()
                      where d.ItemId == id
                      select new
                      {
                          d.ItemId,
                          d.ItemName,
                          d.ItemPrice,
                          d.StorageLocation,
                          d.ReorderPoint

                      }).Select(c => new ProcureVM()
                      {
                         ItemId=c.ItemId,
                         ItemName=c.ItemName,
                         ItemPrice=(decimal)c.ItemPrice,
                         StorageLocation=c.StorageLocation,
                         ReorderPoint=(int)c.ReorderPoint


                      }).FirstOrDefault();
            var ItemType = obj.Getitemtype().ToList();
            var SL = obj.GetSL().ToList();
            SelectList list = new SelectList(ItemType, "Id", "ItemType");
            ViewBag.getItemtypelist = list;

            SelectList lists = new SelectList(SL, "StorageLocation", "StorageLocation");
            ViewBag.getSLlist = lists;


            return PartialView("EditItemsPartial", ap);
        }
        public ActionResult EditItems(ProcureVM model)
        {
            IProcure obj = new Procure();
            var ItemType = obj.Getitemtype().ToList();
            var SL = obj.GetSL().ToList();
            SelectList list = new SelectList(ItemType, "Id", "ItemType");
            ViewBag.getItemtypelist = list;

            SelectList lists = new SelectList(SL, "StorageLocation", "StorageLocation");
            ViewBag.getSLlist = lists;


            obj.UpdateItem(model.ItemId,model.ItemName,model.TypeId,model.StorageLocation,model.ItemPrice,model.ReorderPoint);
            obj.Save();
            TempData["SuccessMessage1"] = "Successfully Updated";

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetDocumentNumberRanges()
        {
            return View();
        }
        public ActionResult GetDocTypes(int? id)
        {
            IProcure obj = new Procure();
            var ap = (from d in obj.GetDoctypes()
                      where d.TypeId == id
                      select new
                      {
                          d.TypeId,
                          d.DocumentType,
                          d.DocumentName,
                          d.NumberRangefrom,
                          d.NumberRangeTo

                      }).Select(c => new ProcureVM()
                      {
                          TypeId=c.TypeId,
                          DocType=c.DocumentType,
                          Docnumberfrom=(int)c.NumberRangefrom,
                          DocnumberTo=(int)c.NumberRangeTo

                      }).FirstOrDefault();
          

            return PartialView("SetDocRangePartial", ap);
        }
        public ActionResult SetDocRange(ProcureVM model)
        {
            IProcure obj = new Procure();
           
            var checkrangeduplicate = obj.GetDoctypes().Where(x => x.DocumentType == "PR").Where(b=>b.NumberRangefrom==model.Docnumberfrom || b.NumberRangeTo==model.DocnumberTo).FirstOrDefault();
            var checkrangeduplicate1 = obj.GetDoctypes().Where(x => x.DocumentType == "PO").Where(b => b.NumberRangefrom == model.Docnumberfrom || b.NumberRangeTo == model.DocnumberTo).FirstOrDefault();

            if (checkrangeduplicate == null || checkrangeduplicate1== null)
            {
                obj.UpdateDocType(model.TypeId, model.Docnumberfrom, model.DocnumberTo);
                obj.Save();
                TempData["UpdateMessage3"] = "Successfully Updated";
            }
            else 
            {
                TempData["ErrorMessage1"] = "Document Number Range matches other Document Number Range";
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
       
        [HttpGet]
        public ActionResult CreateVendors()
        {
            IProcure obj = new Procure();
            var ItemType = obj.Getitemtype().ToList();
            var vendortype = new SelectList(new[]
             {

                new {ID="1",Name="Local"},
                new {ID="2",Name="Foreign"}

                },
                 "Name", "Name", "1"
             );
            ViewBag.getVendortypelist = vendortype;
            SelectList list = new SelectList(ItemType, "Id", "ItemType");
            ViewBag.getItemtypelist = list;

            IEnumerable<ProcureVM> listofItems =
                (from items in obj.Getitems()
                 select new ProcureVM()
                 {
                     ItemId=items.ItemId,
                     ItemName=items.ItemName
                 }).ToList();
            ViewBag.Getitem = listofItems;

            return View();
        }

        [HttpPost]
        public ActionResult CreateVendors(ProcureVM model)
        {
            IProcure obj = new Procure();
            var ItemType = obj.Getitemtype().ToList();
            var vendortype = new SelectList(new[]
             {

                new {ID="1",Name="Local"},
                new {ID="2",Name="Foreign"}

                },
                 "Name", "Name", "1"
             );
            ViewBag.getVendortypelist = vendortype;
            SelectList list = new SelectList(ItemType, "Id", "ItemType");
            ViewBag.getItemtypelist = list;

            IEnumerable<ProcureVM> listofItems =
                (from items in obj.Getitems()
                 select new ProcureVM()
                 {
                     ItemId = items.ItemId,
                     ItemName = items.ItemName
                 }).ToList();
            ViewBag.Getitem = listofItems;
           var add= obj.addvendor(model.VendorName,model.Contact,model.TypeId,model.Address,model.VendorType);
            obj.Addvendors(add);
            obj.Save();
            TempData["SuccessMessage1"] = "Successfully Created";
        
            return View();
        }


    }
}