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
    public partial class Belepes : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        public Belepes()
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnUjFelh_Click(object sender, EventArgs e)
        {
            Regisztracio reg = new Regisztracio();
            reg.ShowDialog();
            //Regisztracio.Show();
        }

        private void BtnBelep_Click(object sender, EventArgs e)
        {
            string user = null;
            string userpass = null;
            try
            {
                connection.Open();
                adapter = new MySqlDataAdapter($"SELECT * FROM kuldes.felhasznalo WHERE felhNev = \"{txtBFelh.Text}\"; ", connection);
            }
            catch
            {
                throw new Exception("Hiba");
            }
            connection.Close();

            if (adapter != null)
            {
                adapter.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    user = dt.Rows[0][1].ToString();
                    userpass = dt.Rows[0][3].ToString();
                }
                else
                {
                    MessageBox.Show("Nincs ilyen felhasználó, vagy téves jelszó!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (txtBJelszo.Text == "" || txtBFelh.Text == "")
            {
                MessageBox.Show("Egyik adat sem lehet üres!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //else if (HashExtension.sha256_hash(txtBJelszo.Text)== HashExtension.sha256_hash())
            else if (txtBFelh.Text == user && HashExtension.sha256_hash(txtBJelszo.Text) == userpass)
            {
                this.Visible = false;
                Kuldes kuld = new Kuldes();
                kuld.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Téves jelszó vagy felhasználó név!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        private void radioBAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBAdmin.Checked)
            {
                label3.Visible = true;
                txtBEmail.Visible = true;
                Admin a = new Admin(); //itt még vizsgálni kell a belépést is
                a.ShowDialog();
            }
            else
            {
                label3.Visible = false;
                txtBEmail.Visible = false;
            }
        }
    }
}
