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
    public partial class Admin : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlDataAdapter adapter;
        MySqlCommand cmd;

        Felhasznalo felhasznalok = new Felhasznalo();
        DataTable felhTable = new DataTable();
        DataTable jvTable = new DataTable();
        DataTable csapatokTable = new DataTable();
        DataTable merkozesek = new DataTable();
        DataTable telepules = new DataTable();
        DataTable osztaly = new DataTable();
        DataTable elerhetoseg = new DataTable();

        public string table = null;
        private string kod = null;
        private string id = "";
        public Admin()
        {
            InitializeComponent();
            dGridAdmin.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dGridAdmin.BorderStyle = BorderStyle.Fixed3D;
            dGridAdmin.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void btnFelhKarb_Click(object sender, EventArgs e)
        {
            felhTable.Clear();
            connection.Open();

            adapter = new MySqlDataAdapter("SELECT felhKod, felhNev, email,admin, aszf, torolt " +
                " FROM kuldes.felhasznalo", connection);
            if (felhTable.Rows.Count == 0)
            {
                adapter.Fill(felhTable);
            }
            dGridAdmin.DataSource = felhTable;
            //for (int i = 0; i < felhTable.Rows.Count; i++)
            //{
            //    felhasznalok = new Felhasznalo
            //    {
            //        felhKod = (int)felhTable.Rows[i][0],
            //        felhNev = felhTable.Rows[i][1].ToString(),
            //        email = felhTable.Rows[i][2].ToString(),
            //        //jelszo,
            //        admin = (bool)felhTable.Rows[i][3],
            //        aszf = (bool)felhTable.Rows[i][4]
            //    };
            //}
            connection.Close();
            dGridAdmin.Columns[0].HeaderText = "Kód";
            dGridAdmin.Columns[1].HeaderText = "Név";
            dGridAdmin.Columns[2].HeaderText = "Email";
            dGridAdmin.Columns[3].HeaderText = "Admin";
            dGridAdmin.Columns[4].HeaderText = "ÁSZF";
            dGridAdmin.Columns[5].HeaderText = "Törölt";
            table = "felhasznalo";
            kod = "felhKod";
            AdatFeltolt();
        }

        private void btnMerkKarb_Click(object sender, EventArgs e)
        {
            //merkozesek.Clear();
            connection.Open();

            adapter = new MySqlDataAdapter("SELECT m.merkozesKod, m.merkozesDatum, t.Telepules," +
                " c.csapatNev, d.csapatNev, o.osztalyMegnevezes  FROM ((((kuldes.merkozes m INNER JOIN " +
                " kuldes.telepules t ON t.IdTelepules = m.IdTelepules) INNER JOIN kuldes.csapatok c " +
                " ON c.idCsapat = m.hazaiCsapatId) INNER JOIN kuldes.csapatok d " +
                " ON d.idCsapat = m.vendegCsapatId) INNER JOIN kuldes.osztaly o " +
                " ON o.idOsztaly = m.idOsztaly)  ;", connection);
            if (merkozesek.Rows.Count == 0)
            {
                adapter.Fill(merkozesek);
            }
            dGridAdmin.DataSource = merkozesek;
            connection.Close();
            dGridAdmin.Columns[0].HeaderText = "Kód";
            dGridAdmin.Columns[1].HeaderText = "Dátum";
            dGridAdmin.Columns[2].HeaderText = "Település";
            dGridAdmin.Columns[3].HeaderText = "Hazai Csapet";
            dGridAdmin.Columns[4].HeaderText = "Vendég Csapat";
            dGridAdmin.Columns[5].HeaderText = "Osztály";

            table = "merkozes";
            kod = "merkozesekKod";
            AdatFeltolt();
        }

        private void btnJvKarb_Click(object sender, EventArgs e)
        {
            connection.Open();

            adapter = new MySqlDataAdapter("SELECT j.jvKod, j.nev, j.feladatkor, " +
                "  j.keret, j.minosites, t.Telepules, j.elerhetosegKod " +
                " FROM kuldes.jatekvezetok j INNER JOIN kuldes.telepules t ON j.idTelepules = t.idTelepules", connection);
            if (jvTable.Rows.Count == 0)
            {
                adapter.Fill(jvTable);
            }
            dGridAdmin.DataSource = jvTable;
            connection.Close();
            dGridAdmin.Columns[0].HeaderText = "JV Kód";
            dGridAdmin.Columns[1].HeaderText = "Név";
            dGridAdmin.Columns[2].HeaderText = "Feladatkör";
            dGridAdmin.Columns[3].HeaderText = "Keret";
            dGridAdmin.Columns[4].HeaderText = "Minősítés";
            dGridAdmin.Columns[5].HeaderText = "Település";
            dGridAdmin.Columns[6].HeaderText = "Elérhetőség";
            table = "jatekvezetok";
            kod = "jvKod";
            AdatFeltolt();
        }

        private void btnCsapKarb_Click(object sender, EventArgs e)
        {
            csapatokTable.Clear();
            connection.Open();

            adapter = new MySqlDataAdapter("SELECT c.idCsapat, c.csapatnev, " +
                " c.csapatVezeto, o.osztalyMegnevezes " +
                " FROM kuldes.csapatok c INNER JOIN kuldes.osztaly o " +
                " ON c.idOsztaly = o.idOsztaly ;", connection);
            if (csapatokTable.Rows.Count == 0)
            {
                adapter.Fill(csapatokTable);
            }
            dGridAdmin.DataSource = csapatokTable;
            connection.Close();
            dGridAdmin.Columns[0].HeaderText = "Azonosító";
            dGridAdmin.Columns[1].HeaderText = "Csapat Név";
            dGridAdmin.Columns[2].HeaderText = "Csapatvezető";
            dGridAdmin.Columns[3].HeaderText = "Osztály";

            table = "csapatok";
            kod = "idOsztaly";
            AdatFeltolt();
        }

        private void textBKeres_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKeres_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBKeres.Text.Trim()))
                dGridAdmin.Refresh();
            //{
            //    loadData("");
            //}
            //else
            //{
            //    loadData(this.textBKeres.Text.Trim());
            //}

            //resetMe();
            //Felhasznalo felh = new Felhasznalo();
            //foreach (Felhasznalo f in felhasznalok.GetType().GetProperties())
            //foreach (Felhasznalo f in felhasznalok)
            //{
            //    lBAdmin.Items.Add(f.felhKod + f.felhNev+ f.email);
            //}
        }
        public void AdatFeltolt()
        {
            DataGridView dgv1 = dGridAdmin;

            this.id = Convert.ToString(dgv1.CurrentRow.Cells[0].Value);
            btnModosit.Text = "Módosít (" + this.id + ")";
            btnTorol.Text = "Töröl (" + this.id + ")";

            label1.Text = $"Adatforrás: {table} táblázat";
            //firstNameTextBox.Text = Convert.ToString(dgv1.CurrentRow.Cells[1].Value);
            //lastNameTextBox.Text = Convert.ToString(dgv1.CurrentRow.Cells[2].Value);

            //genderComboBox.SelectedItem = Convert.ToString(dgv1.CurrentRow.Cells[4].Value);


        }
        private void dGridAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                AdatFeltolt();
            }
        }

        private void btnModosit_Click(object sender, EventArgs e)
        {
            dGridAdmin.ReadOnly = false;
            btnModosit.Text = "Véglegesít: (" + this.id + ")";
            var a = dGridAdmin.DataSource.GetType();
            if (a != null)
            {
                label1.Text = a.ToString();
            }
            //dt.AcceptChanges();
        }

        private void btnTorol_Click(object sender, EventArgs e)
        {
            if (dGridAdmin.Rows.Count == 0)
            {
                return;
            }
            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Válassz egy elemet a listából.", "Adattörlés", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("Biztos törlöd az adatot?", "Adattörlés",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                connection.Open();
                cmd = new MySqlCommand($"DELETE FROM kuldes.{table} WHERE {kod} = {this.id};", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show($"Sikeres {id} azonosító rekord törlés!");
                dGridAdmin.Refresh();
            }
        }

        private void btnUj_Click(object sender, EventArgs e)
        {
            DataTable dt = dGridAdmin.DataSource as DataTable;
            //DataRow row = dt.NewRow();
            var row = dt.NewRow();
            row[0] = -1;
            row[1] = dGridAdmin.Rows[dGridAdmin.CurrentRow.Index].Cells[0].Value.ToString();
            dt.Rows.Add(row);
            //row[0] = dGridAdmin.Rows[dGridAdmin.RowCount-1].Cells[0].Value.ToString();
            //string oszlop = dGridAdmin.Columns[e.ColumnIndex].Name; // az eredeti oszlop nevét kell visszadni!!!
            //dGridAdmin.Rows.Add(new object[] { -1, "kutya", "cica", "serialkillah" }); //Nem vehetők fel sorok programozott módon a DataGridView vezérlő sorgyűjteményébe, ha a vezérlő adatokhoz van kötve.'
            //Adatmodositas am = new Adatmodositas(table, id, kod);
            //Adatmodositas am = new Adatmodositas(table);
            //am.ShowDialog();
            //    cmd = new MySqlCommand("INSERT INTO kuldes.felhasznalo (felhNev,email,jelszo,admin,aszf) " +
            //            "VALUES (@felhNev,@email,@jelszo,@admin,@aszf)", connection);
            //    connection.Open();
            //        cmd.Parameters.AddWithValue("@felhNev", txtBRegFelh.Text.Trim());
            //        cmd.Parameters.AddWithValue("@email", txtBRegEmail.Text.Trim());
            //        cmd.Parameters.AddWithValue("@jelszo", HashExtension.sha256_hash(txtBRegJelszo.Text));
            //        cmd.Parameters.AddWithValue("@admin", 0);

            //        cmd.ExecuteNonQuery();

            //        connection.Close();
        }

        private void dGridAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //label2.Text = dGridAdmin.CurrentCell.OwningColumn.Name;
            label2.Text = dGridAdmin.Columns[e.ColumnIndex].Name;
            if (dGridAdmin.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                MessageBox.Show(dGridAdmin.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        private void btnTelepKarb_Click(object sender, EventArgs e)
        {
            //telepules.Columns.Clear();
            //telepules.Clear();
            connection.Open();

            adapter = new MySqlDataAdapter("SELECT * FROM kuldes.telepules", connection);
            if (telepules.Rows.Count == 0)
            {
                adapter.Fill(telepules);
            }
            dGridAdmin.DataSource = telepules;
            connection.Close();
            dGridAdmin.Columns[0].HeaderText = "Azonosító";
            dGridAdmin.Columns[1].HeaderText = "Település";
            dGridAdmin.Columns[2].HeaderText = "Irányítószám";
            //telepules.Columns[0].ColumnName = "Azonosító";
            //telepules.Columns[1].ColumnName = "Település";
            //telepules.Columns[2].ColumnName = "Irányítószám";
            table = "telepules";
            kod = "idTelepules";
            AdatFeltolt();
        }

        private void btnOsztKarb_Click(object sender, EventArgs e)
        {
            //osztaly.Columns.Clear();
            //osztaly.Clear();
            connection.Open();
            adapter = new MySqlDataAdapter("SELECT * FROM kuldes.osztaly ;", connection);
            if (osztaly.Rows.Count == 0)
            {
                adapter.Fill(osztaly);
            }
            connection.Close();
            dGridAdmin.DataSource = osztaly;
            dGridAdmin.Columns[0].HeaderText = "Azonosító";
            dGridAdmin.Columns[1].HeaderText = "Osztály";
            //osztaly.Columns[0].ColumnName = "Azonosító";
            //osztaly.Columns[1].ColumnName = "Osztály";
            table = "osztaly";
            kod = "idOsztaly";
            AdatFeltolt();
        }

        private void btnElerhetKarb_Click(object sender, EventArgs e)
        {
            //dt.Clear();
            //dt.Columns.Clear();
            connection.Open();

            adapter = new MySqlDataAdapter("SELECT * FROM kuldes.elerhetoseg ;", connection);
            if (elerhetoseg.Rows.Count == 0)
            {
                adapter.Fill(elerhetoseg);
            }
            connection.Close();
            dGridAdmin.DataSource = elerhetoseg;
            dGridAdmin.Columns[0].HeaderText = "Azonosító";
            dGridAdmin.Columns[1].HeaderText = "Email-cím";
            dGridAdmin.Columns[2].HeaderText = "Telefonszám";
            //elerhetoseg.Columns[0].ColumnName = "Azonosító";
            //elerhetoseg.Columns[1].ColumnName = "Email-cím";
            //elerhetoseg.Columns[2].ColumnName = "Telefonszám";
            table = "elerhetoseg";
            kod = "elerhetosegKod";
            AdatFeltolt();
        }

        private void dGridAdmin_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

            //label2.Text = dGridAdmin.CurrentCell.OwningColumn.Name;
            //label2.Text = dGridAdmin.Columns[e.ColumnIndex].Name;
        }

        private void dGridAdmin_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string oszlop = dGridAdmin.Columns[e.ColumnIndex].Name;//az eredeti oszlop nevét kell visszadni!!!
            string szoveg = dGridAdmin.CurrentCell.Value.ToString();
            //switch (table)
            //{
            //    case "elerhetoseg":
            //        switch (e.ColumnIndex)
            //        {
            //            case 0:
            //                oszlop = "elerhetosegKod";
            //                break;
            //            case 1:
            //                oszlop = "email";
            //                break;
            //            case 2:
            //                oszlop = "telefon";
            //                break;
            //            default:
            //                break;
            //        }
            //        break;
            //    case "osztaly":
            //        switch (e.ColumnIndex)
            //        {
            //            case 0:
            //                oszlop = "idOsztaly";
            //                break;
            //            case 1:
            //                oszlop = "osztalyMegnevezes";
            //                break;
            //            default:
            //                break;
            //        }
            //        break;
            //    case "telepules":
            //        switch (e.ColumnIndex)
            //        {
            //            case 0:
            //                oszlop = "idTelepules";
            //                break;
            //            case 1:
            //                oszlop = "Telepules";
            //                break;
            //            case 2:
            //                oszlop = "iranyitoszam";
            //                break;
            //            default:
            //                break;
            //        }
            //        break;
            //    case "csapatok":
            //        switch (e.ColumnIndex)
            //        {
            //            case 0:
            //                oszlop = "idCsapat";
            //                break;
            //            case 1:
            //                oszlop = "csapatNev";
            //                break;
            //            case 2:
            //                oszlop = "elerhetosegKod";
            //                break;
            //            case 3:
            //                oszlop = "csapatVezeto";
            //                break;
            //            case 4:
            //                oszlop = "idOsztaly";
            //                break;
            //            default:
            //                break;
            //        }
            //        break;
            //    default:
            //        break;
            //}
            try
            {
                connection.Open();
                cmd = new MySqlCommand($"UPDATE kuldes.{table} SET {oszlop} " +
                    $" = \"{szoveg}\" WHERE {kod} = {this.id};", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                //throw new Exception("Hiba");
            }
        }
    }
}
