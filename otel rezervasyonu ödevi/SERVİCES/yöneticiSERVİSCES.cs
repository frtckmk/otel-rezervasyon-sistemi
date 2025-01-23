using otel_rezarvasyon_sistemi.DAL;
using otel_rezarvasyon_sistemi.DOMAIN;
using System;
using System.Windows.Forms;
using Yonetici = otel_rezarvasyon_sistemi.DAL.Yonetici;

namespace otel_rezarvasyon_sistemi.SERVICES
{
    public class YoneticiService
    {
    
        public bool GirisKontrol(string kullaniciAdi, string sifre)
        {
            try
            {
                YoneticiDAO yoneticiDAO = new YoneticiDAO();
                bool girisBasarili = yoneticiDAO.GirisDogrula(new Yonetici(kullaniciAdi, sifre));

                if (girisBasarili)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı adı veya şifre.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
