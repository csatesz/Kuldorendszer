using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuldorendszer
{
    public partial class Statisztika : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlDataAdapter adapter;
       
        DataTable jv = new DataTable();
        DataTable osztaly = new DataTable();
        int jvKod, osztKod = 0;
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

            adapter = new MySqlDataAdapter($"SELECT nev FROM kuldes.jatekvezetok ;", connection);
            adapter.Fill(jv);
            for (int i = 0; i < jv.Rows.Count; i++)
            {
                string jvNev = jv.Rows[i][0].ToString();
                cBoxJv.Items.Add(jvNev);
            }

            adapter = new MySqlDataAdapter($"SELECT osztalyMegnevezes FROM kuldes.osztaly ;", connection);
            adapter.Fill(osztaly);
            for (int j = 0; j < osztaly.Rows.Count; j++)
            {
                string oszt = osztaly.Rows[j][0].ToString();
                cBoxOsztaly.Items.Add(oszt);
            }
        }

        public void StatisztikaKiir()
        {
            //List<ListBoxItems> statisztika = new List<ListBoxItems>();
            adapter = new MySqlDataAdapter($"SELECT COUNT(k.jvKod OR k.assz1Kod OR k.assz2Kod) FROM kuldes.kuldes k " +
            //$" INNER JOIN kuldes.merkozes m ON m.merkozesDatum BETWEEN \"{dTPTol.Value}\" AND \"{dTPIg.Value}\") " +
            $" WHERE k.jvKod = {jvKod} OR k.assz1Kod = {jvKod} OR k.assz2Kod = {jvKod} " +
            $";", connection); // Ez a lekérdezés még nem jó számolja külön a jvt az asszisztenst 
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //statisztika.Add(new ListBoxItems
                //{
                //    Kod = jvKod,
                //    Text = $"{cBoxJv.SelectedItem}:\n-játékvezetés: "+ dt.Rows[i][0].ToString() + "\n-asszisztálás: "
                //});
            }
            lBStat.DisplayMember = "Text";
            lBStat.ValueMember = "Kod";
            //lBStat.DataSource = statisztika;
            lBStat.Refresh();
            //lBStat.SelectedIndex = pos;
        }

        private void cBoxJv_SelectedIndexChanged(object sender, EventArgs e)
        {
            adapter = new MySqlDataAdapter($"SELECT jvKod  FROM kuldes.jatekvezetok" +
               $" WHERE nev = \"{cBoxJv.SelectedItem}\"", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
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
            adapter = new MySqlDataAdapter($"SELECT idOsztaly FROM kuldes.osztaly" +
               $" WHERE osztalyMegnevezes = \"{cBoxOsztaly.SelectedItem}\"", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Int32.TryParse(dt.Rows[0][0].ToString(), out osztKod);
        }
    }
}
