using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace KuldorendszerDAL
{
    public class CRUD
    {
        private static string getConnectionString()
        {
            string host = "datasource=localhost;";
            string port = "port=3306;";
            string user = "username=root;";
            string pass = "password=";
            //string db = "Database=;";
            string conString = string.Format("{0}{1}{2}{3}", host, port, user, pass);

            return conString;
        }
        public static bool InsertUpdateDelete(string sql, Dictionary<string, object> parameters)
        {
            using (MySqlConnection con = new MySqlConnection(getConnectionString()))
            {
                try
                {
                    con.Open();

                    using (MySqlCommand sqlCommand = new MySqlCommand(sql, con))
                    {
                        // Dictionary-hoz hozzáadni paramétereket
                        foreach (KeyValuePair<string, object> parameter in parameters)
                            sqlCommand.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));

                        if (sqlCommand.ExecuteNonQuery() > 0) return true;
                        else return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba: " + ex.Message, " CRUD művelet sikertelen!");
                    return false;
                }
            }
        }
        public static DataTable Select(string sql, Dictionary<string, object> parameters = null)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(getConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    using (MySqlCommand sqlCommand = new MySqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.Text;

                        if (parameters != null)
                            foreach (KeyValuePair<string, object> parameter in parameters)
                                sqlCommand.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));

                        using (MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sqlDataAdapter.Fill(dt);
                                return dt;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba: " + ex.Message, " CRUD művelet sikertelen!");
                    return null;
                }
            }
        }
    }
}
