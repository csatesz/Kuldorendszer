using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KuldorendszerBLL;

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

        public string table = null;
        private string kod = "";
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
            textBKeres.Text = "";
            felhTable.Clear();
            this.Text = "Felhasználók";
            FelhasznaloBLL felh = new FelhasznaloBLL();
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
            textBKeres.Text = "";
            merkozesek.Clear();
            this.Text = "Mérkőzések";
            MerkozesBLL m = new MerkozesBLL();
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
            textBKeres.Text = "";
            jvTable.Clear();
            this.Text = "Játékvezetők";
            JatekvezetoBLL jv = new JatekvezetoBLL();
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
            textBKeres.Text = "";
            csapatokTable.Clear();
            this.Text = "Csapatok";

            CsapatBLL csapat = new CsapatBLL();
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
                    CsapatBLL csap = new CsapatBLL();
                    csapatokTable = csap.GetAllCsapatSearch(textBKeres.Text.Trim());
                    dGridAdmin.DataSource = csapatokTable;
                    break;
                case "elerhetoseg":
                    ElerhetosegBLL el = new ElerhetosegBLL();
                    elerhetoseg = el.GetElerhetosegSearch(textBKeres.Text.Trim());
                    dGridAdmin.DataSource = elerhetoseg;
                    break;
                case "felhasznalo":
                    FelhasznaloBLL fel = new FelhasznaloBLL();
                    felhTable = fel.GetfelhasznaloSearch(textBKeres.Text.Trim());
                    dGridAdmin.DataSource = felhTable;
                    break;
                case "jatekvezetok":
                    JatekvezetoBLL jv = new JatekvezetoBLL();
                    jvTable = jv.GetJatekvezetoSearch(textBKeres.Text.Trim());
                    dGridAdmin.DataSource = jvTable;
                    break;
                case "merkozes":
                    MerkozesBLL m = new MerkozesBLL();
                    merkozesek = m.GetMerkozesSearch(textBKeres.Text.Trim());
                    dGridAdmin.DataSource = merkozesek;
                    break;
                case "telepules":
                    TelepulesBLL t = new TelepulesBLL();
                    telepules = t.GetAllTelepulesSearch(textBKeres.Text.Trim());
                    dGridAdmin.DataSource = telepules;
                    break;
                case "osztaly":
                    OsztalyBLL o = new OsztalyBLL();
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
                        CsapatBLL csap = new CsapatBLL();
                        if (csap.DeleteCsapat(this.id))
                            MessageBox.Show($"Sikeres {id} azonosítójú csapat törlés!");
                        break;
                    case "elerhetoseg":
                        ElerhetosegBLL el = new ElerhetosegBLL();
                        if (el.DeleteElerhetoseg(this.id))
                            MessageBox.Show($"Sikeres {id} azonosítójú elérhetőség törlés!");
                        break;
                    case "felhasznalo":
                        FelhasznaloBLL f = new FelhasznaloBLL();
                        if (f.ArchiveFelhasznalo(this.id))
                            MessageBox.Show($"Sikeres {id} azonosítójú felhasználó archiválás!");
                        break;
                    case "jatekvezetok":
                        JatekvezetoBLL j = new JatekvezetoBLL();
                        j.ArchiveJatekvezeto(this.id);
                        MessageBox.Show($"Sikeres {id} azonosítójú játékvezető archiválás!");
                        break;
                    case "merkozes":
                        Merkozesek m = new Merkozesek();
                        m.Show();
                        break;
                    case "telepules":
                        TelepulesBLL t = new TelepulesBLL();
                        if (t.DeleteTelepules(this.id))
                            MessageBox.Show($"Sikeres {id} azonosítójú telepulés törlés!");
                        break;
                    case "osztaly":
                        OsztalyBLL o = new OsztalyBLL();
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
            textBKeres.Text = "";
            telepules.Clear();
            this.Text = "Települések";
            TelepulesBLL tel = new TelepulesBLL();
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
            textBKeres.Text = "";
            osztaly.Clear();
            this.Text = "Osztályok";
            OsztalyBLL oszt = new OsztalyBLL();
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
            textBKeres.Text = "";
            this.Text = "Elérhetőségek";
            ElerhetosegBLL el = new ElerhetosegBLL();
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
                            CsapatBLL csapat = new CsapatBLL();
                            if (csapat.UpdateCsapat(Int32.Parse(id), oszlop, szoveg))
                                MessageBox.Show("Sikeres adatmódosítás", "Adatmódosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "elerhetoseg":
                            ElerhetosegBLL el = new ElerhetosegBLL();
                            if (el.UpdateElerhetoseg(Int32.Parse(id), oszlop, szoveg))
                                MessageBox.Show("Sikeres adatmódosítás", "Adatmódosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "felhasznalo":
                            FelhasznaloBLL f = new FelhasznaloBLL();
                            if (f.UpdateFelhasznalo(Int32.Parse(id), oszlop, szoveg))
                                MessageBox.Show("Sikeres adatmódosítás", "Adatmódosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "jatekvezetok":
                            JatekvezetoBLL j = new JatekvezetoBLL();
                            if (j.UpdateJatekvezeto(Int32.Parse(id), oszlop, szoveg))
                                MessageBox.Show("Sikeres adatmódosítás", "Adatmódosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "merkozes":
                            MerkozesBLL m = new MerkozesBLL();
                            if (m.UpdateMerkozes(Int32.Parse(id), oszlop, szoveg))
                                MessageBox.Show("Sikeres adatmódosítás", "Adatmódosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "telepules":
                            TelepulesBLL t = new TelepulesBLL();
                            if (t.UpdateTelepules(Int32.Parse(id), oszlop, szoveg))
                                MessageBox.Show("Sikeres adatmódosítás", "Adatmódosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "osztaly":
                            OsztalyBLL o = new OsztalyBLL();
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
