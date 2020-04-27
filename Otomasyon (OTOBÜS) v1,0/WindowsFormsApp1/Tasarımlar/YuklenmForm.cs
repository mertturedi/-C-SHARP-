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
    public partial class YüklenmForm : Form
    {
        public YüklenmForm()
        {
            
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            
            SeçimEkranıForm frm = new SeçimEkranıForm();
            this.Hide();
            frm.Show();
            label1.Text = label1.Text.Substring(1) + label1.Text.Substring(0, 1);
            timer1.Enabled = false;
        }

        private void YüklenmForm_Load(object sender, EventArgs e)
        {

            timer1.Enabled = true; 
            timer2.Enabled = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = label1.Text.Substring(1) + label1.Text.Substring(0, 1);
           

        }
    }
}
