using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuldorendszer
{
    class SqlTevekenyseg
    {
        private static string getConnectionString()
        {

            string host = "datasource=localhost;";
            string port = "port=3306;";
            //string db = "Database=;";
            string user = "username=root;";
            string pass = "password=";

            string conString = string.Format("{0}{1}{2}{3}", host, port, user, pass);

            return conString;

        }

        public static MySqlConnection conn = new MySqlConnection(getConnectionString());
        public static MySqlCommand cmd = default(MySqlCommand);
        public static string sql = string.Empty;

        public static DataTable CRUD(MySqlCommand com)
        {

            MySqlDataAdapter adapter = default(MySqlDataAdapter);
            DataTable dt = new DataTable();

            try
            {
                adapter = new MySqlDataAdapter(com);
                adapter.SelectCommand = com;
                adapter.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba: " + ex.Message, " CRUD művelet sikertelen!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dt = null;
            }

            return dt;
        }
    }
}
