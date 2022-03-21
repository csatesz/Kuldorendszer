using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuldorendszerBLL.Interfaces
{
    interface IKuldesService
    {
        bool AddKuldes(string merkozesKod, string jvKod, string assz1Kod, string assz2Kod, int torolt);
        bool UpdateKuldes(string merkozesKod, string jvKod, string assz1Kod, string assz2Kod, int torolt);
        DataTable GetMerkozesJvvel();
        DataTable GetJatekvezetoOnKuldesByMerkozesKod(string mKod, string feladat);
        DataTable JatekvezetoOsszesMerkozesStat(int id);
        DataTable JatekvezetoJvSzamStat(int id);
        DataTable JatekvezetoAsszisztSzamStat(int id);
        DataTable SzabadJatekvezetok(DateTime date, int interval);
        bool KuldesKeszit(int kod, DateTime date, int jvszam);

    }
}
