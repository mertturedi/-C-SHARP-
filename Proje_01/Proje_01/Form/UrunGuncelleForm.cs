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
    public partial class UrunGuncelleForm : MaterialForm
    {
        public UrunGuncelleForm()
        {
            InitializeComponent();
        }

        private void UrunGuncelleForm_Load(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            SqlCommand cmd, cmk;
            SqlDataReader dr;
            try
            {
                if (textBox4.Text != "")
                {
                    
                    con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
                    cmd = new SqlCommand();
                    cmk = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmk.Connection = con;
                    cmd.CommandText = "select * from tbl_urun where  Barkod ='" + textBox4.Text + "'";
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.Read() == true)
                    {

                        if (textBox6.Text != "" || textBox5.Text != "" || richTextBox1.Text != "")
                        {

                        
                        DialogResult durum = MessageBox.Show(textBox4.Text + " Numaralı ürünü güncellemek istediğinizden emin misiniz?", "Güncelleme Onayı", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == durum)
                        {
                            string barkod = textBox4.Text;
                            string miktar = textBox6.Text;
                            string fiyat = textBox5.Text;
                            string bilgi = richTextBox1.Text;
                            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
                            cmd = new SqlCommand();
                            con.Open();
                            cmd.Connection = con;


                           
                            if (textBox4.Text != "" && textBox6.Text != "" && textBox5.Text != "" && richTextBox1.Text != "")
                            {


                                cmd.CommandText = "UPDATE tbl_urun SET Mikar=@miktar , Fiyat= @fiyat, Bilgi=@bilgi where Barkod=@barkod";
                                cmd.Parameters.AddWithValue("@barkod", textBox4.Text);
                                cmd.Parameters.AddWithValue("@fiyat", textBox5.Text);
                                cmd.Parameters.AddWithValue("@miktar", textBox6.Text);
                                cmd.Parameters.AddWithValue("@bilgi", richTextBox1.Text);
                                cmd.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Ürün Güncelleme İşlemi Gerçekleşti...");
                                textBox5.Text = " ";
                                richTextBox1.Text = " ";
                                textBox6.Text = " ";
                                textBox4.Text = " ";


                            }
                            else if (textBox4.Text != "" && textBox6.Text != "")
                            {
                                cmd.CommandText = "UPDATE tbl_urun SET Mikar=@miktar where Barkod=@barkod";
                                cmd.Parameters.AddWithValue("@barkod", textBox4.Text);
                                cmd.Parameters.AddWithValue("@miktar", textBox6.Text);
                                cmd.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Ürün Güncelleme İşlemi Gerçekleşti...");
                                textBox5.Text = " ";
                                richTextBox1.Text = " ";
                                textBox6.Text = " ";
                                textBox4.Text = " ";
                            }
                            else if(textBox4.Text != "" && textBox5.Text != "")
                            {
                                cmd.CommandText = "UPDATE tbl_urun SET Fiyat=@fiyat where Barkod=@barkod";
                                cmd.Parameters.AddWithValue("@barkod", textBox4.Text);
                                cmd.Parameters.AddWithValue("@fiyat", textBox5.Text);
                                cmd.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Ürün Güncelleme İşlemi Gerçekleşti...");
                                textBox5.Text = " ";
                                richTextBox1.Text = " ";
                                textBox6.Text = " ";
                                textBox4.Text = " ";
                            }
                            else
                            {
                                cmd.CommandText = "UPDATE tbl_urun SET Bilgi=@bilgi where Barkod=@barkod";
                                cmd.Parameters.AddWithValue("@barkod", textBox4.Text);
                                cmd.Parameters.AddWithValue("@bilgi", richTextBox1.Text);
                                cmd.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Ürün Güncelleme İşlemi Gerçekleşti...");
                                textBox5.Text = " ";
                                richTextBox1.Text = " ";
                                textBox6.Text = " ";
                                textBox4.Text = " ";
                            }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Alanları Doldurunuz...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("UYUŞMAYAN BİLGİ");
                    }
                }
                else
                {
                    MessageBox.Show("Barkod Numarasını Giriniz");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);

            }
        }
    }
}
