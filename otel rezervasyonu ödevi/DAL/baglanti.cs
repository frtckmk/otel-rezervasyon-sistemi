using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace otel_rezervasyonu_ödevi.DAL
{
    internal class baglanti
    {
        public MySqlConnection baglantiGetir()
        {
            MySqlConnection baglanti = new MySqlConnection("Server=172.21.54.253; Database=25_132330055; Uid=25_132330055; Pwd=!nif.ogr55CA");
            baglanti.Open();
            return baglanti;
        }

        internal IDisposable BaglantiGetir()
        {
            throw new NotImplementedException();
        }
    }
}
