using System;
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

        public DataSet Show_Reqnoticounts()
        {
            var req = System.Web.HttpContext.Current.Session["RequestId"].ToString();
            var roles = System.Web.HttpContext.Current.Session["RoleName"].ToString();
            var emp = System.Web.HttpContext.Current.Session["EmployeeId"].ToString();

            SqlCommand com = new SqlCommand("select Totalcount = (select Count(*) as NotiCount from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status='Pending' and RequestType='Transfer' and AuthorizedRole='" + roles + "') +(select Count(*) as NotiCount from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status!='Pending' and RequestType='Transfer' and RequestId='" + req + "' and IsSeen='False')+(select Count(*) as NotiCount from tblEmployee emp inner join tblEmployeeDetail det on emp.EmployeeId=det.EmployeeId inner join tblPosition pos on emp.PositionId=pos.Id where emp.EmployeeId=" + emp + " and det.IsSalaryset='True' and det.IsSeenPromotion='False')+(select Count(*) as NotiCount from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status='Pending' and RequestType='Leave' and AuthorizedRole='" + roles + "')+(select COUNT(*) as NotiCount from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status!='Pending' and RequestType='Leave' and RequestId='" + req + "' and IsSeen='False')", con);
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
            
            var req = System.Web.HttpContext.Current.Session["RequestId"].ToString();

            SqlCommand com = new SqlCommand("select * from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status!='Pending' and RequestType='Leave' and RequestId='" + req + "' and IsSeen='False'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_PRItemsdata(int Docno)
        {
           
            SqlCommand com = new SqlCommand("select doc.DocumentNo,doc.Docno,item.ItemName,det.Quantity,v.VendorName,det.RequestedDate from tblDocument doc inner join tblDocDetails det on doc.DocumentNo=det.DocumentNo inner join tblItem item on det.ItemId=item.ItemId inner join tblVendors v on det.VendorId=v.VendorId where doc.DocumentNo='" +Docno+ "' and doc.Status='Pending' ", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet DonotShow_PRItemsdata(int Docno)
        {

            SqlCommand com = new SqlCommand("select doc.DocumentNo,doc.Docno,item.ItemName,det.Quantity,v.VendorName,det.RequestedDate from tblDocument doc inner join tblDocDetails det on doc.DocumentNo=det.DocumentNo inner join tblItem item on det.ItemId=item.ItemId inner join tblVendors v on det.VendorId=v.VendorId where doc.DocumentNo!='" + Docno + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_PRlineitem()
        {

            SqlCommand com = new SqlCommand("select Id,ItemType,ItemName,Quantity,ItemPrice,VendorName,RequestedDate from tblprlineitem where Status='Pending' ", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


    }
}