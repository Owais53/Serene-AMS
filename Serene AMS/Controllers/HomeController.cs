using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
using Serene_AMS.Models;
using Serene_AMS.ViewModel;
using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serene_AMS.Controllers
{
    public class HomeController : Controller
    {
        IProcure obj = new Procure();
        HrmsEntities context = new HrmsEntities();
        public ActionResult Index()
        {
            var list = context.tblExpenses.Include("Year").GroupBy(p => p.Year).Select(g => new { year = g.Key }).ToList();
            SelectList year = new SelectList(list, "year", "year");
            ViewBag.getyearlist = year;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();

        }
        public ActionResult UnAuthorized()
        {
            
            return View();
        }
        public ActionResult GetLineChartData(int? y)
        {
           
                ReqList r = new ReqList();
                DataSet ds = r.Get_Months(y);
                List<PoVM> list = new List<PoVM>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new PoVM
                    {
                        month=DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(Convert.ToInt32(dr["month"])),
                        total=Convert.ToDecimal(dr["Total"])
                    });
                }
                return Json(list, JsonRequestBehavior.AllowGet);
           
            
        }
        public ActionResult GetBarChartData()
        {

            ReqList r = new ReqList();
            DataSet ds = r.Get_TotalStock();
            List<PoVM> list = new List<PoVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new PoVM
                {
                     ItemName=dr["ItemName"].ToString(),
                     AvailableStock=Convert.ToInt32(dr["Availablestock"]),
                     QualityStock=Convert.ToInt32(dr["Qualityinspectionstock"]),
                     ReorderPoint=Convert.ToInt32(dr["ReorderPoint"])
                });
            }
            return Json(list, JsonRequestBehavior.AllowGet);


        }
        public JsonResult Getddlyear()
        {
            context.Configuration.ProxyCreationEnabled = false;
            
            return Json( JsonRequestBehavior.AllowGet);
        }
    }
}