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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLCALISANLAR", bgl.baglanti());
            da.Fill(ds);
            u_dgv.DataSource = ds.Tables[0];

        }
        private void Anasayfa_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (adtb.Text == "" || stb.Text == "" || teltb.Text == "" || tctb.Text == "" || mtb.Text == "" || atb.Text == "" || gtb.Text == "" )
            {

                MessageBox.Show("Eksik Bilgi!!");

            }
            else
            {

                SqlCommand cm = new SqlCommand("insert into TBLCALISANLAR (C_adi,C_soyadi,telefon,tc,mail,adres,görevi) values ('" + adtb.Text + "','" + stb.Text + "','" + teltb.Text + "','" + tctb.Text + "','" + mtb.Text + "','" + atb.Text + "','" + gtb.Text + "')", bgl.baglanti());
                cm.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("KAYIT EKLENDİ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                listele();
                adtb.Clear();
                stb.Clear();
                teltb.Clear();
                tctb.Clear();
                mtb.Clear();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
             int hata = 0;
            if (idtb.Text == string.Empty)
                hata = 1;
            if (hata == 1)
                MessageBox.Show("ALANI DOLDURUNUZ", "UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            else
            {
                SqlCommand komut = new SqlCommand("select * from TBLCALISANLAR where ID = '" + idtb.Text + "'", bgl.baglanti());
                komut.ExecuteNonQuery();
                SqlDataReader dr = komut.ExecuteReader();
                if(dr.Read())
                {
                    SqlCommand cm = new SqlCommand("delete from TBLCALISANLAR where ID = '" + idtb.Text + "'", bgl.baglanti());
                    int basari = cm.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    if(basari==1)
                        MessageBox.Show("ÜRÜN SİLİNDİ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("ÜRÜN SİLİNMEDİ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                    MessageBox.Show("BÖYLE BİR ÜRÜN BULUNAMADI", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            idtb.Clear();
            listele();
            bgl.baglanti().Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            secim secim = new secim();
            secim.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand("update TBLCALISANLAR set C_adi=@p1, C_soyadi=@p2, telefon=@p3, tc=@p4, mail=@p5, adres=@p6 ,görevi=@p7  where ID=@p8", bgl.baglanti());
            cm.Parameters.AddWithValue("@p1", adtb.Text);
            cm.Parameters.AddWithValue("@p2", stb.Text);
            cm.Parameters.AddWithValue("@p3", teltb.Text);
            cm.Parameters.AddWithValue("@p4", tctb.Text);
            cm.Parameters.AddWithValue("@p5", mtb.Text);
            cm.Parameters.AddWithValue("@p6", atb.Text);
            cm.Parameters.AddWithValue("@p7", gtb.Text);
            cm.Parameters.AddWithValue("@p8", idtb.Text);

            int basari = cm.ExecuteNonQuery();
            bgl.baglanti().Close();

            if (basari == 1)
                MessageBox.Show("ÜRÜN GÜNCELLENDİ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("ÜRÜN GÜNCELLENEMEDİ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            listele();
            adtb.Clear();
            stb.Clear();
            teltb.Clear();
            tctb.Clear();
            mtb.Clear();
            atb.Clear();
            gtb.Clear();
        }
        private void u_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void u_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idtb.Text = u_dgv.CurrentRow.Cells[0].Value.ToString();
            adtb.Text = u_dgv.CurrentRow.Cells[1].Value.ToString();
            stb.Text = u_dgv.CurrentRow.Cells[2].Value.ToString();
            teltb.Text = u_dgv.CurrentRow.Cells[3].Value.ToString();
            tctb.Text = u_dgv.CurrentRow.Cells[4].Value.ToString();
            mtb.Text = u_dgv.CurrentRow.Cells[5].Value.ToString();
            atb.Text = u_dgv.CurrentRow.Cells[6].Value.ToString();
            gtb.Text = u_dgv.CurrentRow.Cells[7].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sifrever sifrever = new sifrever();
            sifrever.Show();
            this.Hide();
        }
    }
}
