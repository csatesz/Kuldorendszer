using KuldorendszerBLL.Interfaces;
using KuldorendszerDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace KuldorendszerBLL
{
    public class MerkozesService : IMerkozesService
    {
        public DataTable GetAllMerkozes()
        {
            string sqlQuery = "SELECT * FROM kuldes.merkozes ORDER BY merkozesKod;";
            return CRUD.Select(sqlQuery);
        }
        public DataTable GetMerkozes()
        {
            string sqlQuery = "SELECT m.merkozesKod, m.merkozesDatum, t.Telepules," +
                " c.csapatNev, d.csapatNev, o.osztalyMegnevezes  FROM ((((kuldes.merkozes m INNER JOIN " +
                " kuldes.telepules t ON t.IdTelepules = m.IdTelepules) INNER JOIN kuldes.csapatok c " +
                " ON c.idCsapat = m.hazaiCsapatId) INNER JOIN kuldes.csapatok d " +
                " ON d.idCsapat = m.vendegCsapatId) INNER JOIN kuldes.osztaly o " +
                " ON o.idOsztaly = m.idOsztaly)";

            return CRUD.Select(sqlQuery);
        }
        public DataTable GetMerkozesKodByDate(DateTime date, int interval)
        {
            string sqlQuery = "SELECT merkozesKod FROM kuldes.merkozes WHERE merkozesDatum BETWEEN " +
                "@fromdate AND @todate;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@fromdate", date.AddHours(-interval));
            parameters.Add("@todate", date.AddHours(interval));

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable GetMerkozesSearch(string keres)
        {
            string sqlQuery = "SELECT m.merkozesKod, m.merkozesDatum, t.Telepules," +
                " c.csapatNev, d.csapatNev, o.osztalyMegnevezes  FROM ((((kuldes.merkozes m INNER JOIN " +
                " kuldes.telepules t ON t.IdTelepules = m.IdTelepules) INNER JOIN kuldes.csapatok c " +
                " ON c.idCsapat = m.hazaiCsapatId) INNER JOIN kuldes.csapatok d " +
                " ON d.idCsapat = m.vendegCsapatId) INNER JOIN kuldes.osztaly o " +
                $" ON o.idOsztaly = m.idOsztaly) WHERE m.merkozesKod LIKE \"%{keres}%\" OR m.merkozesDatum LIKE \"%{keres}%\" ;";

            return CRUD.Select(sqlQuery);
        }
        public bool ArchiveMerkozes(string id)
        {
            string sqlQuery = $"UPDATE kuldes.merkozes SET torolt = true WHERE merkozesKod = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return CRUD.InsertUpdateDelete(sqlQuery, parameters);
        }
        public bool UpdateMerkozes(int id, string oszlop, string adat)
        {
            string sqlQuery = $"UPDATE kuldes.merkozes SET {oszlop} = @adat WHERE merkozesKod = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@adat", adat);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters);
        }
        public bool UpdateMindenMerkozesAdat(int kod, int hazai, int vendeg, int jvSzam, DateTime date,
                    int telep, int osztaly, int fordulo, int torolt)
        {
            string sqlQuery = "UPDATE kuldes.merkozes SET HazaiCsapatId = @hazai, " +
                    " vendegCsapatId = @vendeg, JvSzam = @jvSzam, merkozesDatum = @date, " +
                    " idTelepules = @telep, idOsztaly = @osztaly,  fordulo = @fordulo, " +
                    " torolt = @torolt WHERE merkozesKod = @kod ;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@kod", kod);
            parameters.Add("@hazai", hazai);
            parameters.Add("@vendeg", vendeg);
            parameters.Add("@telep", telep);
            parameters.Add("@jvSzam", jvSzam);
            parameters.Add("@date", date);
            parameters.Add("@osztaly", osztaly);
            parameters.Add("@fordulo", fordulo);
            parameters.Add("@torolt", torolt);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters);
        }
        public bool AddMerkozes(int kod, int hazai, int vendeg, int jvSzam, DateTime date,
                    int telep, int osztaly, int fordulo, int torolt)
        {
            string sqlQuery = "INSERT INTO kuldes.merkozes VALUES(@kod, @hazai, @vendeg, " +
                    " @jvSzam, @date, @telep, @osztaly, @fordulo, @torolt)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@kod", kod);
            parameters.Add("@hazai", hazai);
            parameters.Add("@vendeg", vendeg);
            parameters.Add("@telep", telep);
            parameters.Add("@jvSzam", jvSzam);
            parameters.Add("@date", date);
            parameters.Add("@osztaly", osztaly);
            parameters.Add("@fordulo", fordulo);
            parameters.Add("@torolt", torolt);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters);
        }
        public DataTable GetMerkozesById(int id)
        {
            string sqlQuery = "SELECT * FROM kuldes.merkozes WHERE merkozesKod = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id.ToString());

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable GetForduloJvSzamById(int id)
        {
            string sqlQuery = "SELECT fordulo, jvSzam FROM kuldes.merkozes WHERE merkozesKod = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id.ToString());

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable GetMerkozesByOsztaly(string osztaly)
        {
            string sqlQuery = "SELECT * FROM kuldes.merkozes WHERE idOsztaly = " +
                "(SELECT idOsztaly FROM kuldes.osztaly WHERE osztalyMegnevezes = @osztaly);";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@osztaly", osztaly);

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable GetMerkozesByFordulo(string fordulo)
        {
            string sqlQuery = "SELECT * FROM kuldes.merkozes WHERE fordulo = @fordulo ;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@fordulo", fordulo);

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable GetMerkozesByForduloAndOsztaly(string fordulo, string osztaly)
        {
            string sqlQuery = "SELECT * FROM kuldes.merkozes WHERE idOsztaly = " +
                " (SELECT idOsztaly FROM kuldes.osztaly WHERE osztalyMegnevezes = @osztaly" +
                " AND  fordulo = @fordulo) ;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@fordulo", fordulo);
            parameters.Add("@osztaly", osztaly);

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable GetMerkozesJvSzamById(int id)
        {
            string sqlQuery = "SELECT jvSzam FROM kuldes.merkozes WHERE merkozesKod = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id.ToString());

            return CRUD.Select(sqlQuery, parameters);
        }
    }
}
