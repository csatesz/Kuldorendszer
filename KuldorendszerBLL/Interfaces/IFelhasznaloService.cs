using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuldorendszerBLL.Interfaces
{
    interface IFelhasznaloService
    {
        DataTable SelectUserByName(string nev);
        DataTable GetAllUser();
        bool AddUser(string nev, string email, string jelszo, bool admin, bool aszf);
        DataTable GetfelhasznaloSearch(string keres);
        bool ArchiveFelhasznalo(string id);
        bool UpdateFelhasznalo(int id, string oszlop, string adat);

    }
}
