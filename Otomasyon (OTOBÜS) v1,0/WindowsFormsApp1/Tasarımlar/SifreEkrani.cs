using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class SifreEkrani : Form
    {
        public SifreEkrani()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        string aktKod;
        SqlConnection baglanti = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");

        private void button1_Click(object sender, EventArgs e)
        {



            try
            {

                sqlBağlanti kullanici = new sqlBağlanti();
                kullanici.Mail = textBox1.Text;

                baglanti.Open();


                string sorgu = "SELECT * FROM tbl_kullaniciKayit WHERE MAİL='" + textBox1.Text + "'";

                SqlCommand komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();
                DataTable  tablo = new DataTable();
                SqlDataAdapter adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
                adaptor.Fill(tablo);
               


                aktKod = rnd.Next(10000000, 99999999).ToString();
                if (tablo.Rows.Count > 0)
                {
                    textBox1.Text = tablo.Rows[0]["MAİL"].ToString();


                    if (kullanici.Mail == textBox1.Text)
                    {
                        MailMessage message = new MailMessage();
                        SmtpClient istemci = new SmtpClient();
                        istemci.Credentials = new NetworkCredential("iksvinfo@gmail.com", "iksvESTP34");
                        istemci.Port = 587;
                        istemci.Host = "smtp.gmail.com";
                        istemci.EnableSsl = true;
                        message.To.Add(textBox1.Text);
                        message.From = new MailAddress(textBox1.Text);
                        message.Subject = "Aktivasyon Kodu";
                        message.Body = "Aktivasyon kodunuz artık yeni şifreniz oldu   : " + aktKod;
                        istemci.Send(message);
                        MessageBox.Show("Aktivasyon kodu mail adresine gönderildi. Yönlendiriliyorsunuz ... Daha sonra şifrenizi güncellemeyi unutmayınız ...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //textBox1.Text = " ";


                        //baglanti.Open();
                       
                        //string sorgu2 = "UPDATE tbl_KullaniciKayit SET Sifre='" + aktKod + "' WHERE Email='" + kullanici.Mail + "'";
                        //SqlCommand cmd = new SqlCommand(sorgu2, baglanti);
                        //cmd.ExecuteNonQuery();
                        //baglanti.Close();
                        //KullanıcıGirişForm formLogin = new KullanıcıGirişForm();
                        //this.Hide();
                        //formLogin.Show();


                    }
                    else
                    {
                        label2.Visible = true;
                        label2.Text = "Kayıtlı Email adresi bulunamadı";
                    }

                }
                else
                {


                    label2.Visible = true;
                    label2.Text = "Kayıtlı Email adresi bulunamadı";
                }

                baglanti.Close();
                baglanti.Dispose();
            }

            catch (Exception hata)
            {
                label2.Visible = true;
                label2.Text = "Hata kodu : " + hata.Message;
            }










        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {


            sqlBağlanti kullanici = new sqlBağlanti();
            kullanici.Mail = textBox1.Text;
            if (textBox2.Text == aktKod)
            {
                SqlConnection con;
                SqlCommand cmd;
                SqlDataReader dr;

                con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT SİFRE FROM tbl_kullaniciKayit where MAİL = '" + textBox1.Text + "'";
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {


                    MessageBox.Show(dr["SİFRE"].ToString());



                }
                else
                {

                    MessageBox.Show("Lütfen alanları doğru doldurduğunuzdan emin olunuz...");
                }



            }


        }

    

        private void SifreEkrani_Load(object sender, EventArgs e)
        {

        }
    }



        //MailMessage mesajim = new MailMessage();
        //SmtpClient istemci = new SmtpClient();
        //istemci.Credentials = new System.Net.NetworkCredential("sberk291@gmail.com", "mert5261..");
        //istemci.Port = 587;
        //istemci.Host = "smtp.live.com";
        //istemci.EnableSsl = true;
        //mesajim.To.Add(textBox1.Text);
        //mesajim.From = new MailAddress ("sberk291@gmail.com");
        //mesajim.Subject = "OTOBÜS OTOMASYON";
        //mesajim.Body = listBox1.Text;






    }

