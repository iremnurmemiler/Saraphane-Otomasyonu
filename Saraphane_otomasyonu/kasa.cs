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
    public partial class kasa : Form
    {
        public kasa()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        void listele()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_GIDERLER", bgl.baglanti());
            da.Fill(ds);
            u_dgv.DataSource = ds.Tables[0];

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hata = 0;
            if (etb.Text == string.Empty)
                hata = 1;
            if (stb.Text == string.Empty)
                hata = 1;
            if (dtb.Text == string.Empty)
                hata = 1;
            if (intb.Text == string.Empty)
                hata = 1;
            if (ktb.Text == string.Empty)
                hata = 1;
            if (mtb.Text == string.Empty)
                hata = 1;
            if (aycb.Text == string.Empty)
                hata = 1;
            if (yilcb.Text == string.Empty)
                hata = 1;
            if (hata == 1)
                MessageBox.Show("BÜTÜN ALANLARI DOLDURUNUZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                SqlCommand cm = new SqlCommand("insert into TBL_GIDERLER(elektrik,su,dogalgaz,internet,kira,maaslar,ay,yil) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                cm.Parameters.AddWithValue("@p1", etb.Text);
                cm.Parameters.AddWithValue("@p2", stb.Text);
                cm.Parameters.AddWithValue("@p3", dtb.Text);
                cm.Parameters.AddWithValue("@p4", intb.Text);
                cm.Parameters.AddWithValue("@p5", ktb.Text);
                cm.Parameters.AddWithValue("@p6", mtb.Text);
                cm.Parameters.AddWithValue("@p7", aycb.Text);
                cm.Parameters.AddWithValue("@p8", yilcb.Text);

                int basari = cm.ExecuteNonQuery();
                if (basari == 1)
                    MessageBox.Show("KAYIT EKLENDİ", "MESAJ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else
                    MessageBox.Show("KAYIT EKLENMEDİ", "MESAJ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            listele();
            etb.Clear();
            stb.Clear();
            dtb.Clear();
            intb.Clear();
            ktb.Clear();
            mtb.Clear();



        }

        private void kasa_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void u_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            itb.Text = u_dgv.CurrentRow.Cells[0].Value.ToString();
            etb.Text = u_dgv.CurrentRow.Cells[1].Value.ToString();
            stb.Text = u_dgv.CurrentRow.Cells[2].Value.ToString();
            dtb.Text = u_dgv.CurrentRow.Cells[3].Value.ToString();
            intb.Text = u_dgv.CurrentRow.Cells[4].Value.ToString();
            ktb.Text = u_dgv.CurrentRow.Cells[5].Value.ToString();
            mtb.Text = u_dgv.CurrentRow.Cells[6].Value.ToString();
            aycb.Text = u_dgv.CurrentRow.Cells[7].Value.ToString();
            yilcb.Text = u_dgv.CurrentRow.Cells[8].Value.ToString();
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
                SqlCommand cm = new SqlCommand("select * from TBL_GIDERLER where ID= @p1", bgl.baglanti());
                cm.Parameters.AddWithValue("@p1", itb.Text);
                cm.ExecuteNonQuery();
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    SqlCommand km = new SqlCommand("delete from TBL_GIDERLER where ID=@p1", bgl.baglanti());
                    km.Parameters.AddWithValue("@p1", itb.Text);
                    int basari = km.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    if (basari == 1)
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

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand("update TBL_GIDERLER set elektrik=@p1, su=@p2, dogalgaz=@p3, internet=@p4, kira=@p5 , maaslar=@p6 , ay=@p7 , yil=@p8 where ID=@p9", bgl.baglanti());
            cm.Parameters.AddWithValue("@p1", decimal.Parse(etb.Text));
            cm.Parameters.AddWithValue("@p2", decimal.Parse(stb.Text));
            cm.Parameters.AddWithValue("@p3", decimal.Parse(dtb.Text));
            cm.Parameters.AddWithValue("@p4", decimal.Parse(intb.Text));
            cm.Parameters.AddWithValue("@p5", decimal.Parse(ktb.Text));
            cm.Parameters.AddWithValue("@p6", decimal.Parse(mtb.Text));
            cm.Parameters.AddWithValue("@p7", aycb.Text);
            cm.Parameters.AddWithValue("@p8", yilcb.Text);
            cm.Parameters.AddWithValue("@p9", itb.Text);

            int basari = cm.ExecuteNonQuery();
            bgl.baglanti().Close();

            if (basari == 1)
                MessageBox.Show("ÜRÜN GÜNCELLENDİ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("ÜRÜN GÜNCELLENEMEDİ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            listele();
            etb.Clear();
            stb.Clear();
            dtb.Clear();
            intb.Clear();
            ktb.Clear();
            mtb.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
