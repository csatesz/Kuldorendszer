using System.Data;

namespace KuldorendszerBLL.Interfaces
{
    interface IJatekvezetoService
    {
        DataTable GetAllJatekvezeto();
        DataTable GetJatekvezetoSearch(string keres);
        bool ArchiveJatekvezeto(string id);
        bool UpdateJatekvezeto(int id, string oszlop, string adat);
        bool AddJatekvezeto(int jvKod, string nev, int elKod, int telep, string min,
                    string oszt, string feladat, int torolt);
        bool UpdateMindenJatekvezetoAdat(int jvKod, string nev, int elKod, int telep, string min,
                   string oszt, string feladat, int torolt);
        DataTable GetJatekvezetoById(int id);
        DataTable GetJatekvezetoNevIdByMerkozesKod(int kod, string feladat);
        DataTable GetJatekvezetoByFeladat(string feladat);
        DataTable GetJatekvezetoIdByNev(string nev);
    }
}
