using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuldorendszer
{
    public partial class Osztaly : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        MySqlCommand cmd;
        public Osztaly()
        {
            InitializeComponent();
        }

        private void btnMegse_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztos hogy bezárod az ablakot!", "Bezár",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool ervenyes = false;
            bool foglalt = false;

            if (Int32.TryParse(txtBOsztalyKod.Text, out int osztalyKod))
            {
                if (osztalyKod > 99999999)
                {
                    MessageBox.Show("Az osztály kódja nem lehet ennyi!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ervenyes = false;
                }
                else ervenyes = true;
            }
            else
                MessageBox.Show("Az osztály kódja csak számot tartalmazhat.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            adapter = new MySqlDataAdapter($"SELECT idOsztaly FROM kuldes.osztaly ;", connection);
            if (adapter != null)
            {
                adapter.Fill(dt);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == txtBOsztalyKod.Text.Trim()) 
                {
                    foglalt = true;
                    break;
                }
            }
            if (foglalt)
            {
                MessageBox.Show("Már van ilyen kódú osztáy!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (ervenyes && !foglalt)
            {

                cmd = new MySqlCommand($"INSERT INTO kuldes.osztaly VALUES ({osztalyKod}, " +
                    $" @osztaly);", connection);
                try
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@osztaly", txtBOsztaly.Text.Trim()); 
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch
                {
                    throw new Exception("Hiba");
                }
                connection.Close();
                MessageBox.Show("Sikeres adatfelvitel", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
