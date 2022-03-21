using KuldorendszerBLL;
using KuldorendszerModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Kuldorendszer
{
    public partial class Kuldes : Form
    {
        DataTable merkozesTable = new DataTable(); //SELECT * FROM kuldes.merkozes
        DataTable merkozesekJvel = new DataTable();
        DataTable jv = new DataTable(); // játékvezetők
        DataTable assz = new DataTable(); //asszsiztensek
        int jvszam;
        int pos = 0;
        public Kuldes()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception)
            {
                throw new Exception("Hiba történt! Indítsa újra a programot.");
            }
        }

        private void Kuldes_Load(object sender, EventArgs e)
        {
            MerkozesService m = new MerkozesService();
            merkozesTable = m.GetAllMerkozes();
            ShowData(pos);
            FillCombo();
            MerkozesJvvel();
            FillJvCombo();
        }

        private void FillCombo()
        {
            cBoxVerseny.Items.Clear();
            cBoxFordulo.Items.Clear();
            cBoxVerseny.Items.Add("Összes");
            cBoxFordulo.Items.Add("Összes");
            cBoxVerseny.SelectedItem = "Összes";
            cBoxFordulo.SelectedItem = "Összes";

            OsztalyService o = new OsztalyService();
            DataTable dt = o.GetAllOsztalyMegnevezes();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string osztaly = dt.Rows[i][0].ToString();
                cBoxVerseny.Items.Add(osztaly);
            }

            List<int> forduloszam = new List<int>();
            for (int j = 0; j < merkozesTable.Rows.Count; j++)
            {
                if (!forduloszam.Contains((int)merkozesTable.Rows[j][7]))
                {
                    forduloszam.Add((int)merkozesTable.Rows[j][7]);
                    cBoxFordulo.Items.Add(merkozesTable.Rows[j][7].ToString());
                }
            }
        }

        public void ShowData(int index) // itt kellene feltölteni a mérkőzést jvvel?!
        {
            int szam = (int)merkozesTable.Rows[index][0];
            MerkozesService m = new MerkozesService();
            DataTable dt = m.GetForduloJvSzamById(szam);
            jvszam = Int32.Parse(merkozesTable.Rows[index][3].ToString()); // Jv-k száma
            txtBFordulo.Text = dt.Rows[0][0].ToString(); // Forduló

            //cBoxFordulo.SelectedItem = txtBFordulo.Text;
            OsztalyService o = new OsztalyService();
            DataTable dt1 = o.GetOsztalyById(Int32.Parse(merkozesTable.Rows[index][6].ToString()));

            txtBVerseny.Text = dt1.Rows[0][0].ToString(); //verseny
            txtBKod.Text = merkozesTable.Rows[index][0].ToString(); // mérkőzés kódja
            txtBDatum.Text = merkozesTable.Rows[index][4].ToString(); // Mérkőzés dátuma

            CsapatService cs = new CsapatService();
            DataTable dt2 = cs.GetCsapatById(Int32.Parse(merkozesTable.Rows[index][1].ToString()));
            txtBHazai.Text = dt2.Rows[0][0].ToString(); // hazai csapat ID

            DataTable dt3 = cs.GetCsapatById(Int32.Parse(merkozesTable.Rows[index][2].ToString()));
            txtBVendeg.Text = dt3.Rows[0][0].ToString();// vendég csapat ID

            TelepulesService t = new TelepulesService();
            DataTable dt4 = t.GetTelepulesById(Int32.Parse(merkozesTable.Rows[index][5].ToString()));

            txtBHely.Text = dt4.Rows[0][0].ToString();// Hol? idTelepules -> 

            JatekvezetoService j = new JatekvezetoService();
            DataTable dt5 = j.GetJatekvezetoNevIdByMerkozesKod(Int32.Parse(merkozesTable.Rows[index][0].ToString()), "jvKod");
            if (dt5.Rows.Count != 0)
            {
                txtBJV.Text = dt5.Rows[0][0].ToString(); // jv-k száma itt van merkozesTable.Rows[index][3].ToString();
                lblJvKod.Text = dt5.Rows[0][1].ToString();// jv kódja
            }
            else
            {
                txtBJV.Text = "";
                lblJvKod.Text = "";
            }

            DataTable dt6 = j.GetJatekvezetoNevIdByMerkozesKod(Int32.Parse(merkozesTable.Rows[index][0].ToString()), "assz1Kod");
            if (dt6.Rows.Count != 0)
            {
                txtBAssz1.Text = dt6.Rows[0][0].ToString(); // assz 1
                lblAssz1Kod.Text = dt6.Rows[0][1].ToString();// assz 1 kódja
            }
            else
            {
                txtBAssz1.Text = "";
                lblAssz1Kod.Text = "";
            }

            DataTable dt7 = j.GetJatekvezetoNevIdByMerkozesKod(Int32.Parse(merkozesTable.Rows[index][0].ToString()), "assz2Kod");
            if (dt7.Rows.Count != 0)
            {
                txtBAssz2.Text = dt7.Rows[0][0].ToString(); // assz 2
                lblAssz2Kod.Text = dt7.Rows[0][1].ToString(); // assz 2 kódja
            }
            else
            {
                txtBAssz2.Text = "";
                lblAssz2Kod.Text = "";
            }
            MerkozesKiir();
        }

        private void btnElozo_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos >= 0)
            {
                ShowData(pos);
            }
            else
            {
                MessageBox.Show("Elérte az adatok elejét!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pos = 0;
            }
        }

        private void btnKovetkezo_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos < merkozesTable.Rows.Count)
            {
                ShowData(pos);
            }
            else
            {
                MessageBox.Show("Elérte az adatok végét!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pos = merkozesTable.Rows.Count - 1;
            }
        }

        private void cBoxVerseny_SelectedIndexChanged(object sender, EventArgs e)
        {
            VersenyForduloValt();
        }
        private void cBoxFordulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            VersenyForduloValt();
        }

        private void VersenyForduloValt()
        {
            merkozesTable.Clear();
            MerkozesService m = new MerkozesService();

            if (cBoxVerseny.SelectedIndex <= 0 && cBoxFordulo.SelectedIndex <= 0)
            {
                merkozesTable = m.GetAllMerkozes();
            }
            else if (cBoxFordulo.SelectedItem.ToString() == "Összes" || cBoxFordulo.SelectedIndex <= 0)
            {
                merkozesTable = m.GetMerkozesByOsztaly(cBoxVerseny.SelectedItem.ToString());
            }
            else if (cBoxVerseny.SelectedItem.ToString() == "Összes" || cBoxVerseny.SelectedIndex <= 0)
            {
                merkozesTable = m.GetMerkozesByFordulo(cBoxFordulo.SelectedItem.ToString());
            }
            else
            {
                merkozesTable = m.GetMerkozesByForduloAndOsztaly(cBoxFordulo.SelectedItem.ToString(), cBoxVerseny.SelectedItem.ToString());
            }

            if (merkozesTable.Rows.Count > 0)
            {
                pos = 0;
                ShowData(pos);
            }
            else
            {
                MessageBox.Show("Ebben az osztályban/fordulóban nincs mérkőzés!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (merkozesTable.Rows.Count > 0)
            {
                pos = merkozesTable.Rows.Count - 1;
                ShowData(pos);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            MessageBox.Show(e.ClickedItem.Text);
            string itemText = e.ClickedItem.Text;

            switch (itemText)
            {
                case "&file":
                    //do stuff
                    break;
                case "&edit":
                    // do stuff
                    break;
                case "&tools":
                    // do stuff
                    break;
                case "&help":
                    // do stuff
                    break;
            }
        }

        private void btnModosit_Click(object sender, EventArgs e)
        {
            chkBoxJV.Visible = cBoxJv.Visible = cBoxAssz1.Visible = cBoxAssz2.Visible = btnVegleg.Visible = true;
            dataGridView1.Enabled = lBMerkozesek.Enabled = cBoxFordulo.Enabled = cBoxVerseny.Enabled = btnKuldes.Enabled = btnStat.Enabled = btnElozo.Enabled = btnFirst.Enabled = btnKovetkezo.Enabled = btnLast.Enabled = false;
            cBoxJv.Text = txtBJV.Text;
            cBoxAssz1.Text = txtBAssz1.Text; ;
            cBoxAssz2.Text = txtBAssz2.Text;
        }
        public void FillJvCombo()
        {
            cBoxJv.Items.Clear();
            cBoxAssz1.Items.Clear();
            cBoxAssz2.Items.Clear();

            JatekvezetoService j = new JatekvezetoService();
            jv = j.GetJatekvezetoByFeladat("játékvezető");
            assz = j.GetJatekvezetoByFeladat("asszisztens");
            //jvszam = (int)merkozesTable.Rows[i][3];
            for (int i = 0; i < jv.Rows.Count; i++)
                cBoxJv.Items.Add(jv.Rows[i]["nev"].ToString());

            if (chkBoxJV.Checked)
            {
                for (int i = 0; i < jv.Rows.Count; i++)
                {
                    cBoxAssz1.Items.Add(jv.Rows[i]["nev"].ToString());
                    cBoxAssz2.Items.Add(jv.Rows[i]["nev"].ToString());
                }
                for (int k = 0; k < assz.Rows.Count; k++)
                {
                    cBoxAssz1.Items.Add(assz.Rows[k]["nev"].ToString());
                    cBoxAssz2.Items.Add(assz.Rows[k]["nev"].ToString());
                }
            }
            else
            {
                for (int k = 0; k < assz.Rows.Count; k++)
                {
                    //merkozesekJvel.Rows[i][5] = assz.Rows[i][0];
                    cBoxAssz1.Items.Add(assz.Rows[k]["nev"].ToString());
                    cBoxAssz2.Items.Add(assz.Rows[k]["nev"].ToString());
                }
            }
        }

        private void btnVegleg_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = lBMerkozesek.Enabled = cBoxFordulo.Enabled = cBoxVerseny.Enabled = btnStat.Enabled = btnKuldes.Enabled = btnElozo.Enabled = btnFirst.Enabled = btnKovetkezo.Enabled = btnLast.Enabled = true;
            chkBoxJV.Visible = cBoxJv.Visible = cBoxAssz1.Visible = cBoxAssz2.Visible = btnVegleg.Visible = false;

            // meg kell nézni, hogy van-e már ilyen kódú mérkőzésen játékvezető - 
            // ha nincs fel kell vinni 
            KuldesService m = new KuldesService();
            if (txtBJV.Text == "" || txtBJV.Text == null)
            {
                if (m.AddKuldes(txtBKod.Text, lblJvKod.Text, lblJvKod.Text, lblAssz2Kod.Text, 0))
                {
                    MessageBox.Show("Sikeres adatfelvitel", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Sikertelen adatfelvitel", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (m.UpdateKuldes(txtBKod.Text, lblJvKod.Text, lblAssz1Kod.Text, lblAssz2Kod.Text, 0))
                {
                    MessageBox.Show("Sikeres adatfelvitel", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Sikertelen adatfelvitel", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtBJV.Text = cBoxJv.Text;
            txtBAssz1.Text = cBoxAssz1.Text;
            txtBAssz2.Text = cBoxAssz2.Text;
            MerkozesJvvel();
        }

        private void btnKuldes_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztos elkészíti a küldést?", "Küldés készítés",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {// ha nincs jv abban a sorban, akkor kell arra a meccsre jvt, asszisztenst beírni jvszám függvényében
             //merkozesTable-ba vannak a mérkőzések, merkozesekJvel-ben jv vel!

                for (int i = 0; i < merkozesTable.Rows.Count; i++)// ha nincs ilyen kódú mérkőzésre jv küldeni kell
                {
                    //bool exists = merkozesekJvel.Select().ToList()
                    //    .Exists(row => row["merkozesKod"].ToString() == 
                    //    merkozesTable.Rows[i][0].ToString());

                    // ha nincs még benne a mérkőzés a merkozesekjvvel-ben és a dátum későbbi
                    DateTime date = DateTime.Parse(merkozesTable.Rows[i][4].ToString());
                    if (merkozesekJvel.Rows.IndexOf(merkozesekJvel.AsEnumerable()
                        .Where(c => c.Field<int>(0) == Int32.Parse(merkozesTable.Rows[i][0].ToString()))
                        .FirstOrDefault()) < 0 && date > DateTime.Now)
                    {
                        KuldesService k = new KuldesService();
                        if (k.KuldesKeszit(Int32.Parse(merkozesTable.Rows[i][0].ToString()), date, (int)merkozesTable.Rows[i][3]))
                            MessageBox.Show($"Sikeres  küldés készítés a {merkozesTable.Rows[i][0]} kódú mérkőzésre!", "Adatfelvitel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //else
                        //    MessageBox.Show("Sikertelen küldés készítés!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error); ;//ide jön a fő rész küldés készítés
                    }
                }
            }
            MerkozesJvvel();
            MerkozesKiir();
        }
        public void MerkozesJvvel()
        {
            merkozesekJvel.Clear();
            KuldesService k = new KuldesService();
            merkozesekJvel = k.GetMerkozesJvvel();
            if (merkozesekJvel.Columns.Count <= 6)
            {
                merkozesekJvel.Columns.Add("Asszisztens 1", typeof(String));
                merkozesekJvel.Columns.Add("Asszisztens 2", typeof(String));
            }
            int z = 0; int n = 0;
            for (int i = 0; i < merkozesTable.Rows.Count; i++)
            {
                if ((DateTime)merkozesTable.Rows[i][4] > DateTime.Now)
                {
                    DataTable assziszt1 = k.GetJatekvezetoOnKuldesByMerkozesKod(merkozesTable.Rows[i][0].ToString(), "assz1Kod");
                    if (assziszt1.Rows.Count != 0)
                    {
                        merkozesekJvel.Rows[z][6] = assziszt1.Rows[0][0];
                        z++;
                    }
                    assziszt1.Clear();
                    DataTable assziszt2 = k.GetJatekvezetoOnKuldesByMerkozesKod(merkozesTable.Rows[i][0].ToString(), "assz2Kod");
                    if (assziszt2.Rows.Count != 0)
                    {
                        merkozesekJvel.Rows[n][7] = assziszt2.Rows[0][0];
                        n++;
                    }
                    assziszt2.Clear();
                }
            }
            dataGridView1.DataSource = merkozesekJvel;
            dataGridView1.Columns[0].HeaderText = "Kód";
            dataGridView1.Columns[1].HeaderText = "Dátum";
            dataGridView1.Columns[2].HeaderText = "Helyszín";
            dataGridView1.Columns[3].HeaderText = "Hazai";
            dataGridView1.Columns[4].HeaderText = "Vendég";
            dataGridView1.Columns[5].HeaderText = "Játékvezető";
        }

        public void MerkozesKiir()
        {
            List<ListBoxItems> merkozesek = new List<ListBoxItems>();
            CsapatService cs = new CsapatService();
            for (int i = 0; i < merkozesTable.Rows.Count; i++)
            {
                DataTable hazai = cs.GetCsapatById(Int32.Parse(merkozesTable.Rows[i][1].ToString()));
                DataTable vendeg = cs.GetCsapatById(Int32.Parse(merkozesTable.Rows[i][2].ToString()));
                merkozesek.Add(new ListBoxItems
                {
                    Kod = (int)merkozesTable.Rows[0][0],
                    Text = hazai.Rows[0][0].ToString() + "\t\t-\t\t" + vendeg.Rows[0][0].ToString()
                });
            }
            lBMerkozesek.DisplayMember = "Text";
            lBMerkozesek.ValueMember = "Kod";
            lBMerkozesek.DataSource = merkozesek;
            lBMerkozesek.Refresh();
            lBMerkozesek.SelectedIndex = pos;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            pos = 0;
            ShowData(pos);
        }

        private void lBMerkozesek_DoubleClick(object sender, EventArgs e)
        {
            pos = lBMerkozesek.SelectedIndex;
            ShowData(pos);
        }

        private void cBoxJv_SelectedIndexChanged(object sender, EventArgs e)
        {
            JatekvezetoService jv = new JatekvezetoService();
            DataTable dt = jv.GetJatekvezetoIdByNev(cBoxJv.SelectedItem.ToString());
            if (dt.Rows.Count != 0)
            {
                lblJvKod.Text = dt.Rows[0][0].ToString();
            }
        }

        private void cBoxAssz1_SelectedIndexChanged(object sender, EventArgs e)
        {
            JatekvezetoService jv = new JatekvezetoService();
            DataTable dt = jv.GetJatekvezetoIdByNev(cBoxAssz1.SelectedItem.ToString());
            if (dt.Rows.Count != 0)
            {
                lblAssz1Kod.Text = dt.Rows[0][0].ToString();
            }
        }

        private void cBoxAssz2_SelectedIndexChanged(object sender, EventArgs e)
        {
            JatekvezetoService jv = new JatekvezetoService();
            DataTable dt = jv.GetJatekvezetoIdByNev(cBoxAssz2.SelectedItem.ToString());
            if (dt.Rows.Count != 0)
            {
                lblAssz2Kod.Text = dt.Rows[0][0].ToString();
            }
        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            Statisztika s = new Statisztika();
            s.Show();
        }

        private void chkBoxJV_CheckedChanged(object sender, EventArgs e)
        {
            FillJvCombo();
        }
    }
}

