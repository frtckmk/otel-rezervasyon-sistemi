using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace OtelRezervasyonApp.DAL
{
    public class RezervasyonDAO
    {
        private string connectionString = "Server=172.21.54.253; Database=25_132330055; Uid=25_132330055; Pwd=!nif.ogr55CA";

        public bool TcSil(string tc)
        {
            string query = "DELETE FROM tbl_rezervasyon WHERE TC = @tc";
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@tc", tc);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySQL Hatası: {ex.Message}");
                    return false;
                }
            }
        }

        internal DataTable VeriyiGetir(string sorgu)
        {
            throw new NotImplementedException();
        }
    }
}
