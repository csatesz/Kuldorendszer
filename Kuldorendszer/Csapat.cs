using KuldorendszerBLL;
using Kuldorendszer.Interfaces;
using System;
using System.Data;
using System.Windows.Forms;


namespace Kuldorendszer
{
    public partial class Csapat : Form,IUpdatableCombosForm
    {
        int id, elKod, osztaly, csKod;
        CsapatService csap = new CsapatService();
        public Csapat()
        {
            InitializeComponent();
        }
        public Csapat(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void Csapat_Load(object sender, EventArgs e)
        {
            FillCombos();
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
            
            if (ValidateCsapat())
            {
                if (csap.AddCsapat(csKod, txtBCsapatNev.Text, elKod, txtBCsapatvezeto.Text, osztaly))
                {
                    MessageBox.Show("Sikeres adatfelvitel", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
                MessageBox.Show("Sikertelen adatfelvitel", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void FillCombos()
        {
            cBoxElerhetoseg.Items.Clear();
            cBoxOsztaly.Items.Clear();
            cBoxElerhetoseg.Items.Add("Új elérhetőség");

            OsztalyService o = new OsztalyService();
            DataTable dt1 = o.GetAllOsztalyMegnevezes();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string osztaly = dt1.Rows[i][0].ToString();
                cBoxOsztaly.Items.Add(osztaly);
            }
            cBoxOsztaly.SelectedItem = o.GetOsztalyById(elKod);
            ElerhetosegService el = new ElerhetosegService();
            DataTable dt2 = el.GetAllEmail();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                string nev = dt2.Rows[i][0].ToString();
                cBoxElerhetoseg.Items.Add(nev);
            }
            if (id != 0)
            {
                txtBCsapatKod.Enabled = btnOk.Enabled = false;
                txtBCsapatKod.Text = id.ToString();

                DataTable dtcs = csap.GetCsapatAdatById(id);
                txtBCsapatNev.Text = dtcs.Rows[0][1].ToString();
                txtBCsapatvezeto.Text = dtcs.Rows[0][3].ToString();
                DataTable dto = o.GetOsztalyById(Int32.Parse(dtcs.Rows[0][4].ToString()));// csapat név idOsztaly alapján
                DataTable dte = el.GetEmailById(Int32.Parse(dtcs.Rows[0][2].ToString()));// email elerhetosegKod alapján
                cBoxOsztaly.SelectedItem = dto.Rows[0][0];
                cBoxElerhetoseg.SelectedItem = dte.Rows[0][0];
            }
        }
        private bool ValidateCsapat()
        {
            bool ervenyes = false;
            bool foglalt = false;

            if (Int32.TryParse(txtBCsapatKod.Text, out int csKod))
            {
                if (csKod > 99999999 || csKod < 1)
                {
                    MessageBox.Show("A csapat kódja nem lehet ennyi!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ervenyes = false;
                }
                else
                    ervenyes = true;
            }
            else
            {
                MessageBox.Show("A csapat kódja csak pozitív számot tartalmazhat.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ervenyes = false;
            }
            DataTable dt = csap.GetCsapatById(csKod);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Már van ilyen kódú csapat.", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                foglalt = true;
            }

            return ervenyes && !foglalt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (csap.UpdateMindenCsapatAdat(id, txtBCsapatNev.Text, elKod, txtBCsapatvezeto.Text, osztaly))
            {
                MessageBox.Show("Sikeres adatmódosítás", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Sikertelen adatmódosítás", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void cBoxElerhetoseg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxElerhetoseg.Text == "Új elérhetőség")
            {
                Elerhetoseg el = new Elerhetoseg(this); //elérhetőség felvitel
                el.Show();
                //Delay(2000);
                FillCombos();
            }
            else
            {
                ElerhetosegService el = new ElerhetosegService();
                DataTable dt = el.GetIdByEmail(cBoxElerhetoseg.Text.ToString());
                Int32.TryParse(dt.Rows[0][0].ToString(), out elKod);
            }
        }

        private void cBoxOsztaly_SelectedIndexChanged(object sender, EventArgs e)
        {
            OsztalyService o = new OsztalyService();
            DataTable dt = o.GetIdByOsztalyNev(cBoxOsztaly.SelectedItem.ToString());
            Int32.TryParse(dt.Rows[0][0].ToString(), out osztaly);
        }
    }
}
