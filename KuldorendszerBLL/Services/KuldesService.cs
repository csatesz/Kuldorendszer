using KuldorendszerBLL.Interfaces;
using KuldorendszerDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace KuldorendszerBLL
{
    public class KuldesService: IKuldesService
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

            return CRUD.InsertUpdateDelete(sqlQuery, parameters);
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

            return CRUD.InsertUpdateDelete(sqlQuery, parameters);
        }
        public DataTable GetMerkozesJvvel() //Javítani kell ezt a LEKÉRDEZÉST!
        {
            string sqlQuery = "SELECT m.merkozesKod, m.merkozesDatum, t.Telepules, c.csapatNev,  d.csapatNev, j.nev" +
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
        public DataTable JatekvezetoOsszesMerkozesStat(int id)
        {
            string sqlQuery = "SELECT COUNT(k.jvKod OR k.assz1Kod OR k.assz2Kod) FROM kuldes.kuldes k " +
                $" WHERE k.jvKod = @id OR k.assz1Kod = @id OR k.assz2Kod = @id " +
                $"  ;"; // dátum(merkozesDatum) és osztály(idOsztaly) szerinti szűrést is betenni GROUPBY?!
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable JatekvezetoJvSzamStat(int id)
        {
            string sqlQuery = "SELECT COUNT(jvKod) FROM kuldes.kuldes WHERE jvKod = @id " +
                " ;";  // dátum és osztály szerinti szűrést is betenni
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable JatekvezetoAsszisztSzamStat(int id)
        {
            string sqlQuery = "SELECT COUNT(assz1Kod OR assz2Kod) FROM kuldes.kuldes WHERE assz1Kod = @id OR assz2Kod = @id" +
                " ;";  // dátum és osztály szerinti szűrést is betenni
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable SzabadJatekvezetok(DateTime date, int interval) //nem jó - Nem szűri dátum szerint! :(
        {
            string sqlQuery = "SELECT DISTINCT j.jvKod, j.nev, j.feladatkor FROM ((kuldes.jatekvezetok j INNER JOIN " +
                " kuldes.kuldes k ON j.jvKod <> k.jvKod) INNER JOIN  kuldes.merkozes m " +
                $" ON  m.merkozesDatum BETWEEN @fromdate AND  @todate) ;"; //feladatkör is!

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@fromdate", date.AddHours(-interval));
            parameters.Add("@todate", date.AddHours(interval));

            return CRUD.Select(sqlQuery, parameters);
        }
        public bool KuldesKeszit(int kod, DateTime date, int jvszam)
        {
            // akinek nincs mérkőzése azon a napon +- 4 óra mehetnek + az osztályt is nézni!!!
            DataTable dt = SzabadJatekvezetok(date, 4); //id , név és feladatkör lesz a táblában 
            switch (jvszam)
            { // a jv-k kódját kell elküldeni!!!
                case 1: // 1 jv
                        //if (dt.Rows[0][2].ToString() == "játékvezető")
                    AddKuldes(kod.ToString(), dt.Rows[0][0].ToString(), "0", "0", 0);
                    break;
                case 2:// 1 jv 1 assziszt
                    AddKuldes(kod.ToString(), dt.Rows[0][0].ToString(), dt.Rows[1][0].ToString(), "0", 0);
                    break;
                case 3:// 1 jv 2 assziszt
                    AddKuldes(kod.ToString(), dt.Rows[0][0].ToString(), dt.Rows[1][0].ToString(), dt.Rows[2][0].ToString(), 0);
                    break;
            }
            return true;
        }
    }
}