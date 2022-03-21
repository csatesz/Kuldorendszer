using KuldorendszerBLL;
using System;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;

namespace Kuldorendszer
{
    public partial class Regisztracio : Form
    {
        DataTable dt = new DataTable();
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
                    MessageBox.Show("Az email cím nem érvényes!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            if (txtBRegEmailUjra.Text.Trim() != txtBRegEmail.Text.Trim())
            {
                MessageBox.Show("Az email címek nem egyeznek!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ervenyes = false;
            }

            FelhasznaloService felh = new FelhasznaloService();
            dt = felh.SelectUserByName(txtBRegFelh.Text);// ha sikertelen úgy is jó lehet?!
            if (dt.Rows.Count > 0) foglalt = true;

            if (ervenyes && !foglalt)
            {
                if (felh.AddUser(txtBRegFelh.Text.Trim(), txtBRegEmail.Text.Trim(),
                    HashExtension.sha256_hash(txtBRegJelszo.Text), false, chkAszf.Checked))
                {
                    MessageBox.Show("Sikeres Regisztráció", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Sikertelen Regisztráció", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("A felhasználó név már foglalt", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnReg_MouseHover(object sender, EventArgs e)
        {
            BtnReg.BackColor = Color.RoyalBlue;
        }

        private void BtnReg_MouseLeave(object sender, EventArgs e)
        {
            BtnReg.BackColor = Color.LightSteelBlue;
        }
    }
}
