using KuldorendszerBLL;
using KuldorendszerModels; // ezt ki kell venni innen!
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Kuldorendszer
{
    public partial class Statisztika : Form
    {
        DataTable jv = new DataTable();
        DataTable osztaly = new DataTable();
        int jvKod = 0;
        int osztKod = 0;
        DateTime dateFrom, dateTo; // statisztika készítés dátum intervalluma
        JatekvezetoService jvs = new JatekvezetoService();
        public Statisztika()
        {
            InitializeComponent();
            FillCombos();
            dTPIg.Value = DateTime.Now;
            dTPTol.Value = DateTime.Now.AddDays(-7);
        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            StatisztikaKiir();
        }
        private void FillCombos()
        {
            cBoxJv.Items.Clear();
            cBoxOsztaly.Items.Clear();
            jv = jvs.GetAllJatekvezeto();// Jv kód és név 
            for (int i = 0; i < jv.Rows.Count; i++)
                cBoxJv.Items.Add(jv.Rows[i][1].ToString());

            OsztalyService o = new OsztalyService();
            osztaly = o.GetAllOsztalyMegnevezes();
            for (int k = 0; k < osztaly.Rows.Count; k++)
                cBoxOsztaly.Items.Add(osztaly.Rows[k][0].ToString());

            cBoxJv.SelectedIndex = 0;
        }

        public void StatisztikaKiir()
        {
            List<ListBoxItems> statisztika = new List<ListBoxItems>();
            DataTable dt, dt1, dt2;
            KuldesService k = new KuldesService();
            if (chkBDate.Checked)
            {
                dateFrom = dTPTol.Value;
                dateTo = dTPIg.Value;
            }

            if (chkBOsztaly.Checked) // && chkBDate.Checked dateFrom = dTPTol.Value; dateTo = dTPIg.Value;
            {// Összes mérkőzés adott osztályból osztKod 
                dt = k.JatekvezetoOsszesMerkozesStat(jvKod, osztKod);
                dt1 = k.JatekvezetoJvSzamStat(jvKod, osztKod);
                dt2 = k.JatekvezetoAsszisztSzamStat(jvKod, osztKod);
            }
            else
            {
                dt = k.JatekvezetoOsszesMerkozesStat(jvKod);
                dt1 = k.JatekvezetoJvSzamStat(jvKod);
                dt2 = k.JatekvezetoAsszisztSzamStat(jvKod);
            }

            statisztika.Add(new ListBoxItems
            {
                Kod = jvKod,
                Text = $"{cBoxJv.SelectedItem}:"
            });
            statisztika.Add(new ListBoxItems
            {
                Kod = jvKod,
                Text = $"- Összes működése: {dt.Rows[0][0]} mérkőzés"
            });            
            statisztika.Add(new ListBoxItems
            {
                Kod = jvKod,
                Text = $"- Játékvezetés: {dt1.Rows[0][0]} mérkőzés"
            });           
            statisztika.Add(new ListBoxItems
            {
                Kod = jvKod,
                Text = $"- Asszisztálás: {dt2.Rows[0][0]} mérkőzés"
            });

            lBStat.DisplayMember = "Text";
            lBStat.ValueMember = "Kod";
            lBStat.DataSource = statisztika;
            lBStat.Refresh();
            lBStat.SelectedIndex = -1;
        }

        private void cBoxJv_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = jvs.GetJatekvezetoIdByNev(cBoxJv.SelectedItem.ToString());
            if (dt.Rows.Count != 0)
                Int32.TryParse(dt.Rows[0][0].ToString(), out jvKod);
        }

        private void btnBezar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztos hogy bezárod az ablakot!", "Bezár",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cBoxOsztaly_SelectedIndexChanged(object sender, EventArgs e)
        {
            OsztalyService o = new OsztalyService();
            DataTable dt = o.GetIdByOsztalyNev(cBoxOsztaly.SelectedItem.ToString());
            if (dt.Rows.Count != 0)
                Int32.TryParse(dt.Rows[0][0].ToString(), out osztKod);
        }

        private void chkBOsztaly_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBOsztaly.Checked)
            {
                cBoxOsztaly.Enabled = true;
                cBoxOsztaly.SelectedIndex = 0;
            }
            else
            {
                cBoxOsztaly.Enabled = false;
            }
        }

        private void chkBDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBDate.Checked)
            {
                dTPTol.Enabled = true;
                dTPIg.Enabled = true;
            }
            else
            {
                dTPTol.Enabled = false;
                dTPIg.Enabled = false;
            }
        }
    }
}
