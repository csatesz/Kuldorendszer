using System.Data;

namespace KuldorendszerBLL.Interfaces
{
    interface ITelepulesService
    {
        DataTable GetAllTelepules();
        DataTable GetAllTelepulesSearch(string keres);
        DataTable GetTelepulesById(int id);
        DataTable GetIdByTelepulesNev(string nev);
        bool AddTelepules(int id, string telepules, int irsz);
        bool DeleteTelepules(string id);
        bool UpdateTelepules(int id, string oszlop, string adat);
        DataTable GetAllTelepulesName();
    }
}
