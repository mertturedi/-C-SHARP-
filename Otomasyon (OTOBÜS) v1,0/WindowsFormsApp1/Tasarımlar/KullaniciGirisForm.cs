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
    public partial class KullanıcıGirişForm : Form
    {
        public KullanıcıGirişForm()
        {
            InitializeComponent();
        }

        public static string mert ;

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con,kom;
            SqlCommand cmd, cmk,cml;
            SqlDataReader dr, dc;

            

            string user = textBox1.Text;
            string pass = textBox2.Text;
            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
            kom = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
            cmd = new SqlCommand();
            cmk = new SqlCommand();
            cml = new SqlCommand();
            con.Open();
            kom.Open();
            cmd.Connection = con;
            cmk.Connection = kom;
           
           


            cmk.CommandText = "SELECT * FROM tbl_kullaniciKayit where  KADI='" + textBox1.Text + "' AND SİFRE='" + textBox2.Text + "'AND KYETKİ = 'k'";
            cmd.CommandText = "SELECT * FROM tbl_kullaniciKayit where  KADI='" + textBox1.Text + "' AND SİFRE='" + textBox2.Text + "'AND KYETKİ = 'Y'";
            dr = cmd.ExecuteReader();
            dc = cmk.ExecuteReader();
            mert = textBox1.Text;
           
            if (dr.Read())
            {
            
            YöneticiPaneliForm frm = new YöneticiPaneliForm();
            this.Hide();
            frm.Show();
                
            }
            else if(dc.Read())
            {
                
                KullaniciPanel grş = new KullaniciPanel();
                this.Hide();
                grş.Show();
             

            }
            else
            {
                MessageBox.Show("Hatalı Giriş !");
            }
          
            con.Close();
            kom.Close();


        }

        private void KullanıcıGirişForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            SifreEkrani sfr = new SifreEkrani();
          
            sfr.Show();
        }
    }
}
