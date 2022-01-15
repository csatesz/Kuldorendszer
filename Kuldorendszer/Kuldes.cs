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
            txtBHely.Text = table.Rows[index][5].ToString();
            txtBKod.Text = table.Rows[index][0].ToString();
            txtBHazai.Text = table.Rows[index][1].ToString();
            txtBVendeg.Text = table.Rows[index][2].ToString();
            txtBDatum.Text = table.Rows[index][4].ToString();
            txtBJV.Text = table.Rows[index][3].ToString();
            txtBVerseny.Text = table.Rows[index][6].ToString();
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
            List<ListBoxItems> merkozesek = new List<ListBoxItems>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                merkozesek.Add(new ListBoxItems
                {
                    Kod = (int)table.Rows[i][0],
                    Text = table.Rows[i][1].ToString() + "\t-\t" + table.Rows[i][2].ToString()
                });

            }
            lBMerkozesek.DisplayMember = "Text";
            lBMerkozesek.ValueMember = "Kod";
            lBMerkozesek.DataSource = merkozesek;
            lBMerkozesek.Refresh();
            lBMerkozesek.SelectedIndex = -1;
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
                adapter.Fill(table);

                pos = 0;
                ShowData(pos);
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
    }
}
