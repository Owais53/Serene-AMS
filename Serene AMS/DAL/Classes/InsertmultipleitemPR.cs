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