using KuldorendszerBLL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Kuldorendszer
{
    public partial class Admin : Form
    {
        DataTable felhTable = new DataTable();
        DataTable jvTable = new DataTable();
        DataTable csapatokTable = new DataTable();
        DataTable merkozesek = new DataTable();
        DataTable telepules = new DataTable();
        DataTable osztaly = new DataTable();
        DataTable elerhetoseg = new DataTable();

        private string table = null;
        private string kod = null;
        private string id = "";
        public Admin()
        {
            InitializeComponent();
            //dGridAdmin.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            //dGridAdmin.BorderStyle = BorderStyle.Fixed3D;
            //dGridAdmin.EditMode = DataGridViewEditMode.EditOnEnter;
        }
        private void btnFelhKarb_Click(object sender, EventArgs e)
        {
            textBKeres.Text = ""; lblKeresMezo.Text = "Név";
            felhTable.Clear();
            this.Text = "Felhasználók";
            FelhasznaloService felh = new FelhasznaloService();
            felhTable = felh.GetAllUser();

            dGridAdmin.DataSource = felhTable;
            dGridAdmin.Columns[0].HeaderText = "Kód";
            dGridAdmin.Columns[1].HeaderText = "Név";
            dGridAdmin.Columns[2].HeaderText = "Email";
            dGridAdmin.Columns[3].HeaderText = "Admin";
            dGridAdmin.Columns[4].HeaderText = "ÁSZF";
            dGridAdmin.Columns[5].HeaderText = "Törölt";
            table = "felhasznalo";
            kod = "felhKod";
            AdatFeltolt();
        }

        private void btnMerkKarb_Click(object sender, EventArgs e)
        {
            textBKeres.Text = ""; lblKeresMezo.Text = "Kód";
            merkozesek.Clear();
            this.Text = "Mérkőzések";
            MerkozesService m = new MerkozesService();
            merkozesek = m.GetMerkozes();

            dGridAdmin.DataSource = merkozesek;
            dGridAdmin.Columns[0].HeaderText = "Kód";
            dGridAdmin.Columns[1].HeaderText = "Dátum";
            dGridAdmin.Columns[2].HeaderText = "Település";
            dGridAdmin.Columns[3].HeaderText = "Hazai Csapet";
            dGridAdmin.Columns[4].HeaderText = "Vendég Csapat";
            dGridAdmin.Columns[5].HeaderText = "Osztály";

            table = "merkozes";
            kod = "merkozesKod";
            AdatFeltolt();
        }

        private void btnJvKarb_Click(object sender, EventArgs e)
        {
            textBKeres.Text = ""; lblKeresMezo.Text = "Név, feladatkör, keret";
            jvTable.Clear();
            this.Text = "Játékvezetők";
            JatekvezetoService jv = new JatekvezetoService();
            jvTable = jv.GetAllJatekvezeto();
            dGridAdmin.DataSource = jvTable;
            dGridAdmin.Columns[0].HeaderText = "JV Kód";
            dGridAdmin.Columns[1].HeaderText = "Név";
            dGridAdmin.Columns[2].HeaderText = "Feladatkör";
            dGridAdmin.Columns[3].HeaderText = "Keret";
            dGridAdmin.Columns[4].HeaderText = "Minősítés";
            dGridAdmin.Columns[5].HeaderText = "Település";
            dGridAdmin.Columns[6].HeaderText = "Elérhetőség";
            table = "jatekvezetok";
            kod = "jvKod";
            AdatFeltolt();
        }

        private void btnCsapKarb_Click(object sender, EventArgs e)
        {
            textBKeres.Text = ""; lblKeresMezo.Text = "Csapat név, csapatvezető";
            csapatokTable.Clear();
            this.Text = "Csapatok";

            CsapatService csapat = new CsapatService();
            csapatokTable = csapat.GetAllCsapat();
            dGridAdmin.DataSource = csapatokTable;
            dGridAdmin.Columns[0].HeaderText = "Azonosító";
            dGridAdmin.Columns[1].HeaderText = "Csapat Név";
            dGridAdmin.Columns[2].HeaderText = "Csapatvezető";
            dGridAdmin.Columns[3].HeaderText = "Osztály";

            table = "csapatok";
            kod = "idOsztaly";
            AdatFeltolt();
        }

        private void textBKeres_TextChanged(object sender, EventArgs e)
        {
            Keres();
        }

        private void Keres()
        {
            switch (table)
            {
                case "csapatok":
                    CsapatService csap = new CsapatService();
                    csapatokTable = csap.GetAllCsapatSearch(textBKeres.Text.Trim());
                    dGridAdmin.DataSource = csapatokTable;
                    break;
                case "elerhetoseg":
                    ElerhetosegService el = new ElerhetosegService();
                    elerhetoseg = el.GetElerhetosegSearch(textBKeres.Text.Trim());
                    dGridAdmin.DataSource = elerhetoseg;
                    break;
                case "felhasznalo":
                    FelhasznaloService fel = new FelhasznaloService();
                    felhTable = fel.GetfelhasznaloSearch(textBKeres.Text.Trim());
                    dGridAdmin.DataSource = felhTable;
                    break;
                case "jatekvezetok":
                    JatekvezetoService jv = new JatekvezetoService();
                    jvTable = jv.GetJatekvezetoSearch(textBKeres.Text.Trim());
                    dGridAdmin.DataSource = jvTable;
                    break;
                case "merkozes":
                    MerkozesService m = new MerkozesService();
                    merkozesek = m.GetMerkozesSearch(textBKeres.Text.Trim());
                    dGridAdmin.DataSource = merkozesek;
                    break;
                case "telepules":
                    TelepulesService t = new TelepulesService();
                    telepules = t.GetAllTelepulesSearch(textBKeres.Text.Trim());
                    dGridAdmin.DataSource = telepules;
                    break;
                case "osztaly":
                    OsztalyService o = new OsztalyService();
                    osztaly = o.GetAllOsztalySearch(textBKeres.Text.Trim());
                    dGridAdmin.DataSource = osztaly;
                    break;
            }
        }
        private void btnKeres_Click(object sender, EventArgs e)
        {
            Keres();
        }
        public void AdatFeltolt()
        {
            DataGridView dgv1 = dGridAdmin;
            btnUj.Enabled = btnModosit.Enabled = btnTorol.Enabled = btnKeres.Enabled = true;

            this.id = Convert.ToString(dgv1.CurrentRow.Cells[0].Value);
            btnModosit.Text = "Módosít (" + this.id + ")";
            btnTorol.Text = "Töröl (" + this.id + ")";
            //label1.Text = $"Adatforrás: {table}"; // Kiírja a használt táblát
        }
        private void dGridAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                AdatFeltolt();
            }
        }

        private void btnModosit_Click(object sender, EventArgs e)
        {
            dGridAdmin.ReadOnly = false;
        }

        private void btnTorol_Click(object sender, EventArgs e)
        {
            if (dGridAdmin.Rows.Count == 0)
            {
                return;
            }
            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Válassz egy elemet a listából.", "Adattörlés", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Meg kell vizsgálni használja e valamelyik tábla, akkor nem törölhető, archiválható!!!

            if (MessageBox.Show("Biztos törlöd az adatot?", "Adattörlés",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                switch (table)
                {
                    case "csapatok":
                        CsapatService csap = new CsapatService();
                        if (csap.DeleteCsapat(this.id))
                            MessageBox.Show($"Sikeres {id} azonosítójú csapat törlés!");
                        break;
                    case "elerhetoseg":
                        ElerhetosegService el = new ElerhetosegService();
                        if (el.DeleteElerhetoseg(this.id))
                            MessageBox.Show($"Sikeres {id} azonosítójú elérhetőség törlés!");
                        break;
                    case "felhasznalo":
                        FelhasznaloService f = new FelhasznaloService();
                        if (f.ArchiveFelhasznalo(this.id))
                            MessageBox.Show($"Sikeres {id} azonosítójú felhasználó archiválás!");
                        break;
                    case "jatekvezetok":
                        JatekvezetoService j = new JatekvezetoService();
                        j.ArchiveJatekvezeto(this.id);
                        MessageBox.Show($"Sikeres {id} azonosítójú játékvezető archiválás!");
                        break;
                    case "merkozes":
                        Merkozesek m = new Merkozesek();
                        m.Show();
                        break;
                    case "telepules":
                        TelepulesService t = new TelepulesService();
                        if (t.DeleteTelepules(this.id))
                            MessageBox.Show($"Sikeres {id} azonosítójú telepulés törlés!");
                        break;
                    case "osztaly":
                        OsztalyService o = new OsztalyService();
                        if (o.DeleteOsztaly(this.id))
                            MessageBox.Show($"Sikeres {id} azonosítójú osztály törlés!");
                        break;
                    default:
                        break;
                }
                dGridAdmin.Refresh();
            }
        }

        private void btnUj_Click(object sender, EventArgs e)
        {
            switch (table)
            {
                case "csapatok":
                    Csapat cs = new Csapat();
                    cs.Show();
                    break;
                case "elerhetoseg":
                    Elerhetoseg el = new Elerhetoseg();
                    el.Show();
                    break;
                case "felhasznalo":
                    Regisztracio r = new Regisztracio();
                    r.Show();
                    break;
                case "jatekvezetok":
                    Jatekvezeto j = new Jatekvezeto();
                    j.Show();
                    break;
                case "merkozes":
                    Merkozesek m = new Merkozesek();
                    m.Show();
                    break;
                case "telepules":
                    Telepules t = new Telepules();
                    t.Show();
                    break;
                case "osztaly":
                    Osztaly o = new Osztaly();
                    o.Show();
                    break;
                default:
                    break;
            }
        }

        private void dGridAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ////label2.Text = dGridAdmin.CurrentCell.OwningColumn.Name;
            //label2.Text = dGridAdmin.Columns[e.ColumnIndex].Name;
            //if (dGridAdmin.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //{
            //    MessageBox.Show(dGridAdmin.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            //}
        }

        private void btnTelepKarb_Click(object sender, EventArgs e)
        {
            textBKeres.Text = ""; lblKeresMezo.Text = "Település, irányítószám";
            telepules.Clear();
            this.Text = "Települések";
            TelepulesService tel = new TelepulesService();
            telepules = tel.GetAllTelepules();
            dGridAdmin.DataSource = telepules;
            dGridAdmin.Columns[0].HeaderText = "Azonosító";
            dGridAdmin.Columns[1].HeaderText = "Település";
            dGridAdmin.Columns[2].HeaderText = "Irányítószám";
            table = "telepules";
            kod = "idTelepules";
            AdatFeltolt();
        }

        private void btnOsztKarb_Click(object sender, EventArgs e)
        {
            textBKeres.Text = ""; lblKeresMezo.Text = "Osztály";
            osztaly.Clear();
            this.Text = "Osztályok";
            OsztalyService oszt = new OsztalyService();
            osztaly = oszt.GetAllOsztaly();
            dGridAdmin.DataSource = osztaly;
            dGridAdmin.Columns[0].HeaderText = "Azonosító";
            dGridAdmin.Columns[1].HeaderText = "Osztály";
            table = "osztaly";
            kod = "idOsztaly";
            AdatFeltolt();
        }

        private void btnElerhetKarb_Click(object sender, EventArgs e)
        {
            textBKeres.Text = ""; lblKeresMezo.Text = "Email, telefonszám";
            this.Text = "Elérhetőségek";
            ElerhetosegService el = new ElerhetosegService();
            elerhetoseg = el.GetAllElerhetoseg();
            dGridAdmin.DataSource = elerhetoseg;
            dGridAdmin.Columns[0].HeaderText = "Azonosító";
            dGridAdmin.Columns[1].HeaderText = "Email-cím";
            dGridAdmin.Columns[2].HeaderText = "Telefonszám";
            table = "elerhetoseg";
            kod = "elerhetosegKod";
            AdatFeltolt();
        }

        private void dGridAdmin_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //label2.Text = dGridAdmin.CurrentCell.OwningColumn.Name;
            //label2.Text = dGridAdmin.Columns[e.ColumnIndex].Name;
            //Console.WriteLine();
        }

        private void dGridAdmin_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string oszlop = dGridAdmin.Columns[e.ColumnIndex].Name;//az eredeti oszlop nevét kell visszadni!!!
            string szoveg = dGridAdmin.CurrentCell.Value.ToString();
            if (szoveg.ToLower() == "true")
            {
                szoveg = 1.ToString();
            }
            else if (szoveg.ToLower() == "false")
            {
                szoveg = 0.ToString();
            }
            if (MessageBox.Show($"Biztos módosítod az adatot {szoveg}-re?", "Adatmódosítás",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (dGridAdmin.CurrentCell.ColumnIndex != 0)
                {
                    switch (table)
                    {
                        case "csapatok":
                            CsapatService csapat = new CsapatService();
                            if (csapat.UpdateCsapat(Int32.Parse(id), oszlop, szoveg))
                                MessageBox.Show("Sikeres adatmódosítás", "Adatmódosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "elerhetoseg":
                            ElerhetosegService el = new ElerhetosegService();
                            if (el.UpdateElerhetoseg(Int32.Parse(id), oszlop, szoveg))
                                MessageBox.Show("Sikeres adatmódosítás", "Adatmódosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "felhasznalo":
                            FelhasznaloService f = new FelhasznaloService();
                            if (f.UpdateFelhasznalo(Int32.Parse(id), oszlop, szoveg))
                                MessageBox.Show("Sikeres adatmódosítás", "Adatmódosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "jatekvezetok":
                            JatekvezetoService j = new JatekvezetoService();
                            if (j.UpdateJatekvezeto(Int32.Parse(id), oszlop, szoveg))
                                MessageBox.Show("Sikeres adatmódosítás", "Adatmódosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "merkozes":
                            MerkozesService m = new MerkozesService();
                            if (m.UpdateMerkozes(Int32.Parse(id), oszlop, szoveg))
                                MessageBox.Show("Sikeres adatmódosítás", "Adatmódosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "telepules":
                            TelepulesService t = new TelepulesService();
                            if (t.UpdateTelepules(Int32.Parse(id), oszlop, szoveg))
                                MessageBox.Show("Sikeres adatmódosítás", "Adatmódosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "osztaly":
                            OsztalyService o = new OsztalyService();
                            if (o.UpdateOsztaly(Int32.Parse(id), oszlop, szoveg))
                                MessageBox.Show("Sikeres adatmódosítás", "Adatmódosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Ezt az adatot nem módosíthatja!", "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdatFeltolt();
                }
            }
            dGridAdmin.ReadOnly = true;
        }

        private void btnUj_MouseHover(object sender, EventArgs e)
        {
            btnUj.BackColor = Color.RoyalBlue;
        }

        private void btnUj_MouseLeave(object sender, EventArgs e)
        {
            btnUj.BackColor = Color.Transparent;
        }

        private void btnModosit_MouseLeave(object sender, EventArgs e)
        {
            btnModosit.BackColor = Color.Transparent;
        }

        private void btnModosit_MouseHover(object sender, EventArgs e)
        {
            btnModosit.BackColor = Color.RoyalBlue;
        }

        private void btnTorol_MouseHover(object sender, EventArgs e)
        {
            btnTorol.BackColor = Color.RoyalBlue;
        }

        private void btnTorol_MouseLeave(object sender, EventArgs e)
        {
            btnTorol.BackColor = Color.Transparent;
        }

        private void btnKeres_MouseHover(object sender, EventArgs e)
        {
            btnKeres.BackColor = Color.RoyalBlue;
        }

        private void btnKeres_MouseLeave(object sender, EventArgs e)
        {
            btnKeres.BackColor = Color.Transparent;
        }
    }
}
