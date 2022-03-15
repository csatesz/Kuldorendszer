using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuldorendszerModels
{
    class Csapatok
    {
        public int isCsapat { get; set; }
        public string csapatNev { get; set; }
        public int elerhetosegKod { get; set; }
        public string csapatVezeto { get; set; }
        public int idOsztaly { get; set; }
        public bool torolt { get; set; }
    }
}
