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

        public void AddPRItems(tblDocument obj)
        {
            context.tblDocuments.Add(obj);
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

        public IEnumerable<tblSL> GetSL()
        {
            return context.tblSLs;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void updateDocstatus(int Docno)
        {
           
            var obj = context.tblDocuments.Where(x => x.DocumentNo == Docno).FirstOrDefault();
            if (obj == null)
            {
                
            }
            else
            {
                obj.DocStatus = "Complete";
                context.Entry(obj).State = EntityState.Modified;
            }
        }

        public void UpdateDocType(int Typeid, int DocNofrom, int DocNoto)
        {
            var obj = context.tblDoctypes.Where(x => x.TypeId == Typeid).FirstOrDefault();
            obj.NumberRangefrom = DocNofrom;
            obj.NumberRangeTo = DocNoto;
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

        public void updatqty(int Id, string item, int qty)
        {
            var price = context.tblItems.Where(x => x.ItemName == item).FirstOrDefault();
            var obj = context.tblDocDetails.Where(x => x.Id == Id).FirstOrDefault();
            obj.Quantity = qty;
            obj.TotalPrice = qty * price.ItemPrice;
            context.Entry(obj).State = EntityState.Modified;
        }
    }
}