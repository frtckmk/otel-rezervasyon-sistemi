namespace otel_rezarvasyon_sistemi.DAL
{
    public class Yonetici
    {
        public Yonetici(string kullaniciAdi, string sifre)
        {
            KullaniciAdi = kullaniciAdi;
            Sifre = sifre;
        }

        public object KullaniciAdi { get; internal set; }
        public object Sifre { get; internal set; }
    }
}