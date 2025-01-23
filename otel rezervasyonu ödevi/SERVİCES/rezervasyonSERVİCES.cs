using MySql.Data.MySqlClient;
using otel_rezervasyonu_ödevi.DAL;
using otel_rezervasyonu_ödevi.DOMAİN;
using OtelRezervasyonApp.DAL;
using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApplication1.DAL;

namespace otel_rezarvasyon_sistemi.SERVICES
{
    public class rezervasyonSERVİCES
    {
        private object dbHelper;

        internal void rezGuncelle(int id, string gİsim, string gSoyisim, string gTelefon, string gTC, string gOdaTipi, string gOdaNumarası, string gGirişTarihi, string gÇıkışTarihi)
        {
            (new rezervasyondaoDÜZENLE()).UpdateRecord(id, gİsim, gSoyisim, gTelefon, gTC, gOdaTipi, gOdaNumarası, gGirişTarihi, gÇıkışTarihi);
        }
        private readonly RezervasyonDAO veriKatmani = new RezervasyonDAO();

       
        internal void rezKaydet(string gİsim, string gSoyisim, string gTelefon, string gTC, string gOdaTipi, string gOdaNumarası, string gGirişTarihi, string gÇıkışTarihi)
        {
            (new RezervazyonDAO()).rezKaydet(new rezervasyon(gİsim, gSoyisim, gTelefon, gTC, gOdaTipi, gOdaNumarası, gGirişTarihi, gÇıkışTarihi));
        }
        public class RezervasyonServic
        {
            private RezervasyonDAO rezervasyonDAO;

            public RezervasyonServic()
            {
                rezervasyonDAO = new RezervasyonDAO();
            }

            public bool SilRezervasyon(string tc)
            {
                if (string.IsNullOrEmpty(tc))
                {
                    Console.WriteLine("Geçersiz TC numarası.");
                    return false;
                }

                return rezervasyonDAO.TcSil(tc);
            }



        }
     


    }
    }

       