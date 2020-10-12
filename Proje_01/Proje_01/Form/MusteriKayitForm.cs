using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using System.Data.SqlClient;

namespace Proje_01
{
    public partial class MusteriKayitForm : MaterialForm
    {
        public MusteriKayitForm()
        {
            InitializeComponent();
        }

        private void MusteriKayitForm_Load(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox7.Text != "" && richTextBox1.Text != "")
                {
                    SqlConnection con;
                    SqlCommand cmd;
                    SqlDataReader dr;

                    string Adi = textBox7.Text;
                    string Soyadi = textBox2.Text;
                    string Tel = textBox5.Text;
                    string Mail = textBox4.Text;
                    string Cari = textBox1.Text;
                    string Adres = richTextBox1.Text;

                    con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
                    cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tbl_musteri(Adi,Soyadi,Tel,Mail,Cari,Adres) values (@Adi,@Soyadi,@Tel,@Mail,@Cari,@Adres)";
                    cmd.Parameters.AddWithValue("@Cari", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Soyadi", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Mail", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Tel", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Adi", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Adres", richTextBox1.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Müşteri Kayıt İşlemi Gerçekleşti...");
                    textBox5.Text = " ";
                    textBox4.Text = " ";
                    textBox7.Text = " ";
                    textBox2.Text = " ";
                    richTextBox1.Text = " ";
                    textBox1.Text = " ";

                }
                else
                {
                    MessageBox.Show("lütfen Boş Alanları Doldurunuz...");
                }

            }
            catch (Exception hata)
            {

                MessageBox.Show("HATA...");

            }










        }
    }
}
