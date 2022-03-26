using KuldorendszerBLL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Kuldorendszer
{
    public partial class Belepes : Form
    {
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
        }

        private void BtnBelep_Click(object sender, EventArgs e)
        {
            FelhasznaloService felh = new FelhasznaloService();
            dt = felh.SelectUserByName(txtBFelh.Text);

            if (dt != null)
            {
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

        private void BtnBelep_MouseHover(object sender, EventArgs e)
        {
            BtnBelep.BackColor = Color.RoyalBlue;
        }
        private void BtnBelep_MouseLeave(object sender, EventArgs e)
        {
            BtnBelep.BackColor = Color.LightSteelBlue;
        }
        private void BtnUjFelh_MouseHover(object sender, EventArgs e)
        {
            BtnUjFelh.BackColor = Color.RoyalBlue;
        }
        private void BtnUjFelh_MouseLeave(object sender, EventArgs e)
        {
            BtnUjFelh.BackColor = Color.LightSteelBlue;
        }

        private void btnElfJsz_MouseHover(object sender, EventArgs e)
        {
            btnElfJsz.BackColor = Color.RoyalBlue;
        }

        private void btnElfJsz_MouseLeave(object sender, EventArgs e)
        {
            btnElfJsz.BackColor = Color.LightSteelBlue;
        }
        private void btnElfJsz_Click(object sender, EventArgs e)
        {
            FelhasznaloService felh = new FelhasznaloService();
            dt = felh.SelectUserByName(txtBFelh.Text);
            string email;
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    user = dt.Rows[0][1].ToString();
                    email = dt.Rows[0][2].ToString();
                }
                else
                {
                    MessageBox.Show("Nincs ilyen felhasználó!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtBFelh.Text == user && txtBEmail.Text == email)
                {
                    // emailt kell küldeni egy generált jelszóval amennyiben a felhazsnálónak létezik ilyen email cím
                    MessageBox.Show("Email küldés!");
                }
            }
        }
    }
}
