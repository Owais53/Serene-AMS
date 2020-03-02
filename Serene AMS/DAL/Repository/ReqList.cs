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

            SqlCommand com = new SqlCommand("select * from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status='Pending' and AuthorizedRole='"+role+"'", con);
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

            SqlCommand com = new SqlCommand("select * from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status!='Pending' and RequestId='" + req + "' and IsSeen='False'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet Show_Reqnoticount1()
        {
            var req = System.Web.HttpContext.Current.Session["RequestId"].ToString();

            SqlCommand com = new SqlCommand("select Count(*) as NotiCount from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status!='Pending' and RequestId='" + req + "' and IsSeen='False'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet Show_Reqnoticounts()
        {
            var req = System.Web.HttpContext.Current.Session["RequestId"].ToString();
            var roles = System.Web.HttpContext.Current.Session["RoleName"].ToString();
           
                SqlCommand com = new SqlCommand("select Totalcount = (select Count(*) as NotiCount from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status='Pending' and AuthorizedRole='" + roles + "') +(select Count(*) as NotiCount from tblRequests r Inner join tblEmployee emp on r.EmployeeId=emp.EmployeeId Inner join tblPosition pos on r.PositionId=pos.Id where Status!='Pending' and RequestId='" + req + "' and IsSeen='False')", con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            
           
        }
    }
}