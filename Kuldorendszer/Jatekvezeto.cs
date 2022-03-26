using KuldorendszerBLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kuldorendszer
{
    public partial class Jatekvezeto : Form
    {
        int telep, elKod, keret = 0;
        DataTable dt = new DataTable();

        public Jatekvezeto()
        {
            InitializeComponent();
        }
        private void Jatekvezeto_Load(object sender, EventArgs e)
        {
            FillCombos();
        }

        private void txtBFordulo_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool ervenyes = false;
            bool foglalt = false;
            JatekvezetoService jv = new JatekvezetoService();

            if (Int32.TryParse(txtBJvKod.Text, out int jvKod))
            {
                if (jvKod > 99999999 || jvKod < 1)
                {
                    MessageBox.Show("A játékvezető kódja nem lehet ennyi!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ervenyes = false;
                }
                else ervenyes = true;
            }
            else
                MessageBox.Show("A játékvezető kódja csak számot tartalmazhat!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            dt = jv.GetJatekvezetoById(jvKod);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("A játékvezető kódja foglalt!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                foglalt = true;
            }

            if (String.IsNullOrEmpty(txtBJvNev.Text))
            {
                MessageBox.Show("A játékvezető neve nem lehet üres!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                ervenyes = false;
            }
            if (cBoxOsztaly.SelectedIndex < 0 || cBoxTelepules.SelectedIndex < 0 || cBoxElerhetoseg.SelectedIndex < 0)
            {
                MessageBox.Show("Válassz ki keretet/települést/elérhetőséget!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ervenyes = false;
            }

            if (ervenyes && !foglalt)
            {
                if (jv.AddJatekvezeto(jvKod, txtBJvNev.Text, elKod, telep, txtBMinosites.Text,
                    cBoxOsztaly.Text, cBoxFeladat.Text, 0))
                {
                    MessageBox.Show("Sikeres adatfelvitel", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Sikertelen adatfelvitel", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnMegse_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztos hogy bezárod az ablakot!", "Bezár",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public void FillCombos()
        {
            cBoxElerhetoseg.Items.Clear();
            cBoxOsztaly.Items.Clear();
            cBoxTelepules.Items.Clear();
            cBoxFeladat.Items.Clear();
            cBoxTelepules.Items.Add("Új település");
            cBoxElerhetoseg.Items.Add("Új elérhetőség");
            cBoxFeladat.Items.Add("Új tipusú feladat");
            cBoxFeladat.Items.Add("asszisztens");
            cBoxFeladat.Items.Add("játékvezető");

            OsztalyService o = new OsztalyService();
            DataTable dt1 = o.GetAllOsztalyMegnevezes();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string osztaly = dt1.Rows[i][0].ToString();
                cBoxOsztaly.Items.Add(osztaly);
            }
            ElerhetosegService el = new ElerhetosegService();
            DataTable dt2 = el.GetAllEmail();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                string nev = dt2.Rows[i][0].ToString();
                cBoxElerhetoseg.Items.Add(nev);
            }
            TelepulesService t = new TelepulesService();
            DataTable dt3 = t.GetAllTelepules();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                string telepules = dt3.Rows[i][1].ToString();
                cBoxTelepules.Items.Add(telepules);
            }
        }

        private void cBoxElerhetoseg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxElerhetoseg.Text == "Új elérhetőség")
            {
                Elerhetoseg el = new Elerhetoseg(); //elérhetőség felvitel
                el.Show();
                FillCombos();
            }
            else
            {
                ElerhetosegService el = new ElerhetosegService();
                DataTable dt = el.GetIdByEmail(cBoxElerhetoseg.Text);
                Int32.TryParse(dt.Rows[0][0].ToString(), out elKod);
            }
        }

        private void cBoxTelepules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxTelepules.Text == "Új település") //település felvitel
            {
                Telepules t = new Telepules();
                t.Show();
            }
            else
            {
                TelepulesService tel = new TelepulesService();
                DataTable dt = tel.GetIdByTelepulesNev(cBoxTelepules.SelectedItem.ToString());
                Int32.TryParse(dt.Rows[0][0].ToString(), out telep);
            }
        }

        private void cBoxOsztaly_SelectedIndexChanged(object sender, EventArgs e)
        {
            OsztalyService o = new OsztalyService();
            DataTable dt = o.GetIdByOsztalyNev(cBoxOsztaly.SelectedItem.ToString());
            Int32.TryParse(dt.Rows[0][0].ToString(), out keret);
        }
    }
}
