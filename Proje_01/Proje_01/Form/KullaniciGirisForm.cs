using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using System.Data.SqlClient;

namespace Proje_01
{
    public partial class KullaniciGirsForm : MaterialForm
    {
        public KullaniciGirsForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {

            SqlConnection con;
            SqlCommand cmd; 
            SqlDataReader dr;
            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM tbl_login where  Kadi='" + materialSingleLineTextField1.Text + "' AND Sifre='" + materialSingleLineTextField2.Text + "'";
            dr = cmd.ExecuteReader();
            if (materialSingleLineTextField1.Text != "" && materialSingleLineTextField2.Text != "")
            {
                if (dr.Read())
                {
                    SecimForm gecis = new SecimForm();
                    this.Hide();
                    gecis.Show();
                }
                else
                {
                    MessageBox.Show("Şifre Ve Kullancı Adını Kontrol Ediniz...");
                }
            }else {
                MessageBox.Show("Lütfen Alanları Doldurunuz...");
            }
        }
    }
}