﻿using Serene_AMS.DAL.Classes;
using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
using Serene_AMS.Models;
using Serene_AMS.ViewModels;
using System.Linq;
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
            model.requestedMaterialArray = new string[Itemcount.Length];
            for (int i = 0; i < Itemcount.Length; i++)
            {              
               model.requestedMaterialArray[i]= Itemcount[i];
            }
            bool flag=db.savePR(model);
            if (flag)
            {
                var DocNo = obj.GetDoc().Select(x => new ProcureVM { DocNo = x.DocumentNo }).LastOrDefault();
                TempData["UpdateMessage3"] = "Success";                
                return View("SelectItemsQuantityforPR", DocNo);
            }
            else
            {
             
                return View("SelectItemsQuantityforPR");
            }
          
        }
        public ActionResult SelectItemsQuantityforPR()
        {
            IProcure obj = new Procure();
            var DocNo = obj.GetDoc().Select(x => new ProcureVM { DocNo = x.DocumentNo }).LastOrDefault();

            return View(DocNo);
        }
        public ActionResult GetPRItemsList(int DocNo)
        {
            IProcure repo = new Procure();

            var Data = (from u in repo.GetDocDetail()
                        where u.DocumentNo==DocNo
                        select new
                        {

                           u.DocumentNo,
                           u.ItemId,
                           u.Quantity,
                           u.TotalPrice,
                           u.Id

                        }).ToList();

            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetItemforqty(int? id)
        {
            IProcure obj = new Procure();

            var result = (from d in obj.GetDocDetail()
                          where d.Id == id
                          select new
                          {
                              d.Id,
                              d.ItemId,
                              d.Quantity

                          }).Select(c => new ProcureVM()
                          {
                              Id= c.Id,
                              ItemName=c.ItemId,
                              Quantity=(int)c.Quantity

                          }).FirstOrDefault();

            return PartialView("AddQuantityPartial", result);
        }
        public ActionResult UpdateItemQtyforPr(ProcureVM model)
        {
            IProcure obj = new Procure();
            var docdetail = obj.GetDocDetail().Where(x => x.DocumentNo == model.DocNo && x.Quantity != 0).LastOrDefault();
            if (docdetail != null)
            {
                obj.updateDocstatus(model.DocNo);
                obj.Save();
            }
                obj.updatqty(model.Id,model.ItemName,model.Quantity);
                obj.Save();
               
                TempData["UpdateMessage3"] = "Success";
                
            return Json(new { success = true,code=1}, JsonRequestBehavior.AllowGet);
           
        }
    }
}