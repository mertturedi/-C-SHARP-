using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {


            try
            {
                if (textBox1.Text != "" || comboBox1.Text != "" || textBox2.Text != "" || textBox4.Text != "" || textBox5.Text != "" || textBox6.Text != "" || richTextBox1.Text != "")
                {
                    SqlConnection con;
                    SqlCommand cmd;
                    SqlDataReader dr;
                    string markası = textBox1.Text;
                    string modeli = textBox2.Text;
                    string yakıttürü = comboBox1.Text;
                    string km = textBox4.Text;
                    string koltuksayisi = textBox5.Text;
                    string plaka = textBox6.Text;
                    string Bilgi = richTextBox1.Text;
                    con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
                    cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tbl_OtobusKayit(Marka,Model,YakitTürü,Km,Koltuksayisi,Plaka,Bilgi) values (@markası,@modeli,@yakıttürü,@km,@koltuksayisi,@plaka,@Bilgi)";
                    cmd.Parameters.AddWithValue("@markası", textBox1.Text);
                    cmd.Parameters.AddWithValue("@modeli", textBox2.Text);
                    cmd.Parameters.AddWithValue("@yakıttürü", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@km", textBox4.Text);
                    cmd.Parameters.AddWithValue("@koltuksayisi", textBox5.Text);
                    cmd.Parameters.AddWithValue("@plaka", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Bilgi", richTextBox1.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ARAÇ Kayıt İşlemi Gerçekleşti...");
                    textBox5.Text = " ";
                    textBox4.Text = " ";
                    textBox6.Text = " ";
                    textBox2.Text = " ";
                    comboBox1.Text = " ";
                    richTextBox1.Text = " ";
                    textBox1.Text = " ";

                }
                else
                {
                    MessageBox.Show("lütfen Boş Alanları Doldurunuz...");
                }
            
            }
            catch (Exception)
            {
                MessageBox.Show("HATA...");
                throw;
            }

          
        }
    }
}
