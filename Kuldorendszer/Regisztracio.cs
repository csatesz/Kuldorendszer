using Kuldorendszer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuldorendszer
{
    public partial class Regisztracio : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        MySqlCommand cmd;
        public Regisztracio()
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

        private void Regisztracio_Load(object sender, EventArgs e)
        {
            adapter = new MySqlDataAdapter($"SELECT felhNev FROM kuldes.felhasznalo ;", connection);
            if (adapter != null)
            {
                adapter.Fill(dt);
            }
        }
        private void BtnReg_Click(object sender, EventArgs e)
        {
            bool ervenyes = false;
            bool foglalt = false;

            if (txtBRegFelh.Text.Length < 4 || txtBRegEmail.Text == "" || txtBRegJelszo.Text.Length < 4)
            {
                MessageBox.Show("Egyik adat sem lehet üres, vagy 4 karakternél rövidebb!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtBRegJelszo.Text != txtBJelszoUjra.Text.Trim())
            {
                MessageBox.Show("A jelszavak nem egyeznek meg!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b regex
                try
                {
                    MailAddress email = new MailAddress(txtBRegEmail.Text.Trim());
                    ervenyes = (email.Address == txtBRegEmail.Text.Trim());
                }
                catch (FormatException)
                {
                    //txtBRegEmail.Text = "";
                    MessageBox.Show("Az email cím nem érvényes!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
             if( dt.Rows[i][0].ToString().Contains(txtBRegFelh.Text.Trim()))
                {
                    foglalt = true;
                    break;
                }
            }
            if (ervenyes && !foglalt)
            {
                Felhasznalo felh = new Felhasznalo
                {
                    felhNev = txtBRegFelh.Text.Trim(),
                    email = txtBRegEmail.Text.Trim(),
                    jelszo = HashExtension.sha256_hash(txtBRegJelszo.Text.Trim()) // titkosítani! sha256_hash

                };
                cmd = new MySqlCommand("INSERT INTO kuldes.felhasznalo (felhNev,email,jelszo,admin,aszf) " +
                    "VALUES (@felhNev,@email,@jelszo,@admin,@aszf)", connection);
                try
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@felhNev", txtBRegFelh.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtBRegEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@jelszo", HashExtension.sha256_hash(txtBRegJelszo.Text));
                    cmd.Parameters.AddWithValue("@admin", 0);
                    if (chkAszf.Checked)
                    {
                        cmd.Parameters.AddWithValue("@aszf", 1);
                    }
                    else 
                        cmd.Parameters.AddWithValue("@aszf", 0);
                    //if (radioBAdmin.Checked)
                    //{
                    //    cmd.Parameters.AddWithValue("@admin", 1);
                    //}else
                    //    cmd.Parameters.AddWithValue("@admin", 0);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch
                {
                    throw new Exception("Hiba");
                }

                connection.Close();
                MessageBox.Show("Sikeres Regisztráció", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("A felhasználó név már foglalt", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void radioBKuldo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
