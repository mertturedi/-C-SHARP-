using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Proje_01
{
    public partial class SecimForm : MaterialForm
    {
        public SecimForm()
        {
            InitializeComponent();
        }
        
        private void SecimForm_Load(object sender, EventArgs e)
        {
           
            //var skinManager = MaterialSkinManager.Instance;
            //skinManager.AddFormToManage(this);
            //skinManager.Theme = MaterialSkinManager.Themes.DARK;
            //SkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey800, Primary.BlueGrey800, Accent.LightBlue200, TextShade.WHITE);
        }

        private void materialDivider1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UrunEkleForm gecis = new UrunEkleForm();
            gecis.Show();
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MusteriKayitForm gecis = new MusteriKayitForm();
            gecis.Show();
         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MusteriSilForm gecis = new MusteriSilForm();
            gecis.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UrunSilForm gecis = new UrunSilForm();
            gecis.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UrunGuncelleForm gecis = new UrunGuncelleForm();
            gecis.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MusteriGuncelleForm gecis = new MusteriGuncelleForm();
            gecis.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UrunListeleForm gecis = new UrunListeleForm();
            gecis.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
          
            UrunSatForm gecis = new UrunSatForm();
            gecis.textBox3.Text = "0";
              gecis.Show();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MusteriListeleForm gecis = new MusteriListeleForm();
            gecis.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SiparisForm gecis = new SiparisForm();
            gecis.Show();
        }
    }
}
