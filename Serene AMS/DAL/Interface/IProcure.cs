using Serene_AMS.Models;
using Serene_AMS.ViewModels;
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
        IEnumerable<tblDocument> GetDoc();
        IEnumerable<tblDocDetail> GetDocDetail();
        void AddTypes(tblItemType obj);
        tblItemType AddItemtype(string ItemType);
        IEnumerable<tblItem> Getitems();
        tblItem Additem(int typeid,string itemname,string SL,int reorderpoint,decimal price);
        void Additems(tblItem obj);
        void UpdateSL(int SLid, string city, string SL);
        void UpdateItemType(int id,string itemtype);
        void UpdateItem(int ItemId,string ItemName,int id,string SL,decimal ItemPrice,int Reorderpoint);
        IEnumerable<tblDoctype> GetDoctypes();
        void UpdateDocType(int Typeid,int DocNofrom,int DocNoto);
        tblDocument CreatePRItems(ProcureVM model);
        void AddPRItems(tblDocument obj);
    }
}
