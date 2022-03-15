using KuldorendszerBLL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuldorendszer
{
    public partial class Elerhetoseg : Form
    {
        DataTable dt = new DataTable();
        public Elerhetoseg()
        {
            InitializeComponent();
        }

        private void btnMegse_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztos hogy bezárod az ablakot!", "Bezár",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Close();
            }
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
            ElerhetosegBLL el = new ElerhetosegBLL();
            dt = el.GetIdByEmail(txtBEmail.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Ez az e-mail cím már használatban van!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foglalt = true;
            }

            if (ervenyes && !foglalt)
            {
                if (el.AddElerhetoseg(txtBEmail.Text, txtBTelSzam.Text))
                {
                    MessageBox.Show("Sikeres adatfelvitel", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Jatekvezeto j = new Jatekvezeto();
                    j.FillCombos();
                    this.Close();
                }
                else
                    MessageBox.Show("Sikertelen adatfelvitel", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
