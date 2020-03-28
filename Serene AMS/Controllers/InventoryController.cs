using Serene_AMS.DAL.Classes;
using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
using Serene_AMS.Models;
using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serene_AMS.Controllers
{
    public class InventoryController : Controller
    {
        InsertmultipleitemPR db = new InsertmultipleitemPR();
        public ActionResult CreatePurchaseRequest()
        {
            return View();
        }
        public ActionResult GetItemsList()
        {
            IProcure repo = new Procure();

            var Data = (from u in repo.Getitems()
                        join type in repo.Getitemtype() on u.TypeId equals type.Id
                        select new
                        {

                           u.ItemId,
                           u.ItemName,
                           type.ItemType,
                           u.StorageLocation,
                           u.ItemPrice
                           


                        }).ToList();

            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemtypebyId(int? Id)
        {
            HrmsEntities db = new HrmsEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.tblItems.Where(p => p.TypeId == Id).Select(x => new { x.TypeId, x.ItemName}), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemTypetoremove(int? Id)
        {
            HrmsEntities db = new HrmsEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.tblItems.Where(p => p.TypeId != Id).Select(x => new { x.TypeId, x.ItemName }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemName(int? id)
        {
            IProcure obj = new Procure();

            var list = (from items in obj.Getitems()
                        where items.ItemId==id
                        select new
                        {
                           
                            items.ItemName

                        }).ToList();


            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreatePurchaseRequest(ProcureVM model)
        {
            IProcure obj = new Procure();
           
            string[] Itemcount = model.ItemsID.ToString().Split(',');
            model.requestedMaterialArray = new int[Itemcount.Length];
            for (int i = 0; i < Itemcount.Length; i++)
            {              
               model.requestedMaterialArray[i]= Convert.ToInt32(Itemcount[i]);
            }
            bool flag=db.savePR(model);
            if (flag)
            {
               
                return View();
            }
            else
            {
               
                return View();
            }
           
        }
        public ActionResult SelectItemsQuantityforPR()
        {
            return View();
        }
    }
}