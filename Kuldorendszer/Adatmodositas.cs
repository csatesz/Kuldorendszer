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
    public partial class Adatmodositas : Form
    {
        string table = "";
        string id = "";
        string kod = "";
        public Adatmodositas(string table)
        {
            InitializeComponent();
            //btnOk.Text = table + id + kod;
            //label1.Text = f.Controls.ToString();
            //Admin a = new Admin();
            label2.Text = table; 
        }

        private void Adatmodositas_Load(object sender, EventArgs e)
        {
            //Adatmodositas a;
            //cmd = new MySqlCommand("INSERT INTO kuldes.kuldes (merkozesKod,jvKod,assz1Kod,assz2Kod) " +
            //       "VALUES (@merkozesKod,@jvKod,@assz1Kod,@assz2Kod)", connection);
            //cmd = new MySqlCommand($"SELECT * FROM {table} WHERE {kod}={id}");
            //connection.Open();
            //cmd.Parameters.AddWithValue("@merkozesKod", txtBKod.Text.Trim());
            //cmd.Parameters.AddWithValue("@jvKod", cBoxJv.SelectedIndex);
            //cmd.Parameters.AddWithValue("@assz1Kod", cBoxAssz1.SelectedIndex);
            //cmd.Parameters.AddWithValue("@assz2Kod", cBoxAssz2.SelectedIndex);
            //cmd.ExecuteNonQuery();
            //connection.Close();

        }

        private void btnMegse_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztos hogy bezárod az ablakot!", "Bezár",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
