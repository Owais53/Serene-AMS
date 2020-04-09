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

        public tblItem Additem(int Typeid, string itemname, string SL, int reorderpoint, decimal price)
        {
            var add = new tblItem()
            {
                ItemName=itemname,
                TypeId=Typeid,
                StorageLocation=SL,
                ReorderPoint=reorderpoint,
                ItemPrice=price,
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

        public tblDocument AddPowithref(int PRref,int vendorid)
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
            };
            return add;
        }

        public tblDocument Addpr()
        {
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();
            var add = new tblDocument()
            {
                DTypeId=1,
                CreationDate = DateTime.Now,
                CreatedBy = user,
                DocStatus="Complete",
                Status="Pending",

            };
            return add;
        }

        public tblDocDetail AddPrdetails(int prno, int itemid, int vendorid, DateTime? reqdate, int? qty, decimal? totalprice)
        {
            var add = new tblDocDetail()
            {
                DocumentNo=prno,
                ItemId=itemid,
                VendorId=vendorid,
                RequestedDate=reqdate,
                Quantity=qty,
                TotalPrice=totalprice,
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

        public tblprlineitem addprlineitem(string itype, string item, int qty, decimal price, string vendor, DateTime reqdate)
        {
            var add = new tblprlineitem()
            {
                ItemType=itype,
                ItemName=item,
                Quantity=qty,
                ItemPrice=price,
                VendorName=vendor,
                RequestedDate=reqdate,
                Status="Pending",
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

        public void SetVendorforItem(int detailid, int Itemid, int vendorid,DateTime deliverydate,int Poreference)
        {
            var obj = context.tblDocDetails.Where(x => x.Id == detailid).FirstOrDefault();
            obj.ItemId = Itemid;
            obj.VendorId = vendorid;
            obj.DeliveryDate = deliverydate;
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

        public void UpdateSL(int SLid, string city, string SL)
        {
            var obj = context.tblSLs.Find(SLid);
            obj.City = city;
            obj.StorageLocation = SL;
            context.Entry(obj).State = EntityState.Modified;
        }

        public void updatqty(int Id, string item, int qty,DateTime requesteddate)
        {
            var price = context.tblItems.Where(x => x.ItemName == item).FirstOrDefault();
            var obj = context.tblDocDetails.Where(x => x.Id == Id).FirstOrDefault();
            obj.Quantity = qty;
            obj.TotalPrice = qty * price.ItemPrice;
            obj.RequestedDate = requesteddate;
            context.Entry(obj).State = EntityState.Modified;
        }
    }
}