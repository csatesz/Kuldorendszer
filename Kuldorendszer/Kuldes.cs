using Kuldorendszer.Models;
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
        DataTable merkozesekJvel = new DataTable();
        DataTable jv = new DataTable();
        DataTable assz = new DataTable();

        MySqlCommand cmd;
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
            connection.Close();
            ShowData(pos);
            FillCombo();
            MerkozesJvvel();
            FillJvCombo();
        }

        private void FillCombo()
        {
            cBoxVerseny.Items.Clear();
            cBoxFordulo.Items.Clear();
            cBoxVerseny.Items.Add("Összes");
            cBoxFordulo.Items.Add("Összes");
            cBoxVerseny.SelectedItem = "Összes";
            cBoxFordulo.SelectedItem = "Összes";
            //connection.Open();
            adapter = new MySqlDataAdapter("SELECT osztalyMegnevezes FROM kuldes.osztaly", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            //connection.Close();
            //reader = adapter.;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string osztaly = dt.Rows[i][0].ToString();
                cBoxVerseny.Items.Add(osztaly);
            }
            //cBoxVerseny.SelectedIndex = -1;
            List<int> forduloszam = new List<int>();
            for (int j = 0; j < table.Rows.Count; j++)
            {
                if (!forduloszam.Contains((int)table.Rows[j][7]))
                {
                    forduloszam.Add((int)table.Rows[j][7]);
                    cBoxFordulo.Items.Add(table.Rows[j][7].ToString());
                }
            }
            //cBoxFordulo.SelectedIndex = -1;
        }

        public void ShowData(int index)
        {
            DataTable dt = new DataTable();
            try
            {
                //connection.Open();
                int szam = (int)table.Rows[index][0];
                adapter = new MySqlDataAdapter($"SELECT fordulo FROM kuldes.merkozes WHERE merkozesKod = {szam};", connection); // Mi van ha nincs? index -1 lesz?!
                adapter.Fill(dt);
                //merkozesekJvel.Merge(dt); // jvvel táblával összeolvasztani a többi adatot
            }
            catch
            {
                throw new Exception("HIBA! ");
            }
            txtBFordulo.Text = dt.Rows[0][0].ToString(); // Forduló
            //merkozesekJvel.Merge(dt);

            //cBoxFordulo.SelectedItem = txtBFordulo.Text;
            adapter = new MySqlDataAdapter($"SELECT osztalyMegnevezes FROM kuldes.osztaly WHERE " +
                $"idOsztaly = {table.Rows[index][6]};", connection);
            DataTable dt1 = new DataTable();
            adapter.Fill(dt1);
            txtBVerseny.Text = dt1.Rows[0][0].ToString(); //verseny
            txtBKod.Text = table.Rows[index][0].ToString(); // mérkőzés kódja
            txtBDatum.Text = table.Rows[index][4].ToString(); // Mérkőzés dátuma
            //merkozesekJvel.Merge(dt1);
            adapter = new MySqlDataAdapter($"SELECT csapatNev FROM kuldes.csapatok WHERE idCsapat = {table.Rows[index][1]};", connection);
            DataTable dt2 = new DataTable();
            adapter.Fill(dt2);
            txtBHazai.Text = dt2.Rows[0][0].ToString(); // hazai csapat ID
            adapter = new MySqlDataAdapter($"SELECT csapatNev FROM kuldes.csapatok WHERE idCsapat = {table.Rows[index][2]};", connection);
            //merkozesekJvel.Merge(dt2);
            DataTable dt3 = new DataTable();
            adapter.Fill(dt3);
            txtBVendeg.Text = dt3.Rows[0][0].ToString();// vendég csapat ID
            //merkozesekJvel.Merge(dt3);
            adapter = new MySqlDataAdapter($"SELECT telepules FROM kuldes.telepules WHERE idTelepules = {table.Rows[index][5]};", connection);
            DataTable dt4 = new DataTable();
            adapter.Fill(dt4);
            txtBHely.Text = dt4.Rows[0][0].ToString();// Hol? idTelepules -> 
            //merkozesekJvel.Merge(dt4);
            adapter = new MySqlDataAdapter($"SELECT j.nev FROM ((kuldes.jatekvezetok j INNER JOIN " +
                $" kuldes.kuldes k ON j.jvKod = k.jvKod) INNER JOIN kuldes.merkozes m ON " +
                $" {table.Rows[index][0]} = k.merkozesKod);", connection);
            DataTable dt5 = new DataTable();
            adapter.Fill(dt5);
            if (dt5.Rows.Count != 0)
            {
                txtBJV.Text = dt5.Rows[0][0].ToString(); // jv-k száma table.Rows[index][3].ToString();
            }
            else txtBJV.Text = "";
            //merkozesekJvel.Merge(dt5);
            adapter = new MySqlDataAdapter($"SELECT j.nev FROM ((kuldes.jatekvezetok j INNER JOIN " +
               $" kuldes.kuldes k ON j.jvKod = k.assz1Kod) INNER JOIN kuldes.merkozes m ON " +
               $" {table.Rows[index][0]} = k.merkozesKod);", connection);
            DataTable dt6 = new DataTable();
            adapter.Fill(dt6);
            if (dt6.Rows.Count != 0)
            {
                txtBAssz1.Text = dt6.Rows[0][0].ToString(); // assz 1
            }
            else txtBAssz1.Text = "";
            //merkozesekJvel.Merge(dt6);
            adapter = new MySqlDataAdapter($"SELECT j.nev FROM (kuldes.jatekvezetok j INNER JOIN " +
               $" kuldes.kuldes k ON j.jvKod = k.assz2Kod) WHERE " +
               $" {table.Rows[index][0]} = k.merkozesKod;", connection);
            DataTable dt7 = new DataTable();
            adapter.Fill(dt7);
            if (dt7.Rows.Count != 0)
            {
                txtBAssz2.Text = dt7.Rows[0][0].ToString(); // assz 2
            }
            else txtBAssz2.Text = "";
            //merkozesekJvel.Merge(dt);
            //merkozesekJvel.Merge(dt) összes adattáblát öszeolvasztani
            MerkozesKiir();
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
                MessageBox.Show("Elérte az adatok elejét!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Elérte az adatok végét!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pos = table.Rows.Count - 1;
            }
        }

        private void cBoxVerseny_SelectedIndexChanged(object sender, EventArgs e)
        {
            VersenyForduloValt();
        }
        private void cBoxFordulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            VersenyForduloValt();
        }

        private void VersenyForduloValt()
        {
            table.Clear();
            string query;
            if (cBoxVerseny.SelectedIndex <= 0 && cBoxFordulo.SelectedIndex <= 0)
            {
                query = $"SELECT * FROM kuldes.merkozes ;";
            }
            else if (cBoxFordulo.SelectedItem.ToString() == "Összes" || cBoxFordulo.SelectedIndex <= 0)
            {
                //lBMerkozesek.Items.Clear();
                query = $"SELECT * FROM kuldes.merkozes WHERE idOsztaly = " +
                    $"(SELECT idOsztaly FROM kuldes.osztaly WHERE osztalyMegnevezes = \"{cBoxVerseny.SelectedItem}\");";
            }
            else if (cBoxVerseny.SelectedItem.ToString() == "Összes" || cBoxVerseny.SelectedIndex <= 0)
            {
                query = $"SELECT * FROM kuldes.merkozes WHERE fordulo = {cBoxFordulo.SelectedItem} ;";
            }
            else
            {
                query = $"SELECT * FROM kuldes.merkozes WHERE idOsztaly = " +
                $"(SELECT idOsztaly FROM kuldes.osztaly WHERE osztalyMegnevezes = \"{cBoxVerseny.SelectedItem}\"" +
                $" AND fordulo = {cBoxFordulo.SelectedItem}) ;";
            }
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
                    MessageBox.Show("Ebben az osztályban/fordulóban nincs mérkőzés!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
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
            cBoxJv.Visible = true;
            cBoxJv.Text = txtBJV.Text;
            cBoxAssz1.Visible = true;
            cBoxAssz1.Text = txtBAssz1.Text;
            cBoxAssz2.Visible = true;
            cBoxAssz2.Text = txtBAssz2.Text;
            btnVegleg.Visible = true;
            btnElozo.Enabled = btnFirst.Enabled = btnKovetkezo.Enabled = btnLast.Enabled = false;
            //cBoxJv.Items.Add("JV");
            //cBoxAssz1.Items.Add("assz1");
            //cBoxAssz2.Items.Add("assz2");
        }
        public void FillJvCombo()
        {
            for (int i = 0; i < merkozesekJvel.Rows.Count; i++)
            {
                adapter = new MySqlDataAdapter("SELECT nev FROM kuldes.jatekvezetok " +
                    " WHERE feladatkor = \"játékvezető\" ;", connection); // meg kell vizsgálni szabad-e és az osztályt is
                adapter.Fill(jv);

                //merkozesekJvel.Rows[i][4] = jv.Rows[i][0];
                cBoxJv.Items.Add(jv.Rows[i][0].ToString());
                int JvSzam = (int)table.Rows[i][3];
                if (JvSzam > 1)
                {
                    adapter = new MySqlDataAdapter("SELECT nev FROM kuldes.jatekvezetok " +
                        "WHERE feladatkor = \"asszisztens\" ;", connection);
                    adapter.Fill(assz);// asszisztens is szabad-e és az osztály? Mennyi assziszt kell?

                    //merkozesekJvel.Rows[i][5] = assz.Rows[i][0];
                    cBoxAssz1.Items.Add(assz.Rows[i][0].ToString());
                    //merkozesekJvel.Rows[i][6] = assz.Rows[i][0];
                    cBoxAssz2.Items.Add(assz.Rows[i][0].ToString());
                }
            }
        }

        private void btnVegleg_Click(object sender, EventArgs e)
        {
            btnElozo.Enabled = btnFirst.Enabled = btnKovetkezo.Enabled = btnLast.Enabled = true;
            cBoxJv.Visible = cBoxAssz1.Visible = cBoxAssz2.Visible = btnVegleg.Visible= false;
            txtBJV.Text = cBoxJv.Text;
            txtBAssz1.Text = cBoxAssz1.Text;
            txtBAssz2.Text = cBoxAssz2.Text;
            //lBMerkozesek.DoubleClick = disable;

            cmd = new MySqlCommand("INSERT INTO kuldes.kuldes (merkozesKod,jvKod,assz1Kod,assz2Kod) " +
                    "VALUES (@merkozesKod,@jvKod,@assz1Kod,@assz2Kod)", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@merkozesKod", txtBKod.Text.Trim());
            cmd.Parameters.AddWithValue("@jvKod", cBoxJv.SelectedIndex);// ne indexet adjam át!
            cmd.Parameters.AddWithValue("@assz1Kod", cBoxAssz1.SelectedIndex);
            cmd.Parameters.AddWithValue("@assz2Kod", cBoxAssz2.SelectedIndex);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        private void txtBVerseny_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnKuldes_Click(object sender, EventArgs e)
        {
            //MerkozesKiir();
            //connection.Open();           
            //MerkozesJvvel();
        }
        public void MerkozesJvvel() { 
            adapter = new MySqlDataAdapter("SELECT m.merkozesDatum, t.Telepules, c.csapatNev, d.csapatNev, " +
                " j.nev " +
                " FROM (((((kuldes.merkozes m INNER JOIN kuldes.telepules t ON t.IdTelepules = m.IdTelepules)" +
                " INNER JOIN kuldes.csapatok c ON c.idCsapat = m.hazaiCsapatId)" +
                " INNER JOIN kuldes.csapatok d ON d.idCsapat = m.vendegCsapatId)" +
                " INNER JOIN kuldes.kuldes k ON m.merkozesKod = k.merkozesKod) " +
                " INNER JOIN kuldes.jatekvezetok j ON k.jvKod = j.jvKod)" +
                //" ;", connection);
                " WHERE  m.merkozesDatum > CURRENT_TIMESTAMP ;", connection);//FUNCTION GETDATE does not exist
            //adapter = new MySqlDataAdapter("SELECT kuldes.merkozes.merkozesDatum, kuldes.telepules.Telepules" +
            //  "FROM kuldes.merkozes JOIN kuldes.telepules USING (kuldes.telepules.IdTelepules);", connection);
            adapter.Fill(merkozesekJvel);
            /*
             * Javítani kell ezt a részt!!!
            */
            //if (merkozesekJvel.Columns.Count <= 5)
            //{
            //    merkozesekJvel.Columns.Add("Játékvezető", typeof(String));
            merkozesekJvel.Columns.Add("Asszisztens 1", typeof(String));
            merkozesekJvel.Columns.Add("Asszisztens 2", typeof(String));
            ////}

            dataGridView1.DataSource = merkozesekJvel;
            dataGridView1.Columns[0].HeaderText = "Dátum";
            dataGridView1.Columns[1].HeaderText = "Helyszín";
            dataGridView1.Columns[2].HeaderText = "Hazai";
            dataGridView1.Columns[3].HeaderText = "Vendég";
            dataGridView1.Columns[4].HeaderText = "Játékvezető";
            //dataGridView1.Columns[5].HeaderText = "Asszisztens 1";
            //dataGridView1.Columns[6].HeaderText = "Asszisztens 2";
            //feltoltMerkozesekJvel();
        }

        public void MerkozesKiir()
        {
            List<ListBoxItems> merkozesek = new List<ListBoxItems>();
            DataTable hazai = new DataTable();
            DataTable vendeg = new DataTable();
            connection.Open();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                adapter = new MySqlDataAdapter($"SELECT csapatNev FROM kuldes.csapatok WHERE idCsapat = {table.Rows[i][1]} ;", connection);
                adapter.Fill(hazai);
                adapter = new MySqlDataAdapter($"SELECT csapatNev FROM kuldes.csapatok WHERE idCsapat = {table.Rows[i][2]} ;", connection);
                adapter.Fill(vendeg);
                merkozesek.Add(new ListBoxItems
                {
                    Kod = (int)table.Rows[i][0],
                    Text = hazai.Rows[i][0].ToString() + "\t- " + vendeg.Rows[i][0].ToString()
                });
            }
            connection.Close();
            lBMerkozesek.DisplayMember = "Text";
            lBMerkozesek.ValueMember = "Kod";
            lBMerkozesek.DataSource = merkozesek;
            lBMerkozesek.Refresh();
            lBMerkozesek.SelectedIndex = pos;
        }
        //public void feltoltMerkozesekJvel()
        //{
        //    for (int i = 0; i < merkozesekJvel.Rows.Count; i++)
        //    {
        //        JatekvezetoKuldes jvk = new JatekvezetoKuldes
        //        {
        //            //kuldKod = dt2.Rows[0][0].ToString(),
        //            idopont = (DateTime)merkozesekJvel.Rows[i][0],
        //            hazaiCsapat = merkozesekJvel.Rows[i][2].ToString(),
        //            vendegCsapat = merkozesekJvel.Rows[i][3].ToString(),
        //            //jatekvezeto =  ,
        //            //asszisztens1 =  ,
        //            //asszisztens2 =
        //        };

        //        lBMerkozesek.DataSource = merkozesekJvel;
        //    }
        //    //merkozesekJvel => DataTable;
        //}


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            pos = 0;
            ShowData(pos);
        }

        private void lBMerkozesek_DoubleClick(object sender, EventArgs e)
        {
            pos = lBMerkozesek.SelectedIndex;
            ShowData(pos);
        }
    }
}

