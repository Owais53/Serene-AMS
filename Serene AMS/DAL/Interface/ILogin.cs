using Serene_AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serene_AMS.DAL.Interface
{
    public interface ILogin
    {
        IEnumerable<tblUser> Login();

    }
}
