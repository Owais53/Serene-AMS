using Serene_AMS.DAL.Classes;
using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serene_AMS.Controllers
{
    public class ReportsController : Controller
    {
        
        public ActionResult StockReport()
        {
            return View();
        }
        public JsonResult GetStockList()
        {
            IProcure obj = new Procure();
            var Data = (from i in obj.Getitems()                        
                        select new
                        {
                           i.ItemName,
                           i.Availablestock,
                           i.Qualityinspectionstock

                        }).ToList();

            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ReturnReport(int? id)
        {
            IProcure obj = new Procure();
            var data = (from doc in obj.GetDoc()
                        join v in obj.GetVendor() on doc.VendorId equals v.VendorId
                        where doc.DocumentNo == id
                        select new
                        {
                            doc.DocumentNo,
                            doc.Docno,
                            doc.CreationDate,
                            doc.CreatedBy,
                            doc.Reasonofreturn,
                            v.VendorName

                        }).Select(x => new ProcureVM()
                        {
                            Grno = x.Docno,
                            Createdon = (DateTime)x.CreationDate,
                            Createdby = x.CreatedBy,
                            VendorName = x.VendorName,
                            Reasonofreturn=x.Reasonofreturn,
                            IRDetails = GetReturnDetails(id)
                        }).FirstOrDefault();

            Report _report = new Report();
            byte[] abytes = _report.PrepareReturnReport(data);
            return File(abytes, "application/pdf");
        }
        public List<ProcureVM> GetReturnDetails(int? id)
        {
            ReqList li = new ReqList();
            DataSet ds = li.Show_returniteminreport(id);
            List<ProcureVM> procure = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                procure.Add(new ProcureVM
                {
                    ItemName = dr["ItemName"].ToString(),
                    DeliveredQuantity = Convert.ToInt32(dr["DeliveredQuantity"]),
                    RejectedQuantity = Convert.ToInt32(dr["RejectedQuantity"])
                });
            }
            return procure;

        }
    
   }
}