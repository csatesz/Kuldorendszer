using KuldorendszerBLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kuldorendszer
{
    public partial class Merkozesek : Form
    {
        int hazaiId, vendegId, telepId, osztId;
        public Merkozesek()
        {
            InitializeComponent();

        }
        private void Merkozesek_Load(object sender, EventArgs e)
        {
            FillOsztalyCombo();
            FillCsapatCombos();
            FillTelepulesCombo();
            this.dateTimePicker.Value = DateTime.Now;
        }
        private void FillOsztalyCombo()
        {
            cBoxOsztaly.Items.Clear();
            OsztalyService o = new OsztalyService();
            DataTable dt1 = o.GetAllOsztalyMegnevezes(); ;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string osztaly = dt1.Rows[i][0].ToString();
                cBoxOsztaly.Items.Add(osztaly);
            }
        }
        private void FillTelepulesCombo()
        {
            cBoxTelepules.Items.Clear();
            TelepulesService t = new TelepulesService();
            DataTable dt3 = t.GetAllTelepulesName();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                string telepules = dt3.Rows[i][0].ToString();
                cBoxTelepules.Items.Add(telepules);
            }
        }
        private void FillCsapatCombos()
        {
            cBoxHazai.Items.Clear();
            cBoxVendeg.Items.Clear();

            CsapatService cs = new CsapatService();
            DataTable dt2 = cs.GetAllCsapatNameByOsztaly(osztId);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                string nev = dt2.Rows[i][0].ToString();
                cBoxHazai.Items.Add(nev);
                cBoxVendeg.Items.Add(nev);
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool ervenyes = false;
            bool foglalt = false;

            if (Int32.TryParse(txtBMKod.Text, out int merkozesKod))
            {
                if (merkozesKod > 99999999)
                {
                    MessageBox.Show("A mérkőzés kódja nem lehet ilyen hosszú!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ervenyes = false;
                }
                else ervenyes = true;
            }
            else
            {
                MessageBox.Show("A mérkőzés kódja csak számot tartalmazhat.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ervenyes = false;
            }

            if (Int32.TryParse(txtBJvSzam.Text, out int jvSzam))
            {
                if (jvSzam > 6)
                {
                    MessageBox.Show("A Játékvezető száma nem lehet ennyi!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ervenyes = false;
                }
                else ervenyes = true;
            }
            else
                MessageBox.Show("A Játékvezetők száma csak számot tartalmazhat!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if (Int32.TryParse(txtBFordulo.Text, out int fordulo))
            {
                if (fordulo > 50)
                {
                    MessageBox.Show("Nincs ennyi forduló!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ervenyes = false;
                }
                else ervenyes = true;
            }
            else
                MessageBox.Show("A forduló csak szám lehet!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            MerkozesService m = new MerkozesService();
            DataTable dt = m.GetMerkozesById(merkozesKod);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Ez a kód foglalt!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foglalt = true;
            }

            if (ervenyes && !foglalt)
            {
                if (m.AddMerkozes(merkozesKod, hazaiId, vendegId, jvSzam, dateTimePicker.Value,
                    telepId, osztId, fordulo, 0))
                {
                    MessageBox.Show("Sikeres adatfelvitel", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Sikertelen adatfelvitel", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cBoxHazai_SelectedIndexChanged(object sender, EventArgs e)
        {
            CsapatService cs = new CsapatService();
            DataTable dt = cs.GetIdByCsapatNev(cBoxHazai.SelectedItem.ToString());
            Int32.TryParse(dt.Rows[0][0].ToString(), out hazaiId);
        }

        private void cBoxVendeg_SelectedIndexChanged(object sender, EventArgs e)
        {
            CsapatService cs = new CsapatService();
            DataTable dt = cs.GetIdByCsapatNev(cBoxVendeg.SelectedItem.ToString());
            Int32.TryParse(dt.Rows[0][0].ToString(), out vendegId);
        }

        private void cBoxTelepules_SelectedIndexChanged(object sender, EventArgs e)
        {
            TelepulesService t = new TelepulesService();
            DataTable dt = t.GetIdByTelepulesNev(cBoxTelepules.SelectedItem.ToString());
            Int32.TryParse(dt.Rows[0][0].ToString(), out telepId);
        }

        private void cBoxOsztaly_SelectedIndexChanged(object sender, EventArgs e)
        {
            OsztalyService o = new OsztalyService();
            DataTable dt = o.GetIdByOsztalyNev(cBoxOsztaly.SelectedItem.ToString());
            Int32.TryParse(dt.Rows[0][0].ToString(), out osztId);
            FillCsapatCombos();
        }
    }
}
