using KuldorendszerBLL.Interfaces;
using KuldorendszerDAL;
using System.Collections.Generic;
using System.Data;

namespace KuldorendszerBLL
{
    public class OsztalyService : IOsztalyService
    {
        public DataTable GetAllOsztaly()
        {
            string sqlQuery = "SELECT * FROM kuldes.osztaly ;";

            return CRUD.Select(sqlQuery);
        }
        public DataTable GetAllOsztalySearch(string keres)
        {
            string sqlQuery = $"SELECT * FROM kuldes.osztaly WHERE osztalyMegnevezes LIKE \"%{keres}%\"";

            return CRUD.Select(sqlQuery);
        }
        public DataTable GetOsztalyById(int id)
        {
            string sqlQuery = "SELECT osztalyMegnevezes FROM kuldes.osztaly WHERE idOsztaly = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id.ToString());

            return CRUD.Select(sqlQuery, parameters);
        }

        public DataTable GetIdByOsztalyNev(string nev)
        {
            string sqlQuery = "SELECT idOsztaly FROM kuldes.osztaly WHERE  osztalyMegnevezes = @nev;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@nev", nev);

            return CRUD.Select(sqlQuery, parameters);
        }
        public bool AddOsztaly(int id, string nev)
        {
            string sqlQuery = "INSERT INTO kuldes.osztaly (idOsztaly, osztalyMegnevezes) " +
                    $" VALUES (@id, @nev);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@nev", nev);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters);
        }
        public bool DeleteOsztaly(string id)
        {
            string sqlQuery = "DELETE FROM kuldes.osztaly WHERE idOsztaly= @id ; ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters);
        }
        public bool UpdateOsztaly(int id, string oszlop, string adat)
        {
            string sqlQuery = $"UPDATE kuldes.osztaly SET {oszlop} = @adat WHERE idOsztaly = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@adat", adat);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters);
        }
        public DataTable GetAllOsztalyMegnevezes()
        {
            string sqlQuery = "SELECT osztalyMegnevezes FROM kuldes.osztaly;";

            return CRUD.Select(sqlQuery);
        }
        public DataTable GetAllOsztalyMegnevezesByOsztaly()
        {
            string sqlQuery = "SELECT osztalyMegnevezes FROM kuldes.osztaly WHERE ;";

            return CRUD.Select(sqlQuery);
        }
    }
}
