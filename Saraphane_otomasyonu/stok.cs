using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Saraphane_otomasyonu
{
    public partial class stok : Form
    {
        public stok()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void stok_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select renk, sum(adet)as 'ADET' from TBL_URUNLER group by renk", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            u_dgv.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
