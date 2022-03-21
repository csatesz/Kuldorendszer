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
            JatekvezetoService j = new JatekvezetoService();
            jv = j.GetAllJatekvezeto();// Jv kód és név 
            for (int i = 0; i < jv.Rows.Count; i++)
            {
                string jvNev = jv.Rows[i][1].ToString();
                cBoxJv.Items.Add(jvNev);
            }

            OsztalyService o = new OsztalyService();
            osztaly = o.GetAllOsztalyMegnevezes();
            for (int k = 0; k < osztaly.Rows.Count; k++)
            {
                string oszt = osztaly.Rows[k][0].ToString();
                cBoxOsztaly.Items.Add(oszt);
            }
            cBoxJv.SelectedIndex = 0;
        }

        public void StatisztikaKiir()
        {
            List<ListBoxItems> statisztika = new List<ListBoxItems>();
            KuldesService k = new KuldesService();
            DataTable dt = k.JatekvezetoOsszesMerkozesStat(jvKod);// Összes mérkőzés - osztKod?            
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

            DataTable dt1 = k.JatekvezetoJvSzamStat(jvKod);
            statisztika.Add(new ListBoxItems
            {
                Kod = jvKod,
                Text = $"- Játékvezetés: {dt1.Rows[0][0]} mérkőzés"
            });
            DataTable dt2 = k.JatekvezetoAsszisztSzamStat(jvKod);
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
            JatekvezetoService jv = new JatekvezetoService();
            DataTable dt = jv.GetJatekvezetoIdByNev(cBoxJv.SelectedItem.ToString());
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
                //cBoxOsztaly.SelectedIndex = -1;
            }

        }

        private void chkBFrom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBFrom.Checked)
                dTPTol.Enabled = true;
            else
                dTPTol.Enabled = false;
        }

        private void chkBTo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBTo.Checked)
                dTPIg.Enabled = true;
            else
                dTPIg.Enabled = false;
        }
    }
}
