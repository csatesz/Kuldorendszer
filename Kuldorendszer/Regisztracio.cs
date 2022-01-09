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
    public partial class Regisztracio : Form
    {
        public Regisztracio()
        {
            InitializeComponent();
        }

        private void Regisztracio_Load(object sender, EventArgs e)
        {

        }

        private void BtnReg_Click(object sender, EventArgs e)
        {
            if (txtBRegJelszo.Text != txtBJelszoUjra.Text)
            {
                MessageBox.Show("A jelszavak nem egyeznek meg!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.Close();
            }
        }
    }
}
