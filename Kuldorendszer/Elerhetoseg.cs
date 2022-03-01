using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuldorendszer
{
    public partial class Elerhetoseg : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        MySqlCommand cmd;
        public Elerhetoseg()
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
            if (txtBEmail.Text == "" || txtBEmail.Text == null)
            {
                MessageBox.Show("Az email nem lehet üres!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    MailAddress email = new MailAddress(txtBEmail.Text.Trim());
                    ervenyes = (email.Address == txtBEmail.Text.Trim());
                }
                catch (FormatException)
                {
                    MessageBox.Show("Az email cím nem érvényes!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            adapter = new MySqlDataAdapter($"SELECT email FROM kuldes.elerhetoseg ;", connection);

            //Külön osztályba szervezni a CRUD műveleteket!
            //SqlTevekenyseg.sql = "SELECT email FROM kuldes.elerhetoseg ;";
            //SqlTevekenyseg.cmd = new MySqlCommand(SqlTevekenyseg.sql, SqlTevekenyseg.conn);
            //SqlTevekenyseg.cmd.Parameters.Clear(); // itt hiba van
            //SqlTevekenyseg.cmd.Parameters.AddWithValue("", e); // paraméter hozzáadása
            //DataTable dt =  SqlTevekenyseg.CRUD(SqlTevekenyseg.cmd);

            if (adapter != null)
            {
                adapter.Fill(dt);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == txtBEmail.Text)
                {
                    foglalt = true;
                    break;
                }
            }
            if (ervenyes && !foglalt)
            {
                cmd = new MySqlCommand($"INSERT INTO kuldes.elerhetoseg VALUES (\"{txtBElerhetosegKod.Text}\", " +
                    $" \"{txtBEmail.Text}\", \"{txtBTelSzam.Text}\") ;", connection);
                try
                {
                    connection.Open();
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
            else
            {
                MessageBox.Show("Az email cím már foglalt, vagy nem érvényes!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
