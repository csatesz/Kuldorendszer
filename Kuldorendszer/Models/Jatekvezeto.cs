using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuldorendszer.Models
{
    class Jatekvezeto
    {
        public int jvKod { get; set; }
        public string Nev { get; set; }
        public string Keret { get; set; }
        public int idTelepules { get; set; }
        public string minosites { get; set; }
        public string elerhetosegKod { get; set; }
        public bool torolt { get; set; }
    }
}
