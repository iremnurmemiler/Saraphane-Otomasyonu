using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Saraphane_otomasyonu
{
    public partial class crypto : Form
    {
        public crypto()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void crypto_Load(object sender, EventArgs e)
        {
            
        }

        public static string EncryptWithMD5(string ClearString)
        {
            System.Text.UnicodeEncoding objUE = new System.Text.UnicodeEncoding();

            byte[] bytClearString = objUE.GetBytes(ClearString);

            MD5CryptoServiceProvider objProv = new MD5CryptoServiceProvider();

            byte[] hash = objProv.ComputeHash(bytClearString);
            return Convert.ToBase64String(hash);
        }

        private void katb_TextChanged(object sender, EventArgs e)
        {
            if (sstb.Text != "")
            {
                stb.Text = EncryptWithMD5(sstb.Text);

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kaditb.Text == "" || sifretb.Text == "")
            {

                MessageBox.Show("Eksik Bilgi!!");

            }
            else
            {

                SqlCommand cm = new SqlCommand("insert into TBL_ADMINN (ad,sifre) values ('" + kaditb.Text + "','" + sifretb.Text + "')", bgl.baglanti());
                cm.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("KAYIT EKLENDİ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);


                kaditb.Clear();
                sifretb.Clear();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sifrever sifrever= new sifrever();
            sifrever.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
