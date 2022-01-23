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
    public partial class Kuldes : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();
        int pos = 0;
        public Kuldes()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception)
            {
                throw new Exception("Hiba történt! Indítsa újra a programot.");
            }
        }

        private void Kuldes_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                adapter = new MySqlDataAdapter("SELECT * FROM kuldes.merkozes", connection);
                adapter.Fill(table);
            }
            catch
            {
                throw new Exception();
            }
            ShowData(pos);
            FillCombo();
            connection.Close();
        }

        private void FillCombo()
        {
            cBoxVerseny.Items.Clear();
            cBoxVerseny.Items.Add("Összes");
            adapter = new MySqlDataAdapter("SELECT osztalyMegnevezes FROM kuldes.osztaly", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            //reader = adapter.;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string osztaly = dt.Rows[i][0].ToString();
                cBoxVerseny.Items.Add(osztaly);
            }
        }

        public void ShowData(int index)
        {
            //connection.Open();
            adapter = new MySqlDataAdapter($"SELECT osztalyMegnevezes FROM kuldes.osztaly WHERE idOsztaly = {table.Rows[index][6]};", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            txtBVerseny.Text = dt.Rows[0][0].ToString(); // Osztály? idOsztály

            txtBKod.Text = table.Rows[index][0].ToString(); // mérkőzés kódja
            txtBDatum.Text = table.Rows[index][4].ToString(); // Mérkőzés dátuma

            adapter = new MySqlDataAdapter($"SELECT csapatNev FROM kuldes.csapatok WHERE idCsapat = {table.Rows[index][1]};", connection);
            DataTable dt2 = new DataTable();
            adapter.Fill(dt2);
            txtBHazai.Text = dt2.Rows[0][0].ToString(); // hazai csapat ID
            adapter = new MySqlDataAdapter($"SELECT csapatNev FROM kuldes.csapatok WHERE idCsapat = {table.Rows[index][2]};", connection);
            DataTable dt3 = new DataTable();
            adapter.Fill(dt3);
            txtBVendeg.Text = dt3.Rows[0][0].ToString();// vendég csapat ID

            adapter = new MySqlDataAdapter($"SELECT telepules FROM kuldes.telepules WHERE idTelepules = {table.Rows[index][5]};", connection);
            DataTable dt4 = new DataTable();
            adapter.Fill(dt4);
            txtBHely.Text = dt4.Rows[0][0].ToString();// Hol? idTelepules -> 

            txtBJV.Text = ""; // table.Rows[index][3].ToString(); ez a jv-k száma
            txtBAssz1.Text = "";
            txtBAssz1.Text = "";

            //connection.Close();
        }

        private void btnElozo_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos >= 0)
            {
                ShowData(pos);
            }
            else
            {
                MessageBox.Show("Elérte az adatok elejét!");
            }
        }

        private void btnKovetkezo_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos < table.Rows.Count)
            {
                ShowData(pos);
            }
            else
            {
                MessageBox.Show("Elérte az adatok végét!");
                pos = table.Rows.Count - 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void cBoxVerseny_SelectedIndexChanged(object sender, EventArgs e)
        {
            table.Clear();
            if (cBoxVerseny.SelectedIndex == 0)
            {
                Kuldes_Load(sender, e);
            }
            else
            {
                //lBMerkozesek.Items.Clear();
                string query = $"SELECT * FROM kuldes.merkozes WHERE idOsztaly = " +
                    $"(SELECT idOsztaly FROM kuldes.osztaly WHERE osztalyMegnevezes = \"{cBoxVerseny.SelectedItem}\");";
                adapter = new MySqlDataAdapter(query, connection);
                if (adapter != null)
                {
                    adapter.Fill(table);
                    if (table.Rows.Count != 0)
                    {
                        pos = 0;
                        ShowData(pos);
                    }
                    else
                    {
                        MessageBox.Show("Ebben az osztályban nincs mérkőzés!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }              

                
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (table.Rows.Count > 0)
            {
                pos = table.Rows.Count - 1;
                ShowData(pos);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            MessageBox.Show(e.ClickedItem.Text);
            string itemText = e.ClickedItem.Text;


            switch (itemText)
            {
                case "&file":
                    //do stuff
                    break;
                case "&edit":
                    // do stuff
                    break;
                case "&tools":
                    // do stuff
                    break;
                case "&help":
                    // do stuff
                    break;
            }
        }

        private void lBMerkozesek_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pos = lBMerkozesek.SelectedIndex;
            //ShowData(pos);
        }

        private void btnModosit_Click(object sender, EventArgs e)
        {
            cBoxJv.Visible= true;
            cBoxAssz1.Visible = true;
            cBoxAssz2.Visible = true;
            btnVegleg.Visible = true;

            cBoxJv.Items.Add("JV");
            cBoxAssz1.Items.Add("assz1");
            cBoxAssz2.Items.Add("assz2");

        }

        private void btnVegleg_Click(object sender, EventArgs e)
        {
            cBoxJv.Visible = false;
            txtBJV.Text = cBoxJv.Text;

            cBoxAssz1.Visible =false;
            txtBAssz1.Text = cBoxAssz1.Text;

            cBoxAssz2.Visible =false;
            txtBAssz2.Text = cBoxAssz2.Text;

            btnVegleg.Visible =false;
        }

        private void txtBVerseny_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKuldes_Click(object sender, EventArgs e)
        {
            List<ListBoxItems> merkozesek = new List<ListBoxItems>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                merkozesek.Add(new ListBoxItems
                {
                    Kod = (int)table.Rows[i][0],
                    Text = table.Rows[i][1].ToString() + "\t-\t" + table.Rows[i][2].ToString() +
                    "jv, " +" Assz1 " + " Assz2 "
                });

            }
            lBMerkozesek.DisplayMember = "Text";
            lBMerkozesek.ValueMember = "Kod";
            lBMerkozesek.DataSource = merkozesek;
            lBMerkozesek.Refresh();
            lBMerkozesek.SelectedIndex = -1;
        }
    }
}
