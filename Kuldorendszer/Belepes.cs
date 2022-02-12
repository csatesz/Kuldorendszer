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
        string user = null;
        string userpass = null;
        bool admin = false;
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

            try
            {
                connection.Open();
                adapter = new MySqlDataAdapter($"SELECT * FROM kuldes.felhasznalo WHERE felhNev = \"{txtBFelh.Text}\" " +
                    $" AND (torolt = 0 OR torolt is NULL); ", connection);
            }
            catch
            {
                throw new Exception("Nem csatlakozik az adatbázishoz, indítsa újra a programot!"); // ha nem megy az xampp hiba
            }
            connection.Close();

            if (adapter != null)
            {
                adapter.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    user = dt.Rows[0][1].ToString();
                    userpass = dt.Rows[0][3].ToString();
                    if (radioBAdmin.Checked) { admin = (bool)dt.Rows[0][4]; }
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
            else if (txtBFelh.Text == user && HashExtension.sha256_hash(txtBJelszo.Text) == userpass)
            {
                this.Visible = false;
                if (radioBAdmin.Checked && admin)
                {
                    Admin a = new Admin();
                    a.ShowDialog();
                }
                else
                {
                    Kuldes kuld = new Kuldes();
                    kuld.ShowDialog();
                }
                this.Close();
            }
            else
                MessageBox.Show("Téves jelszó vagy felhasználó név!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        private void radioBAdmin_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioBAdmin.Checked)//itt még vizsgálni kell az emailt is
            //{
            //    label3.Visible = true;
            //    txtBEmail.Visible = true;
            //    Admin a = new Admin(); 
            //    a.ShowDialog();
            //}
            //else
            //{
            //    label3.Visible = false;
            //    txtBEmail.Visible = false;
            //}
        }

        private void BtnBelep_MouseHover(object sender, EventArgs e)
        {
            BtnBelep.BackColor = Color.RoyalBlue;
        }
        private void BtnBelep_MouseLeave(object sender, EventArgs e)
        {
            BtnBelep.BackColor = Color.LightSteelBlue;
        }
        private void BtnBelep_MouseEnter(object sender, EventArgs e)
        {
           
        }
        private void BtnUjFelh_MouseHover(object sender, EventArgs e)
        {
            BtnUjFelh.BackColor = Color.RoyalBlue;
        }
        private void BtnUjFelh_MouseLeave(object sender, EventArgs e)
        {
            BtnUjFelh.BackColor = Color.LightSteelBlue;
        }

        private void btnElfJsz_Click(object sender, EventArgs e)
        {

        }

        private void btnElfJsz_MouseHover(object sender, EventArgs e)
        {
            btnElfJsz.BackColor = Color.RoyalBlue;
        }

        private void btnElfJsz_MouseLeave(object sender, EventArgs e)
        {
            btnElfJsz.BackColor = Color.LightSteelBlue;
        }
    }
}
