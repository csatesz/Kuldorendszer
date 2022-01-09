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
    public partial class Kuldes : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();
        int pos = 0;
        public Kuldes()
        {
            InitializeComponent();
        }

        private void Kuldes_Load(object sender, EventArgs e)
        {
            adapter = new MySqlDataAdapter("SELECT * FROM ami.users", connection);
            adapter.Fill(table);
            showData(pos);

        }
        public void showData(int index)
        {
            txtBVerseny.Text = table.Rows[index][2].ToString();
            txtBKod.Text = table.Rows[index][0].ToString();
            txtBHazai.Text = table.Rows[index][1].ToString();
            txtBVendeg.Text = table.Rows[index][1].ToString();
            txtBDatum.Text = table.Rows[index][3].ToString();
        }

        private void btnElozo_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos >= 0)
            {
                showData(pos);
            }
            else
            {
                MessageBox.Show("Az adatok elejét elérte!");
            }
        }

        private void btnKovetkezo_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos < table.Rows.Count)
            {
                showData(pos);
            }
            else
            {
                MessageBox.Show("Az adatok végét elérte!");
                pos = table.Rows.Count - 1;
            }
        }
    }
}
