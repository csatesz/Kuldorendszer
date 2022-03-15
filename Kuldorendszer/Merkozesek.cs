using KuldorendszerBLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kuldorendszer
{
    public partial class Merkozesek : Form
    {
        //MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        //MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        //MySqlCommand cmd;
        int hazaiId, vendegId, telepId, osztId = 0;
        //string table = "";
        //string kod = "";
        public Merkozesek()
        {
            InitializeComponent();

        }
        private void Merkozesek_Load(object sender, EventArgs e)
        {
            FillCombos();
            this.dateTimePicker.Value = DateTime.Now;
        }
        private void FillCombos()
        {
            cBoxHazai.Items.Clear();
            cBoxVendeg.Items.Clear();
            cBoxTelepules.Items.Clear();
            cBoxOsztaly.Items.Clear();

            OsztalyBLL o = new OsztalyBLL();
            DataTable dt1 = o.GetAllMegnevezes(); ;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string osztaly = dt1.Rows[i][0].ToString();
                cBoxOsztaly.Items.Add(osztaly);
            }
            CsapatBLL cs = new CsapatBLL();
            DataTable dt2 = cs.GetAllCsapatName();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                string nev = dt2.Rows[i][0].ToString();
                cBoxHazai.Items.Add(nev);
                cBoxVendeg.Items.Add(nev);
            }
            TelepulesBLL t = new TelepulesBLL();
            DataTable dt3 = t.GetAllTelepulesName();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                string telepules = dt3.Rows[i][0].ToString();
                cBoxTelepules.Items.Add(telepules);
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
                MessageBox.Show("A mérkőzés kódja csak számot tartalmazhat.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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

            MerkozesBLL m = new MerkozesBLL();
            dt = m.GetMerkozesById(merkozesKod);
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
            CsapatBLL cs = new CsapatBLL();
            DataTable dt = cs.GetIdByCsapatName(cBoxHazai.SelectedItem.ToString());
            Int32.TryParse(dt.Rows[0][0].ToString(), out hazaiId);
        }

        private void cBoxVendeg_SelectedIndexChanged(object sender, EventArgs e)
        {
            CsapatBLL cs = new CsapatBLL();
            DataTable dt = cs.GetIdByCsapatName(cBoxVendeg.SelectedItem.ToString());
            Int32.TryParse(dt.Rows[0][0].ToString(), out vendegId);
        }

        private void cBoxTelepules_SelectedIndexChanged(object sender, EventArgs e)
        {
            TelepulesBLL t = new TelepulesBLL();
            DataTable dt = t.GetIdByTelepulesNev(cBoxTelepules.SelectedItem.ToString());
            Int32.TryParse(dt.Rows[0][0].ToString(), out telepId);
        }

        private void cBoxOsztaly_SelectedIndexChanged(object sender, EventArgs e)
        {
            OsztalyBLL o = new OsztalyBLL();
            DataTable dt = o.GetIdByOsztalyNev(cBoxOsztaly.SelectedItem.ToString());
            Int32.TryParse(dt.Rows[0][0].ToString(), out osztId);
        }
    }
}
