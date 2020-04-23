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
        IEnumerable<tblInvoiceReceipt> Getir();
        IEnumerable<tblreturnlineitem> Getreturnd();
        IEnumerable<tblGrItemsPrice> GetGrline();

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
        void updatqty(int Id, string item, int qty);
        void updateDocstatus(int Docno);
        tblVendor addvendor(string name,string contact,int Itypeid,string address,string vtype);
        void Addvendors(tblVendor obj);
        void SetVendorforItem(int detailid,int Itemid,int vendorid,int PoReference);
        tblDocument AddPowithref(int PRref,int vendorid,DateTime reqdate,DateTime deldate);
        void AddPO(tblDocument obj);
        void setstatusonpocreate(int docnoofpr);
        tblDocument Addpr(DateTime reqdate);
        tblDocDetail AddPrdetails(int prno,int itemid,int vendorid,int? qty,decimal? totalprice);
        void docdetails(tblDocDetail obj);
        void upatedocdetail(int doc,string prno);
        void updateduplicate(int doc, int itemid, int vendorid, int? qty, decimal? price, int prevqty, decimal prevprice);
        tblprlineitem addprlineitem(string itype,string item,int qty,decimal price,string vendor);
        void Addprline(tblprlineitem obj);
        void updateprlineitem(string item, string vendor, int qty, decimal itemprice);
        void rejectpr(int id);
        void vendorselect(int docno, int vendorid);
        void itemqtydelivered(int Prdocno, int itemid, int qty);
        tblDocument AddGr(int porefno,int vendor);
        tblDocument AddGrwithcomp(int porefno, int vendor);

        void addgr(tblDocument obj);
        void updatestatuscomplete(int docno);
        void updatestatuspartial(int docno);
        void itempartialqtydelivered(int Prdocno, int itemid, int qty);
        tblStock addslinstock(int slid);
        void addstocksl(tblStock obj);
        void updateitemstock(int itemid,int qty);
        void updateslstock(int Slid,int qty);
        void minusslstock(int Slid, int qty);
        tblGrItemsPrice addGritemsPrice(int docno, int itemid, int deliveredqty);
        void addpriceofitems(tblGrItemsPrice obj);
        tblGrItemsPrice addPartialGritemsPrice(int docno, int itemid, int partialdeliveredqty);
        void calculateitemprice(int docno, int itemid, decimal price);
        tblInvoiceReceipt AddIR( int Grno, decimal total, decimal paid, decimal balance);
        tblInvoiceReceipt AddIRPartial(int Grno, decimal total, decimal paid, decimal balance);
        void addInvoiceR(tblInvoiceReceipt obj);
        void statuscompletepay(int Grno);
        void statuspartialpay(int Grno);
        void getIRno(int IRid,string IRno);
        void updategrlineforrdquality(int Grno,int itemid,int qty);
        tblDocument Addrd(int vendorid, int grref, string reasonofreturn);
        void updategrstatustoopen(int grno);
        tblreturnlineitem Addreturn(int rno, int grno,int vendorid, int itemid, int dqty, int rqty, int Approvedbyqualityqty);
        tblreturnlineitem Addreturnformissing(int rno, int grno, int vendorid, int itemid, int dqty, int rqty, int Approvedqty);
        void addr(tblreturnlineitem obj);
        void minusitemsfromqualitystock(int itemid,int rejectedquantity);
        void addmissingquantityinreturnline(int Grno, int itemid, int qty);
        void addmissingqtyinGrline(int Grno, int itemid, int qty);
        void transferqualitystocktoavailable(int itemid,int qty);
        void ApproveGR(int Grno);
        void minusAvailablestock(int itemid, int qty);
    }
}
