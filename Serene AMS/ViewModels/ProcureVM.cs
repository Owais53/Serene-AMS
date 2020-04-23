using Serene_AMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serene_AMS.ViewModels
{
    public class ProcureVM
    {
        string sdr = @"Data Source=DESKTOP-JIC57MJ;Integrated Security=true;Initial Catalog=Hrms";
        [Required]
        public string City { get; set; }
        [Required]
        public string StorageLocation { get; set; }
        [Required]
        public string ItemType { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int ReorderPoint { get; set; }
        [Required]
        public decimal ItemPrice { get; set; }
        public int SlId { set; get; }
        public int Id { get; set; }
        public int ItemId { get; set; }
        [Required]
        public int TypeId { get; set; }
   
        public string DocType { get; set; }
        [Required]
        public int Docnumberfrom { get; set; }
        [Required]
        public int DocnumberTo { get; set; }
        public int DocPofrom { get; set; }
        public int DocPoto { get; set; }
        public string VendorName { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string VendorType { get; set; }
        public string []requestedMaterialArray { set; get; }
        public int[] requesteditemId { get; set; }
        public bool isChecked { get; set; }
        public String ItemsID { get; set; }
        public int DocNo { get; set; }
       public int Quantity { get; set; }
        public string Item { get; set; }

        public string status { get; set; }
        public DateTime Createdon { get; set; }
        public string Createdby { get; set; }
        public string Reasonofreturn { get; set; }
        public decimal unitprice { get; set; }
        public int RejectedQuantity { get; set; }
        public int ApprovedQuantity { get; set; }
        public decimal Total { get; set; }
        public decimal Totalforall { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime RequestedDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DeliveryDate { get; set; }
        public int Prreferenceno { get; set; }
        public int Poreferenceno { get; set; }
        public int VendorId { get; set; }
        public string Prno { get; set; }
        public string Grno { get; set; }
        public int DeliveredQuantity { get; set; }
        public int RemainingQuantity { get; set; }
        public decimal Paid { get; set; }
        public decimal Balance { get; set; }
        public List<ProcureVM> GRDetails { get; set; }
        public List<ProcureVM> IRDetails { get; set; }
        public string ReturnCreationDateForDisplay
        {
            get
            {
                return this.Createdon.ToString("d");
            }
        }
        public string ReturnDeliveryDateForDisplay
        {
            get
            {
                return this.DeliveryDate.ToString("d");
            }
        }
        public string ReturnRequestedDateForDisplay
        {
            get
            {
                return this.RequestedDate.ToString("d");
            }
        }
        public IEnumerable<ProcureVM> PoData { get; set; }
        public List<ProcureVM> getItemDataforVendorSelection(int id)
        {
            List<ProcureVM> lf = new List<ProcureVM>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString))
            {
                con.Open();
                String s = "select det.Id,det.DocumentNo,det.ItemName,det.Quantity,item.ItemId,item.TypeId,item.StorageLocation from tblDocDetails det inner join tblItem item on det.ItemName=item.ItemName where det.Id=@id";
                SqlCommand smd = new SqlCommand(s, con);
                smd.Parameters.AddWithValue("@id", id);
               
                SqlDataReader sdr = smd.ExecuteReader();
                while (sdr.Read())
                {
                    ProcureVM rf = new ProcureVM();
                    rf.Id = (int)sdr["Id"];
                    rf.DocNo = Convert.ToInt32(sdr["DocumentNo"]);
                    rf.ItemName = sdr["ItemName"].ToString();
                    rf.Quantity = Convert.ToInt32(sdr["Quantity"]);
                    rf.ItemId = Convert.ToInt32(sdr["ItemId"]);
                    rf.TypeId = Convert.ToInt32(sdr["TypeId"]);
                    rf.StorageLocation = sdr["StorageLocation"].ToString();
                    lf.Add(rf);
                }
                return lf;
            }
        }
      
    }
}