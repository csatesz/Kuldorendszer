using KuldorendszerBLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kuldorendszer
{
    public partial class Osztaly : Form
    {
        DataTable dt = new DataTable();
        OsztalyService oszt = new OsztalyService();
        public Osztaly()
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

            if (Int32.TryParse(txtBOsztalyKod.Text, out int osztalyKod))
            {
                if (osztalyKod > 99999999)
                {
                    MessageBox.Show("Az osztály kódja nem lehet ennyi!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ervenyes = false;
                }
                else ervenyes = true;
            }
            else
                MessageBox.Show("Az osztály kódja csak számot tartalmazhat.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            dt = oszt.GetOsztalyById(osztalyKod);
            if (dt.Rows.Count > 0)
            {
                foglalt = true;
                MessageBox.Show("Már van ilyen kódú osztáy!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (ervenyes && !foglalt)
            {
                if (oszt.AddOsztaly(osztalyKod, txtBOsztaly.Text.Trim()))
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
