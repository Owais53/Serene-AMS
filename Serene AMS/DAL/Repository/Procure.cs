using Serene_AMS.DAL.Interface;
using Serene_AMS.Models;
using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Serene_AMS.DAL.Repository
{
    public class Procure : IProcure
    {

        private HrmsEntities context;

        public Procure()
        {
            context = new HrmsEntities();

        }
        public Procure(HrmsEntities context)
        {
            context = this.context;
        }

        public tblDocument AddGr(int porefno,int vendor)
        {
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();
            var add = new tblDocument()
            {
                DTypeId=4,
                CreationDate=DateTime.Now.Date,
                CreatedBy=user,
                DocStatus="Complete",
                Status="Partial",
                VendorId=vendor,
                POReferenceno=porefno,
            };
            return add;
        }
        public tblDocument AddGrforReturn(int returnrefno, int vendor)
        {
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();
            var add = new tblDocument()
            {
                DTypeId = 4,
                CreationDate = DateTime.Now.Date,
                CreatedBy = user,
                DocStatus = "Complete",
                Status = "Partial",
                VendorId = vendor,
                ReturnReferenceno = returnrefno,
            };
            return add;
        }
        public tblDocument AddGrwithcomp(int porefno,int vendor)
        {
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();
            var add = new tblDocument()
            {
                DTypeId = 4,
                CreationDate = DateTime.Now.Date,
                CreatedBy = user,
                DocStatus = "Complete",
                Status = "Complete",
                VendorId=vendor,
                POReferenceno=porefno,

            };
            return add;
        }
        public tblDocument AddGrwithcompReturn(int returnrefno, int vendor)
        {
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();
            var add = new tblDocument()
            {
                DTypeId = 4,
                CreationDate = DateTime.Now.Date,
                CreatedBy = user,
                DocStatus = "Complete",
                Status = "Complete",
                VendorId = vendor,
                ReturnReferenceno = returnrefno,

            };
            return add;
        }
        public void addgr(tblDocument obj)
        {
            context.tblDocuments.Add(obj);
        }

        public tblItem Additem(int Typeid, string itemname, string SL,int isconsumable,int reorderpoint, decimal price)
        {
            var add = new tblItem()
            {
                ItemName=itemname,
                TypeId=Typeid,
                StorageLocation=SL,
                ReorderPoint=reorderpoint,
                IsConsumable=isconsumable,
                ItemPrice=price,
                Availablestock=0,
                Qualityinspectionstock=0,
            };
            return add;
        }

        public void Additems(tblItem obj)
        {
            context.tblItems.Add(obj);
        }

        public tblItemType AddItemtype(string ItemType)
        {
            var add = new tblItemType()
            {
                ItemType = ItemType
            };
            return add;
        }

        public void AddPO(tblDocument obj)
        {
            context.tblDocuments.Add(obj);
        }

        public tblDocument AddPowithref(int PRref,int vendorid,DateTime reqdate,DateTime deldate)
        {
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();
            var add = new tblDocument()
            {
                DTypeId = 3,
                CreationDate = DateTime.Now.Date,
                CreatedBy = user,
                DocStatus="Complete",
                PrReferenceNo=PRref,
                VendorId=vendorid,
                ItemRequestedDate=reqdate,
                DeliveryDate=deldate,
            };
            return add;
        }

        public tblDocument Addpr(DateTime reqdate)
        {
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();
            var add = new tblDocument()
            {
                DTypeId=1,
                CreationDate = DateTime.Now,
                CreatedBy = user,
                DocStatus="Complete",
                Status="Pending",
                ItemRequestedDate=reqdate,
               

            };
            return add;
        }

        public tblDocDetail AddPrdetails(int prno, int itemid, int vendorid, int? qty, decimal? totalprice)
        {
            var add = new tblDocDetail()
            {
                DocumentNo=prno,
                ItemId=itemid,
                VendorId=vendorid,
                Quantity=qty,
                TotalPrice=totalprice,
                PartialDeliveredQuantity=0,
                RemainingQuantity =-1,
            };
            return add;
        }

        public void AddPRItems(tblDocument obj)
        {
            context.tblDocuments.Add(obj);
        }

        public void Addprline(tblprlineitem obj)
        {
            context.tblprlineitems.Add(obj);
        }

        public tblprlineitem addprlineitem(string itype, string item, int qty, decimal price, string vendor)
        {
            var add = new tblprlineitem()
            {
                ItemType=itype,
                ItemName=item,
                Quantity=qty,
                ItemPrice=price,
                VendorName=vendor,
                Status="Pending",
                Date=DateTime.Now.Date,
            };
            return add;
        }

        public tblSL AddSL(string city, string SL)
        {
            var add = new tblSL()
            {
                City = city,
                StorageLocation=SL,

                
            };
            return add;
        }

        public void AddStore(tblSL obj)
        {
            context.tblSLs.Add(obj);
        }

        public void AddTypes(tblItemType obj)
        {
            context.tblItemTypes.Add(obj);
        }

        public tblVendor addvendor(string name, string contact, int Itypeid, string address, string vtype)
        {
            var add = new tblVendor()
            {
                VendorName=name,
                Contact=contact,
                TypeId=Itypeid,
                Address=address,
                VendorType=vtype,
            };
            return add;
        }

        public void Addvendors(tblVendor obj)
        {
            context.tblVendors.Add(obj);
        }

        public tblDocument CreatePRItems(ProcureVM model)
        {
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();
            var add = new tblDocument()
            {
                CreationDate = DateTime.Now,
                CreatedBy=user,
               
                
            };
            return add;
        }

        public void docdetails(tblDocDetail obj)
        {
            context.tblDocDetails.Add(obj);
        }

        public IEnumerable<tblDocument> GetDoc()
        {
            return context.tblDocuments;
        }

        public IEnumerable<tblDocDetail> GetDocDetail()
        {
            return context.tblDocDetails;
        }

        public IEnumerable<tblDoctype> GetDoctypes()
        {
            return context.tblDoctypes;
        }

        public IEnumerable<tblItem> Getitems()
        {
            return context.tblItems;
        }

        public IEnumerable<tblItemType> Getitemtype()
        {
            return context.tblItemTypes;
        }

        public IEnumerable<tblprlineitem> Getprline()
        {
            return context.tblprlineitems;
        }

        public IEnumerable<tblSL> GetSL()
        {
            return context.tblSLs;
        }

        public IEnumerable<tblVendor> GetVendor()
        {
            return context.tblVendors;
        }

        public void itemqtydelivered(int Prdocno, int itemid, int qty)
        {
            var obj = context.tblDocDetails.Where(x => x.DocumentNo == Prdocno && x.ItemId==itemid).FirstOrDefault();
            obj.DeliveredQuantity = qty;
            obj.RemainingQuantity = obj.Quantity - qty;
            context.Entry(obj).State = EntityState.Modified;
        }
        public void itemqtydeliveredreturn(int docno, int itemid, int qty)
        {
            var obj = context.tblreturnlineitems.Where(x => x.ReturnNo == docno && x.ItemId == itemid).FirstOrDefault();
            obj.ReturnQuantity = qty;
            obj.RemainingQuantity = obj.RejectedQuantity - qty;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void rejectpr(int id)
        {
            var obj = context.tblDocuments.Where(x => x.DocumentNo == id).FirstOrDefault();
            obj.Status = "Rejected";
            context.Entry(obj).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void setstatusonpocreate(int docnoofpr)
        {
            var obj = context.tblDocuments.Where(x => x.DocumentNo == docnoofpr).FirstOrDefault();
            obj.Status = "PO Created";
            context.Entry(obj).State = EntityState.Modified;

        }

        public void SetVendorforItem(int detailid, int Itemid, int vendorid,int Poreference)
        {
            var obj = context.tblDocDetails.Where(x => x.Id == detailid).FirstOrDefault();
            obj.ItemId = Itemid;
            obj.VendorId = vendorid;
            obj.POReference = Poreference;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void upatedocdetail(int doc, string prno)
        {
            var obj = context.tblDocuments.Where(x => x.DocumentNo == doc).FirstOrDefault();
            obj.Docno = prno;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void updateDocstatus(int Docno)
        {
           
            var obj = context.tblDocuments.Where(x => x.DocumentNo == Docno).FirstOrDefault();       
                obj.DocStatus = "Complete";
                context.Entry(obj).State = EntityState.Modified;
            
        }

        public void UpdateDocType(int Typeid, int DocNofrom, int DocNoto)
        {
            var obj = context.tblDoctypes.Where(x => x.TypeId == Typeid).FirstOrDefault();
            obj.NumberRangefrom = DocNofrom;
            obj.NumberRangeTo = DocNoto;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void updateduplicate(int doc, int itemid, int vendorid, int? qty, decimal? price, int prevqty, decimal prevprice)
        {
            var obj = context.tblDocDetails.Where(x => x.Id == doc && x.ItemId==itemid && x.VendorId==vendorid).FirstOrDefault();
            obj.Quantity =  obj.Quantity+ qty;
            obj.TotalPrice = obj.TotalPrice+ price;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void UpdateItem(int ItemId, string ItemName, int Typeid,string SL, decimal ItemPrice, int Reorderpoint)
        {
            var obj = context.tblItems.Where(x => x.ItemId == ItemId).FirstOrDefault();
            obj.ItemName = ItemName;
            obj.TypeId = Typeid;
            obj.StorageLocation = SL;
            obj.ItemPrice = ItemPrice;
            obj.ReorderPoint = Reorderpoint;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void UpdateItemType(int id, string itemtype)
        {
            var obj = context.tblItemTypes.Find(id);
            obj.ItemType = itemtype;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void updateprlineitem(string item, string vendor, int qty, decimal itemprice)
        {
            var obj = context.tblprlineitems.Where(x => x.ItemName == item && x.VendorName == vendor).FirstOrDefault();
            obj.Quantity = obj.Quantity + qty;
            obj.ItemPrice = obj.ItemPrice + itemprice;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void UpdateSL(int SLid, string city, string SL)
        {
            var obj = context.tblSLs.Find(SLid);
            obj.City = city;
            obj.StorageLocation = SL;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void updatestatuscomplete(int docno)
        {
            var obj = context.tblDocuments.Where(x => x.DocumentNo == docno).FirstOrDefault();
            obj.Status = "Complete Delivery";

            context.Entry(obj).State = EntityState.Modified;
        }

        public void updatestatuspartial(int docno)
        {
            var obj = context.tblDocuments.Where(x => x.DocumentNo == docno).FirstOrDefault();
            obj.Status = "Partial Delivery";
            
            context.Entry(obj).State = EntityState.Modified;
        }

        public void updatqty(int Id, string item, int qty)
        {
            var price = context.tblItems.Where(x => x.ItemName == item).FirstOrDefault();
            var obj = context.tblDocDetails.Where(x => x.Id == Id).FirstOrDefault();
            obj.Quantity = qty;
            obj.TotalPrice = qty * price.ItemPrice;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void vendorselect(int docno, int vendorid)
        {
            var obj = context.tblDocuments.Where(x => x.DocumentNo==docno).FirstOrDefault();
            obj.VendorId = vendorid;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void itempartialqtydelivered(int Prdocno, int itemid, int qty)
        {
            var checkstatus = context.tblDocuments.Where(x => x.PrReferenceNo == Prdocno && x.Status == "Partial Delivery").FirstOrDefault();
            if (checkstatus != null)
            {
                var obj = context.tblDocDetails.Where(x => x.DocumentNo == Prdocno && x.ItemId == itemid).FirstOrDefault();
                obj.DeliveredQuantity = obj.DeliveredQuantity + qty;
                obj.PartialDeliveredQuantity = qty;               
                obj.RemainingQuantity = obj.RemainingQuantity - qty;
                context.Entry(obj).State = EntityState.Modified;
            }
        }
        public void itempartialqtydeliveredreturn(int docno, int itemid, int qty)
        {
            var checkstatus = context.tblDocuments.Where(x => x.DocumentNo == docno && x.Status == "Partial Delivery").FirstOrDefault();
            if (checkstatus != null)
            {
                var obj = context.tblreturnlineitems.Where(x => x.ReturnNo == docno && x.ItemId == itemid).FirstOrDefault();
                obj.ReturnQuantity = obj.ReturnQuantity+ qty;
                obj.PartialReturnQuantity = qty;
                obj.RemainingQuantity = obj.RemainingQuantity - qty;
                context.Entry(obj).State = EntityState.Modified;
            }
        }

        public tblStock addslinstock(int slid)
        {
            var add = new tblStock()
            {
                SLId=slid,
                AvailableStock=0,
            };
            return add;
        }

        public void addstocksl(tblStock obj)
        {
            context.tblStocks.Add(obj);
        }

        public void updateitemstock(int itemid,int qty)
        {
            var obj = context.tblItems.Where(x => x.ItemId == itemid).FirstOrDefault();
            obj.Qualityinspectionstock = obj.Qualityinspectionstock + qty;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void updateslstock(int Slid,int qty)
        {
            var obj = context.tblStocks.Where(x => x.SLId == Slid).FirstOrDefault();
            obj.AvailableStock = obj.AvailableStock + qty;
            context.Entry(obj).State = EntityState.Modified;
        }

        public tblGrItemsPrice addGritemsPrice(int docno, int itemid, int deliveredqty)
        {
            var add = new tblGrItemsPrice()
            {
                DocumentNo=docno,
                ItemId=itemid,
                DeliveredQuantity=deliveredqty,
                ReturnQuantity=0,
                MissingQuantity=0,
                ApprovedQuantity=0,
                Approved="No",
            };
            return add;
        }

        public void addpriceofitems(tblGrItemsPrice obj)
        {
            context.tblGrItemsPrices.Add(obj);
        }

        public tblGrItemsPrice addPartialGritemsPrice(int docno, int itemid, int partialdeliveredqty)
        {
            var add = new tblGrItemsPrice()
            {
                DocumentNo = docno,
                ItemId = itemid,
                PartialDeliveredQuantity=partialdeliveredqty,

            };
            return add;
        }

        public void calculateitemprice(int docno, int itemid, decimal price)
        {
            var obj = context.tblGrItemsPrices.Where(x => x.ItemId == itemid && x.DocumentNo==docno).FirstOrDefault();
            obj.ItemPrice = obj.DeliveredQuantity * price;
            context.Entry(obj).State = EntityState.Modified;
        }
        public void updatestatusdoctorejected(int docno)
        {
            var obj = context.tblDocuments.Where(x => x.DocumentNo == docno).FirstOrDefault();
            obj.Status = "Rejected";
            context.Entry(obj).State = EntityState.Modified;
        }
        public tblInvoiceReceipt AddIR(int Grno, decimal total, decimal paid, decimal balance)
        {
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();
            var add = new tblInvoiceReceipt()
            {
               
                GRReferenceNo=Grno,
                TotalAmount=total,
                PaidAmount=paid,
                Balance=balance,
                Createdon=DateTime.Now.Date,
                Createdby=user,
                Status="Complete"
            };
            return add;
        }
        public tblInvoiceReceipt AddIRPartial(int Grno, decimal total, decimal paid, decimal balance)
        {
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();
            var add = new tblInvoiceReceipt()
            {
             
                GRReferenceNo = Grno,
                TotalAmount = total,
                PaidAmount = paid,
                Balance = balance,
                Createdon = DateTime.Now.Date,
                Createdby = user,
                Status = "Partial"
            };
            return add;
        }
        public void addInvoiceR(tblInvoiceReceipt obj)
        {
            context.tblInvoiceReceipts.Add(obj);
        }

        public void statuscompletepay(int Grno)
        {
            var obj = context.tblDocuments.Where(x => x.DocumentNo == Grno).FirstOrDefault();
            obj.Status = "Paid";
            context.Entry(obj).State = EntityState.Modified;
        }

        public void statuspartialpay(int Grno)
        {
            var obj = context.tblDocuments.Where(x => x.DocumentNo == Grno).FirstOrDefault();
            obj.Status = "Partially Paid";
            context.Entry(obj).State = EntityState.Modified;
        }

        public void getIRno(int IRid,string IRno)
        {
            var obj = context.tblInvoiceReceipts.Where(x => x.InvoiceReceiptId == IRid).FirstOrDefault();
            obj.InvoiceReceiptNo = IRno;
            context.Entry(obj).State = EntityState.Modified;
        }

        public IEnumerable<tblInvoiceReceipt> Getir()
        {
            return context.tblInvoiceReceipts;
        }

        public void updategrlineforrdquality(int Grno, int itemid, int qty)
        {
            var obj = context.tblGrItemsPrices.Where(x => x.DocumentNo==Grno && x.ItemId==itemid).FirstOrDefault();
            obj.ReturnQuantity = qty;
            obj.ApprovedQuantity = obj.DeliveredQuantity - qty;
            context.Entry(obj).State = EntityState.Modified;
        }

        public tblDocument Addrd(int vendorid, int grref, string reasonofreturn,DateTime dateofdev,int prref)
        {
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();
            var add = new tblDocument()
            {
              
                DTypeId=5,
                CreationDate=DateTime.Now.Date,
                CreatedBy=user,
                DocStatus="Complete",
                Status="InProgress",
                VendorId=vendorid,
                GRReferencenoforReturn=grref,
                Reasonofreturn=reasonofreturn,
                DeliveryDate=dateofdev,
                PrReferenceNo=prref,
            };
            return add;
        }

        public void updategrstatustoopen(int grno)
        {
            var obj = context.tblDocuments.Where(x => x.DocumentNo == grno).FirstOrDefault();
            obj.DocStatus = "Open";
            context.Entry(obj).State = EntityState.Modified;
        }

        public tblreturnlineitem Addreturn(int rno, int grno,int vendorid, int itemid, int dqty, int rqty, int Approvedbyqualityqty)
        {
            var add = new tblreturnlineitem()
            {
                ReturnNo=rno,
                Grreferenceno=grno,
                VendorId=vendorid,
                ItemId=itemid,
                DeliveredQuantity=dqty,
                RejectedQuantity=rqty,
                ApprovedQtybyQuality=Approvedbyqualityqty,
                MissingQuantity=0,
                AvailableQuantity=0,
                ReturnQuantity=0,
                PartialReturnQuantity=0,
                RemainingQuantity=-1,
                Approved="No",
            };
            return add;
        }

        public void addr(tblreturnlineitem obj)
        {
            context.tblreturnlineitems.Add(obj);
        }

        public void minusitemsfromqualitystock(int itemid, int rejectedquantity)
        {
            var obj = context.tblItems.Where(x => x.ItemId == itemid).FirstOrDefault();
            obj.Qualityinspectionstock = obj.Qualityinspectionstock-rejectedquantity;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void minusslstock(int Slid, int qty)
        {
            var obj = context.tblStocks.Where(x => x.SLId == Slid).FirstOrDefault();
            obj.AvailableStock = obj.AvailableStock - qty;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void addmissingquantityinreturnline(int Grno, int itemid, int qty)
        {
            var obj = context.tblreturnlineitems.Where(x => x.Grreferenceno == Grno && x.ItemId == itemid).FirstOrDefault();
            obj.MissingQuantity = qty;
            obj.AvailableQuantity = obj.ApprovedQtybyQuality - qty;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void addmissingqtyinGrline(int Grno, int itemid, int qty)
        {
            var obj = context.tblGrItemsPrices.Where(x => x.DocumentNo == Grno && x.ItemId == itemid).FirstOrDefault();
            obj.MissingQuantity = qty;
            obj.ApprovedQuantity = obj.DeliveredQuantity - qty;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void transferqualitystocktoavailable(int itemid, int qty)
        {
            var obj = context.tblItems.Where(x => x.ItemId == itemid).FirstOrDefault();
            obj.Qualityinspectionstock = obj.Qualityinspectionstock - qty;
            obj.Availablestock = obj.Availablestock + qty;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void ApproveGR(int Grno)
        {
            var obj = context.tblDocuments.Where(x => x.DocumentNo == Grno).FirstOrDefault();
            obj.GRApproved = "Yes";
            context.Entry(obj).State = EntityState.Modified;
        }

        public IEnumerable<tblreturnlineitem> Getreturnd()
        {
            return context.tblreturnlineitems;
        }
        public IEnumerable<tblGrItemsPrice> GetGrline()
        {
            return context.tblGrItemsPrices;
        }

        public void minusAvailablestock(int itemid, int qty)
        {
            var obj = context.tblItems.Where(x => x.ItemId == itemid).FirstOrDefault();
            obj.Availablestock = obj.Availablestock - qty;
            context.Entry(obj).State = EntityState.Modified;
        }

        public tblreturnlineitem Addreturnformissing(int rno, int grno, int vendorid, int itemid, int dqty, int rqty, int Approvedqty)
        {
            var add = new tblreturnlineitem()
            {
                ReturnNo = rno,
                Grreferenceno = grno,
                VendorId = vendorid,
                ItemId = itemid,
                DeliveredQuantity = dqty,
                RejectedQuantity = 0,
                ApprovedQtybyQuality = dqty,
                MissingQuantity = rqty,
                AvailableQuantity = Approvedqty,
            };
            return add;
        }

        public void updategrapprove(int grno, int itemid)
        {
            var obj = context.tblGrItemsPrices.Where(x => x.ItemId == itemid && x.DocumentNo==grno).FirstOrDefault();
            obj.Approved = "Yes";
            context.Entry(obj).State = EntityState.Modified;
        }

        public void updaterdapprove(int grno, int itemid)
        {
            var obj = context.tblreturnlineitems.Where(x => x.ItemId == itemid && x.Grreferenceno == grno).FirstOrDefault();
            obj.Approved = "Yes";
            context.Entry(obj).State = EntityState.Modified;
        }
    }
}