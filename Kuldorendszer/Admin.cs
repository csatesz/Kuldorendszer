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
        DataTable dt = new DataTable();

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
            //dGridAdmin.DataSource = null;
            connection.Open();

            adapter = new MySqlDataAdapter("SELECT felhKod AS Kód, felhNev AS Név, email AS Email, admin AS Admin, aszf AS ÁSZF" +
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
        }

        private void btnMerkKarb_Click(object sender, EventArgs e)
        {
            //merkozesek.Clear();
            connection.Open();

            adapter = new MySqlDataAdapter("SELECT m.merkozesKod, m.merkozesDatum, t.Telepules," +
                " c.csapatNev, d.csapatNev, o.osztalyMegnevezes FROM ((((kuldes.merkozes m INNER JOIN " +
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
        }

        private void btnJvKarb_Click(object sender, EventArgs e)
        {
            connection.Open();

            adapter = new MySqlDataAdapter("SELECT j.jvKod, j.nev, j.feladatkor, j.keret, j.minosites, " +
                " t.Telepules, j.elerhetosegKod FROM kuldes.jatekvezetok j INNER JOIN kuldes.telepules t" +
                " ON j.idTelepules = t.idTelepules", connection);
            if (jvTable.Rows.Count == 0)
            {
                adapter.Fill(jvTable);
            }
            dGridAdmin.DataSource = jvTable;
            connection.Close();
        }

        private void btnCsapKarb_Click(object sender, EventArgs e)
        {
            connection.Open();

            adapter = new MySqlDataAdapter("SELECT c.csapatnev, c.csapatVezeto, o.osztalyMegnevezes " +
                " FROM kuldes.csapatok c " +
                " INNER JOIN kuldes.osztaly o " +
                " ON c.idOsztaly = o.idOsztaly ;", connection);
            if (csapatokTable.Rows.Count == 0)
            {
                adapter.Fill(csapatokTable);
            }
            dGridAdmin.DataSource = csapatokTable;
            connection.Close();
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

        private void dGridAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView dgv1 = dGridAdmin;

                this.id = Convert.ToString(dgv1.CurrentRow.Cells[0].Value);
                btnModosit.Text = "Módosít (" + this.id + ")";
                btnTorol.Text = "Töröl (" + this.id + ")";

                label1.Text = dGridAdmin.DataSource.ToString() + "???";
                //firstNameTextBox.Text = Convert.ToString(dgv1.CurrentRow.Cells[1].Value);
                //lastNameTextBox.Text = Convert.ToString(dgv1.CurrentRow.Cells[2].Value);

                //genderComboBox.SelectedItem = Convert.ToString(dgv1.CurrentRow.Cells[4].Value);

            }
        }

        private void btnModosit_Click(object sender, EventArgs e)
        {
            dGridAdmin.ReadOnly = false;

            var a = dGridAdmin.DataSource.GetType();
            if (a != null)
            {
                label1.Text = a.ToString();
            }
            dt.AcceptChanges();
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
                //cmd = new MySqlCommand($"DELETE FROM kuldes.{table} WHERE felhKod = {this.id};", connection);
                cmd.ExecuteNonQuery();
                connection.Close();

                //dGridAdmin.Refresh();
            }

        }

        private void btnUj_Click(object sender, EventArgs e)
        {
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

        }

        private void btnTelepKarb_Click(object sender, EventArgs e)
        {
            dt.Columns.Clear();
            dt.Clear();
            connection.Open();

            adapter = new MySqlDataAdapter("SELECT * FROM kuldes.telepules", connection);
            if (dt.Rows.Count == 0)
            {
                adapter.Fill(dt);
            }
            dGridAdmin.DataSource = dt;
            connection.Close();
        }

        private void btnOsztKarb_Click(object sender, EventArgs e)
        {
            dt.Columns.Clear();
            dt.Clear();
            connection.Open();

            adapter = new MySqlDataAdapter("SELECT * FROM kuldes.osztaly ;", connection);
            if (dt.Rows.Count == 0)
            {
                adapter.Fill(dt);
            }
            connection.Close();
            dGridAdmin.DataSource = dt;
            
        }

        private void btnElerhetKarb_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dt.Columns.Clear();
            connection.Open();

            adapter = new MySqlDataAdapter("SELECT * FROM kuldes.elerhetoseg ;", connection);
            if (dt.Rows.Count == 0)
            {
                adapter.Fill(dt);
            }
            connection.Close();
            dGridAdmin.DataSource = dt;
            
        }

        private void dGridAdmin_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
