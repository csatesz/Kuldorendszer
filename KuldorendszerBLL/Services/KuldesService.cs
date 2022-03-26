using KuldorendszerBLL.Interfaces;
using KuldorendszerDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace KuldorendszerBLL
{
    public class KuldesService : IKuldesService
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
        public DataTable GetMerkozesJvvel() 
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
        public DataTable GetJatekvezetokOnKuldesByMerkozesKod(string mKod)
        {
            string sqlQuery = "SELECT j.nev FROM (kuldes.jatekvezetok j INNER JOIN " +
                $" kuldes.kuldes k ON j.jvKod = k.jvKod OR j.jvKod = k.assz1Kod OR j.jvKod = k.assz2Kod ) " +
                $" WHERE k.merkozesKod = @mKod ;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@mKod", mKod);

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable JatekvezetoOsszesMerkozesStat(int id)
        {// dátum(merkozesDatum) és osztály(idOsztaly) szerinti szűrést is betenni!
            string sqlQuery = "SELECT COUNT(k.jvKod OR k.assz1Kod OR k.assz2Kod) FROM kuldes.kuldes k " +
                $" WHERE k.jvKod = @id OR k.assz1Kod = @id OR k.assz2Kod = @id " +
                $"  ;"; 
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            //parameters.Add("@keret", keret);

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable JatekvezetoOsszesMerkozesStat(int id, int osztId)
        {// dátum(merkozesDatum) szerinti szűrést is betenni!
            string sqlQuery = "SELECT COUNT(k.jvKod OR k.assz1Kod OR k.assz2Kod) FROM (kuldes.kuldes k " +
                $" INNER JOIN kuldes.merkozes m ON m.merkozesKod = k.merkozesKod)  " +
                $" WHERE k.jvKod = @id OR k.assz1Kod = @id OR k.assz2Kod = @id " +
                $" AND m.idOsztaly = @osztId ;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@osztId", osztId);

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
        public DataTable SzabadJatekvezetok(DateTime date, int interval)
        {// lekérdezem az összes mérkőzést 4 órán belül, utána jv-ket akik vezetik, majd aki nem működik szabad 
            MerkozesService m = new MerkozesService();
            DataTable dtMerkKod = m.GetMerkozesKodByDate(date, interval);//adott időn kívüli mérkőzéskódok.
            JatekvezetoService jv = new JatekvezetoService();
            DataTable dtJv = jv.GetAllJatekvezeto();// mérkőzés osztályára is szűrjek?
            KuldesService k = new KuldesService();
            foreach (DataRow rw in dtJv.Rows)// where keret = merkozes osztaly
            {
                string nev = rw[1].ToString(); // rw[0] jv kódja , rw[1] neve, rw[3] keret/osztály
                foreach (DataRow row in dtMerkKod.Rows)
                {//row[0] mérkőzéskódú küldésen működő jv, asszisztensek       
                    DataTable aktivJvdt = k.GetJatekvezetokOnKuldesByMerkozesKod(row[0].ToString());
                    if (aktivJvdt.Rows.Count > 0)
                        for (int i = 0; i < aktivJvdt.Rows.Count; i++)
                        {
                            string aktiv = aktivJvdt.Rows[i][0].ToString();
                            if (nev == aktiv)
                            {//Ha van a mérkőzéskódon működő jv, azokat törölni a szabad táblából.
                                rw.Delete();
                            }
                        }
                }
            }
            dtJv.AcceptChanges();
            return dtJv;
        }
        public bool KuldesKeszit(int merkozesKod, DateTime date, int jvszam, int osztalyid)
        {
            List<int> jvKod = new List<int>();
            List<int> asszisztKod = new List<int>();
            OsztalyService o = new OsztalyService();
            //DataTable dto = o.GetOsztalyById(osztalyid);
            //string keret = dto.Rows[0][0].ToString();
            int i = 0;
            DataTable dtszbad = SzabadJatekvezetok(date, 4);//id , név, feladatkör, Keret(osztály), minősítés, település, telefon, törölt
            //akinek +- 4 órán belül nincs mérkőzése azon a mehetnek + az osztályt is nézni!
            foreach (DataRow row in dtszbad.Rows)
            {// Azok vezethetnek adott osztályban akik osztály id-je alacsonyabb!
                DataTable dto = o.GetIdByOsztalyNev(dtszbad.Rows[i][3].ToString());
                int keretOsztalyId = Int32.Parse(dto.Rows[0][0].ToString());
                if (dtszbad.Rows[i][2].ToString() == "játékvezető" && keretOsztalyId <= osztalyid)
                    jvKod.Add(Int32.Parse(dtszbad.Rows[i][0].ToString()));
                else // ha nem vezethet az adott osztályban, még asszisztálhat
                    asszisztKod.Add(Int32.Parse(dtszbad.Rows[i][0].ToString()));
                i++;
            }
            if (jvKod.Count < 1) // nincs küldhető játékvezető!
            {
                return false;
            }
            switch (jvszam)
            { // a jv-k kódját kell elküldeni. Random nevezem ki a jv-t és az asszisztens(eke)t!
                case 1: // 1 jv
                    AddKuldes(merkozesKod.ToString(), jvKod[RandomSzam(jvKod.Count)].ToString(), null, null, 0);
                    break;
                case 2:// 1 jv 1 assziszt
                    AddKuldes(merkozesKod.ToString(), jvKod[RandomSzam(jvKod.Count)].ToString(),
                        asszisztKod[RandomSzam(asszisztKod.Count)].ToString(), null, 0);
                    break;
                case 3:// 1 jv 2 assziszt - a 2. nem lehet ugyanaz! 
                    AddKuldes(merkozesKod.ToString(), jvKod[RandomSzam(jvKod.Count)].ToString(),
                        asszisztKod[RandomSzam(asszisztKod.Count)].ToString(),
                        asszisztKod[RandomSzam(asszisztKod.Count)].ToString(), 0);
                    break;
            }
            return true;
        }
        public int RandomSzam(int adat)
        {
            var rnd = new Random();
            int szam = rnd.Next(adat);
            return szam;
        }
    }
}