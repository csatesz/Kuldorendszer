using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kuldorendszer.Models
{
    public class Felhasznalo
    {
        public int felhKod { get; set; }
        public string felhNev { get; set; }
        public string email { get; set; }
        private string _jelszo;
        public string jelszo
        {
            get => _jelszo;
            set => sha256_hash(value);
            
        }
        public bool admin { get; set; }
        public bool aszf { get; set; }
        public bool bejelentkezve { get; set; }

        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
