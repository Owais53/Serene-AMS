using Serene_AMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Serene_AMS.DAL.Classes
{
    public class InsertmultipleitemPR
    {
        public List<ProcureVM> getPODocData(int? Docno)
        {
            List<ProcureVM> a = new List<ProcureVM>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select doc.DocumentNo,doc.CreationDate,doc.CreatedBy,v.VendorName,v.Contact,v.Address from tblDocument doc inner join tblDocDetails det on doc.DocumentNo=det.POReference inner join tblVendors v on det.VendorId=v.VendorId where doc.DTypeId=3 and doc.DocumentNo=@id";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@id", Docno);

                SqlDataReader sdr = smd.ExecuteReader();
                while (sdr.Read())
                {
                    ProcureVM r = new ProcureVM();
                    r.DocNo = Convert.ToInt32(sdr["DocumentNo"]);
                    r.Createdon = Convert.ToDateTime(sdr["CreationDate"]).Date;
                    r.Createdby = sdr["CreatedBy"].ToString();
                    r.VendorName = sdr["VendorName"].ToString();
                    r.Contact = sdr["Contact"].ToString();
                    r.Address = sdr["Address"].ToString();
                    a.Add(r);
                }
                return a;
            }
        }
        public bool getItemName(string item)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select * from tblprlineitem";
                SqlCommand smd = new SqlCommand(s, con);
               

                SqlDataReader sdr = smd.ExecuteReader();
                while (sdr.Read())
                {
                    if (sdr[2].ToString() == item)
                    {
                        return true;
                        
                    }
                }
                
            }

            return false;
        }
        public bool getVendorName(string vendor)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select * from tblprlineitem";
                SqlCommand smd = new SqlCommand(s, con);


                SqlDataReader sdr = smd.ExecuteReader();
                while (sdr.Read())
                {
                    if (sdr[5].ToString() == vendor)
                    {
                        return true;

                    }
                }

            }

            return false;
        }
        public int getDocumentNo()
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT max(DocumentNo) FROM [Hrms].[dbo].[tblDocument]";
                SqlCommand smd = new SqlCommand(s, con);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getPrNo(int itemid,int vendorid,int doc)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT min(Id) FROM [Hrms].[dbo].[tblDocDetails] where DocumentNo=@doc and ItemId=@item and VendorId=@vendorid";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@doc", doc);
                smd.Parameters.AddWithValue("@item", itemid);
                smd.Parameters.AddWithValue("@vendorid", vendorid);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public void Removeprline(int id)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("DELETE FROM tblprlineitem WHERE Id=@ID", con))
                {
                    com.Parameters.AddWithValue("@ID", id);
                    com.ExecuteNonQuery();
                }
            }
        }
        public void Deleteprline()
        {           
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("DELETE FROM tblprlineitem WHERE Date<=@date", con))
                {
                    com.Parameters.AddWithValue("@date", DateTime.Now.Date);
                    com.ExecuteNonQuery();
                }
            }
        }
        public int getItemid(string item)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT ItemId FROM [Hrms].[dbo].[tblItem] Where ItemName=@item";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@item", item);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getminItemid(int no)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT min(ItemId) FROM [Hrms].[dbo].[tblItem] Where DocumentNo=@item";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@item", no);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getVendorId(string vendor)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT VendorId FROM [Hrms].[dbo].[tblVendors] Where VendorName=@vendor";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@vendor", vendor);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int checkduplicate(int docno,int itemid,int vendorid)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT ItemId FROM [Hrms].[dbo].[tblDocDetails] Where VendorId=@vendor and Documentno=@doc and ItemId=@item";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@vendor", vendorid);             
                smd.Parameters.AddWithValue("@doc", docno);
                smd.Parameters.AddWithValue("@item", itemid);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getqty(int docno, int itemid, int vendorid)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT Quantity FROM [Hrms].[dbo].[tblDocDetails] Where VendorId=@vendor and Documentno=@doc and ItemId=@item";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@vendor", vendorid);
                smd.Parameters.AddWithValue("@doc", docno);
                smd.Parameters.AddWithValue("@item", itemid);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public decimal getprice(int docno, int itemid, int vendorid)
        {
            decimal id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT TotalPrice FROM [Hrms].[dbo].[tblDocDetails] Where VendorId=@vendor and Documentno=@doc and ItemId=@item";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@vendor", vendorid);
                smd.Parameters.AddWithValue("@doc", docno);
                smd.Parameters.AddWithValue("@item", itemid);
                id = (decimal)smd.ExecuteScalar();

            }
            return id;
        }
        public decimal getTotalPrice(int qty,int item)
        {
            decimal id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT (@qty*ItemPrice) FROM [Hrms].[dbo].[tblItem] where ItemId=@item";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@qty", qty);
                smd.Parameters.AddWithValue("@item", item);
                id = (decimal)smd.ExecuteScalar();

            }
            return id;
        }
        public int getPODocNo()
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT max(doc.DocumentNo) FROM [Hrms].[dbo].[tblDocument] doc inner join tblDocDetails det on doc.PrReferenceNo=det.DocumentNo where doc.DTypeId = 3";
                SqlCommand smd = new SqlCommand(s, con);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getDetailsIdforPo(int Docno)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT max(Id) FROM [Hrms].[dbo].[tblDocDetails] where DocumentNo=@docno";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@docno", Docno);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public string getItemNameforPo(int Docno,int id)
        {
            string name;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT ItemName FROM [Hrms].[dbo].[tblDocDetails] where DocumentNo=@docno and ItemId IS NULL and Id=@id";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@docno", Docno);
                smd.Parameters.AddWithValue("@id", id);
                name = (string)smd.ExecuteScalar();

            }
            return name;
        }
        public int getVendorIdforPo(int Docno)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT min(VendorId) FROM [Hrms].[dbo].[tblDocDetails] where DocumentNo=@docno";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@docno", Docno);
                id = (int)smd.ExecuteScalar();
               
            }
            return id;
        }
        public int getIdforPo(int Docno)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT min(Id) FROM [Hrms].[dbo].[tblDocDetails] where DocumentNo=@docno";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@docno", Docno);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getDetailsId()
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT max(Id) FROM [Hrms].[dbo].[tblDocDetails] where Quantity=@qty";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@qty", 0);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public bool savePR(ProcureVM model)
        {
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "INSERT INTO [dbo].[tblDocument]([DTypeId],[CreationDate],[CreatedBy],[DocStatus],[Status],[ItemName]) VALUES (@DTypeId,@createdDate,@createdby,@docstatus,@status,@item)";
                SqlCommand smd = new SqlCommand(s, con);

                smd.Parameters.AddWithValue("@DTypeId", 1);
                smd.Parameters.AddWithValue("@createdDate", DateTime.Now);
                smd.Parameters.AddWithValue("@createdby", user);
                smd.Parameters.AddWithValue("@docstatus", "InComplete");
                smd.Parameters.AddWithValue("@status", "Pending");
                smd.Parameters.AddWithValue("@item", model.ItemsID);

                int x = smd.ExecuteNonQuery();
                if (x > 0)
                {
                    int rId = getDocumentNo();

                   
                        insertIntoCommonTable(model, rId);
                        return true;
                  
                }
                else
                {
                    return false;
                }
            }
        }
      
        public void insertIntoCommonTable(ProcureVM model, int DId)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                for (int i = 0; i < model.requestedMaterialArray.Length; i++)
                {
                    String s = "INSERT INTO [dbo].[tblDocDetails] ([DocumentNo],[ItemName],[Quantity],[TotalPrice]) VALUES (@Did,@m,@qty,@price)";
                    SqlCommand sd = new SqlCommand(s, con);
                    sd.Parameters.AddWithValue("@Did", DId);
                    sd.Parameters.AddWithValue("@m", model.requestedMaterialArray[i]);
                    sd.Parameters.AddWithValue("@qty", 0);
                    sd.Parameters.AddWithValue("@price", 0);
                    sd.ExecuteNonQuery();
                }
            }
        }


    }
}