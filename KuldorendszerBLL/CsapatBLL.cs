using System.Collections.Generic;
using System.Data;
using KuldorendszerDAL;

namespace KuldorendszerBLL
{
    public class CsapatBLL
    {
        //DataTable dt = new DataTable();
        public DataTable GetAllCsapat()
        {
            string sqlQuery = "SELECT c.idCsapat, c.csapatnev, c.csapatVezeto, o.osztalyMegnevezes " +
                " FROM kuldes.csapatok c INNER JOIN kuldes.osztaly o " +
                " ON c.idOsztaly = o.idOsztaly ;";
            return CRUD.Select(sqlQuery);
        }
        public DataTable GetAllCsapatSearch(string keres)
        {
            string sqlQuery = "SELECT c.idCsapat, c.csapatnev, c.csapatVezeto, o.osztalyMegnevezes " +
                " FROM kuldes.csapatok c INNER JOIN kuldes.osztaly o " +
                $" ON c.idOsztaly = o.idOsztaly WHERE c.csapatnev LIKE \"%{keres}%\" ;";
            return CRUD.Select(sqlQuery);
        }
        public DataTable GetCsapatById(int csapatId)
        {
            string sqlQuery = "SELECT csapatnev FROM kuldes.csapatok WHERE idCsapat = @idCsapat;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@idCsapat", csapatId.ToString());
            return CRUD.Select(sqlQuery, parameters);
        }
        public bool AddCsapat(int id, string nev, int elerhetosegKod, string csapatVezeto, int osztalyId)
        {
            string sqlQuery = "INSERT INTO kuldes.csapatok (idCsapat, csapatNev, elerhetosegKod, " +
                    $" csapatVezeto, idOsztaly) VALUES (@id, @nev, @jelszo, @admin, @aszf)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@nev", nev);
            parameters.Add("@jelszo", elerhetosegKod);
            parameters.Add("@admin", csapatVezeto);
            parameters.Add("@aszf", osztalyId);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters, false);
        }
        public bool DeleteCsapat(string id)
        {
            string sqlQuery = "DELETE FROM kuldes.csapatok WHERE idCsapat= @id ; ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return CRUD.InsertUpdateDelete(sqlQuery, parameters, false);
        }

        public bool UpdateCsapat(int id, string oszlop, string adat)
        {
            string sqlQuery = $"UPDATE kuldes.csapatok SET {oszlop} = @adat WHERE idCsapat = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@adat", adat);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters, false);
        }
        public DataTable GetAllCsapatName()
        {
            string sqlQuery = "SELECT csapatnev FROM kuldes.csapatok ;";
            return CRUD.Select(sqlQuery);
        }
        public DataTable GetIdByCsapatName(string nev)
        {
            string sqlQuery = "SELECT idCsapat FROM kuldes.csapatok WHERE csapatnev = @csapatnev; ;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@csapatnev", nev);

            return CRUD.Select(sqlQuery);
        }
    }
}
