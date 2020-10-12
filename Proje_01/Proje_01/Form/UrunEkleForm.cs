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
    public partial class UrunEkleForm : MaterialForm
    {
        public UrunEkleForm()
        {
            InitializeComponent();
        }

        private void UrunEkleForm_Load(object sender, EventArgs e)
        {

        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox7.Text != "" && richTextBox1.Text != "")
                {
                    SqlConnection con;
                    SqlCommand cmd;
                    SqlDataReader dr;

                    string Adi = textBox7.Text;
                    string Miktarı = textBox6.Text;
                    string Fiyati = textBox5.Text;
                    string Barkod = textBox4.Text;
                    string Bilgi = richTextBox1.Text;

                    con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
                    cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tbl_urun(Adi,Mikar,Fiyat,Barkod,Bilgi) values (@Adi,@Miktarı,@Fiyati,@Barkod,@Bilgi)";
                    cmd.Parameters.AddWithValue("@Miktarı", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Barkod", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Fiyati", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Adi", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Bilgi", richTextBox1.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Ürün Kayıt İşlemi Gerçekleşti...");
                    textBox5.Text = " ";
                    textBox4.Text = " ";
                    textBox7.Text = " ";
                    textBox6.Text = " ";
                    richTextBox1.Text = " ";


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
