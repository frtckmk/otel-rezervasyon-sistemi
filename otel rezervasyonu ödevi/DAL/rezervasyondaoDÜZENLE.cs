using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace otel_rezervasyonu_ödevi.DAL
{
    internal class rezervasyondaoDÜZENLE
    {
        //{
            private string connectionString = "Server=172.21.54.253; Database=25_132330055; Uid=25_132330055; Pwd=!nif.ogr55CA";
            public bool UpdateRecord(int id,string gİsim, string gSoyisim, string gTelefon, string gTC, string gOdaTipi, string gOdaNumarası, string gGirişTarihi, string gÇıkışTarihi)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE tbl_rezervasyon SET İsim = @İsim,Soyisim=@Soyisim,Telefon=@Telefon,TC=@TC,OdaTipi=@OdaTipi,OdaNumarası=@OdaNumarası,GirişTarihi=@gt,ÇıkışTarihi=@ct WHERE id = @id";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@İsim", gİsim);
                            cmd.Parameters.AddWithValue("@Soyisim", gSoyisim);

                            cmd.Parameters.AddWithValue("@Telefon", gTelefon);

                            cmd.Parameters.AddWithValue("@TC", gTC);
                            cmd.Parameters.AddWithValue("@OdaTipi", gOdaTipi);
                            cmd.Parameters.AddWithValue("@OdaNumarası", gOdaNumarası);
                            cmd.Parameters.AddWithValue("@gt", gGirişTarihi);
                            cmd.Parameters.AddWithValue("@ct", gÇıkışTarihi);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            return rowsAffected > 0;  
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                    return false;
                }
            }
        }
    }

