using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuldorendszerBLL.Interfaces
{
    public interface IElerhetosegService
    {
        DataTable GetAllElerhetoseg();
        DataTable GetIdByEmail(string email);
        DataTable GetEmailById(int id);
        DataTable GetElerhetosegSearch(string keres);
        bool AddElerhetoseg(string email, string telefon);
        bool UpdateElerhetoseg(int id, string oszlop, string adat);
        bool DeleteElerhetoseg(string id);
        DataTable GetAllEmail();

    }
}
