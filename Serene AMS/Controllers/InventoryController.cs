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
            obj.updatqty(model.Id, model.ItemName, model.Quantity);
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
                            doc.TotalPrice

                        }).Select(x => new ProcureVM()
                        {
                            ItemName = x.ItemName,
                            Quantity = (int)x.Quantity,
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
            var DocNo = obj.GetDoc().Select(x => new ProcureVM { DocNo = x.DocumentNo, Createdby = x.CreatedBy, Createdon = (DateTime)x.CreationDate, RequestedDate = (DateTime)x.ItemRequestedDate }).LastOrDefault();
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
                            DocNo = (int)doc.PrReferenceNo,
                            Createdby = doc.CreatedBy,
                            Createdon = (DateTime)doc.CreationDate,
                            DeliveryDate=(DateTime)doc.DeliveryDate,
                            VendorName = vendor.VendorName,
                            Address = vendor.Address,
                            Contact = vendor.Contact,

                        }).FirstOrDefault();
            return View(Data);
        }
        public JsonResult GetPODetailsfordoc(int? id)
        {

            IProcure obj = new Procure();

            var list = (from doc in obj.GetDoc()
                        join detail in obj.GetDocDetail() on doc.PrReferenceNo equals detail.DocumentNo
                        join item in obj.Getitems() on detail.ItemId equals item.ItemId
                        where doc.PrReferenceNo == id
                        select new
                        {
                           item.ItemName,
                           detail.Quantity,
                           detail.TotalPrice

                        }).Select(x => new ProcureVM()
                        {
                            ItemName = x.ItemName,
                            Quantity = (int)x.Quantity,
                            Total=(decimal)x.TotalPrice

                        }).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPrList()
        {
            IProcure repo = new Procure();

            var Data = (from u in repo.GetDoc()
                        join doctype in repo.GetDoctypes() on u.DTypeId equals doctype.TypeId
                        join v in repo.GetVendor() on u.VendorId equals v.VendorId
                        where u.DocStatus == "Complete" && u.Status == "Pending" && u.DTypeId == 1
                        select new
                        {
                            u.DocumentNo,
                            u.Docno,
                            doctype.DocumentType,
                            v.VendorName,
                            u.ItemRequestedDate

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
                    RequestedDate = Convert.ToDateTime(dr["ItemRequestedDate"])


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
                    RequestedDate = Convert.ToDateTime(dr["ItemRequestedDate"])


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
                        var add = obj.AddPowithref(model.DocNo, model.VendorId, model.RequestedDate, model.RequestedDate);
                        obj.AddPO(add);
                        obj.Save();
                        obj.setstatusonpocreate(model.DocNo);
                        obj.Save();
                        obj.SetVendorforItem(model.Id, model.ItemId, model.VendorId, add.DocumentNo);
                        obj.Save();
                        return Json(new { model, message = "Purchase Order Created with Document No. " + add.DocumentNo + " and Vendor Selected for Item " + model.ItemName + "", code = 1 }, JsonRequestBehavior.AllowGet);
                    }
                    else if (db.getVendorIdforPo(model.DocNo) == model.VendorId)
                    {
                        var list = obj.GetVendor().ToList();

                        SelectList vendorlst = new SelectList(list, "VendorId", "VendorName");
                        ViewBag.getvendorlist = vendorlst;
                        obj.SetVendorforItem(model.Id, model.ItemId, model.VendorId, db.getPODocNo());
                        obj.Save();
                        return Json(new { model, message = "Vendor Selected for Item " + model.ItemName + "", code = 1 }, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        var list = obj.GetVendor().ToList();

                        SelectList vendorlst = new SelectList(list, "VendorId", "VendorName");
                        ViewBag.getvendorlist = vendorlst;
                        var add = obj.AddPowithref(model.DocNo, model.VendorId, model.RequestedDate, model.RequestedDate);
                        obj.AddPO(add);
                        obj.Save();
                        obj.setstatusonpocreate(model.DocNo);
                        obj.Save();
                        obj.SetVendorforItem(model.Id, model.ItemId, model.VendorId, add.DocumentNo);
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
        public JsonResult CreatePR(List<tblDocDetail> prlists, DateTime datereq)
        {
            IProcure obj = new Procure();
            InsertmultipleitemPR getid = new InsertmultipleitemPR();

            NumberSequence seq = new NumberSequence();

            if (prlists == null)
            {
                prlists = new List<tblDocDetail>();
                return Json(new { code = 0, message = "Please add to list before Submitting" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (prlists == null)
                {
                    prlists = new List<tblDocDetail>();

                }

                var add = obj.Addpr(datereq);
                obj.AddPRItems(add);
                obj.Save();
                string no = seq.GenerateNo("PR", add.DocumentNo);
                obj.upatedocdetail(add.DocumentNo, no);
                obj.Save();
                var anyrecord = obj.GetDocDetail().Where(x => x.DocumentNo == add.DocumentNo).FirstOrDefault();
                foreach (tblDocDetail pr in prlists)
                {

                    if (anyrecord == null)
                    {
                        var adddet = obj.AddPrdetails(add.DocumentNo, getid.getItemid(pr.ItemName), getid.getVendorId(pr.VendorName), pr.Quantity, pr.TotalPrice);
                        obj.docdetails(adddet);
                        obj.Save();
                        obj.vendorselect(add.DocumentNo, getid.getVendorId(pr.VendorName));
                        obj.Save();

                    }

                }


                return Json(new { prlists, message = "PR " + add.Docno + " Created" }, JsonRequestBehavior.AllowGet);
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
        public JsonResult PostPrItems(string type, string item, int qty, decimal price, string vendor)
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

                if (vendorcheck == null)
                {
                    var add = obj.addprlineitem(type, item, qty, price, vendor);
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
                    Id = Convert.ToInt32(dr["Id"]),
                    ItemType = dr["ItemType"].ToString(),
                    ItemName = dr["ItemName"].ToString(),
                    Quantity = Convert.ToInt32(dr["Quantity"]),
                    ItemPrice = Convert.ToDecimal(dr["ItemPrice"]),
                    VendorName = dr["VendorName"].ToString(),



                });
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Removeprline(int id)
        {

            db.Removeprline(id);

            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeletePrline()
        {
            db.Deleteprline();
            return Json(JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetConfirmRejectPartial(int DocNo)
        {
            IProcure obj = new Procure();
            var data = obj.GetDoc().Where(x => x.DocumentNo == DocNo).Select(x => new ProcureVM() { DocNo = x.DocumentNo }).FirstOrDefault();

            return PartialView("ConfirmRejectPartial", data);
        }

        public JsonResult GetConfirmRejectPartial(ProcureVM model)
        {
            IProcure obj = new Procure();
            obj.rejectpr(model.DocNo);
            obj.Save();

            return Json(new { code = 0, message = "PR Rejected" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreatePO(int Docno)
        {
            IProcure obj = new Procure();
            var data = (from doc in obj.GetDoc()
                        join detail in obj.GetDocDetail() on doc.DocumentNo equals detail.DocumentNo
                        where doc.DocumentNo == Docno
                        select new
                        {
                            doc.DocumentNo,
                            detail.VendorName


                        }).Select(x => new ProcureVM()
                        {
                            DocNo = x.DocumentNo,
                            VendorName = x.VendorName

                        }).FirstOrDefault();

            return View(data);
        }
        public ActionResult GetPRDataPartial(int DocNo)
        {
            IProcure obj = new Procure();
            var data = obj.GetDoc().Where(x => x.DocumentNo == DocNo).Select(x => new ProcureVM() { DocNo = x.DocumentNo, VendorId = (int)x.VendorId, Prno = x.Docno, RequestedDate = (DateTime)x.ItemRequestedDate }).FirstOrDefault();


            return PartialView("PRtoPOPartial", data);
        }
        [HttpPost]
        public JsonResult GetPRDataPartial(ProcureVM model)
        {
            IProcure obj = new Procure();
            NumberSequence seq = new NumberSequence();
            var add = obj.AddPowithref(model.DocNo, model.VendorId, model.RequestedDate, model.RequestedDate);
            obj.AddPO(add);
            obj.Save();
            obj.setstatusonpocreate(model.DocNo);
            obj.Save();
            string no = seq.GenerateNo("PO", add.DocumentNo);
            obj.upatedocdetail(add.DocumentNo, no);
            obj.Save();

            return Json(new { message = "Purchase Order " + add.Docno + " Created With Reference to Purchase Request " + model.Prno + "" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewPOforGR()
        {
            return View();
        }
        public JsonResult GetPOlistforGR()
        {
            IProcure repo = new Procure();
            var Data = (from u in repo.GetDoc()
                        join doctype in repo.GetDoctypes() on u.DTypeId equals doctype.TypeId
                        join v in repo.GetVendor() on u.VendorId equals v.VendorId
                        where u.DocStatus == "Complete" && u.DTypeId == 3 && (u.Status == null || u.Status == "Partial Delivery")
                        select new
                        {
                            u.DocumentNo,
                            u.Docno,
                            doctype.DocumentType,
                            v.VendorName,
                            u.ItemRequestedDate,
                            u.DeliveryDate

                        }).ToList();
            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetGRHeaderdataforPO(int? id,int? typeid)
        {
            IProcure obj = new Procure();

            var data = (from doc in obj.GetDoc()
                        join v in obj.GetVendor() on doc.VendorId equals v.VendorId
                        where doc.DocumentNo == id && doc.DTypeId ==typeid 
                        select new ProcureVM()
                        {
                            DocNo = doc.DocumentNo,
                            Prreferenceno = (int)doc.PrReferenceNo,
                            Prno = doc.Docno,
                            TypeId=(int)doc.DTypeId,
                            VendorName = v.VendorName,
                            VendorId = (int)doc.VendorId
                        }).ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateGR(int? id)
        {
            IProcure obj = new Procure();

            var data = (from doc in obj.GetDoc()
                        join v in obj.GetVendor() on doc.VendorId equals v.VendorId
                        where doc.DocumentNo == id && (doc.DTypeId == 3||doc.DTypeId==5)
                        select new ProcureVM()
                        {
                            DocNo = doc.DocumentNo,
                            Prreferenceno = (int)doc.PrReferenceNo,
                            Prno = doc.Docno,
                            VendorName = v.VendorName,
                            VendorId = (int)doc.VendorId
                        }).FirstOrDefault();



            return View(data);
        }
        public JsonResult RemoveItemsforGR(int? Doc)
        {
            ReqList li = new ReqList();
            DataSet ds = li.NotShow_iteminddl(Doc);
            List<ProcureVM> list = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ProcureVM
                {
                    ItemId = Convert.ToInt32(dr["ItemId"]),
                    ItemName = dr["ItemName"].ToString()

                });
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemsforGR(int? Doc)
        {
            ReqList li = new ReqList();
            DataSet ds = li.Show_iteminddl(Doc);
            List<ProcureVM> list = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ProcureVM
                {
                    ItemId = Convert.ToInt32(dr["ItemId"]),
                    ItemName = dr["ItemName"].ToString()

                });
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemsData(int id)
        {
            ReqList li = new ReqList();
            DataSet ds = li.Show_itemDataingrid(id);
            List<ProcureVM> list = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ProcureVM
                {
                    ItemType = dr["ItemType"].ToString(),
                    ItemName = dr["ItemName"].ToString(),
                    Quantity = Convert.ToInt32(dr["Quantity"])
                });
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPrforGr(int Pono)
        {
            return Json(db.getPrrefforgr(Pono),JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetGrforreturn(int returnno)
        {
            return Json(db.getGrrefforreturn(returnno), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPonoforgr(int Pono)
        {
            return Json(db.getPorefforgr(Pono), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTypeidforgr(int Pono)
        {
            return Json(db.gettypeidgr(Pono), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Getreturnnoforgr(int Pono)
        {
            return Json(db.getreturnrefforgr(Pono), JsonRequestBehavior.AllowGet);
        }
        public JsonResult RemoveItemsData(int id)
        {
            ReqList li = new ReqList();
            DataSet ds = li.Remove_itemDataingrid(id);
            List<ProcureVM> list = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ProcureVM
                {
                    ItemType = dr["ItemType"].ToString(),
                    ItemName = dr["ItemName"].ToString(),
                    Quantity = Convert.ToInt32(dr["Quantity"])
                });
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetQuantityData(int id)
        {
            var checkstatus = context.tblDocuments.Where(x => x.PrReferenceNo == id && x.Status == "Partial Delivery").FirstOrDefault();
            if (checkstatus == null)
            {
                ReqList li = new ReqList();
                DataSet ds = li.Show_QtyDataingrid(id);
                List<ProcureVM> list = new List<ProcureVM>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new ProcureVM
                    {

                        ItemName = dr["ItemName"].ToString(),
                        DeliveredQuantity = Convert.ToInt32(dr["DeliveredQuantity"]),
                        RemainingQuantity = Convert.ToInt32(dr["RemainingQuantity"])
                    });
                }

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ReqList li = new ReqList();
                DataSet ds = li.Show_QtyDataingridpartial(id);
                List<ProcureVM> list = new List<ProcureVM>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new ProcureVM
                    {

                        ItemName = dr["ItemName"].ToString(),
                        DeliveredQuantity = Convert.ToInt32(dr["PartialDeliveredQuantity"]),
                        RemainingQuantity = Convert.ToInt32(dr["RemainingQuantity"])
                    });
                }

                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetQuantityDataReturn(int id)
        {
            var checkstatus = context.tblDocuments.Where(x => x.DocumentNo == id && x.Status == "Partial Delivery").FirstOrDefault();
            if (checkstatus == null)
            {
                ReqList li = new ReqList();
                DataSet ds = li.Show_QtyDataingridReturn(id);
                List<ProcureVM> list = new List<ProcureVM>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new ProcureVM
                    {

                        ItemName = dr["ItemName"].ToString(),
                        DeliveredQuantity = Convert.ToInt32(dr["ReturnQuantity"]),
                        RemainingQuantity = Convert.ToInt32(dr["RemainingQuantity"])
                    });
                }

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ReqList li = new ReqList();
                DataSet ds = li.Show_QtyDataingridpartialReturn(id);
                List<ProcureVM> list = new List<ProcureVM>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new ProcureVM
                    {

                        ItemName = dr["ItemName"].ToString(),
                        DeliveredQuantity = Convert.ToInt32(dr["PartialReturnQuantity"]),
                        RemainingQuantity = Convert.ToInt32(dr["RemainingQuantity"])
                    });
                }

                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetQuantityDataonupdate(int id)
        {
            ReqList li = new ReqList();
            DataSet ds = li.Show_QtyDataingridpartial(id);
            List<ProcureVM> list = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ProcureVM
                {

                    ItemName = dr["ItemName"].ToString(),
                    DeliveredQuantity = Convert.ToInt32(dr["PartialDeliveredQuantity"]),
                    RemainingQuantity = Convert.ToInt32(dr["RemainingQuantity"])
                });
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RemovePartialQuantityData(int id)
        {
            ReqList li = new ReqList();
            DataSet ds = li.NotShow_QtyPartialDataingrid(id);
            List<ProcureVM> list = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ProcureVM
                {
                    ItemType = dr["ItemType"].ToString(),
                    ItemName = dr["ItemName"].ToString(),
                    Quantity = Convert.ToInt32(dr["RemainingQuantity"])

                });
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPartialQuantityData(int id)
        {
            ReqList li = new ReqList();
            DataSet ds = li.Show_QtyPartialDataingrid(id);
            List<ProcureVM> list = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ProcureVM
                {
                    ItemType = dr["ItemType"].ToString(),
                    ItemName = dr["ItemName"].ToString(),
                    Quantity = Convert.ToInt32(dr["RemainingQuantity"])
                });
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PostQuantityItems(int PrDocno, int item, int qty)
        {
            IProcure obj = new Procure();

            var checkstatus = context.tblDocuments.Where(x => x.PrReferenceNo == PrDocno && x.Status == "Partial Delivery").FirstOrDefault();
            if (checkstatus == null)
            {
                obj.itemqtydelivered(PrDocno, item, qty);
                obj.Save();
            }
            else
            {
                obj.itempartialqtydelivered(PrDocno, item, qty);
                obj.Save();
            }

            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult PostQuantityItemsforReturn(int Docno, int item, int qty)
        {
            IProcure obj = new Procure();

            var checkstatus = context.tblDocuments.Where(x => x.DocumentNo == Docno && x.Status == "Partial Delivery").FirstOrDefault();
            if (checkstatus == null)
            {
                obj.itemqtydeliveredreturn(Docno, item, qty);
                obj.Save();
            }
            else
            {
                obj.itempartialqtydeliveredreturn(Docno, item, qty);
                obj.Save();
            }

            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult PostGRwithstatus(int Docno,int returnno, int vendor,int typeid ,List<ProcureVM> grlists)
        {
            IProcure obj = new Procure();
            NumberSequence seq = new NumberSequence();
          
            if (grlists == null)
            {
                grlists = new List<ProcureVM>();
                return Json(new { code = 0, message = "Please add Delivered Quantity before Submitting" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (grlists == null)
                {
                    grlists = new List<ProcureVM>();

                }
                if (typeid == 3)
                {
                    bool flag = db.getRemainingQty(Docno);


                    if (flag)
                    {
                        var add1 = obj.AddGr(db.getPono(Docno), vendor);
                        obj.addgr(add1);
                        obj.Save();
                        string no = seq.GenerateNo("GR", add1.DocumentNo);
                        obj.upatedocdetail(add1.DocumentNo, no);
                        obj.Save();
                        obj.updatestatuspartial(db.getPono(Docno));
                        obj.Save();
                        foreach (ProcureVM gr in grlists)
                        {
                            var addprice2 = obj.addGritemsPrice(add1.DocumentNo, db.getItemid(gr.ItemName), gr.DeliveredQuantity);
                            obj.addpriceofitems(addprice2);
                            obj.Save();
                            obj.calculateitemprice(add1.DocumentNo, db.getItemid(gr.ItemName), db.getItemPriceofGR(add1.DocumentNo, db.getItemid(gr.ItemName)));
                            obj.Save();
                            obj.updateslstock(db.getSlid(gr.ItemName), gr.DeliveredQuantity);
                            obj.Save();
                            obj.updateitemstock(db.getItemid(gr.ItemName), gr.DeliveredQuantity);
                            obj.Save();


                        }
                        return Json(new { Grno = add1.DocumentNo, message = "Goods Receipt " + add1.Docno + " Created with Status Partial Delivery" }, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        var add = obj.AddGrwithcomp(db.getPono(Docno), vendor);
                        obj.addgr(add);
                        obj.Save();
                        string no = seq.GenerateNo("GR", add.DocumentNo);
                        obj.upatedocdetail(add.DocumentNo, no);
                        obj.Save();
                        obj.updatestatuscomplete(db.getPono(Docno));
                        obj.Save();
                        foreach (ProcureVM gr in grlists)
                        {
                            var addprice2 = obj.addGritemsPrice(add.DocumentNo, db.getItemid(gr.ItemName), gr.DeliveredQuantity);
                            obj.addpriceofitems(addprice2);
                            obj.Save();
                            obj.calculateitemprice(add.DocumentNo, db.getItemid(gr.ItemName), db.getItemPriceofGR(add.DocumentNo, db.getItemid(gr.ItemName)));
                            obj.Save();
                            obj.updateslstock(db.getSlid(gr.ItemName), gr.DeliveredQuantity);
                            obj.Save();
                            obj.updateitemstock(db.getItemid(gr.ItemName), gr.DeliveredQuantity);
                            obj.Save();


                        }

                        return Json(new { Grno = add.DocumentNo, message = "Goods Receipt " + add.Docno + " Created with Status Complete Delivery" }, JsonRequestBehavior.AllowGet);
                    }

                }
                else
                {
                    bool flag1 = db.getRemainingQtyforReturn(returnno);
                    if (flag1)
                    {
                        var add1 = obj.AddGrforReturn(returnno, vendor);
                        obj.addgr(add1);
                        obj.Save();
                        string no = seq.GenerateNo("GR", add1.DocumentNo);
                        obj.upatedocdetail(add1.DocumentNo, no);
                        obj.Save();
                        obj.updatestatuspartial(returnno);
                        obj.Save();
                        foreach (ProcureVM gr in grlists)
                        {
                            var addprice2 = obj.addGritemsPrice(add1.DocumentNo, db.getItemid(gr.ItemName), gr.DeliveredQuantity);
                            obj.addpriceofitems(addprice2);
                            obj.Save();
                            obj.calculateitemprice(add1.DocumentNo, db.getItemid(gr.ItemName), db.getItemPriceofGR(add1.DocumentNo, db.getItemid(gr.ItemName)));
                            obj.Save();
                            obj.updateslstock(db.getSlid(gr.ItemName), gr.DeliveredQuantity);
                            obj.Save();
                            obj.updateitemstock(db.getItemid(gr.ItemName), gr.DeliveredQuantity);
                            obj.Save();


                        }
                        return Json(new { Grno = add1.DocumentNo, message = "Goods Receipt " + add1.Docno + " Created with Status Partial Delivery" }, JsonRequestBehavior.AllowGet);

                    }

                    else
                    {
                        var add = obj.AddGrwithcompReturn(returnno, vendor);
                        obj.addgr(add);
                        obj.Save();
                        string no = seq.GenerateNo("GR", add.DocumentNo);
                        obj.upatedocdetail(add.DocumentNo, no);
                        obj.Save();
                        obj.updatestatuscomplete(returnno);
                        obj.Save();
                        foreach (ProcureVM gr in grlists)
                        {
                            var addprice2 = obj.addGritemsPrice(add.DocumentNo, db.getItemid(gr.ItemName), gr.DeliveredQuantity);
                            obj.addpriceofitems(addprice2);
                            obj.Save();
                            obj.calculateitemprice(add.DocumentNo, db.getItemid(gr.ItemName), db.getItemPriceofGR(add.DocumentNo, db.getItemid(gr.ItemName)));
                            obj.Save();
                            obj.updateslstock(db.getSlid(gr.ItemName), gr.DeliveredQuantity);
                            obj.Save();
                            obj.updateitemstock(db.getItemid(gr.ItemName), gr.DeliveredQuantity);
                            obj.Save();


                        }

                        return Json(new { Grno = add.DocumentNo, message = "Goods Receipt " + add.Docno + " Created with Status Complete Delivery" }, JsonRequestBehavior.AllowGet);
                    }

                }

            }
        }
        [HttpGet]
        public ActionResult CreateInvoice(int? id)
        {

            IProcure obj = new Procure();
            
            var data = (from doc in obj.GetDoc()
                        join v in obj.GetVendor() on doc.VendorId equals v.VendorId
                        where doc.DocumentNo == id && doc.DTypeId == 4
                        select new ProcureVM()
                        {
                            DocNo = doc.DocumentNo,
                            Grno = doc.Docno,
                            VendorName = v.VendorName,
                            VendorId = (int)doc.VendorId,
                          
                        }).FirstOrDefault();



            return View(data);
        }

        public JsonResult PostInvoicewithstatus(int Docno, decimal total, decimal paid, decimal balance)
        {
            NumberSequence seq = new NumberSequence();
            IProcure obj = new Procure();
            if (balance == 0)
            {
                var add = obj.AddIR(Docno, total, paid, balance);
                obj.addInvoiceR(add);
                obj.Save();
                string no = seq.GenerateNo("IR", add.InvoiceReceiptId);
                obj.getIRno(add.InvoiceReceiptId, no);
                obj.Save();
                obj.statuscompletepay(Docno);
                obj.Save();
                return Json(new {Irno=add.InvoiceReceiptId, message = "Invoice Receipt Created with " + add.InvoiceReceiptNo + " and Status Paid" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var add = obj.AddIRPartial(Docno, total, paid, balance);
                obj.addInvoiceR(add);
                obj.Save();
                string no = seq.GenerateNo("IR", add.InvoiceReceiptId);
                obj.getIRno(add.InvoiceReceiptId, no);
                obj.Save();
                obj.statuspartialpay(Docno);
                obj.Save();
                return Json(new {Irno=add.InvoiceReceiptId, message = "Invoice Receipt Created with " + add.InvoiceReceiptNo + " and Status Partially Paid" }, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult ApplyValidationonQty(int docno, int itemid)
        {
            IProcure obj = new Procure();
            var checkpostatus = obj.GetDoc().Where(x => x.PrReferenceNo == docno && x.Status == null).FirstOrDefault();
            if (checkpostatus != null)
            {
                return Json(db.getOrderedqty(docno, itemid), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(db.getpartialOrderedqty(docno, itemid), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ApplyValidationonQtyReturn(int docno, int itemid)
        {
            IProcure obj = new Procure();
            var checkreturnstatus = obj.GetDoc().Where(x => x.DocumentNo == docno && x.Status == "InProgress").FirstOrDefault();
            if (checkreturnstatus != null)
            {
                return Json(db.getOrderedqtyforreturn(docno, itemid), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(db.getpartialOrderedqtyreturn(docno, itemid), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ViewGRforInvoice()
        {
            return View();
        }
        public JsonResult GetGRListforInvoice()
        {
            IProcure repo = new Procure();
            var Data = (from u in repo.GetDoc()
                        join doctype in repo.GetDoctypes() on u.DTypeId equals doctype.TypeId
                        join v in repo.GetVendor() on u.VendorId equals v.VendorId
                        where u.DocStatus == "Complete" && u.DTypeId == 4 && (u.Status == "Partial"||u.Status=="Complete"||u.Status== "Partially Paid")
                        select new
                        {
                            u.DocumentNo,
                            u.Docno,
                            doctype.DocumentType,
                            v.VendorName
                           

                        }).ToList();

            return Json(new {data=Data },JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetGRItemswithPrice(int Doc)
        {
            ReqList li = new ReqList();
            DataSet ds = li.Show_gritemininvoicegrid(Doc);
            List<ProcureVM> list = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ProcureVM
                {                    
                    ItemName = dr["ItemName"].ToString(),
                    Quantity = Convert.ToInt32(dr["DeliveredQuantity"]),
                    ItemPrice= Convert.ToDecimal(dr["ItemPrice"])
                });
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RemoveGRItemswithPrice(int Doc)
        {
            ReqList li = new ReqList();
            DataSet ds = li.Remove_gritemininvoicegrid(Doc);
            List<ProcureVM> list = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ProcureVM
                {
                    ItemName = dr["ItemName"].ToString(),
                    Quantity = Convert.ToInt32(dr["DeliveredQuantity"]),
                    ItemPrice = Convert.ToDecimal(dr["ItemPrice"])
                });
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTotalPrice(int Doc)
        {
            IProcure obj = new Procure();

            var checkstatus = obj.GetDoc().Where(x =>x.DocumentNo==Doc && x.Status == "Partially Paid").FirstOrDefault();
            if (checkstatus != null)
            {
                return Json(db.getPartiallPrice(Doc), JsonRequestBehavior.AllowGet);
            }
            else
            {

                return Json(db.getTotalPrice(Doc), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GRReport(int? id)
        {
            IProcure obj = new Procure();
            var data = (from doc in obj.GetDoc()
                        join v in obj.GetVendor() on doc.VendorId equals v.VendorId
                        where doc.DTypeId == 4 && doc.DocumentNo == id
                        select new
                        {
                            doc.Docno,
                            doc.CreationDate,
                            doc.CreatedBy,
                            v.VendorName,
                            doc.Status
                        }).Select(x => new ProcureVM()
                        {
                            Grno=x.Docno,
                            Createdon=(DateTime)x.CreationDate,
                            Createdby=x.CreatedBy,
                            VendorName=x.VendorName,
                            GeneratedDate=DateTime.Now.Date,
                            GRDetails=GetGrDetails(id)
                        }).FirstOrDefault();

            Report _report = new Report();
            byte[] abytes = _report.PrepareReport(data);
            return File(abytes, "application/pdf");
        }
        public List<ProcureVM> GetGrDetails(int? id)
        {
            ReqList li = new ReqList();
            DataSet ds = li.Show_griteminreport(id);
            List<ProcureVM> procure = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                procure.Add(new ProcureVM
                {
                    ItemType = dr["ItemType"].ToString(),
                    ItemName = dr["ItemName"].ToString(),                 
                    DeliveredQuantity = Convert.ToInt32(dr["DeliveredQuantity"])
                    
                });
            }
            return procure;

        }
        public ActionResult IRReport(int? id)
        {
            IProcure obj = new Procure();
            var data = (from ir in obj.Getir()
                        join doc in obj.GetDoc() on ir.GRReferenceNo equals doc.DocumentNo
                        join v in obj.GetVendor() on doc.VendorId equals v.VendorId
                        where ir.InvoiceReceiptId == id
                        select new
                        {
                           ir.InvoiceReceiptNo,
                           ir.Createdby,
                           ir.Createdon,
                           ir.Status,
                           ir.TotalAmount,
                           ir.PaidAmount,
                           ir.Balance,
                           v.VendorName

                        }).Select(x => new ProcureVM()
                        {
                            Grno = x.InvoiceReceiptNo,
                            Createdon = (DateTime)x.Createdon,
                            Createdby = x.Createdby,
                            VendorName = x.VendorName,
                            Total=(decimal)x.TotalAmount,
                            Paid =(decimal)x.PaidAmount,
                            Balance=(decimal)x.Balance,
                            status=x.Status,
                            IRDetails = GetIrDetails(id)
                        }).FirstOrDefault();

            Report _report = new Report();
            byte[] abytes = _report.PrepareIRReport(data);
            return File(abytes, "application/pdf");
        }
        public List<ProcureVM> GetIrDetails(int? id)
        {
            ReqList li = new ReqList();
            DataSet ds = li.Show_iritempriceinreport(id);
            List<ProcureVM> procure = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                procure.Add(new ProcureVM
                {
                    ItemName = dr["ItemName"].ToString(),
                    DeliveredQuantity = Convert.ToInt32(dr["DeliveredQuantity"]),
                    ItemPrice=Convert.ToDecimal(dr["ItemPrice"])
                });
            }
            return procure;

        }
        public ActionResult CreateGoodsIssue()
        {
            return View();
        }
        public ActionResult GetItemsonetimeList()
        {
            IProcure obj = new Procure();          
                   var Data = (from items in obj.Getitems()                              
                               where items.IsConsumable == 1
                               select new
                               {
                                   items.ItemName,
                                   items.Availablestock

                               }).Select(x => new
                               {
                                   x.ItemName,
                                   x.Availablestock

                               }).ToList();
            return Json(new {data=Data},JsonRequestBehavior.AllowGet);
        }
    }
}