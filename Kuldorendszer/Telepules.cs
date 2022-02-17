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
    public partial class Telepules : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        MySqlCommand cmd;
        public Telepules()
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

            if (Int32.TryParse(txtBTelepulesKod.Text, out int telepulesKod))
            {
                if (telepulesKod > 99999999)
                {
                    MessageBox.Show("A település kódja nem lehet ennyi!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ervenyes = false;
                }
                else ervenyes = true;
            }
            else
                MessageBox.Show("A település kódja csak számot tartalmazhat.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if (Int32.TryParse(txtBIrSzam.Text, out int irSzam))
            {
                if (irSzam > 9999)
                {
                    MessageBox.Show("Az irányítószám nem lehet ennyi!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ervenyes = false;
                }
                else ervenyes = true;
            }
            else
                MessageBox.Show("A irányítószám csak 4 jegyű számot tartalmazhat.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            adapter = new MySqlDataAdapter($"SELECT idTelepules FROM kuldes.telepules ;", connection);
            if (adapter != null)
            {
                adapter.Fill(dt);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == txtBTelepulesKod.Text) // nem teljes számot vizsgál
                {
                    foglalt = true;
                    break;
                }
            }
            if (foglalt)
            {
                MessageBox.Show("Már van ilyen kódú település.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (ervenyes && !foglalt)
            {

                cmd = new MySqlCommand($"INSERT INTO kuldes.telepules VALUES ({telepulesKod}, " +
                    $" @telep, {irSzam} );", connection);
                try
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@telep", txtBTelepules.Text.Trim()); // létező id-t ne írjon felül!

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
