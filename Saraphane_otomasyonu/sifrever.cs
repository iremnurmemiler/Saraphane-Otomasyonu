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
    public partial class sifrever : Form
    {
        public sifrever()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select ad,sifre from TBL_ADMINN", bgl.baglanti());
            da.Fill(ds);
            u_dgv.DataSource = ds.Tables[0];

        }
        private void sifrever_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            crypto crypto = new crypto();
            crypto.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void stb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void katb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Anasayfa Anasayfa = new Anasayfa();
            Anasayfa.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
            {
                SqlCommand komut = new SqlCommand("select * from TBL_ADMINN where ad = '" + katb.Text + "'", bgl.baglanti());
                komut.ExecuteNonQuery();
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    SqlCommand cm = new SqlCommand("delete from TBL_ADMINN where ad = '" + katb.Text + "'", bgl.baglanti());
                    int basari = cm.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    if (basari == 1)
                        MessageBox.Show("ÜRÜN SİLİNDİ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("ÜRÜN SİLİNMEDİ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                    MessageBox.Show("BÖYLE BİR ÜRÜN BULUNAMADI", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            katb.Clear();
            stb.Clear();
            listele();
            bgl.baglanti().Close();
        }

        private void u_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void u_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                katb.Text = u_dgv.CurrentRow.Cells[0].Value.ToString();
                stb.Text = u_dgv.CurrentRow.Cells[1].Value.ToString();
            }
        }
    }
}
