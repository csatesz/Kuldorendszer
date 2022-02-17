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
    public partial class Csapat : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        MySqlCommand cmd;
        public Csapat()
        {
            InitializeComponent();
        }
        private void Csapat_Load(object sender, EventArgs e)
        {
            FillCombos();
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

            if (Int32.TryParse(txtBCsapatKod.Text, out int csKod))
            {
                if (csKod > 99999999)
                {
                    MessageBox.Show("A csapat kódja nem lehet ennyi!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ervenyes = false;
                }
                //else ervenyes = true;
            }
            else
                MessageBox.Show("A csapat kódja csak számot tartalmazhat.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
            adapter = new MySqlDataAdapter($"SELECT idCsapat FROM kuldes.csapatok ;", connection);
            if (adapter != null)
            {
                adapter.Fill(dt);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == txtBCsapatKod.Text) // nem teljes számot vizsgál
                {
                    foglalt = true;
                    break;
                }
            }
            if (foglalt)
            {
                MessageBox.Show("Már van ilyen kódú csapat.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (ervenyes && !foglalt)
            {

                cmd = new MySqlCommand($"INSERT INTO kuldes.csapatok VALUES ({csKod}, " +
                    $" \"{txtBCsapatNev.Text}\", @elerhetoseg, \"{txtBCsapatvezeto.Text}\", @osztaly ) ;", connection);
                try
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@elerhetoseg", cBoxElerhetoseg.Text.Trim()); //id csapatokból névől kódot visszaadni
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
        private void FillCombos()
        {
            cBoxElerhetoseg.Items.Clear();
            cBoxOsztaly.Items.Clear();
            cBoxElerhetoseg.Items.Add("Új elérhetőség");

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
        }

        private void cBoxElerhetoseg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxElerhetoseg.Text == "Új elérhetőség")
            {
                Regisztracio r = new Regisztracio(); //elérhetőség felvitel
                r.Show();
            }
        }
    }
}
