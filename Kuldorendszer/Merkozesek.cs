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
    public partial class Merkozesek : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        MySqlCommand cmd;
        int hazaiId, vendegId, telepId, osztId = 0;
        //string table = "";
        //string kod = "";
        public Merkozesek()
        {
            InitializeComponent();

        }
        private void Merkozesek_Load(object sender, EventArgs e)
        {
            FillCombos();
            this.dateTimePicker.Value = DateTime.Now;
        }
        private void FillCombos()
        {
            cBoxHazai.Items.Clear();
            cBoxVendeg.Items.Clear();
            cBoxTelepules.Items.Clear();
            cBoxOsztaly.Items.Clear();

            adapter = new MySqlDataAdapter("SELECT osztalyMegnevezes FROM kuldes.osztaly", connection);
            DataTable dt1 = new DataTable();
            adapter.Fill(dt1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string osztaly = dt1.Rows[i][0].ToString();
                cBoxOsztaly.Items.Add(osztaly);
            }
            //cBoxOsztaly.SelectedIndex = -1;
            adapter = new MySqlDataAdapter("SELECT csapatNev FROM kuldes.csapatok", connection);
            DataTable dt2 = new DataTable();
            adapter.Fill(dt2);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                string nev = dt2.Rows[i][0].ToString();
                cBoxHazai.Items.Add(nev);
                cBoxVendeg.Items.Add(nev);
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

            if (Int32.TryParse(txtBMKod.Text, out int merkozesKod))
            {
                if (merkozesKod > 99999999)
                {
                    MessageBox.Show("A mérkőzés kódja nem lehet ilyen hosszú!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ervenyes = false;
                }
                else ervenyes = true;
            }
            else
                MessageBox.Show("A mérkőzés kódja csak számot tartalmazhat.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if (Int32.TryParse(txtBJvSzam.Text, out int jvSzam))
            {
                if (jvSzam > 6)
                {
                    MessageBox.Show("A Játékvezető száma nem lehet ennyi!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ervenyes = false;
                }
                else ervenyes = true;
            }
            else
                MessageBox.Show("A Játékvezetők száma csak számot tartalmazhat!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if (Int32.TryParse(txtBFordulo.Text, out int fordulo))
            {
                if (fordulo > 50)
                {
                    MessageBox.Show("Nincs ennyi forduló!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ervenyes = false;
                }
                else ervenyes = true;
            }
            else
                MessageBox.Show("A forduló csak szám lehet!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            adapter = new MySqlDataAdapter($"SELECT merkozesKod FROM kuldes.merkozes ;", connection);
            if (adapter != null)
            {
                adapter.Fill(dt);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == txtBMKod.Text) // nem teljes számot vizsgál - mit csináljon
                {
                    foglalt = true;
                    break;
                }
            }
            if (ervenyes && !foglalt)
            {

                cmd = new MySqlCommand($"INSERT INTO kuldes.merkozes VALUES ({merkozesKod}, " +
                    $"{hazaiId}, {vendegId}, {jvSzam}, @datum, {telepId}, {osztId}, {fordulo})", connection);
                try
                {
                    connection.Open();
                    //cmd.Parameters.AddWithValue("@hazai", cBoxHazai.Text.Trim()); //id csapatokból névől kódot visszaadni
                    //cmd.Parameters.AddWithValue("@vendeg", cBoxVendeg.Text.Trim());// itt is id csapatokból 
                    //cmd.Parameters.AddWithValue("@telepules", cBoxTelepules.Text.Trim()); //itt is település kód
                    cmd.Parameters.AddWithValue("@datum", dateTimePicker.Value);
                    cmd.Parameters.AddWithValue("@osztaly", cBoxOsztaly.Text.Trim());// itt is osztálykód

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

        private void cBoxHazai_SelectedIndexChanged(object sender, EventArgs e)
        {
            adapter = new MySqlDataAdapter($"SELECT idCsapat FROM kuldes.csapatok" +
                $" WHERE csapatNev = \"{cBoxHazai.SelectedItem}\"", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Int32.TryParse(dt.Rows[0][0].ToString(), out hazaiId);
        }

        private void cBoxVendeg_SelectedIndexChanged(object sender, EventArgs e)
        {
            adapter = new MySqlDataAdapter($"SELECT idCsapat FROM kuldes.csapatok" +
                $" WHERE csapatNev = \"{cBoxVendeg.SelectedItem}\"", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Int32.TryParse(dt.Rows[0][0].ToString(), out vendegId);
        }

        private void cBoxTelepules_SelectedIndexChanged(object sender, EventArgs e)
        {
            adapter = new MySqlDataAdapter($"SELECT idTelepules FROM kuldes.telepules " +
                $" WHERE Telepules = \"{cBoxTelepules.SelectedItem}\"", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Int32.TryParse(dt.Rows[0][0].ToString(), out telepId);
        }

        private void cBoxOsztaly_SelectedIndexChanged(object sender, EventArgs e)
        {
            adapter = new MySqlDataAdapter($"SELECT idOsztaly FROM kuldes.osztaly WHERE osztalyMegnevezes = \"{cBoxOsztaly.SelectedItem}\"", connection);
            DataTable dto = new DataTable();
            adapter.Fill(dto);
            Int32.TryParse(dto.Rows[0][0].ToString(), out osztId);
        }
    }
}
