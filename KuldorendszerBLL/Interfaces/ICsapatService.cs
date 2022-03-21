using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuldorendszerBLL.Interfaces
{
    interface ICsapatService
    {
        DataTable GetAllCsapat();
        DataTable GetAllCsapatSearch(string keres);
        DataTable GetCsapatById(int csapatId);
        bool AddCsapat(int id, string nev, int elerhetosegKod, string csapatVezeto, int osztalyId);
        bool DeleteCsapat(string id);
        bool UpdateCsapat(int id, string oszlop, string adat);
        DataTable GetAllCsapatName();
        DataTable GetAllCsapatNameByOsztaly(int idOsztaly);
        DataTable GetIdByCsapatNev(string nev);

    }
}
