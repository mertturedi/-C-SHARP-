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
    public partial class KullanıcıKayıtForm : Form
    {
        public KullanıcıKayıtForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void KullanıcıKayıtForm_Load(object sender, EventArgs e)
        {
            rastgele();
        }
        void rastgele()
        {
             Random rastgele = new Random();
           // int sayi = rastgele.Next();
            int sayi = rastgele.Next(100, 10000);
            textBox9.Text = sayi.ToString();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            
            
           
            try
            {
               
                if (textBox1.Text != "" || comboBox1.Text != "" || textBox2.Text != "" || textBox4.Text != "" || textBox5.Text != "" || textBox3.Text != "" || textBox6.Text != "" || textBox8.Text != "")
                {
                    if (textBox5.Text==textBox7.Text)
                    {
                      
                    SqlConnection con;
                    SqlCommand cmd;
                    SqlDataReader dr;
                    string Adi = textBox1.Text;
                    string Soyadi = textBox2.Text;
                    string Mail = textBox4.Text;
                    string TelNo = textBox3.Text;
                    string TcNo = textBox8.Text;
                    string Kadi = textBox6.Text;
                    string Sifre = textBox5.Text;
                    string Kyetki = comboBox1.Text;
                    string kno = textBox9.Text;
                    con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
                    cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tbl_kullaniciKayit(AD,SOYAD,MAİL,TELNO,TCNO,KADI,SİFRE,KYETKİ,KNO) values (@adi,@soyadi,@mail,@telno,@tcno,@kadi,@sifre,@kyetki,@kno)";
                    cmd.Parameters.AddWithValue("@adi", textBox1.Text);
                    cmd.Parameters.AddWithValue("@soyadi", textBox2.Text);
                    cmd.Parameters.AddWithValue("@mail", textBox4.Text);
                    cmd.Parameters.AddWithValue("@telno", textBox3.Text);
                    cmd.Parameters.AddWithValue("@tcno", textBox8.Text);
                    cmd.Parameters.AddWithValue("@kadi", textBox6.Text);
                    cmd.Parameters.AddWithValue("@sifre", textBox5.Text);
                    cmd.Parameters.AddWithValue("@kyetki", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@kno", textBox9.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kullanıcı Kayıt İşlemi Gerçekleşmiştir...");
                    textBox1.Text = "";
                    comboBox1.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox3.Text = "";
                    textBox6.Text = "";
                    textBox8.Text = "";
                    textBox7.Text = "";
                    textBox9.Text = "";
                        rastgele();
                    }
                    else
                    {
                        MessageBox.Show("Şifre alanını kontrol ediniz...");
                    }
                   
                }
                else
                {
                    MessageBox.Show("Alanları doldurunuz...");
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
