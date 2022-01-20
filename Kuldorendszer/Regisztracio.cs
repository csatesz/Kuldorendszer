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

        }

        private void BtnReg_Click(object sender, EventArgs e)
        {
            bool ervenyes = false;

            if (txtBRegFelh.Text.Length < 4 || txtBRegEmail.Text == "" || txtBRegJelszo.Text.Length < 4)
            {
                MessageBox.Show("Egyik adat sem lehet üres, vagy 4 karakternél rövidebb!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtBRegJelszo.Text != txtBJelszoUjra.Text)
            {
                MessageBox.Show("A jelszavak nem egyeznek meg!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b regex
                try
                {
                    MailAddress email = new MailAddress(txtBRegEmail.Text);
                    ervenyes = (email.Address == txtBRegEmail.Text);
                }
                catch (FormatException)
                {
                    //txtBRegEmail.Text = "";
                    MessageBox.Show("Az email cím nem érvényes!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (ervenyes)
            {
                Felhasznalo felh = new Felhasznalo
                {
                    felhNev = txtBRegFelh.Text,
                    email = txtBRegEmail.Text,
                    jelszo = txtBRegJelszo.Text // titkosítani! sha256_hash

                };
                cmd = new MySqlCommand("INSERT INTO kuldes.felhasznalo (felhNev,email,jelszo) VALUES (@felhNev,@email,@jelszo)", connection);
                try
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@felhNev", txtBRegFelh.Text);
                    cmd.Parameters.AddWithValue("@email", txtBRegEmail.Text);
                    cmd.Parameters.AddWithValue("@jelszo", txtBRegJelszo.Text);
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

        }

        private void radioBKuldo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
