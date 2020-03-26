using Serene_AMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Serene_AMS.DAL.Classes
{
    public class SetDocNumber
    {
        public HrmsEntities context;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);

        public void AddAutoIncrementColumn(int Id)
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "DBCC CHECKIDENT ('tblItem', RESEED,"+Id+") ";
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}