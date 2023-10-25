using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class LogicBaglanti
    {
        public static SqlConnection LLBaglan(string DatabaseAdi)
        {
            if (DatabaseAdi != "")
            {
                return DALBaglanti.Baglan(DatabaseAdi);
            }
            else
            { return null; }
        }
    } 
}
