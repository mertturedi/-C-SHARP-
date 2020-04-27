using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class KullaniciPanel : Form
    {
        public KullaniciPanel()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BiletTakip takip = new BiletTakip();
            takip.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BiletSatForm al = new BiletSatForm();
            al.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 otobus = new Form7();
            otobus.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {

        }
    }
}
