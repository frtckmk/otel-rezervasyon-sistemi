using MySql.Data.MySqlClient;
using otel_rezervasyonu_ödevi.DAL;
using System;
namespace otel_rezarvasyon_sistemi.DAL
{
    public class YoneticiDAO
    {
        public bool GirisDogrula(Yonetici yonetici)
        {
            bool girisBasarili = false;

            try
            {
                using (var connection = (new baglanti()).baglantiGetir())
                {
                    string query = "SELECT * FROM tbl_yonetici WHERE KullanıcıAdı = @KullaniciAdi AND Şifre = @Sifre";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@KullaniciAdi", yonetici.KullaniciAdi);
                        command.Parameters.AddWithValue("@Sifre", yonetici.Sifre);

                        if (connection.State == System.Data.ConnectionState.Closed || connection.State == System.Data.ConnectionState.Broken)
                        {
                            connection.Open();
                        }

                        using (var reader = command.ExecuteReader())
                        {
                            girisBasarili = reader.HasRows;
                        }
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                Console.WriteLine($"Veritabanı hatası: {sqlEx.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Beklenmeyen bir hata oluştu: {ex.Message}");
                throw;
            }

            return girisBasarili;
        }
    }
}
