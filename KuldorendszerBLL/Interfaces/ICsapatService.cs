using System.Data;

namespace KuldorendszerBLL.Interfaces
{
    interface ICsapatService
    {
        DataTable GetAllCsapat();
        DataTable GetAllCsapatSearch(string keres);
        DataTable GetCsapatById(int csapatId);
        DataTable GetCsapatAdatById(int csapatId);
        bool AddCsapat(int id, string nev, int elerhetosegKod, string csapatVezeto, int osztalyId);
        bool DeleteCsapat(string id);
        bool UpdateCsapat(int id, string oszlop, string adat);
        bool UpdateMindenCsapatAdat(int id, string nev, int elerhetosegKod, string csapatVezeto, int osztalyId);
        DataTable GetAllCsapatName();
        DataTable GetAllCsapatNameByOsztaly(int idOsztaly);
        DataTable GetIdByCsapatNev(string nev);

    }
}
