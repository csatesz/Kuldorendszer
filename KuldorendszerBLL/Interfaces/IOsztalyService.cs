using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuldorendszerBLL.Interfaces
{
    interface IOsztalyService
    {
        DataTable GetAllOsztaly();
        DataTable GetAllOsztalySearch(string keres);
        DataTable GetOsztalyById(int id);
        DataTable GetIdByOsztalyNev(string nev);
        bool AddOsztaly(int id, string nev);
        bool DeleteOsztaly(string id);
        bool UpdateOsztaly(int id, string oszlop, string adat);
        DataTable GetAllOsztalyMegnevezes();
        DataTable GetAllOsztalyMegnevezesByOsztaly();
    }
}
