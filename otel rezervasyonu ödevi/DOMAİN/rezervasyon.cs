using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otel_rezervasyonu_ödevi.DOMAİN
{
    internal class rezervasyon
    {
        public rezervasyon(int id, string gİsim, string gSoyisim, string gTelefon, string gTC, string gOdaTipi, string gOdaNumarası, string gGirişTarihi, string gÇıkışTarihi)
        {
            this.İsim = gİsim;
            this.Soyisim = gSoyisim;
            this.Telefon = gTelefon;
            this.TC = gTC;
            this.OdaTipi = gOdaTipi;
            this.OdaNumarası = gOdaNumarası;
            this.GirişTarihi = gGirişTarihi;    
            this.ÇıkışTarihi = gÇıkışTarihi;
            this.Id = id;
        }
        public rezervasyon( string gİsim, string gSoyisim, string gTelefon, string gTC, string gOdaTipi, string gOdaNumarası, string gGirişTarihi, string gÇıkışTarihi)
        {
            this.İsim = gİsim;
            this.Soyisim = gSoyisim;
            this.Telefon = gTelefon;
            this.TC = gTC;
            this.OdaTipi = gOdaTipi;
            this.OdaNumarası = gOdaNumarası;
            this.GirişTarihi = gGirişTarihi;
            this.ÇıkışTarihi = gÇıkışTarihi;
            
        }
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string isim;

        public string İsim
        {
            get { return isim; }
            set { isim = value; }
        }
        string soyisim;

        public string Soyisim
        {
            get { return soyisim; }
            set { soyisim = value; }
        }
        string telefon;

        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }
        string tc;

        public string TC
        {
            get { return tc; }
            set { tc = value; }
        }
        string odatipi;

        public string OdaTipi
        {
            get { return odatipi; }
            set { odatipi = value; }
        }
        string odanumarası;

        public string OdaNumarası
        {
            get { return odanumarası; }
            set { odanumarası = value; }
        }
        string girştarihi;

        public string GirişTarihi
        {
            get { return girştarihi; }
            set { girştarihi = value; }
        }
        string çıkıştarihi;

        public string ÇıkışTarihi
        {
            get { return çıkıştarihi; }
            set { çıkıştarihi = value; }
        }






    }
}
