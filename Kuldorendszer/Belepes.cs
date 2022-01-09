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
    public partial class Belepes : Form
    {
        public Belepes()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnUjFelh_Click(object sender, EventArgs e)
        {
            Regisztracio reg = new Regisztracio();
            reg.ShowDialog();
            //Regisztracio.Show();
        }

        private void BtnBelep_Click(object sender, EventArgs e)
        {
            if (txtBEmail.Text == "" || txtBEmail.Text == "" || txtBFelh.Text == "")
            {
                MessageBox.Show("Egyik adat sem lehet üres!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.Visible = false;
            Kuldes kuld = new Kuldes();
            kuld.ShowDialog();
            this.Close();

        }
    }
}
