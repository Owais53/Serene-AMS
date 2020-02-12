using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Serene_AMS.Models;
using System.Data;

namespace Serene_AMS.DAL.Repository
{
    public class JobListing
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);

        public DataSet Show_Jobdata()
        {
            SqlCommand com = new SqlCommand("Select * from tblVacancies", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
         


    }
}