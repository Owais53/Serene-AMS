using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
using Serene_AMS.Infrastructure;
using Serene_AMS.Models;
using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                    RequestId= Convert.ToInt32(dr["RequestId"]),
                    EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                    EmployeeName=dr["EmployeeName"].ToString(),
                    DateofRequest=Convert.ToDateTime(dr["DateofRequest"]),
                    RequestType= dr["RequestType"].ToString(),
                    Position=dr["Position"].ToString()
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
                    Status=dr["Status"].ToString()
                });
            }
            return Json(listreq, JsonRequestBehavior.AllowGet);
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

    }
}