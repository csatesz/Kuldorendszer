using KuldorendszerDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuldorendszerBLL
{
    public class ElerhetosegBLL
    {
        public DataTable GetAllElerhetoseg()
        {
            string sqlQuery = "SELECT * FROM kuldes.elerhetoseg ;";

            return CRUD.Select(sqlQuery);
        }

        public DataTable GetIdByEmail(string email)
        {
            string sqlQuery = "SELECT elerhetosegKod FROM kuldes.elerhetoseg WHERE email = @email;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@email", email);
            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable GetEmailById(int id)
        {
            string sqlQuery = "SELECT email FROM kuldes.elerhetoseg WHERE elerhetosegKod = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id.ToString());
            return CRUD.Select(sqlQuery, parameters);
        }
        public DataTable GetElerhetosegSearch(string keres)
        {
            string sqlQuery = $"SELECT * FROM kuldes.elerhetoseg WHERE email LIKE \"%{keres}%\" ;";

            return CRUD.Select(sqlQuery);
        }
        public bool AddElerhetoseg(string email, string telefon)
        {
            string sqlQuery = "INSERT INTO kuldes.elerhetoseg (email, telefon) VALUES (@email, @telefon) ;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@email", email);
            parameters.Add("@telefon", Int32.Parse(telefon));

            return CRUD.InsertUpdateDelete(sqlQuery, parameters, false);
        }
        public bool UpdateElerhetoseg(int id, string oszlop, string adat)
        {
            string sqlQuery = $"UPDATE kuldes.elerhetoseg SET {oszlop} = @adat WHERE elerhetosegKod = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            if (oszlop == "email")
                parameters.Add("@adat", adat);
            else
                parameters.Add("@adat", Int32.Parse(adat));
            return CRUD.InsertUpdateDelete(sqlQuery, parameters, false);
        }
        public bool DeleteElerhetoseg(string id)
        {
            string sqlQuery = "DELETE FROM kuldes.elerhetoseg WHERE elerhetosegKod= @id ; ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            return CRUD.InsertUpdateDelete(sqlQuery, parameters, false);
        }
        public DataTable GetAllEmail()
        {
            string sqlQuery = "SELECT email FROM kuldes.elerhetoseg";
            return CRUD.Select(sqlQuery);
        }
    }
}
