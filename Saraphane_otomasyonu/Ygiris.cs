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
    public partial class Ygiris : Form
    {
        public Ygiris()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (katb.Text == "" || stb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else if (katb.Text == "beste" && stb.Text == "12345")
            {
                Anasayfa Anasayfa = new Anasayfa();
                Anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı ya da Şifre");
            }
        }
    }
}
