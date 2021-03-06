using KuldorendszerBLL;
using Kuldorendszer.Interfaces;
using System;
using System.Data;
using System.Net.Mail;
using System.Windows.Forms;

namespace Kuldorendszer
{
    public partial class Elerhetoseg : Form
    {
        IUpdatableCombosForm parentForm;
        DataTable dt = new DataTable();
        ElerhetosegService el = new ElerhetosegService();
        public Elerhetoseg(IUpdatableCombosForm form)
        {
            InitializeComponent();
            parentForm = form;
        }

        private void btnMegse_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztos hogy bezárod az ablakot!", "Bezár",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool ervenyes = false;
            bool foglalt = false;
            if (txtBEmail.Text == "" || txtBEmail.Text == null)
            {
                MessageBox.Show("Az email nem lehet üres!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    MailAddress email = new MailAddress(txtBEmail.Text.Trim());
                    ervenyes = (email.Address == txtBEmail.Text.Trim());
                }
                catch (FormatException)
                {
                    MessageBox.Show("Az email cím nem érvényes!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            dt = el.GetIdByEmail(txtBEmail.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Ez az e-mail cím már használatban van!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foglalt = true;
            }
            // telefonszám vizsgálata! int tel
            if (long.TryParse(txtBTelSzam.Text, out long tel))
            {
                if (tel > 99999999999)
                {
                    MessageBox.Show("A telefonszám nem lehet ennyi!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else ervenyes = true;
            }
            else
            {
                MessageBox.Show("A telefonszám csak számot tartalmazhat.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ervenyes = false;
            }
            if (ervenyes && !foglalt)
            {
                if (el.AddElerhetoseg(txtBEmail.Text, tel.ToString()))
                {
                    MessageBox.Show("Sikeres adatfelvitel", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parentForm.FillCombos();
                    this.Close();
                }
                else
                    MessageBox.Show("Sikertelen adatfelvitel", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
