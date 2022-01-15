using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuldorendszer.Models
{
    class Merkozes
    {
        public int merkozesKod { get; set; }
        public int HazaiCsapatId { get; set; }
        public int vendegCsapatId { get; set; }
        public int jvFoSzam { get; set; }
        public DateTime merkozesDatum { get; set; }
        public int idTelepules { get; set; }
        public int idOsztaly { get; set; }
    }
}
