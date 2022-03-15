using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KuldorendszerModels
{
    public class Felhasznalo 
    {
        public int felhKod { get; set; }
        public string felhNev { get; set; }
        public string email { get; set; }
        public string jelszo { get; set; }
        public bool admin { get; set; }
        public bool aszf { get; set; }
        public bool bejelentkezve { get; set; }

    }
}
