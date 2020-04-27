using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class YöneticiPaneliForm : Form
    {
        public YöneticiPaneliForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void YöneticiPaneliForm_Load(object sender, EventArgs e)
        {
           
            label4.Text = KullanıcıGirişForm.mert;
            label2.Text= DateTime.Now.ToString();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            KullanıcıKayıtForm kyt = new KullanıcıKayıtForm();
           // this.Hide();
            kyt.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            KayıtSilmeForm SİL = new KayıtSilmeForm();
            SİL.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 otobus = new Form7();
            otobus.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BiletTakip takip = new BiletTakip();
            takip.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Biletİptal ıptal = new Biletİptal();
            ıptal.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BiletSatForm al = new BiletSatForm();
            al.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OtobüsTakipForm otobustakip = new OtobüsTakipForm();
            otobustakip.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
         
        }

        private void button21_Click(object sender, EventArgs e)
        {
            yardımdestek yardım = new yardımdestek();
            yardım.Show();
        }
    }
}
