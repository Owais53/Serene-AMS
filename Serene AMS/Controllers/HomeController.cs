using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
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
    public class HomeController : Controller
    {
        IProcure obj = new Procure();
        public ActionResult Index()
        {
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
        public ActionResult GetLineChartData()
        {
            HrmsEntities context = new HrmsEntities();
            var list = context.tblExpenses.Include("Month").GroupBy(p => p.Month).Select(g => new { month = g.Key, total = g.Sum(w => w.Amount) }).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
            
        } 

    }
}