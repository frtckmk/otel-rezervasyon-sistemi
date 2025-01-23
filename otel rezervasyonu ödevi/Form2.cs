using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using otel_rezarvasyon_sistemi.SERVICES;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static otel_rezarvasyon_sistemi.SERVICES.rezervasyonSERVİCES;

namespace otel_rezervasyonu_ödevi
{
    public partial class Form2 : Form
    {
        private RezervasyonServic rezervasyonService;
        public Form2()
        {
            InitializeComponent();
            rezervasyonService = new RezervasyonServic();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new rezervasyonSERVİCES()).rezKaydet(txtisim.Text, txtsoyisim.Text, msktelefon.Text, msktc.Text, cmbodatipi.Text, cmbodanum.Text, dategiris.Text, datecıkıs.Text);
            VerileriYukle();
        }
        private readonly string baglantiString = "Server=172.21.54.253; Database=25_132330055; Uid=25_132330055; Pwd=!nif.ogr55CA;";
        private readonly rezervasyonSERVİCES isKatmani = new rezervasyonSERVİCES();
        private void VerileriYukle()
        {
            try
            {
                using (MySqlConnection baglanti = new MySqlConnection(baglantiString))
                {
                    baglanti.Open(); 

                    string sorgu = "SELECT * FROM tbl_rezervasyon"; 

                    MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(komut);

                    DataTable tablo = new DataTable();
                    adapter.Fill(tablo);

                    dataGridView1.DataSource = tablo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            VerileriYukle();
        }

        private void button3_Click(object sender, EventArgs e)
        {//(new rezervasyonSERVİCES()).rezKaydet(txtisim.Text, txtsoyisim.Text, msktelefon.Text, msktc.Text, cmbodatipi.Text, cmbodanum.Text, dategiris.Text, datecıkıs.Text);
            string tc = msktc.Text; 

            bool isSilindi = rezervasyonService.SilRezervasyon(tc);
            VerileriYukle();
            if (isSilindi)
            {
                label9.Text = "Rezervasyon başarıyla silindi.";
            }
            else
            {
                label9.Text = "Silme işlemi başarısız. TC numarasını kontrol edin.";
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            string gİsim=txtisim.Text;
            string gSoyisim=txtsoyisim.Text;
            string gTelefon=msktelefon.Text;
            string gTC=msktc.Text;
            string gOdaTipi=cmbodatipi.Text;
            string gOdaNumarası=cmbodanum.Text;
            string gGirişTarihi = dategiris.Value.ToString("dd-MM-yyyy");
            string gÇıkışTarihi = datecıkıs.Value.ToString("dd-MM-yyyy");
            new rezervasyonSERVİCES().rezGuncelle(id, gİsim, gSoyisim, gTelefon, gTC, gOdaTipi, gOdaNumarası, gGirişTarihi, gÇıkışTarihi);
            MessageBox.Show("başarılı");
            VerileriYukle();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex];
                txtisim.Text = satir.Cells["İsim"].Value?.ToString();
                txtsoyisim.Text = satir.Cells["Soyisim"].Value?.ToString();
                msktelefon.Text = satir.Cells["Telefon"].Value?.ToString();
                msktc.Text = satir.Cells["TC"].Value?.ToString();
                cmbodatipi.Text = satir.Cells["OdaTipi"].Value?.ToString();
                cmbodanum.Text = satir.Cells["OdaNumarası"].Value?.ToString();
                dategiris.Text = satir.Cells["GirişTarihi"].Value?.ToString();
                datecıkıs.Text = satir.Cells["ÇıkışTarihi"].Value?.ToString();
                txtid.Text = satir.Cells["id"].Value?.ToString();
            }
        }
    }
}
