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