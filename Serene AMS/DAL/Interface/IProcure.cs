using Serene_AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serene_AMS.DAL.Interface
{
    public interface IProcure
    {
        IEnumerable<tblSL> GetSL();
        void Save();
        tblSL AddSL(string city, string SL);
        void AddStore(tblSL obj);
        IEnumerable<tblItemType> Getitemtype();
        void AddTypes(tblItemType obj);
        tblItemType AddItemtype(string ItemType);
        IEnumerable<tblItem> Getitems();
        tblItem Additem(string itemtype,string itemname,string SL,int reorderpoint,decimal price);
        void Additems(tblItem obj);
        void UpdateSL(int SLid, string city, string SL);
        void UpdateItemType(int id,string itemtype);
        void UpdateItem(int ItemId,string ItemName,string ItemType,string SL,decimal ItemPrice,int Reorderpoint);
    }
}
