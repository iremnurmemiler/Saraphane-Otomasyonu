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
    public partial class personel : Form
    {
        public personel()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void personel_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select C_adi, C_soyadi, görevi from TBLCALISANLAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            u_dgv.DataSource = dt;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void u_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
