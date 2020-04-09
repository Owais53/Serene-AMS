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
        IEnumerable<tblVendor> GetVendor();
        IEnumerable<tblprlineitem> Getprline();
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
        void updatqty(int Id, string item, int qty,DateTime requesteddate);
        void updateDocstatus(int Docno);
        tblVendor addvendor(string name,string contact,int Itypeid,string address,string vtype);
        void Addvendors(tblVendor obj);
        void SetVendorforItem(int detailid,int Itemid,int vendorid,DateTime Deliverydate,int PoReference);
        tblDocument AddPowithref(int PRref,int vendorid);
        void AddPO(tblDocument obj);
        void setstatusonpocreate(int docnoofpr);
        tblDocument Addpr();
        tblDocDetail AddPrdetails(int prno,int itemid,int vendorid,DateTime? reqdate,int? qty,decimal? totalprice);
        void docdetails(tblDocDetail obj);
        void upatedocdetail(int doc,string prno);
        void updateduplicate(int doc, int itemid, int vendorid, int? qty, decimal? price, int prevqty, decimal prevprice);
        tblprlineitem addprlineitem(string itype,string item,int qty,decimal price,string vendor,DateTime reqdate);
        void Addprline(tblprlineitem obj);
    }
}
