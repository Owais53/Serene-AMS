using Serene_AMS.DAL.Interface;
using Serene_AMS.Models;
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

        public tblItem Additem(string itemtype, string itemname, string SL, int reorderpoint, decimal price)
        {
            var add = new tblItem()
            {
                ItemName=itemname,
                ItemType=itemtype,
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

        public void UpdateItem(int ItemId, string ItemName, string ItemType,string SL, decimal ItemPrice, int Reorderpoint)
        {
            var obj = context.tblItems.Where(x => x.ItemId == ItemId).FirstOrDefault();
            obj.ItemName = ItemName;
            obj.ItemType = ItemType;
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
    }
}