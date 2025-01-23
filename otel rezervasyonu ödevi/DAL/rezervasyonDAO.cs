using MySql.Data.MySqlClient;
using otel_rezervasyonu_ödevi.DAL;
using otel_rezervasyonu_ödevi.DOMAİN;
using System;
using System.Data;
using System.Runtime.ConstrainedExecution;


namespace WindowsFormsApplication1.DAL
{
    class RezervazyonDAO
    {
        
        public void rezKaydet(rezervasyon gRez)
        {
            string query = @"INSERT INTO tbl_rezervasyon 
                            (`İsim`, `Soyisim`, `Telefon`, `TC`, `OdaTipi`, `OdaNumarası`, `GirişTarihi`, `ÇıkışTarihi`) 
                            VALUES (@isim, @soyisim, @telefon, @tc, @odaTipi, @odaNumarasi, @girisTarihi, @cikisTarihi)";

            using (var connection = (new baglanti()).baglantiGetir())
            {
                try
                {

                    Console.WriteLine("Bağlantı başarıyla açıldı.");

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@isim", gRez.İsim);
                        command.Parameters.AddWithValue("@soyisim", gRez.Soyisim);
                        command.Parameters.AddWithValue("@telefon", gRez.Telefon);
                        command.Parameters.AddWithValue("@tc", gRez.TC);
                        command.Parameters.AddWithValue("@odaTipi", gRez.OdaTipi);
                        command.Parameters.AddWithValue("@odaNumarasi", gRez.OdaNumarası);

                        if (DateTime.TryParse(gRez.GirişTarihi, out DateTime girisTarihi))
                        {
                            command.Parameters.AddWithValue("@girisTarihi", girisTarihi.ToString("yyyy-MM-dd"));
                        }
                        else
                        {
                            throw new ArgumentException("Geçersiz giriş tarihi.");
                        }

                        if (DateTime.TryParse(gRez.ÇıkışTarihi, out DateTime cikisTarihi))
                        {
                            command.Parameters.AddWithValue("@cikisTarihi", cikisTarihi.ToString("yyyy-MM-dd"));
                        }
                        else
                        {
                            throw new ArgumentException("Geçersiz çıkış tarihi.");
                        }

                        command.ExecuteNonQuery();
                        Console.WriteLine("Rezervasyon başarıyla kaydedildi.");
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySQL Hatası: {ex.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                    throw;
                }
                
            }
        }
        
    }
}

