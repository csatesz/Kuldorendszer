using KuldorendszerBLL.Interfaces;
using KuldorendszerDAL;
using System.Collections.Generic;
using System.Data;

namespace KuldorendszerBLL
{
    public class JatekvezetoService : IJatekvezetoService
    {
        public DataTable GetAllJatekvezeto()
        {
            string sqlQuery = "SELECT j.jvKod, j.nev, j.feladatkor, j.keret, j.minosites, " +
                " t.Telepules, e.telefon, j.torolt " +
                " FROM ((kuldes.jatekvezetok j INNER JOIN kuldes.telepules t ON j.idTelepules = t.idTelepules) " +
                " INNER JOIN kuldes.elerhetoseg e ON e.elerhetosegKod = j.elerhetosegKod) ;";

            return CRUD.Select(sqlQuery);
        }
        public DataTable GetJatekvezetoSearch(string keres)
        {
            string sqlQuery = "SELECT j.jvKod, j.nev, j.feladatkor, j.keret, j.minosites, t.Telepules, e.telefon " +
                " FROM ((kuldes.jatekvezetok j INNER JOIN kuldes.telepules t ON j.idTelepules = t.idTelepules) " +
                " INNER JOIN kuldes.elerhetoseg e ON e.elerhetosegKod = j.elerhetosegKod) " +
                $" WHERE nev LIKE \"%{keres}%\" OR feladatkor LIKE \"%{keres}%\" OR keret LIKE \"%{keres}%\";";

            return CRUD.Select(sqlQuery);
        }
        public bool ArchiveJatekvezeto(string id)
        {
            string sqlQuery = $"UPDATE kuldes.jatekvezetok SET torolt = true WHERE jvKod = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return CRUD.InsertUpdateDelete(sqlQuery, parameters);
        }
        public bool UpdateJatekvezeto(int id, string oszlop, string adat)
        {
            string sqlQuery = $"UPDATE kuldes.jatekvezetok SET {oszlop} = @adat WHERE jvKod = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@adat", adat);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters);
        }
        public bool AddJatekvezeto(int jvKod, string nev, int elKod, int telep, string min,
                    string oszt, string feladat, int torolt)
        {
            string sqlQuery = "INSERT INTO kuldes.jatekvezetok VALUES(@jvKod, @nev, @elKod, " +
                    " @telep, @min, @oszt,@feladat, @torolt)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@jvKod", jvKod);
            parameters.Add("@nev", nev);
            parameters.Add("@elKod", elKod);
            parameters.Add("@telep", telep);
            parameters.Add("@min", min);
            parameters.Add("@oszt", oszt);
            parameters.Add("@feladat", feladat);
            parameters.Add("@torolt", torolt);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters);
        }
        public DataTable GetJatekvezetoById(int id)
        {
            string sqlQuery = "SELECT nev FROM kuldes.jatekvezetok WHERE jvKod = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id.ToString());

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable GetJatekvezetoAdatById(int id)
        {
            string sqlQuery = "SELECT * FROM kuldes.jatekvezetok WHERE jvKod = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id.ToString());

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable GetJatekvezetoNevIdByMerkozesKod(int kod, string feladat)// ez jó így?
        {
            string sqlQuery = $"SELECT j.nev, j.jvKod FROM ((kuldes.jatekvezetok j INNER JOIN " +
               $" kuldes.kuldes k ON j.jvKod = k.{feladat}) INNER JOIN kuldes.merkozes m ON " +
                " k.merkozesKod = @kod);";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@kod", kod);

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable GetJatekvezetoByFeladat(string feladat)
        {
            string sqlQuery = "SELECT nev FROM kuldes.jatekvezetok WHERE feladatkor = @feladat;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@feladat", feladat);

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable GetJatekvezetoIdByNev(string nev)
        {
            string sqlQuery = "SELECT jvKod FROM kuldes.jatekvezetok WHERE nev = @nev ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@nev", nev);

            return CRUD.Select(sqlQuery, parameters);
        }

        public bool UpdateMindenJatekvezetoAdat(int jvKod, string nev, int elKod, int telep, string min, string oszt, string feladat, int torolt)
        {
            string sqlQuery = "UPDATE kuldes.jatekvezetok SET nev = @nev, elerhetosegKod  = @elKod, " +
                     " idTelepules = @telep, minosites = @min, keret = @oszt, feladatkor = @feladat, " +
                     " torolt = @torolt WHERE jvKod = @jvKod ;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@jvKod", jvKod);
            parameters.Add("@nev", nev);
            parameters.Add("@elKod", elKod);
            parameters.Add("@telep", telep);
            parameters.Add("@min", min);
            parameters.Add("@oszt", oszt);
            parameters.Add("@feladat", feladat);
            parameters.Add("@torolt", torolt);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters);
        }
    }
}
