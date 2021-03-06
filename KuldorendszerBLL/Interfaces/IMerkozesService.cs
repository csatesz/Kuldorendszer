using System;
using System.Data;

namespace KuldorendszerBLL.Interfaces
{
    interface IMerkozesService
    {
        DataTable GetAllMerkozes();
        DataTable GetMerkozes();
        DataTable GetMerkozesSearch(string keres);
        bool ArchiveMerkozes(string id);
        bool UpdateMerkozes(int id, string oszlop, string adat);
        bool UpdateMindenMerkozesAdat(int kod, int hazai, int vendeg, int jvSzam, DateTime date,
                    int telep, int osztaly, int fordulo, int torolt);
        bool AddMerkozes(int kod, int hazai, int vendeg, int jvSzam, DateTime date,
                    int telep, int osztaly, int fordulo, int torolt);
        DataTable GetMerkozesById(int id);
        DataTable GetForduloJvSzamById(int id);
        DataTable GetMerkozesByOsztaly(string osztaly);
        DataTable GetMerkozesByFordulo(string fordulo);
        DataTable GetMerkozesByForduloAndOsztaly(string fordulo, string osztaly);
        DataTable GetMerkozesJvSzamById(int id);
        DataTable GetMerkozesKodByDate(DateTime date, int interval);
    }
}
