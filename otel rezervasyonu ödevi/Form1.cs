using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using otel_rezarvasyon_sistemi.SERVICES;

namespace otel_rezervasyonu_ödevi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            if ((new YoneticiService()).GirisKontrol(txtkullancı.Text, txtsifre.Text))
            {
                MessageBox.Show("GİRİŞ BAŞARILI");
                Form2 fr = new Form2();
                fr.Show();
                this.Hide();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
