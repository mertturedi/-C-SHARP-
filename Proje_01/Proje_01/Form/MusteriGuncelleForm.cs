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
    public partial class MusteriGuncelleForm : MaterialForm
    {
        public MusteriGuncelleForm()
        {
            InitializeComponent();
        }

        private void MusteriGuncelleForm_Load(object sender, EventArgs e)
        {
       
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {

            SqlConnection con;
            SqlCommand cmd, cmk;
            SqlDataReader dr;
            try
            {
                if (textBox1.Text != "")
                {

                    con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
                    cmd = new SqlCommand();
                    cmk = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmk.Connection = con;
                    cmd.CommandText = "select * from tbl_musteri where  Cari ='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        if ( textBox5.Text != "" || richTextBox1.Text != "")
                        { 
                            DialogResult durum = MessageBox.Show(textBox1.Text + " Numaralı müşteriyi güncellemek istediğinizden emin misiniz?", "Güncelleme Onayı", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == durum)
                        {
                            string cari = textBox1.Text;
                            string tel = textBox5.Text;
                            string adres = richTextBox1.Text;
                            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
                            cmd = new SqlCommand();
                            con.Open();
                            cmd.Connection = con;
                            if (textBox1.Text != "" && textBox5.Text != "" && richTextBox1.Text != "")
                            {

                            
                            cmd.CommandText = "UPDATE tbl_musteri SET Tel=@tel , Adres= @adres where Cari=@cari";
                            cmd.Parameters.AddWithValue("@cari", textBox1.Text);
                            cmd.Parameters.AddWithValue("@tel", textBox5.Text);
                            cmd.Parameters.AddWithValue("@Adres", richTextBox1.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Müşteri Güncelleme İşlemi Gerçekleşti...");
                            textBox5.Text = " ";
                            richTextBox1.Text = " ";
                            textBox1.Text = " ";

                            }
                           else if (textBox1.Text != "" && textBox5.Text != "")
                            {
                                cmd.CommandText = "UPDATE tbl_musteri SET Tel=@tel  where Cari=@cari";
                                cmd.Parameters.AddWithValue("@cari", textBox1.Text);
                                cmd.Parameters.AddWithValue("@tel", textBox5.Text);
                                cmd.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Müşteri Güncelleme İşlemi Gerçekleşti...");
                                textBox5.Text = " ";
                                richTextBox1.Text = " ";
                                textBox1.Text = " ";
                            }
                            else if(textBox1.Text != "" && richTextBox1.Text != "")
                            {
                                cmd.CommandText = "UPDATE tbl_musteri SET Adres= @adres where Cari=@cari";
                                cmd.Parameters.AddWithValue("@cari", textBox1.Text);
                                cmd.Parameters.AddWithValue("@adres", richTextBox1.Text);
                                cmd.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Müşteri Güncelleme İşlemi Gerçekleşti...");
                                textBox5.Text = " ";
                                richTextBox1.Text = " ";
                                textBox1.Text = " ";
                            }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Alanları doldurunuz...");
                        }
                       
                    } else
                        {
                            MessageBox.Show("UYUŞMAYAN BİLGİ");
                        }
                   
                }
                else
                {
                    MessageBox.Show("Cari no giriniz...");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
