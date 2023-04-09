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
    public partial class alicilar : Form
    {
        public alicilar()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        void listele()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_SIRKETLER",bgl.baglanti());
            da.Fill(ds);
            u_dgv.DataSource = ds.Tables[0];

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void alicilar_Load(object sender, EventArgs e)
        {

            listele();
            illistesi();

        }

        void illistesi()
        {
            SqlCommand cm = new SqlCommand("select sehir from iller", bgl.baglanti());
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                ilcb.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hata = 0;
            if (katb.Text == string.Empty)
                hata = 1;
            if (yetkitb.Text == string.Empty)
                hata = 1;
            if (yatb.Text == string.Empty)
                hata = 1;
            if (teltb.Text == string.Empty)
                hata = 1;
            if (mtb.Text == string.Empty)
                hata = 1;
            if (ilcb.Text == string.Empty)
                hata = 1;
            if (hata == 1)
                MessageBox.Show("BÜTÜN ALANLARI DOLDURUNUZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                SqlCommand cm = new SqlCommand("insert into TBL_SIRKETLER(ad,yetkili,yetkiliad_soyad,telefon,mail,il) values (@p1,@p2,@p3,@p4,@p5,@p6)",bgl.baglanti());
                cm.Parameters.AddWithValue("@p1", katb.Text);
                cm.Parameters.AddWithValue("@p2", yetkitb.Text);
                cm.Parameters.AddWithValue("@p3", yatb.Text);
                cm.Parameters.AddWithValue("@p4", teltb.Text);
                cm.Parameters.AddWithValue("@p5", mtb.Text);
                cm.Parameters.AddWithValue("@p6", ilcb.Text);

              
                int basari = cm.ExecuteNonQuery();
                if (basari == 1)
                    MessageBox.Show("KAYIT EKLENDİ", "MESAJ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else
                    MessageBox.Show("KAYIT EKLENMEDİ", "MESAJ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            listele();
            katb.Clear();
            yetkitb.Clear();
            yatb.Clear();
            teltb.Clear();
            mtb.Clear();
            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            int hata = 0;
            if (itb.Text == string.Empty)
                hata = 1;
            if (hata == 1)
                MessageBox.Show("Alanları Doldurunuz");
            else
            {
                SqlCommand cm = new SqlCommand("select * from TBL_SIRKETLER where ID= @p1", bgl.baglanti());
                cm.Parameters.AddWithValue("@p1", itb.Text);
                cm.ExecuteNonQuery();
                SqlDataReader dr = cm.ExecuteReader();
                if(dr.Read())
                {
                    SqlCommand km = new SqlCommand("delete from TBL_SIRKETLER where ID=@p1", bgl.baglanti());
                    km.Parameters.AddWithValue("@p1", itb.Text);
                    int basari = km.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    if(basari==1)
                        MessageBox.Show("Müşteri Silindi");
                    else
                        MessageBox.Show("Müşteri Silinmedi");


                }
                else
                    MessageBox.Show("Müşteri Bulunamadı");


            }
            bgl.baglanti().Close();
            itb.Clear();
            listele();
        }

        private void u_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            itb.Text = u_dgv.CurrentRow.Cells[0].Value.ToString();
            katb.Text = u_dgv.CurrentRow.Cells[1].Value.ToString();
            yetkitb.Text = u_dgv.CurrentRow.Cells[2].Value.ToString();
            yatb.Text = u_dgv.CurrentRow.Cells[3].Value.ToString();
            teltb.Text = u_dgv.CurrentRow.Cells[4].Value.ToString();
            mtb.Text = u_dgv.CurrentRow.Cells[5].Value.ToString();
            ilcb.Text = u_dgv.CurrentRow.Cells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlCommand cm = new SqlCommand("update TBL_SIRKETLER set ad=@p1, yetkili=@p2, yetkiliad_soyad=@p3, telefon=@p4, mail=@p5 , il=@p6 where ID=@p7", bgl.baglanti());
            cm.Parameters.AddWithValue("@p1", katb.Text);
            cm.Parameters.AddWithValue("@p2", yetkitb.Text);
            cm.Parameters.AddWithValue("@p3", yatb.Text);
            cm.Parameters.AddWithValue("@p4", teltb.Text);
            cm.Parameters.AddWithValue("@p5", mtb.Text);
            cm.Parameters.AddWithValue("@p6", ilcb.Text);
            cm.Parameters.AddWithValue("@p7", itb.Text);

            int basari = cm.ExecuteNonQuery();
            bgl.baglanti().Close();

            if (basari == 1)
                MessageBox.Show("ÜRÜN GÜNCELLENDİ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("ÜRÜN GÜNCELLENEMEDİ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            listele();
            katb.Clear();
            yetkitb.Clear();
            yatb.Clear();
            teltb.Clear();
            mtb.Clear();
            itb.Clear();
        }

        private void teltb_TextChanged(object sender, EventArgs e)
        {

        }

        private void mtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void u_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void yatb_TextChanged(object sender, EventArgs e)
        {

        }

        private void yetkitb_TextChanged(object sender, EventArgs e)
        {

        }

        private void katb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ilcb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void itb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
