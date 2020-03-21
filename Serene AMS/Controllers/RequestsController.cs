using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serene_AMS.Controllers
{
    public class RequestsController : Controller
    {
        [HttpGet]
        public ActionResult RequestTransfer()
        {

            IStructuredetailRepository objstructureRepository = new StructuredetailRepository();
            var poslist = objstructureRepository.Getpos().ToList();
            var city = Session["CityName"].ToString();
            SelectList list = new SelectList(poslist, "Id", "Position");
            ViewBag.getposlist = list;
            if (city == "Karachi")
            {
                var cityname = new SelectList(new[]
               {

                new {ID="1",Name="Lahore"},
                new {ID="2",Name="Islamabad"}

                },
                   "Name", "Name", "1"
               );
                ViewBag.CitytoTransfer = cityname;

            }
            else if(city == "Lahore")
            {
                var cityname = new SelectList(new[]
              {

                new {ID="1",Name="Karachi"},
                new {ID="2",Name="Islamabad"}

                },
                  "Name", "Name", "1"
              );
                
                ViewBag.CitytoTransfer = cityname;

            }
            else if(city == "Islamabad")
            {
                var cityname = new SelectList(new[]
             {

                new {ID="1",Name="Karachi"},
                new {ID="2",Name="Lahore"}

                },
                 "Name", "Name", "1"
             );
                ViewBag.CitytoTransfer = cityname;

            }
            var CurrentPosition = Session["Position"].ToString();
            
            ViewBag.currentpos = CurrentPosition;

            return View();
        }
        [HttpPost]
        public ActionResult RequestTransfer(RequestVM model)
        {
            IStructuredetailRepository obj = new StructuredetailRepository();
            var poslist = obj.Getpos().ToList();
            var city = Session["CityName"].ToString();
            var empid = Session["EmployeeId"].ToString();
            var role = Session["RoleName"].ToString();
            var checkempid= obj.GetReq().Where(x=>x.EmployeeId == Convert.ToInt32(empid)).FirstOrDefault();

           

           
                SelectList list = new SelectList(poslist, "Id", "Position");
                ViewBag.getposlist = list;
                if (city == "Karachi")
                {
                    var cityname = new SelectList(new[]
                   {

                         new {ID="1",Name="Lahore"},
                         new {ID="2",Name="Islamabad"}

                        },
                       "Name", "Name", "1"
                   );
                    ViewBag.CitytoTransfer = cityname;

                }
                else if (city == "Lahore")
                {
                    var cityname1 = new SelectList(new[]
                  {

                        new {ID="1",Name="Karachi"},
                        new {ID="2",Name="Islamabad"}

                     },
                      "Name", "Name", "1"
                  );

                    ViewBag.CitytoTransfer = cityname1;

                }
                else if (city == "Islamabad")
                {
                    var cityname2 = new SelectList(new[]
                 {

                       new {ID="1",Name="Karachi"},
                       new {ID="2",Name="Lahore"}

                      },
                     "Name", "Name", "1"
                 );
                    ViewBag.CitytoTransfer = cityname2;

                }


                if (role != "DGM")
                {                   


                    var add = obj.Addreqt(Convert.ToInt32(empid), model.positionid, model.CitytoTransfer, model.ReasonofRequest);
                    obj.AddReq(add);
                    obj.Save();
                    TempData["SuccessMessage101"] = "Successfully Submitted";
                }
                else
                {                  


                    var add = obj.Addreqtfordgm(Convert.ToInt32(empid), model.positionid, model.CitytoTransfer, model.ReasonofRequest);
                    obj.AddReq(add);
                    obj.Save();
                    TempData["SuccessMessage101"] = "Successfully Submitted";
                }
            
            return View();
        }
        [HttpGet]
        public ActionResult TransferResponse(int? id)
        {
            IStructuredetailRepository repo = new StructuredetailRepository();
            IDepartmentRepository deprepo = new DepartmentRepository();
            IEmployeeRepository emprepo = new EmployeeRepository();

            var Data = (from req in repo.GetReq()
                        join emp in emprepo.GetAll() on req.EmployeeId equals emp.EmployeeId
                        join pos in repo.Getpos() on req.PositionId equals pos.Id
                        join cupos in repo.Getpos() on emp.PositionId equals cupos.Id
                        join dep in deprepo.GetAll() on emp.DepartmentId equals dep.DepartmentId
                        where req.RequestId == id
                        select new RequestVM
                        {
                            EmployeeId=(int)req.EmployeeId,
                            EmployeeName = emp.EmployeeName,
                            CityName = emp.CityName,
                            DateofRequest = (DateTime)req.DateofRequest,
                            RequestId = req.RequestId,
                            Position = cupos.Position,
                            DepartmentName = dep.DepartmentName,
                            PositiontoTransfer = pos.Position,
                            positionid = (int)req.PositionId,
                            CitytoTransfer = req.CitytoTranser,
                            ReasonofRequest = req.ReasonofRequest


                        }).FirstOrDefault();

            return View(Data);
        }
        [HttpPost]
        public ActionResult TransferResponse(RequestVM model)
        {

            var empname = Session["Employeename"].ToString();
            IStructuredetailRepository obj = new StructuredetailRepository();
            obj.updatetransapp(model.EmployeeId,model.CitytoTransfer,model.positionid);
            obj.Save();

            obj.updatereqt(model.RequestId,empname,model.ResponseReason);
            obj.Save();
            TempData["SuccessMessage101"] = "Successfully Approved";

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult TransferResponseReject(RequestVM model)
        {

            var empname = Session["Employeename"].ToString();
            IStructuredetailRepository obj = new StructuredetailRepository();
          
            obj.updatereqtrej(model.RequestId, empname,model.ResponseReasonrej);
            obj.Save();
            TempData["SuccessMessage101"] = "Rejected";

            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public ActionResult ViewTransferResponse(int? id)
        {
            IStructuredetailRepository repo = new StructuredetailRepository();
            IDepartmentRepository deprepo = new DepartmentRepository();
            IEmployeeRepository emprepo = new EmployeeRepository();

            var Data = (from req in repo.GetReq()
                        join emp in emprepo.GetAll() on req.EmployeeId equals emp.EmployeeId
                        join pos in repo.Getpos() on req.PositionId equals pos.Id
                        join cupos in repo.Getpos() on emp.PositionId equals cupos.Id
                        join dep in deprepo.GetAll() on emp.DepartmentId equals dep.DepartmentId
                        where req.RequestId == id
                        select new RequestVM
                        {
                            EmployeeId = (int)req.EmployeeId,
                            EmployeeName = emp.EmployeeName,
                            CityName = emp.CityName,
                            DateofRequest = (DateTime)req.DateofRequest,
                            RequestId = req.RequestId,
                            Position = cupos.Position,
                            DepartmentName = dep.DepartmentName,
                            PositiontoTransfer = pos.Position,
                            positionid = (int)req.PositionId,
                            CitytoTransfer = req.CitytoTranser,
                            ReasonofRequest = req.ReasonofRequest,
                            Status=req.Status,
                            ResponseReason=req.ResponseReason


                        }).FirstOrDefault();

            return View(Data);
        }
        [HttpGet]
        public ActionResult LeaveRequest()
        {
            IEmployeeRepository obj = new EmployeeRepository();
            var leavelist = new SelectList(new[]
            {
                new {ID="1",Name="Casual Leave"},
                new {ID="2",Name="Sick Leave"}
               
            },
          "Name", "Name", "1"
           );
            ViewBag.getleavelist = leavelist;
            

            return View();
        }
        [HttpPost]
        public ActionResult LeaveRequest(RequestVM model)
        {
            IEmployeeRepository obj = new EmployeeRepository();
            IStructuredetailRepository repo = new StructuredetailRepository();
            var empid = Session["EmployeeId"].ToString();
            var posid = Session["Position"].ToString();
            var Duplicatereq = repo.GetReq().Where(a => a.EmployeeId == Convert.ToInt32(empid)).Where(x => x.RequestType =="Leave" && x.IsSeen == false).FirstOrDefault();
            var CasualLeavesLeft = obj.GetEmpLeaves().Where(x => x.EmployeeId == Convert.ToInt32(empid) && x.CasualLeave == 0).FirstOrDefault();
            var SickLeavesLeft = obj.GetEmpLeaves().Where(x => x.EmployeeId == Convert.ToInt32(empid) && x.SickLeave == 0).FirstOrDefault();
            if (model.ToDate < model.FromDate)
            {
                TempData["SuccessMessage101"] = "From Date Should not be greater or equal than To Date";
                
                var leavelist = new SelectList(new[]
               {
                new {ID="1",Name="Casual Leave"},
                new {ID="2",Name="Sick Leave"}

            },
             "Name", "Name", "1"
              );
                ViewBag.getleavelist = leavelist;

            
            }
            else 
            {
                if (Duplicatereq != null)
                {
                    TempData["SuccessMessage101"] = "You have already Submitted Leave Request";
                    var leavelist = new SelectList(new[]
                   {
                    new {ID="1",Name="Casual Leave"},
                    new {ID="2",Name="Sick Leave"}

                 },
                 "Name", "Name", "1"
                  );
                    ViewBag.getleavelist = leavelist;
                }
                else
                {
                    if (CasualLeavesLeft == null && model.Leavetype == "Casual Leave")
                    {
                        obj.updatecasualleaveleft(Convert.ToInt32(empid));
                        obj.Save();

                        var add = obj.AddReql(Convert.ToInt32(empid), Convert.ToInt32(posid), model.FromDate, model.ToDate, model.ReasonofRequest);
                        obj.AddLeaveReq(add);
                        obj.Save();

                        var leavelist = new SelectList(new[]
                        {
                    new {ID="1",Name="Casual Leave"},
                    new {ID="2",Name="Sick Leave"}

                   },
                       "Name", "Name", "1"
                       );
                        ViewBag.getleavelist = leavelist;
                        TempData["SuccessMessage102"] = "Success";
                    }
                    else if(model.Leavetype=="Casual Leave")
                    {
                        TempData["SuccessMessage101"] = "You do not have Casual Leave Left";
                        var leavelist = new SelectList(new[]
                       {
                    new {ID="1",Name="Casual Leave"},
                    new {ID="2",Name="Sick Leave"}

                   },
                      "Name", "Name", "1"
                      );
                        ViewBag.getleavelist = leavelist;
                    }
                    if (SickLeavesLeft == null && model.Leavetype == "Sick Leave")
                    {
                        obj.updatesickleaveleft(Convert.ToInt32(empid));
                        obj.Save();
                        var add = obj.AddReql(Convert.ToInt32(empid), Convert.ToInt32(posid), model.FromDate, model.ToDate, model.ReasonofRequest);
                        obj.AddLeaveReq(add);
                        obj.Save();

                        var leavelist = new SelectList(new[]
                        {
                    new {ID="1",Name="Casual Leave"},
                    new {ID="2",Name="Sick Leave"}

                   },
                       "Name", "Name", "1"
                       );
                        ViewBag.getleavelist = leavelist;
                        TempData["SuccessMessage102"] = "Success";
                    }
                    else if(model.Leavetype=="Sick Leave")
                    {
                        TempData["SuccessMessage101"] = "You do not have Sick Leave Left";
                        var leavelist = new SelectList(new[]
                       {
                    new {ID="1",Name="Casual Leave"},
                    new {ID="2",Name="Sick Leave"}

                   },
                      "Name", "Name", "1"
                      );
                        ViewBag.getleavelist = leavelist;
                    }
                                       
                  
                  }
                }


            return View();
        }

    }
}