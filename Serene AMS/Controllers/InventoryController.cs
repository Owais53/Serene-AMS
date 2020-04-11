using Serene_AMS.DAL.Classes;
using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
using Serene_AMS.Models;
using Serene_AMS.ViewModels;

using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Rotativa;
using System.Collections.Generic;
using System.Data.Entity;

namespace Serene_AMS.Controllers
{
    public class InventoryController : Controller
    {
        InsertmultipleitemPR db = new InsertmultipleitemPR();
        HrmsEntities context = new HrmsEntities();

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
        public JsonResult GetItems(int? Id)
        {
            HrmsEntities db = new HrmsEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.tblItems.Where(x => x.TypeId == Id).Select(x => new { x.ItemId, x.ItemName }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemType()
        {
            HrmsEntities db = new HrmsEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.tblItemTypes.Select(x => new { x.Id, x.ItemType }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemtoremove(int? Id)
        {
            HrmsEntities db = new HrmsEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.tblItems.Where(p => p.TypeId != Id).Select(x => new { x.ItemId, x.ItemName }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemName(int? id)
        {
            IProcure obj = new Procure();

            var list = (from items in obj.Getitems()
                        where items.ItemId == id
                        select new
                        {

                            items.ItemName

                        }).ToList();


            return Json(list, JsonRequestBehavior.AllowGet);
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
                        where u.DocumentNo == DocNo
                        select new
                        {

                            u.DocumentNo,
                            u.ItemName,
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
                              d.ItemName,
                              d.Quantity,
                              d.DocumentNo

                          }).Select(c => new ProcureVM()
                          {
                              Id = c.Id,
                              ItemName = c.ItemName,
                              Quantity = (int)c.Quantity,
                              DocNo = (int)c.DocumentNo

                          }).FirstOrDefault();

            return PartialView("AddQuantityPartial", result);
        }
        public ActionResult UpdateItemQtyforPr(ProcureVM model)
        {
            IProcure obj = new Procure();

            if (db.getDetailsId() == model.Id)
            {
                obj.updateDocstatus(model.DocNo);
                obj.Save();
            }
            obj.updatqty(model.Id, model.ItemName, model.Quantity, model.RequestedDate);
            obj.Save();

            TempData["UpdateMessage3"] = "Success";

            return Json(new { success = true, code = 1 }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult CreatePurchaseOrder()
        {
            IProcure obj = new Procure();


            var list = obj.GetVendor().ToList();

            SelectList vendorlst = new SelectList(list, "VendorId", "VendorName");
            ViewBag.getvendorlist = vendorlst;

            return View();
        }
        public ActionResult GetPRfordoc(int? id)
        {

            IProcure obj = new Procure();
            var Data = (from doc in obj.GetDoc()
                        join detail in obj.GetDocDetail() on doc.DocumentNo equals detail.DocumentNo
                        where doc.DTypeId == 1 && doc.DocumentNo == id
                        select new
                        {
                            doc.DocumentNo,
                            doc.CreatedBy,
                            doc.CreationDate,
                            detail.ItemName,
                            detail.Quantity,
                            detail.TotalPrice
                        }).Select(x => new ProcureVM()
                        {
                            DocNo = x.DocumentNo,
                            Createdby = x.CreatedBy,
                            Createdon = (DateTime)x.CreationDate,
                            ItemName = x.ItemName,
                            Quantity = (int)x.Quantity,
                            Total = (int)x.TotalPrice,
                            Totalforall = (int)x.TotalPrice
                        }).FirstOrDefault();

            return PartialView("PRPartial", Data);
        }
        public JsonResult GetPRDetailsfordoc(int? id)
        {

            IProcure obj = new Procure();

            var list = (from doc in obj.GetDocDetail()
                        join item in obj.Getitems() on doc.ItemId equals item.ItemId
                        where doc.DocumentNo == id
                        select new
                        {
                            item.ItemName,
                            doc.Quantity,
                            doc.RequestedDate,
                            doc.TotalPrice

                        }).Select(x => new ProcureVM()
                        {
                            ItemName = x.ItemName,
                            Quantity = (int)x.Quantity,
                            RequestedDate = (DateTime)x.RequestedDate,
                            Total = (int)x.TotalPrice

                        }).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PrintPR()
        {
            var report = new ActionAsPdf("PRDoc");
            return report;
        }
        public ActionResult PrintPO(int? id)
        {
            IProcure obj = new Procure();
            var Data = (from doc in obj.GetDoc()
                        join vendor in obj.GetVendor() on doc.VendorId equals vendor.VendorId
                        where doc.DocumentNo == id
                        select new ProcureVM()
                        {
                            DocNo = doc.DocumentNo,
                            Createdby = doc.CreatedBy,
                            Createdon = (DateTime)doc.CreationDate,
                            VendorName = vendor.VendorName,
                            Address = vendor.Address,
                            Contact = vendor.Contact,

                        }).FirstOrDefault();
            var report = new ActionAsPdf("PODoc");
            return report;
        }
        public ActionResult PRDoc()
        {
            IProcure obj = new Procure();
            var DocNo = obj.GetDoc().Select(x => new ProcureVM { DocNo = x.DocumentNo, Createdby = x.CreatedBy, Createdon = (DateTime)x.CreationDate }).LastOrDefault();
            return View(DocNo);
        }
        public ActionResult GetPOHeader(int Docno)
        {
            IProcure obj = new Procure();


            var Data = (from doc in obj.GetDoc()
                        join vendor in obj.GetVendor() on doc.VendorId equals vendor.VendorId
                        where doc.DTypeId == 3 && doc.DocumentNo == Docno
                        select new
                        {
                            doc.DocumentNo,
                            doc.CreatedBy,
                            doc.CreationDate,
                            vendor.VendorName,
                            vendor.Address,
                            vendor.Contact,

                        }).Select(x => new ProcureVM() { DocNo = x.DocumentNo, Createdby = x.CreatedBy, Createdon = (DateTime)x.CreationDate, VendorName = x.VendorName, Address = x.Address, Contact = x.Contact }).FirstOrDefault();
            return View("PODoc");
        }


        public ActionResult PODoc(int? id)
        {
            IProcure obj = new Procure();
            InsertmultipleitemPR vM = new InsertmultipleitemPR();



            var Data = (from doc in obj.GetDoc()
                        join vendor in obj.GetVendor() on doc.VendorId equals vendor.VendorId
                        where doc.DocumentNo == id
                        select new ProcureVM()
                        {
                            DocNo = doc.DocumentNo,
                            Createdby = doc.CreatedBy,
                            Createdon = (DateTime)doc.CreationDate,
                            VendorName = vendor.VendorName,
                            Address = vendor.Address,
                            Contact = vendor.Contact,

                        }).FirstOrDefault();
            return View(Data);
        }
        public JsonResult GetPODetailsfordoc(int? id)
        {

            IProcure obj = new Procure();

            var list = (from doc in obj.GetDocDetail()
                        where doc.POReference == id
                        select new
                        {
                            doc.ItemName,
                            doc.Quantity,
                            doc.DeliveryDate,
                            doc.TotalPrice

                        }).Select(x => new ProcureVM()
                        {
                            ItemName = x.ItemName,
                            Quantity = (int)x.Quantity,
                            DeliveryDate = (DateTime)x.DeliveryDate,
                            Total = (int)x.TotalPrice

                        }).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPrList()
        {
            IProcure repo = new Procure();

            var Data = (from u in repo.GetDoc()
                        join doctype in repo.GetDoctypes() on u.DTypeId equals doctype.TypeId
                        where u.DocStatus == "Complete" && u.Status == "Pending" && u.DTypeId == 1
                        select new
                        {
                            u.DocumentNo,
                            u.Docno,
                            doctype.DocumentType

                        }).ToList();

            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPrItemsforpo(int DocNo)
        {
            ReqList obj = new ReqList();
            DataSet ds = obj.Show_PRItemsdata(DocNo);
            List<ProcureVM> list = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ProcureVM
                {
                    DocNo = Convert.ToInt32(dr["DocumentNo"]),
                    Prno = dr["Docno"].ToString(),
                    ItemName = dr["ItemName"].ToString(),
                    Quantity = Convert.ToInt32(dr["Quantity"]),
                    VendorName = dr["VendorName"].ToString(),
                    RequestedDate = Convert.ToDateTime(dr["RequestedDate"])


                });
            }
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public JsonResult RemovePrItemsforpo(int DocNo)
        {
            ReqList obj = new ReqList();
            DataSet ds = obj.DonotShow_PRItemsdata(DocNo);
            List<ProcureVM> list = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ProcureVM
                {
                    DocNo = Convert.ToInt32(dr["DocumentNo"]),
                    Prno = dr["Docno"].ToString(),
                    ItemName = dr["ItemName"].ToString(),
                    Quantity = Convert.ToInt32(dr["Quantity"]),
                    VendorName = dr["VendorName"].ToString(),
                    RequestedDate = Convert.ToDateTime(dr["RequestedDate"])

                });
            }
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public JsonResult RemovecommonPrItems(int DocNo)
        {
            ReqList obj = new ReqList();
            DataSet ds = obj.Show_PRItemsdata(DocNo);
            List<ProcureVM> list = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ProcureVM
                {
                    DocNo = Convert.ToInt32(dr["DocumentNo"]),
                    ItemName = dr["ItemName"].ToString(),
                    Id = Convert.ToInt32(dr["Id"])

                });
            }
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetItemsofPr(int? id)
        {

            IProcure obj = new Procure();
            var Data = (from doc in obj.GetDoc()
                        join detail in obj.GetDocDetail() on doc.DocumentNo equals detail.DocumentNo
                        where doc.DTypeId == 1 && doc.DocumentNo == id
                        select new
                        {
                            doc.DocumentNo,

                        }).Select(x => new ProcureVM()
                        {
                            DocNo = x.DocumentNo,


                        }).FirstOrDefault();

            return PartialView("PRDetailsPartial", Data);
        }
        public ActionResult GetVendorforItem(int id, ProcureVM model)
        {
            ProcureVM method = new ProcureVM();
            var Data = method.getItemDataforVendorSelection(id).FirstOrDefault();
            IProcure obj = new Procure();
            var list = obj.GetVendor().ToList();

            SelectList vendorlst = new SelectList(list, "VendorId", "VendorName");
            ViewBag.getvendorlist = vendorlst;
            return PartialView("POVendorPartial", Data);
        }
        public JsonResult GetVendorbyId(int? Id)
        {
            HrmsEntities db = new HrmsEntities();
            db.Configuration.ProxyCreationEnabled = false;
            var data = (from itemtype in db.tblItemTypes
                        join vendor in db.tblVendors on itemtype.Id equals vendor.TypeId
                        where vendor.TypeId == Id
                        select new
                        {
                            vendor.VendorId,
                            vendor.VendorName

                        }).Select(x => new
                        {
                            x.VendorId,
                            x.VendorName

                        }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetVendortoremove(int? Id)
        {
            HrmsEntities db = new HrmsEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.tblVendors.Where(p => p.TypeId != Id).Select(x => new { x.VendorId, x.VendorName }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDocPO(int? Id)
        {
            HrmsEntities db = new HrmsEntities();
            var today = DateTime.Now;
            db.Configuration.ProxyCreationEnabled = false;
            var data = (from doc in db.tblDocuments
                        where doc.DTypeId == 3 && DbFunctions.TruncateTime(doc.CreationDate) == DbFunctions.TruncateTime(today)
                        select new
                        {
                            doc.DocumentNo

                        }).Select(x => new
                        {
                            x.DocumentNo

                        }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RemoveDocPO(int? Id)
        {
            HrmsEntities db = new HrmsEntities();
            var today = DateTime.Now;
            db.Configuration.ProxyCreationEnabled = false;
            var data = (from doc in db.tblDocuments
                        where doc.DTypeId == 3 && DbFunctions.TruncateTime(doc.CreationDate) == DbFunctions.TruncateTime(today)
                        select new
                        {
                            doc.DocumentNo

                        }).Select(x => new
                        {
                            x.DocumentNo

                        }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetVendorforItem(ProcureVM model)
        {
            IProcure obj = new Procure();
            var Vendor = obj.GetVendor().Where(x => x.TypeId == model.TypeId && x.VendorId == model.VendorId).FirstOrDefault();
            var checkfirst = obj.GetDocDetail().Where(x => x.Id == model.Id && x.VendorId == null).FirstOrDefault();
            if (Convert.ToBoolean(db.getItemNameforPo(model.DocNo, model.Id) == model.ItemName))
            {
                if (Vendor != null)
                {
                    if (db.getIdforPo(model.DocNo) == model.Id)
                    {
                        var list = obj.GetVendor().ToList();

                        SelectList vendorlst = new SelectList(list, "VendorId", "VendorName");
                        ViewBag.getvendorlist = vendorlst;
                        var add = obj.AddPowithref(model.DocNo, model.VendorId);
                        obj.AddPO(add);
                        obj.Save();
                        obj.setstatusonpocreate(model.DocNo);
                        obj.Save();
                        obj.SetVendorforItem(model.Id, model.ItemId, model.VendorId, model.DeliveryDate, add.DocumentNo);
                        obj.Save();
                        return Json(new { model, message = "Purchase Order Created with Document No. " + add.DocumentNo + " and Vendor Selected for Item " + model.ItemName + "", code = 1 }, JsonRequestBehavior.AllowGet);
                    }
                    else if (db.getVendorIdforPo(model.DocNo) == model.VendorId)
                    {
                        var list = obj.GetVendor().ToList();

                        SelectList vendorlst = new SelectList(list, "VendorId", "VendorName");
                        ViewBag.getvendorlist = vendorlst;
                        obj.SetVendorforItem(model.Id, model.ItemId, model.VendorId, model.DeliveryDate, db.getPODocNo());
                        obj.Save();
                        return Json(new { model, message = "Vendor Selected for Item " + model.ItemName + "", code = 1 }, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        var list = obj.GetVendor().ToList();

                        SelectList vendorlst = new SelectList(list, "VendorId", "VendorName");
                        ViewBag.getvendorlist = vendorlst;
                        var add = obj.AddPowithref(model.DocNo, model.VendorId);
                        obj.AddPO(add);
                        obj.Save();
                        obj.setstatusonpocreate(model.DocNo);
                        obj.Save();
                        obj.SetVendorforItem(model.Id, model.ItemId, model.VendorId, model.DeliveryDate, add.DocumentNo);
                        obj.Save();
                        return Json(new { model, message = "Purchase Order Created with Document No. " + add.DocumentNo + " and Vendor Selected for each Item", code = 1 }, JsonRequestBehavior.AllowGet);

                    }
                }
                else
                {
                    var list = obj.GetVendor().ToList();

                    SelectList vendorlst = new SelectList(list, "VendorId", "VendorName");
                    ViewBag.getvendorlist = vendorlst;

                    return Json(new { model, message = "Please Select Vendor Based on Item Type" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { model, message = "PO already created for Item " + model.ItemName + "" }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult CreatePR()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CreatePR(List<tblDocDetail> prlist)
        {
            IProcure obj = new Procure();
            InsertmultipleitemPR getid = new InsertmultipleitemPR();

            NumberSequence seq = new NumberSequence();

            if (prlist == null)
            {
                prlist = new List<tblDocDetail>();
                return Json(new { code = 0, message = "Please add to list before Submitting" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (prlist == null)
                {
                    prlist = new List<tblDocDetail>();

                }

                var add = obj.Addpr();
                obj.AddPRItems(add);
                obj.Save();
                string no = seq.GenerateNo("PR", add.DocumentNo);
                obj.upatedocdetail(add.DocumentNo, no);
                obj.Save();
                var anyrecord = obj.GetDocDetail().Where(x => x.DocumentNo == add.DocumentNo).FirstOrDefault();
                foreach (tblDocDetail pr in prlist)
                {

                    if (anyrecord == null)
                    {
                        var adddet = obj.AddPrdetails(add.DocumentNo, getid.getItemid(pr.ItemName), getid.getVendorId(pr.VendorName), pr.RequestedDate, pr.Quantity, pr.TotalPrice);
                        obj.docdetails(adddet);
                        obj.Save();
                        obj.vendorselect(add.DocumentNo, getid.getVendorId(pr.VendorName));
                        obj.Save();

                    }

                }


                return Json(new { prlist, message = "PR " + add.Docno + " Created" }, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult GetItemPrice(int qty, int item)
        {
            InsertmultipleitemPR obj = new InsertmultipleitemPR();


            return Json(obj.getTotalPrice(qty, item), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLastDoc()
        {


            return Json(db.getDocumentNo(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult PostPrItems(string type, string item, int qty, decimal price, string vendor, DateTime redate)
        {
            IProcure obj = new Procure();
            bool flag = db.getItemName(item);
            bool flag1 = db.getVendorName(vendor);

            var vendorcheck = obj.Getprline().Where(x => x.VendorName != vendor).FirstOrDefault();

            if (flag && flag1)
            {
                obj.updateprlineitem(item, vendor, qty, price);
                obj.Save();
            }
            else
            {

                if (vendorcheck==null)
                {
                    var add = obj.addprlineitem(type, item, qty, price, vendor, redate);
                    obj.Addprline(add);
                    obj.Save();
                   
                }
                else
                {
                    return Json(new { code = 1, message = "Please select Same Vendor" }, JsonRequestBehavior.AllowGet);

                }
            }

            return Json(JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetPrlineitem()
        {
            ReqList obj = new ReqList();
            DataSet ds = obj.Show_PRlineitem();
            List<tblprlineitem> list = new List<tblprlineitem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new tblprlineitem
                {
                    Id=Convert.ToInt32(dr["Id"]),
                    ItemType = dr["ItemType"].ToString(),
                    ItemName = dr["ItemName"].ToString(),
                    Quantity = Convert.ToInt32(dr["Quantity"]),
                    ItemPrice = Convert.ToDecimal(dr["ItemPrice"]),
                    VendorName=dr["VendorName"].ToString(),
                    RequestedDate = Convert.ToDateTime(dr["RequestedDate"])
                   

                });
            }
            return Json(list,JsonRequestBehavior.AllowGet);
        }
        public JsonResult Removeprline(int id)
        {

            db.Removeprline(id);
                 
            return Json( JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeletePrline()
        {
            db.Deleteprline();
            return Json( JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetConfirmRejectPartial(int DocNo)
        {
            IProcure obj = new Procure();
            var data = obj.GetDoc().Where(x => x.DocumentNo == DocNo).Select(x => new ProcureVM() { DocNo = x.DocumentNo }).FirstOrDefault();

            return PartialView("ConfirmRejectPartial",data);
        }

        public JsonResult GetConfirmRejectPartial(ProcureVM model)
        {
            IProcure obj = new Procure();
            obj.rejectpr(model.DocNo);
            obj.Save();

            return Json(new { code=0, message = "PR Rejected" },JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreatePO(int Docno)
        {
            IProcure obj = new Procure();
          var data= (from doc in obj.GetDoc()           
                    join detail in obj.GetDocDetail() on doc.DocumentNo equals detail.DocumentNo
                    where doc.DocumentNo == Docno
                    select new
                    {
                      doc.DocumentNo,
                       detail.VendorName
                       

                    }).Select(x => new ProcureVM()
                    {
                      DocNo=x.DocumentNo,
                      VendorName=x.VendorName

                     }).FirstOrDefault();
           
            return View(data);
        }
        public ActionResult GetPRDataPartial(int DocNo)
        {
            IProcure obj = new Procure();
            var data = obj.GetDoc().Where(x => x.DocumentNo == DocNo).Select(x => new ProcureVM() {DocNo=x.DocumentNo,VendorId=(int)x.VendorId,Prno=x.Docno }).FirstOrDefault();


            return PartialView("PRtoPOPartial",data);
        }
        [HttpPost]
        public JsonResult GetPRDataPartial(ProcureVM model)
        {
            IProcure obj = new Procure();
            NumberSequence seq = new NumberSequence();
            var add = obj.AddPowithref(model.DocNo, model.VendorId);
            obj.AddPO(add);
            obj.Save();
            obj.setstatusonpocreate(model.DocNo);
            obj.Save();
            string no = seq.GenerateNo("PO", add.DocumentNo);
            obj.upatedocdetail(add.DocumentNo, no);
            obj.Save();

            return Json(new {message="Purchase Order "+add.Docno+" Created With Reference to Purchase Request "+model.Prno+"" },JsonRequestBehavior.AllowGet);
        }

    }
}