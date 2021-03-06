using Kuldorendszer.Interfaces;
using KuldorendszerBLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kuldorendszer
{
    public partial class Telepules : Form
    {
        IUpdatableCombosForm parentForm;
        DataTable dt = new DataTable();
        TelepulesService tel = new TelepulesService();
        public Telepules(IUpdatableCombosForm form)
        {
            InitializeComponent();
            parentForm = form;
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

            if (Int32.TryParse(txtBTelepulesKod.Text, out int telepulesKod))
            {
                if (telepulesKod > 99999999)
                {
                    MessageBox.Show("A település kódja nem lehet ennyi!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ervenyes = false;
                }
                else ervenyes = true;
            }
            else
                MessageBox.Show("A település kódja csak számot tartalmazhat.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if (Int32.TryParse(txtBIrSzam.Text, out int irSzam))
            {
                if (irSzam > 9999)
                {
                    MessageBox.Show("Az irányítószám nem lehet ennyi!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ervenyes = false;
                }
                else ervenyes = true;
            }
            else
                MessageBox.Show("A irányítószám csak 4 jegyű számot tartalmazhat.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            dt = tel.GetTelepulesById(telepulesKod);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Már van ilyen kódú település.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                foglalt = true;
            }

            if (ervenyes && !foglalt)
            {
                if (tel.AddTelepules(telepulesKod, txtBTelepules.Text, irSzam))
                {
                    MessageBox.Show("Sikeres adatfelvitel", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parentForm.FillCombos(); 
                    this.Close();
                }
                else
                    MessageBox.Show("Sikertelen adatfelvitel", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}