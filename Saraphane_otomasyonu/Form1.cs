using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saraphane_otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void stokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stok = new stok
            {

                ShowInTaskbar = false,
                MinimizeBox = false,
                MaximizeBox = false,

            };
            stok.StartPosition = FormStartPosition.CenterParent;
            stok.ShowDialog(this);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var URUNLER = new URUNLER
            {

                ShowInTaskbar = false,
                MinimizeBox = false,
                MaximizeBox = false,

            };
            URUNLER.StartPosition = FormStartPosition.CenterParent;
            URUNLER.ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void personellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var personel = new personel
            {

                ShowInTaskbar = false,
                MinimizeBox = false,
                MaximizeBox = false,

            };
            personel.StartPosition = FormStartPosition.CenterParent;
            personel.ShowDialog(this);
        }

        private void kasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var kasa = new kasa
            {

                ShowInTaskbar = false,
                MinimizeBox = false,
                MaximizeBox = false,

            };
            kasa.StartPosition = FormStartPosition.CenterParent;
            kasa.ShowDialog(this);
        }

        private void faturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fatura = new fatura
            {

                ShowInTaskbar = false,
                MinimizeBox = false,
                MaximizeBox = false,

            };
            fatura.StartPosition = FormStartPosition.CenterParent;
            fatura.ShowDialog(this);
        }

        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var alicilar = new alicilar
            {

                ShowInTaskbar = false,
                MinimizeBox = false,
                MaximizeBox = false,

            };
            alicilar.StartPosition = FormStartPosition.CenterParent;
            alicilar.ShowDialog(this);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            secim secim = new secim();
            secim.Show();
            this.Hide();
        }
    }
}
