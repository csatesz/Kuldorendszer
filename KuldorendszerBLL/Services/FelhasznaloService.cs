using KuldorendszerBLL.Interfaces;
using KuldorendszerDAL;
using System.Collections.Generic;
using System.Data;

namespace KuldorendszerBLL
{
    public class FelhasznaloService: IFelhasznaloService
    {
        //DataTable dt = new DataTable();
        public DataTable SelectUserByName(string nev)
        { //try catch?
          //Felhasznalo felh = new Felhasznalo();
          //Database db = InitializeDatabase();
            string sqlQuery = $"SELECT * FROM kuldes.felhasznalo WHERE felhNev = @felhNev " +
                  $" AND (torolt = 0 OR torolt is NULL); ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@felhNev", nev);

            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable GetAllUser()
        { 
            string sqlQuery = $"SELECT felhKod, felhNev, email, admin, aszf, torolt FROM kuldes.felhasznalo ;";
            //" FROM kuldes.felhasznalo WHERE torolt = 0 OR torolt is NULL); ";
            //Dictionary<string, object> parameters = new Dictionary<string, object>();

            return CRUD.Select(sqlQuery);
        }
        public bool AddUser(string nev, string email, string jelszo, bool admin, bool aszf)
        {
            string sqlQuery = "INSERT INTO kuldes.felhasznalo (felhNev, email, jelszo, admin, aszf) " +
                    $"VALUES (@felhNev, @email, @jelszo, @admin, @aszf)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@felhNev", nev);
            parameters.Add("@email", email);
            parameters.Add("@jelszo", jelszo);
            parameters.Add("@admin", admin);
            parameters.Add("@aszf", aszf);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters);
        }

        public DataTable GetfelhasznaloSearch(string keres)
        {
            string sqlQuery = $"SELECT felhKod, felhNev, email, admin, aszf, torolt FROM kuldes.felhasznalo WHERE " +
                $" felhNev LIKE \"%{keres}%\" OR email LIKE \"%{keres}%\";";

            return CRUD.Select(sqlQuery);
        }
        public bool ArchiveFelhasznalo(string id)
        {
            string sqlQuery = $"UPDATE kuldes.felhasznalo SET torolt = true WHERE felhKod = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return CRUD.InsertUpdateDelete(sqlQuery, parameters);
        }
        public bool UpdateFelhasznalo(int id, string oszlop, string adat)
        {
            string sqlQuery = $"UPDATE kuldes.felhasznalo SET {oszlop} = @adat WHERE felhKod = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@adat", adat);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters);
        }
    }
}
