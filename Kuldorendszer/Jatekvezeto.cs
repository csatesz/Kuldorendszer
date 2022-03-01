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
    public partial class Jatekvezeto : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlDataAdapter adapter;
        //DataTable dt = new DataTable();
        MySqlCommand cmd;
        int telep, elKod = 0;

        public Jatekvezeto()
        {
            InitializeComponent();
        }
        private void Jatekvezeto_Load(object sender, EventArgs e)
        {
            FillCombos();
        }

        private void txtBFordulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool ervenyes = false;
            bool foglalt = false;

            if (Int32.TryParse(txtBJvKod.Text, out int jvKod))
            {
                if (jvKod > 99999999 || jvKod < 1)
                {
                    MessageBox.Show("A játékvezető kódja nem lehet ennyi!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ervenyes = false;
                }
                else ervenyes = true;
            }
            else
                MessageBox.Show("A játékvezető kódja csak számot tartalmazhat.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if (String.IsNullOrEmpty(txtBJvNev.Text))
            {
                MessageBox.Show("A játékvezető neve nem lehet üres.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                ervenyes = false;
            }
            if (cBoxOsztaly.SelectedIndex < 0 || cBoxTelepules.SelectedIndex < 0 || cBoxElerhetoseg.SelectedIndex < 0)
            {
                MessageBox.Show("Válassz ki keretet/települést/elérhetőséget!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ervenyes = false;
            }
            if (ervenyes && !foglalt)
            {

                cmd = new MySqlCommand($"INSERT INTO kuldes.jatekvezetok VALUES ({jvKod}, " +
                    $" \"{txtBJvNev.Text}\", {elKod}, {telep}, \"{txtBMinosites.Text}\", \"{cBoxOsztaly.Text}\", " +
                    $" \"{cBoxFeladat.Text}\", 0)", connection);
                try
                {
                    connection.Open();
                    //cmd.Parameters.AddWithValue("@elerhetoseg", cBoxElerhetoseg.Text.Trim()); //id csapatokból névől kódot visszaadni
                    //cmd.Parameters.AddWithValue("@telepules", cBoxTelepules.Text.Trim()); //itt is település kód
                    //cmd.Parameters.AddWithValue("@keret", cBoxOsztaly.Text.Trim());
                    //cmd.Parameters.AddWithValue("@osztaly", cBoxOsztaly.Text.Trim());// itt is osztálykód
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
        private void btnMegse_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztos hogy bezárod az ablakot!", "Bezár",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void FillCombos()
        {
            cBoxElerhetoseg.Items.Clear();
            cBoxOsztaly.Items.Clear();
            cBoxTelepules.Items.Clear();
            cBoxFeladat.Items.Clear();
            cBoxTelepules.Items.Add("Új település");
            cBoxElerhetoseg.Items.Add("Új elérhetőség");
            cBoxFeladat.Items.Add("Új tipusú feladat");
            cBoxFeladat.Items.Add("asszisztens");
            cBoxFeladat.Items.Add("játékvezető");

            adapter = new MySqlDataAdapter("SELECT osztalyMegnevezes FROM kuldes.osztaly", connection);
            DataTable dt1 = new DataTable();
            adapter.Fill(dt1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string osztaly = dt1.Rows[i][0].ToString();
                cBoxOsztaly.Items.Add(osztaly);
            }
            //cBoxOsztaly.SelectedIndex = -1;
            adapter = new MySqlDataAdapter("SELECT email FROM kuldes.elerhetoseg", connection);
            DataTable dt2 = new DataTable();
            adapter.Fill(dt2);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                string nev = dt2.Rows[i][0].ToString();
                cBoxElerhetoseg.Items.Add(nev);
            }
            //cBoxFordulo.SelectedIndex = -1;
            adapter = new MySqlDataAdapter("SELECT Telepules FROM kuldes.telepules", connection);
            DataTable dt3 = new DataTable();
            adapter.Fill(dt3);
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                string telepules = dt3.Rows[i][0].ToString();
                cBoxTelepules.Items.Add(telepules);
            }
        }

        private void cBoxElerhetoseg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxElerhetoseg.Text == "Új elérhetőség")
            {
                Elerhetoseg el = new Elerhetoseg(); //elérhetőség felvitel
                el.Show();
                FillCombos();
            }
            else
            {
                adapter = new MySqlDataAdapter($"SELECT elerhetosegKod FROM kuldes.elerhetoseg e" +
                   $" WHERE e.email = \"{cBoxElerhetoseg.Text}\" ;", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Int32.TryParse(dt.Rows[0][0].ToString(), out elKod);
            }
        }

        private void cBoxTelepules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxTelepules.Text == "Új település") //település felvitel
            {
                Telepules t = new Telepules();
                t.Show();
                FillCombos();
            }
            else
            {
                adapter = new MySqlDataAdapter($"SELECT idTelepules FROM kuldes.telepules " +
                    $"WHERE Telepules = \"{cBoxTelepules.SelectedItem}\"", connection);
                DataTable dto = new DataTable();
                adapter.Fill(dto);
                Int32.TryParse(dto.Rows[0][0].ToString(), out telep);
            }
        }

        private void cBoxOsztaly_SelectedIndexChanged(object sender, EventArgs e)
        {
            //adapter = new MySqlDataAdapter($"SELECT idOsztaly FROM kuldes.osztaly WHERE osztalyMegnevezes = \"{cBoxOsztaly.SelectedItem}\"", connection);
            //DataTable dto = new DataTable();
            //adapter.Fill(dto);
            //Int32.TryParse(dto.Rows[0][0].ToString(), out keret);
        }
    }
}
