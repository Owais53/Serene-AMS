using Serene_AMS.DAL.Interface;
using Serene_AMS.DAL.Repository;
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
        public bool getRemainingQty(int docno)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select RemainingQuantity from tblDocDetails where DocumentNo="+docno+"";
                SqlCommand smd = new SqlCommand(s, con);


                SqlDataReader sdr = smd.ExecuteReader();
                while (sdr.Read())
                {
                   

                    if (Convert.ToInt32(sdr[0]) > 0)
                    {
                        return true;

                    }
                  
                }

            }

            return false;
        }
        public bool getRemainingQtyforReturn(int docno)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select RemainingQuantity from tblreturnlineitem where ReturnNo=" + docno + "";
                SqlCommand smd = new SqlCommand(s, con);


                SqlDataReader sdr = smd.ExecuteReader();
                while (sdr.Read())
                {


                    if (Convert.ToInt32(sdr[0]) > 0)
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
        public int getDocTypeId(int docno)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT DTypeId FROM [Hrms].[dbo].[tblDocument] where DocumentNo=@docno";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@docno", docno);

                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getEmpcount()
        {
            IEmployeeRepository obj = new EmployeeRepository();

            
            
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT Count(*) FROM [Hrms].[dbo].[tblEmployee]";
                SqlCommand smd = new SqlCommand(s, con);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public decimal getExp()
        {
            IEmployeeRepository obj = new EmployeeRepository();


            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            decimal id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select Sum(Amount) as Total from tblExpenses where Month="+month+" and Year="+year+"";
                SqlCommand smd = new SqlCommand(s, con);
                id = (decimal)smd.ExecuteScalar();

            }
            return id;
        }
        public int getTotalLeaves()
        {
            IEmployeeRepository obj = new EmployeeRepository();

           
            var empid = System.Web.HttpContext.Current.Session["EmployeeId"].ToString();
            var checkifcleaveassigned = obj.GetEmpLeaves().Where(x => x.EmployeeId == Convert.ToInt32(empid) && x.CasualLeave != null ).FirstOrDefault();
            var checkifsleaveassigned = obj.GetEmpLeaves().Where(x => x.EmployeeId == Convert.ToInt32(empid) && x.SickLeave != null).FirstOrDefault();

            if (checkifcleaveassigned == null && checkifsleaveassigned==null ||checkifcleaveassigned==null||checkifsleaveassigned==null)
            {
                int a = 0;
                return a;

            }
            else
            {
               
                int id;
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
                {
                    con.Open();
                    String s = "select (CasualLeave+SickLeave) as TotalLeave from tblEmployeeLeaves where EmployeeId=" + empid + "";
                    SqlCommand smd = new SqlCommand(s, con);
                    id = (int)smd.ExecuteScalar();

                }
                return id;
            }
           
        }
        public int getUserCountNo()
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT Count(*) FROM [Hrms].[dbo].[tblUsers]";
                SqlCommand smd = new SqlCommand(s, con);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getLastItemGrNo(int docno)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select ItemId from tblGrItemsPrice where DocumentNo="+docno+" and id=(SELECT MAX(id)  FROM tblGrItemsPrice where DocumentNo="+docno+")";
                SqlCommand smd = new SqlCommand(s, con);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getLastItemRdNo(int docno)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select ItemId from tblreturnlineitem where Grreferenceno=" + docno + " and id=(SELECT MAX(id) FROM tblreturnlineitem where Grreferenceno=" + docno + ")";
                SqlCommand smd = new SqlCommand(s, con);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getPrrefforgr(int docno)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select PrReferenceNo from tblDocument where DocumentNo=" + docno + "";
                SqlCommand smd = new SqlCommand(s, con);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getGrrefforreturn(int docno)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select GrReferencenoforReturn from tblDocument where DocumentNo=" + docno + "";
                SqlCommand smd = new SqlCommand(s, con);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getPorefforgr(int docno)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select DocumentNo from tblDocument where (PrReferenceNo=" + docno + " or GrReferencenoforReturn="+docno+")";
                SqlCommand smd = new SqlCommand(s, con);
                id = (int)smd.ExecuteScalar();
                

            }
            return id;
        }
        public int gettypeidgr(int docno)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select DTypeId from tblDocument where DocumentNo=" + docno + "";
                SqlCommand smd = new SqlCommand(s, con);
                id = (int)smd.ExecuteScalar();


            }
            return id;
        }
        public int getreturnrefforgr(int docno)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select DocumentNo from tblDocument where GrReferencenoforReturn=" + docno + " and DTypeId=5";
                SqlCommand smd = new SqlCommand(s, con);
                id = (int)smd.ExecuteScalar();


            }
            return id;
        }
        public string getReturnNo(int Docno)
        {
            string id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT Docno FROM [Hrms].[dbo].[tblDocument] where GRReferencenoforReturn="+Docno+" and DTypeId=5";
                SqlCommand smd = new SqlCommand(s, con);
                id = (string)smd.ExecuteScalar();

            }
            return id;
        }
        public decimal getTotalPrice(int Doc)
        {
            decimal id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select Sum(ItemPrice) from tblGritemsPrice where DocumentNo=@doc";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@doc",Doc);
                id = (decimal)smd.ExecuteScalar();

            }
            return id;
        }
        public decimal getPartiallPrice(int Doc)
        {
            decimal id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select Balance from tblInvoiceReceipt where GRReferenceNo=@doc and Balance!=0";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@doc", Doc);
                id = (decimal)smd.ExecuteScalar();

            }
            return id;
        }
        public int getItemidfromgr()
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT  FROM [Hrms].[dbo].[tblDocument]";
                SqlCommand smd = new SqlCommand(s, con);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getOrderedqty(int docno,int itemid)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT Quantity FROM [Hrms].[dbo].[tblDocDetails] where DocumentNo=@doc and ItemId=@item";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@doc", docno);
                smd.Parameters.AddWithValue("@item", itemid);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getOrderedqtyforreturn(int docno, int itemid)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT RejectedQuantity FROM [Hrms].[dbo].[tblreturnlineitem] where ReturnNo=@doc and ItemId=@item";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@doc", docno);
                smd.Parameters.AddWithValue("@item", itemid);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getpartialOrderedqty(int docno, int itemid)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT RemainingQuantity FROM [Hrms].[dbo].[tblDocDetails] where DocumentNo=@doc and ItemId=@item";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@doc", docno);
                smd.Parameters.AddWithValue("@item", itemid);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getpartialOrderedqtyreturn(int docno, int itemid)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT RemainingQuantity FROM [Hrms].[dbo].[tblreturnlineitem] where ReturnNo=@doc and ItemId=@item";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@doc", docno);
                smd.Parameters.AddWithValue("@item", itemid);
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
        public void Deletegi(int docno)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("DELETE FROM tblDocument WHERE DocumentNo=@no and DTypeId=6", con))
                {
                    com.Parameters.AddWithValue("@no", docno);
                    com.ExecuteNonQuery();
                }
            }
        }
        public void Deletegr(int docno)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("DELETE FROM tblDocument WHERE DocumentNo=@no and DTypeId=4", con))
                {
                    com.Parameters.AddWithValue("@no", docno);
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
        public int getSlid(string item)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select s.SLId from tblItem i inner join tblSL s on i.StorageLocation=s.StorageLocation Where ItemName=@item";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@item", item);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public decimal getItemPriceofGR(int docno,int itemid)
        {
            decimal id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select i.ItemPrice from tblGrItemsPrice p inner join tblItem i on p.ItemId=i.ItemId where p.DocumentNo=@no and p.ItemId=@item";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@no", docno);
                smd.Parameters.AddWithValue("@item", itemid);
                id = (decimal)smd.ExecuteScalar();

            }
            return id;
        }
        public decimal getItemPriceofGRPartial(int docno, int itemid)
        {
            decimal id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select (ItemPrice*PartialDeliveredQuantity) from tblItem i inner join tblDocDetails d on i.ItemId=d.ItemId where d.DocumentNo=@no and d.ItemId=@item";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@no", docno);
                smd.Parameters.AddWithValue("@item", itemid);
                id = (decimal)smd.ExecuteScalar();

            }
            return id;
        }
        public int getqty(int itemid,int docno)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT Quantity FROM [Hrms].[dbo].[tblDocDetails] Where ItemId=@item and DocumentNo=@doc";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@item", itemid);
                smd.Parameters.AddWithValue("@doc", docno);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getqtyforpartial(int itemid, int docno)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT RemainingQuantity FROM [Hrms].[dbo].[tblDocDetails] Where ItemId=@item and DocumentNo=@doc";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@item", itemid);
                smd.Parameters.AddWithValue("@doc", docno);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getPono(int prrefno)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "SELECT DocumentNo FROM [Hrms].[dbo].[tblDocument] Where PrReferenceNo=@no";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@no", prrefno);
                id = (int)smd.ExecuteScalar();

            }
            return id;
        }
        public int getdeliverqty(int docno,int itemid)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select DeliveredQuantity from tblDocDetails where DocumentNo=@no and ItemId=@item";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@no", docno);
                smd.Parameters.AddWithValue("@item", docno);
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