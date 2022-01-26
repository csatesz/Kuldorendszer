using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuldorendszer.Models
{
    public class JatekvezetoKuldes
    {
        public int kuldKod { get; set; }
        public DateTime idopont { get; set; }
        public string hazaiCsapat { get; set; }
        public string vendegCsapat { get; set; }
        public string jatekvezeto { get; set; }
        public string asszisztens1 { get; set; }
        public string asszisztens2 { get; set; }
    }
}
