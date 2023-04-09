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
    public partial class URUNLER : Form
    {
        public URUNLER()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
       
       void listele ()
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_URUNLER",bgl.baglanti());
            da.Fill(ds);
            u_dgv.DataSource = ds.Tables[0];    
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void URUNLER_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void u_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (markatb.Text == "" || renktb.Text == "" || yiltb.Text == "" || atb.Text == "" || ftb.Text == "")
            {

                MessageBox.Show("Eksik Bilgi!!");

            }
            else { 

            SqlCommand cm = new SqlCommand("insert into TBL_URUNLER (marka,renk,yil,adet,fiyati) values ('" + markatb.Text + "','" + renktb.Text + "','" + yiltb.Text + "','" + atb.Text + "','" + ftb.Text + "')",bgl.baglanti());
            cm.ExecuteNonQuery();
            bgl.baglanti().Close();

                MessageBox.Show("KAYIT EKLENDİ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            listele();
                markatb.Clear();
                renktb.Clear();
                yiltb.Clear();
                atb.Clear();
                ftb.Clear();
            }



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
                SqlCommand komut = new SqlCommand("select * from TBL_URUNLER where ID = '" + idtb.Text + "'", bgl.baglanti());
                komut.ExecuteNonQuery();
                SqlDataReader dr = komut.ExecuteReader();
                if(dr.Read())
                {
                    SqlCommand cm = new SqlCommand("delete from TBL_URUNLER where ID = '" + idtb.Text + "'", bgl.baglanti());
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

        private void u_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idtb.Text = u_dgv.CurrentRow.Cells[0].Value.ToString();
            markatb.Text = u_dgv.CurrentRow.Cells[1].Value.ToString();
            renktb.Text = u_dgv.CurrentRow.Cells[2].Value.ToString();
            yiltb.Text = u_dgv.CurrentRow.Cells[3].Value.ToString();
            atb.Text = u_dgv.CurrentRow.Cells[4].Value.ToString();
            ftb.Text = u_dgv.CurrentRow.Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand("update TBL_URUNLER set marka=@p1, renk=@p2, yil=@p3, adet=@p4, fiyati=@p5 where ID=@p6",bgl.baglanti());
            cm.Parameters.AddWithValue("@p1", markatb.Text);
            cm.Parameters.AddWithValue("@p2", renktb.Text);
            cm.Parameters.AddWithValue("@p3", yiltb.Text);
            cm.Parameters.AddWithValue("@p4", atb.Text);
            cm.Parameters.AddWithValue("@p5", decimal.Parse(ftb.Text));
            cm.Parameters.AddWithValue("@p6", idtb.Text);

            int basari = cm.ExecuteNonQuery();
            bgl.baglanti().Close();

            if (basari == 1)
                MessageBox.Show("ÜRÜN GÜNCELLENDİ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("ÜRÜN GÜNCELLENEMEDİ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            listele();
            markatb.Clear();
            renktb.Clear();
            yiltb.Clear();
            atb.Clear();
            ftb.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
