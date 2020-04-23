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
    public class ReturnController : Controller
    {
        IProcure obj = new Procure();
        InsertmultipleitemPR db = new InsertmultipleitemPR();
        public ActionResult ReturnDelivery()
        {
            return View();
        }
        public JsonResult GetGrList()
        {
            var Data = (from doc in obj.GetDoc()
                        join v in obj.GetVendor() on doc.VendorId equals v.VendorId
                        join t in obj.GetDoctypes() on doc.DTypeId equals t.TypeId
                        where doc.DTypeId == 4 && doc.DocStatus=="Complete"                           
                        select new
                        {
                            doc.Docno,
                            doc.DocumentNo,
                            t.DocumentType,
                            v.VendorName

                        }).ToList();

            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetGrListformissingitem()
        {
            var Data = (from doc in obj.GetDoc()
                        join v in obj.GetVendor() on doc.VendorId equals v.VendorId
                        join t in obj.GetDoctypes() on doc.DTypeId equals t.TypeId
                        where doc.DTypeId == 4 && (doc.DocStatus=="Open"||doc.DocStatus=="Complete")
                        select new
                        {
                            doc.Docno,
                            doc.DocumentNo,
                            t.DocumentType,
                            v.VendorName

                        }).ToList();

            return Json(new { data = Data }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateReturnDelivery(int? id)
        {


            var levellist = new SelectList(new[]
        {
                new {ID="1",Name="Bad Quality"},
                new {ID="2",Name="Damaged Goods"}


            },
         "Name", "Name", "1"
          );
            ViewBag.getreasonlist = levellist;

            var Data = (from doc in obj.GetDoc()
                        join v in obj.GetVendor() on doc.VendorId equals v.VendorId
                        join d in obj.GetDoc() on doc.POReferenceno equals d.DocumentNo
                        where doc.DTypeId == 4 && doc.DocumentNo == id
                        select new
                        {
                            doc.Docno,
                            doc.POReferenceno,
                            doc.VendorId,
                            v.VendorName,
                            doc.DocumentNo,
                            d.PrReferenceNo,
                        }).Select(x => new ProcureVM()
                        {
                            Grno = x.Docno,
                            DocNo = x.DocumentNo,
                            VendorName = x.VendorName,
                            VendorId = (int)x.VendorId,
                            Poreferenceno = (int)x.POReferenceno,
                            Prreferenceno = (int)x.PrReferenceNo
                        }).FirstOrDefault();
            return View(Data);
        }

        public ActionResult GetGRDataforReturn(int id)
        {


            ReqList li = new ReqList();
            DataSet ds = li.Show_GRdataforrd(id);
            List<ProcureVM> list = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ProcureVM
                {
                    ItemName = dr["ItemName"].ToString(),
                    Quantity = Convert.ToInt32(dr["DeliveredQuantity"])
                });
            }


            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetGRDataforReturnddl(int id)
        {

            ReqList li = new ReqList();
            DataSet ds = li.Show_GRdataforrdddl(id);
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
        public ActionResult GetQuantityDataforrd(int id)
        {

            ReqList li = new ReqList();
            DataSet ds = li.Show_QtyRejectedDataingrid(id);
            List<ProcureVM> list = new List<ProcureVM>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ProcureVM
                {
                    ItemName = dr["ItemName"].ToString(),
                    RejectedQuantity = Convert.ToInt32(dr["ReturnQuantity"]),
                    ApprovedQuantity = Convert.ToInt32(dr["ApprovedQuantity"])
                });
            }


            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PostQuantityItemsRejected(int GrDocno, int item, int qty)
        {
            IProcure obj = new Procure();
            if (item == 0)
            {
                return Json(new { message="Please Add Quantity greater than zero"},JsonRequestBehavior.AllowGet);
            }
            else
            {


                obj.updategrlineforrdquality(GrDocno, item, qty);
                obj.Save();

                return Json(JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult PostRDwithstatus(int Docno, int vendor,string Grno,string reasonofr, List<ProcureVM> rdlists)
        {
           
            NumberSequence seq = new NumberSequence();
              if (rdlists == null)
            {
                rdlists = new List<ProcureVM>();
                return Json(new { code = 0, message = "Please add Rejected Quantity before Submitting" }, JsonRequestBehavior.AllowGet);
            }
           
                if (rdlists == null)
                {
                    rdlists = new List<ProcureVM>();

                }
            var check = obj.GetDoc().Where(x => x.DocumentNo == Docno && x.DocStatus == "Open").FirstOrDefault();
            if (check == null)
            {

                var add = obj.Addrd(vendor, Docno, reasonofr);
                obj.addgr(add);
                obj.Save();
                string no = seq.GenerateNo("Return", add.DocumentNo);
                obj.upatedocdetail(add.DocumentNo, no);
                obj.Save();
                obj.updategrstatustoopen(Docno);
                obj.Save();

                foreach (ProcureVM rd in rdlists)
                {
                    if (rd.RejectedQuantity > 0)
                    {
                        var addetails = obj.Addreturn(add.DocumentNo, Docno, vendor, db.getItemid(rd.ItemName), rd.DeliveredQuantity, rd.RejectedQuantity, rd.ApprovedQuantity);
                        obj.addr(addetails);
                        obj.Save();
                        obj.minusslstock(db.getSlid(rd.ItemName), rd.RejectedQuantity);
                        obj.Save();
                        obj.minusitemsfromqualitystock(db.getItemid(rd.ItemName), rd.RejectedQuantity);
                        obj.Save();
                    }
                }
                return Json(new {message="Return Delivery created with "+add.Docno+" and "+Grno+" Status changed to Open" },JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { message="Return Delivery already created for "+Grno+""},JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ApproveItems()
        {
            return View();
        }
        public ActionResult TransferStocktoAvailable(int? id)
        {
           
                var Data = (from doc in obj.GetDoc()
                            join v in obj.GetVendor() on doc.VendorId equals v.VendorId
                            join d in obj.GetDoc() on doc.POReferenceno equals d.DocumentNo
                            where doc.DTypeId == 4 && doc.DocumentNo == id
                            select new
                            {
                               
                                doc.Docno,
                                doc.POReferenceno,
                                doc.VendorId,
                                v.VendorName,
                                doc.DocumentNo,
                                d.PrReferenceNo,
                                
                                
                            }).Select(x => new ProcureVM()
                            {
                                Grno = x.Docno,
                                DocNo = x.DocumentNo,
                                VendorName = x.VendorName,
                                VendorId = (int)x.VendorId,
                                Poreferenceno = (int)x.POReferenceno,
                                Prreferenceno = (int)x.PrReferenceNo
                            }).FirstOrDefault();
                return View(Data);
            
           
        }
        public JsonResult GetReturnNo(int id)
        {
            var checkStatusofGr = obj.GetDoc().Where(x => x.DocumentNo == id && x.DocStatus == "Open").FirstOrDefault();
            if (checkStatusofGr != null)
            {
                return Json(db.getReturnNo(id), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetGRDataforReturnddlforrdm(int id)
        {
            var checkStatusofGr = obj.GetDoc().Where(x => x.DocumentNo == id && x.DocStatus == "Open").FirstOrDefault();
            if (checkStatusofGr != null)
            {
                ReqList li = new ReqList();
                DataSet ds = li.Show_GRdataforrdmddl(id);
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
            else
            {

                ReqList li = new ReqList();
                DataSet ds = li.Show_GRdataforrdddl(id);
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
        }
        public ActionResult GetGRDataforReturnforrdm(int id)
        {
            var checkStatusofGr = obj.GetDoc().Where(x => x.DocumentNo == id && x.DocStatus == "Open").FirstOrDefault();
            if (checkStatusofGr != null)
            {
                ReqList li = new ReqList();
                DataSet ds = li.Show_GRdataforrdm(id);
                List<ProcureVM> list = new List<ProcureVM>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new ProcureVM
                    {
                        ItemName = dr["ItemName"].ToString(),
                        Quantity = Convert.ToInt32(dr["ApprovedQtybyQuality"])
                    });
                }


                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {


                ReqList li = new ReqList();
                DataSet ds = li.Show_GRdataforrd(id);
                List<ProcureVM> list = new List<ProcureVM>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new ProcureVM
                    {
                        ItemName = dr["ItemName"].ToString(),
                        Quantity = Convert.ToInt32(dr["DeliveredQuantity"])
                    });
                }


                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetQuantityDataforrdm(int id)
        {

            var checkStatusofGr = obj.GetDoc().Where(x => x.DocumentNo == id && x.DocStatus == "Open").FirstOrDefault();
            if (checkStatusofGr != null)
            {
                ReqList li = new ReqList();
                DataSet ds = li.Show_QtyMissingDataingridforrdm(id);
                List<ProcureVM> list = new List<ProcureVM>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new ProcureVM
                    {
                        ItemName = dr["ItemName"].ToString(),
                        RejectedQuantity = Convert.ToInt32(dr["MissingQuantity"]),
                        ApprovedQuantity = Convert.ToInt32(dr["AvailableQuantity"])
                    });
                }


                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {


                ReqList li = new ReqList();
                DataSet ds = li.Show_QtyMissingDataingrid(id);
                List<ProcureVM> list = new List<ProcureVM>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new ProcureVM
                    {
                        ItemName = dr["ItemName"].ToString(),
                        RejectedQuantity = Convert.ToInt32(dr["MissingQuantity"]),
                        ApprovedQuantity = Convert.ToInt32(dr["ApprovedQuantity"])
                    });
                }


                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult PostQuantityItemsMissing(int GrDocno,int item,int qty)
        {
            var checkStatusofGr = obj.GetDoc().Where(x => x.DocumentNo == GrDocno && x.DocStatus == "Open").FirstOrDefault();
            if (checkStatusofGr != null)
            {
                obj.addmissingquantityinreturnline(GrDocno,item,qty);
                obj.Save();
            }
            else
            {
                obj.addmissingqtyinGrline(GrDocno,item,qty);
                obj.Save();
            }

            return Json(JsonRequestBehavior.AllowGet);
        }
      public JsonResult PostRDMwithstatus(int Docno,string Grno,int vendor,List<ProcureVM> objlists)
        {
            if (objlists == null)
            {
                objlists = new List<ProcureVM>();
            }
            foreach (ProcureVM obj in objlists)
            {
                return Json(new { message = ""+obj.Item+"and "+obj.Quantity+"" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { message=""},JsonRequestBehavior.AllowGet);
        }
    }
}

