using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serene_AMS.DAL.Classes
{
    public class NumberSequence
    {

        public string GenerateNo(string Doctype,int id)
        {
            string a = "";
           
            a = Doctype + " - " + id;
            return a;

        }

    }
}