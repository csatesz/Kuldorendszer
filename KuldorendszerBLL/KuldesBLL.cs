using KuldorendszerDAL;
using System.Collections.Generic;
using System.Data;

namespace KuldorendszerBLL
{
    public class KuldesBLL
    {
        public bool AddKuldes(string merkozesKod, string jvKod, string assz1Kod, string assz2Kod, int torolt)
        {
            string sqlQuery = "INSERT INTO kuldes.kuldes (merkozesKod, jvKod, assz1Kod, assz2Kod) " +
                " VALUES(@kod, @jvKod, @assz1Kod, @assz2Kod)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@kod", merkozesKod);
            parameters.Add("@jvKod", jvKod);
            parameters.Add("@assz1Kod", assz1Kod);
            parameters.Add("@assz2Kod", assz2Kod);
            parameters.Add("@torolt", torolt);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters, false);
        }
        public bool UpdateKuldes(string merkozesKod, string jvKod, string assz1Kod, string assz2Kod, int torolt)
        {
            string sqlQuery = "UPDATE kuldes.kuldes SET jvKod = @jvKod, assz1Kod =  @assz1Kod, " +
                " assz2Kod = @assz2Kod, torolt = @torolt WHERE merkozesKod = @merkozesKod ";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@jvKod", jvKod);
            parameters.Add("@assz1Kod", assz1Kod);
            parameters.Add("@assz2Kod", assz2Kod);
            parameters.Add("@merkozesKod", merkozesKod);
            parameters.Add("@torolt", torolt);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters, false);
        }
        public DataTable GetMerkozesJvvel()
        {   
            string sqlQuery = "SELECT m.merkozesDatum, t.Telepules, c.csapatNev, " +
                "  d.csapatNev, j.nev " + //, j.nev, j.nev
                " FROM (((((kuldes.merkozes m INNER JOIN kuldes.telepules t ON t.IdTelepules = m.IdTelepules)" +
                " INNER JOIN kuldes.csapatok c ON c.idCsapat = m.hazaiCsapatId)" +
                " INNER JOIN kuldes.csapatok d ON d.idCsapat = m.vendegCsapatId)" +
                " INNER JOIN kuldes.kuldes k ON m.merkozesKod = k.merkozesKod) " +
                " INNER JOIN kuldes.jatekvezetok j ON k.jvKod = j.jvKod ) " +
                " WHERE  m.merkozesDatum > CURRENT_TIMESTAMP ORDER BY m.merkozesKod ;";
            return CRUD.Select(sqlQuery);
        }
        public DataTable GetJatekvezetoOnKuldesByMerkozesKod(string mKod, string feladat)
        {
            string sqlQuery = "SELECT j.nev FROM (kuldes.jatekvezetok j INNER JOIN " +
                $" kuldes.kuldes k ON j.jvKod = k.{feladat}) WHERE k.merkozesKod = @mKod ;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@mKod", mKod);

            return CRUD.Select(sqlQuery, parameters);
        }
    }
}