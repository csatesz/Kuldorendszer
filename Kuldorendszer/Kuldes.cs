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
        }

        private void FillCombo()
        {
            cBoxVerseny.Items.Clear();
            cBoxFordulo.Items.Clear();
            cBoxVerseny.Items.Add("Összes");
            cBoxFordulo.Items.Add("Összes");
            connection.Open();
            adapter = new MySqlDataAdapter("SELECT osztalyMegnevezes FROM kuldes.osztaly", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
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
                connection.Open();
                adapter = new MySqlDataAdapter($"SELECT fordulo FROM kuldes.merkozes WHERE merkozesKod = {table.Rows[index][0]};", connection); // Mi van ha nincs? index -1 lesz?!
                adapter.Fill(dt);
            }
            catch
            {
                throw new Exception("HIBA! ");
            }
            txtBFordulo.Text = dt.Rows[0][0].ToString(); // Forduló
            //cBoxFordulo.SelectedItem = txtBFordulo.Text;
            adapter = new MySqlDataAdapter($"SELECT osztalyMegnevezes FROM kuldes.osztaly WHERE " +
                $"idOsztaly = {table.Rows[index][6]};", connection);
            DataTable dt1 = new DataTable();
            adapter.Fill(dt1);
            txtBVerseny.Text = dt1.Rows[0][0].ToString(); //verseny
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

            adapter = new MySqlDataAdapter($"SELECT j.nev FROM ((kuldes.jatekvezetok j INNER JOIN " +
                $" kuldes.kuldes k ON j.jvKod = k.jvKod) INNER JOIN kuldes.merkozes m ON " +
                $" {table.Rows[index][0]} = k.merkozesKod);", connection);
            DataTable dt5 = new DataTable();
            adapter.Fill(dt5);
            connection.Close();
            if (dt5.Rows.Count != 0)
            {
                txtBJV.Text = dt5.Rows[0][0].ToString();// jv-k száma table.Rows[index][3].ToString();
            }
            else txtBJV.Text = "";

            //txtBAssz1.Text = dt5.Rows[0][1].ToString(); 1. asszisztens
            //txtBAssz1.Text = dt5.Rows[0][2].ToString(); 1. asszisztens
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
        private void VersenyForduloValt()
        {
            table.Clear();
            string query;
            if (cBoxVerseny.SelectedIndex <= 0 && cBoxFordulo.SelectedIndex <= 0)
            {
                query = $"SELECT * FROM kuldes.merkozes ;";
            }
            else if (cBoxFordulo.SelectedIndex <= 0)
            {
                //lBMerkozesek.Items.Clear();
                query = $"SELECT * FROM kuldes.merkozes WHERE idOsztaly = " +
                    $"(SELECT idOsztaly FROM kuldes.osztaly WHERE osztalyMegnevezes = \"{cBoxVerseny.SelectedItem}\");";
            }
            else if (cBoxVerseny.SelectedIndex <= 0)
            {
                query = $"SELECT * FROM kuldes.merkozes WHERE fordulo = {cBoxFordulo.SelectedItem} ;";
            }
            else
            {
                query = $"SELECT * FROM kuldes.merkozes WHERE idOsztaly = " +
                $"(SELECT idOsztaly FROM kuldes.osztaly WHERE osztalyMegnevezes = \"{cBoxVerseny.SelectedItem}\"" +
                $" AND fordulo = {cBoxFordulo.SelectedItem}) ;";
            }
            //connection.Open();
            adapter = new MySqlDataAdapter(query, connection);
            //connection.Close();
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
    private void cBoxFordulo_SelectedIndexChanged(object sender, EventArgs e)
    {
        VersenyForduloValt();
        //table.Clear();
        //string ford = "";
        //if (cBoxFordulo.SelectedIndex == 0)
        //{
        //    Kuldes_Load(sender, e);
        //}
        //else
        //    ford = cBoxFordulo.SelectedItem.ToString();

        //string verseny;
        //if (cBoxVerseny.SelectedItem == null)
        //{
        //    verseny = "NB 1";
        //}
        //else
        //    verseny = cBoxVerseny.SelectedItem.ToString();
        //if (!String.IsNullOrEmpty(ford) && !String.IsNullOrEmpty(verseny))// HA nincs jelölve forduló vagy veseny!?
        //{
        //    string query = $"SELECT * FROM kuldes.merkozes WHERE idOsztaly = " +
        //        $"(SELECT idOsztaly FROM kuldes.osztaly WHERE osztalyMegnevezes = \"{verseny}\")" +
        //        $" AND fordulo = {ford} ;";
        //    adapter = new MySqlDataAdapter(query, connection);
        //}
        //if (adapter != null)
        //{
        //    adapter.Fill(table);
        //    if (table.Rows.Count != 0)
        //    {
        //        pos = 0;
        //        ShowData(pos);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Ebben a fordulóban nincs mérkőzés!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //}
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
        cBoxAssz1.Visible = true;
        cBoxAssz2.Visible = true;
        btnVegleg.Visible = true;

        //cBoxJv.Items.Add("JV");
        //cBoxAssz1.Items.Add("assz1");
        //cBoxAssz2.Items.Add("assz2");
    }

    private void btnVegleg_Click(object sender, EventArgs e)
    {
        cBoxJv.Visible = false;
        txtBJV.Text = cBoxJv.Text;

        cBoxAssz1.Visible = false;
        txtBAssz1.Text = cBoxAssz1.Text;

        cBoxAssz2.Visible = false;
        txtBAssz2.Text = cBoxAssz2.Text;

        btnVegleg.Visible = false;
        cmd = new MySqlCommand("INSERT INTO kuldes.kuldes (merkozesKod,jvKod,assz1Kod,assz2Kod) " +
                "VALUES (@merkozesKod,@jvKod,@assz1Kod,@assz2Kod)", connection);
        connection.Open();
        cmd.Parameters.AddWithValue("@merkozesKod", txtBKod.Text.Trim());
        cmd.Parameters.AddWithValue("@jvKod", cBoxJv.SelectedIndex);
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
        connection.Open();
        adapter = new MySqlDataAdapter("SELECT m.merkozesDatum, t.Telepules, c.csapatNev, d.csapatNev " +
            "FROM (((kuldes.merkozes m INNER JOIN kuldes.telepules t " +
            "ON t.IdTelepules = m.IdTelepules) INNER JOIN kuldes.csapatok c " +
            "ON c.idCsapat = m.hazaiCsapatId) " +
            " INNER JOIN kuldes.csapatok d ON d.idCsapat = m.vendegCsapatId);", connection);
        //adapter = new MySqlDataAdapter("SELECT kuldes.merkozes.merkozesDatum, kuldes.telepules.Telepules" +
        //  "FROM kuldes.merkozes JOIN kuldes.telepules USING (kuldes.telepules.IdTelepules);", connection);
        adapter.Fill(merkozesekJvel);

        merkozesekJvel.Columns.Add("JatekVezeto", typeof(String));
        merkozesekJvel.Columns.Add("Asszisztens1", typeof(String));
        merkozesekJvel.Columns.Add("Asszisztens2", typeof(String));
        for (int i = 0; i < merkozesekJvel.Rows.Count; i++)
        {
            adapter = new MySqlDataAdapter("SELECT nev FROM kuldes.jatekvezetok WHERE feladatkor =\"játékvezető\" ;", connection);
            adapter.Fill(jv);
            adapter = new MySqlDataAdapter("SELECT nev FROM kuldes.jatekvezetok WHERE feladatkor =\"asszisztens\" ;", connection);
            adapter.Fill(assz);

            merkozesekJvel.Rows[i][4] = jv.Rows[i][0];
            cBoxJv.Items.Add(jv.Rows[i][0].ToString());

            merkozesekJvel.Rows[i][5] = assz.Rows[i][0];
            cBoxAssz1.Items.Add(assz.Rows[i][0].ToString());
            merkozesekJvel.Rows[i][6] = assz.Rows[i][0];
            cBoxAssz2.Items.Add(assz.Rows[i][0].ToString());
        }
        connection.Close();
        dataGridView1.DataSource = merkozesekJvel;
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
        lBMerkozesek.SelectedIndex = -1;
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
}
}

