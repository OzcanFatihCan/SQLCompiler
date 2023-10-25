using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALBaglanti
    {       
        public static SqlConnection Baglan(string DatabaseAdi)
        {
            string ConnectionString = string.Format("Data Source=FatihBuzac\\SQLEXPRESS;Initial Catalog={0};Integrated Security=True", DatabaseAdi);
            SqlConnection conn = new SqlConnection(ConnectionString);
            return conn;
        }
    }
}
