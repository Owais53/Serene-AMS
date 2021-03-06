﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
 
namespace Serene_AMS.DAL.Repository
{
    public class ReqList
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);
       
        public DataSet Show_Reqnotidata()
        {
            var role = System.Web.HttpContext.Current.Session["RoleName"].ToString();

            SqlCommand com = new SqlCommand("select * from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status='Pending' and RequestType='Transfer' and AuthorizedRole='" + role+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_Reqnoticount()
        {
            var roles = System.Web.HttpContext.Current.Session["RoleName"].ToString();

            SqlCommand com = new SqlCommand("select Count(*) as NotiCount from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status='Pending' and AuthorizedRole='" + roles + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_Reqnotidata1()
        {
            var req = System.Web.HttpContext.Current.Session["RequestId"].ToString();

            SqlCommand com = new SqlCommand("select * from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status!='Pending' and RequestType='Transfer' and RequestId='" + req + "' and IsSeen='False'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet Show_Reqnoticount1()
        {
            var req = System.Web.HttpContext.Current.Session["RequestId"].ToString();

            SqlCommand com = new SqlCommand("select Count(*) as NotiCount from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status!='Pending' and RequestType='Transfer' and RequestId='" + req + "' and IsSeen='False'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_Reordernoticounts()
        {
            
            SqlCommand com = new SqlCommand("select Totalcount = (select Count(*) as NotiCount from tblItem where ReorderPoint>=Availablestock and IsConsumable=1)", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }
        public DataSet Show_Reqnoticounts()
        {
            var req = System.Web.HttpContext.Current.Session["RequestId"].ToString();
            var roles = System.Web.HttpContext.Current.Session["RoleName"].ToString();
            var emp = System.Web.HttpContext.Current.Session["EmployeeId"].ToString();

            SqlCommand com = new SqlCommand("select Totalcount = (select Count(*) as NotiCount from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status='Pending' and RequestType='Transfer' and AuthorizedRole='" + roles + "') +(select Count(*) as NotiCount from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status!='Pending' and RequestType='Transfer' and RequestId='" + req + "' and IsSeen='False')+(select Count(*) as NotiCount from tblEmployee emp inner join tblEmployeeDetail det on emp.EmployeeId=det.EmployeeId inner join tblPosition pos on emp.PositionId=pos.Id where emp.EmployeeId=" + emp + " and det.IsSalaryset='True' and det.IsSeenPromotion='False')+(select Count(*) as NotiCount from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status='Pending' and RequestType='Leave' and AuthorizedRole='" + roles + "')+(select COUNT(*) as NotiCount from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status!='Pending' and RequestType='Leave' and r.EmployeeId='" + emp + "' and IsSeen='False')", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }
        public DataSet Show_Emppronoti()
        {
            var emp = System.Web.HttpContext.Current.Session["EmployeeId"].ToString();

            SqlCommand com = new SqlCommand("select * from tblEmployee emp inner join tblEmployeeDetail det on emp.EmployeeId=det.EmployeeId inner join tblPosition pos on emp.PositionId=pos.Id where emp.EmployeeId='"+emp+"' and det.IsSalaryset='True' and det.IsSeenPromotion='False'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_Reorderpointnoti()
        {
            
            SqlCommand com = new SqlCommand("select * from tblItem where ReorderPoint>=Availablestock and IsConsumable=1", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_Reqleavenoti()
        {
            var role = System.Web.HttpContext.Current.Session["RoleName"].ToString();

            SqlCommand com = new SqlCommand("select * from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status='Pending' and RequestType='Leave' and AuthorizedRole='" + role + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_Reqleavenotires()
        {
            
            var req = System.Web.HttpContext.Current.Session["EmployeeId"].ToString();

            SqlCommand com = new SqlCommand("select * from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status!='Pending' and RequestType='Leave' and r.EmployeeId='" + req + "' and IsSeen='False'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_PRItemsdata(int Docno)
        {
           
            SqlCommand com = new SqlCommand("select doc.DocumentNo,doc.Docno,item.ItemName,det.Quantity,v.VendorName,doc.ItemRequestedDate from tblDocument doc inner join tblDocDetails det on doc.DocumentNo=det.DocumentNo inner join tblItem item on det.ItemId=item.ItemId inner join tblVendors v on det.VendorId=v.VendorId where doc.DocumentNo='" +Docno+ "' and doc.Status='Pending' ", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet DonotShow_PRItemsdata(int Docno)
        {

            SqlCommand com = new SqlCommand("select doc.DocumentNo,doc.Docno,item.ItemName,det.Quantity,v.VendorName,doc.ItemRequestedDate from tblDocument doc inner join tblDocDetails det on doc.DocumentNo=det.DocumentNo inner join tblItem item on det.ItemId=item.ItemId inner join tblVendors v on det.VendorId=v.VendorId where doc.DocumentNo!='" + Docno + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_PRlineitem()
        {

            SqlCommand com = new SqlCommand("select Id,ItemType,ItemName,Quantity,ItemPrice,VendorName from tblprlineitem where Status='Pending' ", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_iteminddl(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemId,i.ItemName from tblDocDetails d inner join tblItem i on d.ItemId=i.ItemId where d.DocumentNo="+id+" and (DeliveredQuantity IS NULL or RemainingQuantity>0)", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_returniteminddl(int? id)
        {

            SqlCommand com = new SqlCommand("select r.ItemId,i.ItemName from tblreturnlineitem r inner join tblItem i on r.ItemId=i.ItemId where ReturnNo="+id+"", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_returniteminddlPartial(int? id)
        {

            SqlCommand com = new SqlCommand("select r.ItemId,i.ItemName from tblreturnlineitem r inner join tblItem i on r.ItemId=i.ItemId where ReturnNo=" + id + " and RemainingQuantity>0", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet NotShow_iteminddl(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemId,i.ItemName from tblDocDetails d inner join tblItem i on d.ItemId=i.ItemId where d.DocumentNo!=" + id + " and (DeliveredQuantity IS NULL or RemainingQuantity>0)", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_itemDataingrid(int? id)
        {

            SqlCommand com = new SqlCommand("select t.ItemType,i.ItemName,d.Quantity from tblDocument doc inner join tblDocDetails d on doc.PrReferenceNo=d.DocumentNo inner join tblItem i on d.ItemId=i.ItemId inner join tblItemType t on i.TypeId=t.Id where d.DocumentNo="+id+ " and doc.Status IS NULL and (d.DeliveredQuantity IS NULL or RemainingQuantity!=0)", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Remove_itemDataingrid(int? id)
        {

            SqlCommand com = new SqlCommand("select t.ItemType,i.ItemName,d.Quantity from tblDocument doc inner join tblDocDetails d on doc.PrReferenceNo=d.DocumentNo inner join tblItem i on d.ItemId=i.ItemId inner join tblItemType t on i.TypeId=t.Id where d.DocumentNo!="+id+" and doc.Status IS NULL and (d.DeliveredQuantity IS NULL or RemainingQuantity!=0)", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_QtyDataingrid(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,d.DeliveredQuantity,d.RemainingQuantity from tblDocDetails d inner join tblItem i on d.ItemId=i.ItemId where d.DocumentNo="+id+" and d.DeliveredQuantity IS NOT NULL", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_QtyDataingridReturn(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,d.ReturnQuantity,d.RemainingQuantity from tblreturnlineitem d inner join tblItem i on d.ItemId=i.ItemId where d.ReturnNo=" + id + " and d.ReturnQuantity>=0 and d.RemainingQuantity>=0", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_QtyRejectedDataingrid(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,d.ReturnQuantity,d.ApprovedQuantity from tblGrItemsPrice d inner join tblItem i on d.ItemId=i.ItemId where d.DocumentNo=" + id + "", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_QtyMissingDataingrid(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,d.MissingQuantity,d.ApprovedQuantity from tblGrItemsPrice d inner join tblItem i on d.ItemId=i.ItemId where d.DocumentNo=" + id + "", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_QtyMissingDataingridforrdm(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,d.MissingQuantity,d.AvailableQuantity from tblreturnlineitem d inner join tblItem i on d.ItemId=i.ItemId where d.Grreferenceno=" + id + "", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet Show_QtyDataingridpartial(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,d.PartialDeliveredQuantity,d.RemainingQuantity from tblDocDetails d inner join tblItem i on d.ItemId=i.ItemId where d.DocumentNo=" + id + " and d.PartialDeliveredQuantity IS NOT NULL", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_QtyDataingridpartialReturn(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,d.PartialReturnQuantity,d.RemainingQuantity from tblreturnlineitem d inner join tblItem i on d.ItemId=i.ItemId where d.ReturnNo=" + id + " and d.PartialReturnQuantity>=0 and d.RemainingQuantity>=0", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
      
        public DataSet Show_QtyPartialDataingrid(int? id)
        {

            SqlCommand com = new SqlCommand("select t.ItemType,i.ItemName,d.RemainingQuantity from tblDocument doc inner join tblDocDetails d on doc.PrReferenceNo=d.DocumentNo inner join tblItem i on d.ItemId=i.ItemId inner join tblItemType t on i.TypeId=t.Id where d.DocumentNo="+id+ " and doc.Status='Partial Delivery' and RemainingQuantity>0", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet NotShow_QtyPartialDataingrid(int? id)
        {

            SqlCommand com = new SqlCommand("select t.ItemType,i.ItemName,d.RemainingQuantity from tblDocument doc inner join tblDocDetails d on doc.PrReferenceNo=d.DocumentNo inner join tblItem i on d.ItemId=i.ItemId inner join tblItemType t on i.TypeId=t.Id where d.DocumentNo!=" + id + " and doc.Status='Partial Delivery' and RemainingQuantity>0", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_itempriceofgringrid(int? id)
        {

            SqlCommand com = new SqlCommand("select t.ItemType,i.ItemName,d.Quantity from tblDocument doc inner join tblDocDetails d on doc.PrReferenceNo=d.DocumentNo inner join tblItem i on d.ItemId=i.ItemId inner join tblItemType t on i.TypeId=t.Id where d.DocumentNo=" + id + " and doc.Status IS NULL and (d.DeliveredQuantity IS NULL or RemainingQuantity!=0)", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_gritemininvoicegrid(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,p.DeliveredQuantity,p.ItemPrice from tblGritemsPrice p inner join tblItem i on p.ItemId=i.ItemId where p.DocumentNo="+id+"", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_griteminreport(int? id)
        {

            SqlCommand com = new SqlCommand("select t.ItemType,i.ItemName,p.DeliveredQuantity,p.ItemPrice from tblGrItemsPrice p inner join tblItem i on p.ItemId=i.ItemId inner join tblItemType t on i.TypeId=t.Id where DocumentNo="+id+"", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_iritempriceinreport(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,gr.DeliveredQuantity,gr.ItemPrice from tblInvoiceReceipt ir inner join tblGrItemsPrice gr on ir.GRReferenceNo=gr.DocumentNo inner join tblItem i on gr.ItemId=i.ItemId where ir.InvoiceReceiptId="+id+"", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_returniteminreport(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,r.DeliveredQuantity,r.RejectedQuantity from tblreturnlineitem r inner join tblItem i on r.ItemId=i.ItemId where ReturnNo="+id+"", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_priteminreport(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,r.Quantity,r.TotalPrice from tblDocDetails r inner join tblItem i on r.ItemId=i.ItemId where DocumentNo=" + id + "", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_poiteminreport(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,r.Quantity,r.TotalPrice from tblDocDetails r inner join tblItem i on r.ItemId=i.ItemId where DocumentNo=" + id + "", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Remove_gritemininvoicegrid(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,p.DeliveredQuantity,p.ItemPrice from tblGritemsPrice p inner join tblItem i on p.ItemId=i.ItemId where p.DocumentNo!=" + id + "", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_GRdataforrd(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,gr.DeliveredQuantity from tblGrItemsPrice gr inner join tblItem i on gr.ItemId=i.ItemId where DocumentNo=" + id + "", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Remove_GRdataforrd(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,gr.DeliveredQuantity from tblGrItemsPrice gr inner join tblItem i on gr.ItemId=i.ItemId where DocumentNo=" + id + " and gr.Approved='Yes'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_GRdataforrdm(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,rd.ApprovedQtybyQuality from tblreturnlineitem rd inner join tblitem i on rd.ItemId=i.ItemId where Grreferenceno="+id+" and rd.Approved='No'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_ReturndataforGR(int? id)
        {

            SqlCommand com = new SqlCommand("select t.ItemType,i.ItemName,r.RejectedQuantity from tblreturnlineitem r inner join tblItem i on r.ItemId=i.ItemId inner join tblItemType t on i.TypeId=t.Id where ReturnNo="+id+"", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_ReturndataforGRPartial(int? id)
        {

            SqlCommand com = new SqlCommand("select t.ItemType,i.ItemName,r.RemainingQuantity from tblreturnlineitem r inner join tblItem i on r.ItemId=i.ItemId inner join tblItemType t on i.TypeId=t.Id where ReturnNo=" + id + " and RemainingQuantity>0", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Remove_GRdataforrdm(int? id)
        {

            SqlCommand com = new SqlCommand("select i.ItemName,rd.ApprovedQtybyQuality from tblreturnlineitem rd inner join tblitem i on rd.ItemId=i.ItemId where Grreferenceno=" + id + " and rd.Approved='Yes'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_GRdataforrdddl(int? id)
        {

            SqlCommand com = new SqlCommand("select gr.ItemId,i.ItemName from tblGrItemsPrice gr inner join tblItem i on gr.ItemId=i.ItemId where DocumentNo=" + id + "", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_GRdataforrdmddl(int? id)
        {

            SqlCommand com = new SqlCommand("select r.ItemId,i.ItemName from tblreturnlineitem r inner join tblItem i on r.ItemId=i.ItemId where Grreferenceno="+id+"", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Get_Expenses()
        {

            SqlCommand com = new SqlCommand("select Sum(Amount) as Total from tblExpenses", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Get_Years()
        {

            SqlCommand com = new SqlCommand("select Year from tblExpenses group by Year", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Get_Months(int? y)
        {
            if (y == null || y == 0)
            {

                var year = DateTime.Now.Year;
                SqlCommand com = new SqlCommand("SELECT Sum(Amount) as Total,MONTH(ExpenseDate) [month] FROM tblExpenses WHERE YEAR(ExpenseDate) = " + year + " GROUP BY MONTH(ExpenseDate) ORDER BY [month];", con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            else
            {
                var year = DateTime.Now.Year;
                SqlCommand com = new SqlCommand("SELECT Sum(Amount) as Total,MONTH(ExpenseDate) [month] FROM tblExpenses WHERE YEAR(ExpenseDate) = " + y + " GROUP BY MONTH(ExpenseDate) ORDER BY [month];", con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet Get_TotalStock()
        {         
                var year = DateTime.Now.Year;
                SqlCommand com = new SqlCommand("select ItemName,Availablestock,Qualityinspectionstock,ReorderPoint from tblItem", con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            
        }

    }
}