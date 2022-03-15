using KuldorendszerDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuldorendszerBLL
{
    public class TelepulesBLL
    {
        public DataTable GetAllTelepules()
        {
            string sqlQuery = "SELECT * FROM kuldes.telepules ;";

            return CRUD.Select(sqlQuery);
        }
        public DataTable GetAllTelepulesSearch(string keres)
        {
            string sqlQuery = $"SELECT * FROM kuldes.telepules WHERE Telepules LIKE \"%{keres}%\"";

            return CRUD.Select(sqlQuery);
        }
        public DataTable GetTelepulesById(int id)
        {
            string sqlQuery = "SELECT Telepules FROM kuldes.telepules WHERE idTelepules = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id.ToString());

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable GetIdByTelepulesNev(string nev)
        {
            string sqlQuery = "SELECT idTelepules FROM kuldes.telepules WHERE  Telepules = @nev;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@nev", nev);

            return CRUD.Select(sqlQuery, parameters);
        }
        public bool AddTelepules(int id, string telepules, int irsz)
        {
            string sqlQuery = "INSERT INTO kuldes.telepules (idTelepules, Telepules, iranyitoszam)" +
                " VALUES (@id, @telepules, @irsz);";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@telepules", telepules);
            parameters.Add("@irsz", irsz);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters, false);
        }
        public bool DeleteTelepules(string id)
        {
            string sqlQuery = "DELETE FROM kuldes.telepules WHERE idTelepules= @id ; ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters, false);
        }
        public bool UpdateTelepules(int id, string oszlop, string adat)
        {
            string sqlQuery = $"UPDATE kuldes.telepules SET {oszlop} = @adat WHERE idTelepules = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@adat", adat);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters, false);
        }
        public DataTable GetAllTelepulesName()
        {
            string sqlQuery = "SELECT Telepules FROM kuldes.telepules ;";
            return CRUD.Select(sqlQuery);
        }
    }
}
