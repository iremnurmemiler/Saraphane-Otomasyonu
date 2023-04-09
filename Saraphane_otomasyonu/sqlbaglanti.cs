using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Saraphane_otomasyonu
{
    class sqlbaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection b = new SqlConnection(@"Data Source=DESKTOP-LA73MV0\SQLEXPRESS;Initial Catalog=DBOSARAPHANEOTOMASYONU;Integrated Security=True");
            b.Open();
            return b; 
        }
    }
}
