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
using System.Net;
using System.Net.Mail;

namespace Proje_01
{

    public partial class UrunSatForm : MaterialForm 
    {
        public UrunSatForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();


    
        private void UrunSatForm_Load(object sender, EventArgs e)
        {

           
            textBox3.Text = SiparisGoruntuleForm.gonder1;
            if (textBox3.Text != "")
            {
               
                griddoldur5();
                griddoldur4();
                combobox();
                cari();
                griddoldur();
                griddoldur2();
                string deger5 = dataGridView3.CurrentRow.Cells["MüşteriCariNo"].Value.ToString();
                comboBox2.Text = deger5;



            }
            else
            {

                combobox();
                cari();
                griddoldur4();
                string deger8 = dataGridView4.CurrentRow.Cells["SiparişNo"].Value.ToString();
                textBox5.Text = deger8;
                int sy5 = 0;
                int sy6 = 1;
                int toplam = 0;
                sy5 = Convert.ToInt32(textBox5.Text);
                toplam = sy5 + sy6;
                textBox5.Text = toplam.ToString();
                siparişNo();
            }
          
        }
        void combobox()
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM tbl_urun";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Adi"]);
            }
            baglanti.Close();
        }
        void cari()
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM tbl_musteri";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["Cari"]);
            }
            baglanti.Close();
        }
        void griddoldur()
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "")
            {
                con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
                da = new SqlDataAdapter("Select * From tbl_urun where Adi = '" + comboBox1.Text + "'", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Personel");
                dataGridView1.DataSource = ds.Tables["Personel"];
                con.Close();
            }
        }
        void griddoldur2()
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "")
            {
                con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
                da = new SqlDataAdapter("Select * From tbl_musteri where Cari = '" + comboBox2.Text + "'", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Personel");
                dataGridView2.DataSource = ds.Tables["Personel"];
                con.Close();
            }
        }
        void griddoldur3()
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "")
            {
                con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
                da = new SqlDataAdapter("Select * From tbl_sipariş where SiparişNo = '" + textBox5.Text + "'", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Personel");
                dataGridView3.DataSource = ds.Tables["Personel"];
                con.Close();
            }
        }
        void griddoldur5()
        {
            
                con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
                da = new SqlDataAdapter("Select * From tbl_sipariş where SiparişNo = '" + textBox3.Text + "'", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Personel");
                dataGridView3.DataSource = ds.Tables["Personel"];
                con.Close();
            textBox5.Text = textBox3.Text;

        }
        void griddoldur4()
        {

                
                con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
                da = new SqlDataAdapter(" SELECT TOP 1 SiparişNo FROM tbl_Sipariş ORDER BY SiparişNo DESC ", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Personel");
                dataGridView4.DataSource = ds.Tables["Personel"];
                con.Close();
              

        }

        void getir()
        {
            string deger1 = dataGridView1.CurrentRow.Cells["Fiyat"].Value.ToString();
            textBox2.Text = deger1;
            string deger2 = dataGridView1.CurrentRow.Cells["Adi"].Value.ToString();
            label13.Text = deger2;
            string deger3 = dataGridView1.CurrentRow.Cells["Barkod"].Value.ToString();
            label12.Text = deger3;
            string deger4 = dataGridView2.CurrentRow.Cells["Adi"].Value.ToString();
            label15.Text = deger4;
            string deger5 = dataGridView2.CurrentRow.Cells["Cari"].Value.ToString();
            label14.Text = deger5;
            string deger6 = dataGridView1.CurrentRow.Cells["Mikar"].Value.ToString();
            label16.Text = deger6;
            //string deger7 = dataGridView2.CurrentRow.Cells["Mail"].Value.ToString();
            //textBox3.Text = deger7;
            
        }
        //void güncelle()
        //{
        //    if (textBox4.Text != "")
        //    {
        //        SqlConnection con;
        //        SqlCommand cmd, cmk;
        //        SqlDataReader dr;
        //        con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
        //        cmd = new SqlCommand();
        //        con.Open();
        //        cmd.Connection = con;
        //        cmd.CommandText = "UPDATE tbl_urun SET Mikar=@miktar  where Barkod=@barkod";
        //        cmd.Parameters.AddWithValue("@miktar", textBox4.Text);
        //        cmd.Parameters.AddWithValue("@barkod", label12.Text);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        MessageBox.Show("Sipariş Alındı...");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Lütfen Alanları Doldurunuz...");
        //    }






        //}
        void ListeKayit() {



            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;

            string MusteriAdi = label15.Text;
            string MüşteriCariNo = label14.Text;
            string ÜrünAdi = label13.Text;
            string ÜrünMiktari = label11.Text;
            string ToplamFiyat = label10.Text;
            string SiparişNo = textBox5.Text;

            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into tbl_sipariş(MüşteriAdi,MüşteriCariNo,ÜrünAdi,ÜrünMiktari,ToplamFiyat,SiparişNo) values (@MusteriAdi,@MüşteriCariNo,@ÜrünAdi,@ÜrünMiktari,@ToplamFiyat,@SiparişNo)";
            cmd.Parameters.AddWithValue("@MusteriAdi", label15.Text);
            cmd.Parameters.AddWithValue("@MüşteriCariNo", label14.Text);
            cmd.Parameters.AddWithValue("@ÜrünAdi", label13.Text);
            cmd.Parameters.AddWithValue("@ÜrünMiktari", label11.Text);
            cmd.Parameters.AddWithValue("@ToplamFiyat", label10.Text);
            cmd.Parameters.AddWithValue("@SiparişNo", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
           // MessageBox.Show("Kayıt İşlemi Gerçekleşti...");



        }
        void siparişNo() {

            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
            da = new SqlDataAdapter(" SELECT TOP 1 MüşteriCariNo FROM tbl_Sipariş ORDER BY ID DESC ", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Personel");
            dataGridView5.DataSource = ds.Tables["Personel"];
            con.Close();
            string deger9 = dataGridView5.CurrentRow.Cells["MüşteriCariNo"].Value.ToString();
            textBox6.Text = deger9;
           



        }


        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                griddoldur();
                griddoldur2();
                getir();
                double sy1 = 0;
                double sy2 = 0;
                double toplam;
                sy1 = Convert.ToInt32(textBox1.Text);
                sy2 = Convert.ToDouble(textBox2.Text);
                toplam = sy1 * sy2;
                label10.Text = toplam.ToString();

                label11.Text = textBox1.Text;


                int sy3 = 0;
                int sy4 = 0;
                int sonuç = 0;
                sy3 = Convert.ToInt32(label16.Text);
                sy4 = Convert.ToInt32(label11.Text);
                sonuç = sy3 - sy4;
                textBox4.Text = sonuç.ToString();
                ListeKayit();

                griddoldur3();
              
            }
            else
            {
                if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "")
                {
                    if (textBox6.Text != comboBox2.Text)
                    {
                        int sy5 = 0;
                        int sy6 = 1;
                        int toplamm = 0;
                        sy5 = Convert.ToInt32(textBox5.Text);
                        toplamm = sy5 + sy6;
                        textBox5.Text = toplamm.ToString();
                    }
                    griddoldur();
                    griddoldur2();
                    getir();

                    double sy1 = 0;
                    double sy2 = 0;
                    double toplam;
                    sy1 = Convert.ToInt32(textBox1.Text);
                    sy2 = Convert.ToDouble(textBox2.Text);
                    toplam = sy1 * sy2;
                    label10.Text = toplam.ToString();

                    label11.Text = textBox1.Text;


                    int sy3 = 0;
                    int sy4 = 0;
                    int sonuç = 0;
                    sy3 = Convert.ToInt32(label16.Text);
                    sy4 = Convert.ToInt32(label11.Text);
                    sonuç = sy3 - sy4;
                    textBox4.Text = sonuç.ToString();
                    ListeKayit();

                    griddoldur3();
                    siparişNo();

                }


                else
                {
                    MessageBox.Show("Lütfen Alanları Doldurunuz...");
                }


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            SiparisForm gecis = new SiparisForm();
            gecis.Show();
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {


            //if (textBox3.Text != "")
            //{
            //MailMessage message = new MailMessage();
            //SmtpClient istemci = new SmtpClient();
            //istemci.Credentials = new NetworkCredential("iksvinfo@gmail.com", "iksvESTP34");
            //istemci.Port = 587;
            //istemci.Host = "smtp.gmail.com";
            //istemci.EnableSsl = true;
            //message.To.Add(textBox3.Text);
            //message.From = new MailAddress(textBox3.Text);
            //message.Subject = "E-FATURA";
            //message.Body = "Müşteri Adı   : " + label15.Text + "\n" + "Müşteri Cari No    :" + label14.Text + "\n" + "Ürün Adı    :" + label13.Text + "\n" + "Ürün Barkod    :" + label12.Text + "\n" + "Ürün Miktarı   :" + label11.Text + "\n" + "Toplam Fiyat    :" + label10.Text;
            //istemci.Send(message);
            //MessageBox.Show("Dekont Gönderildi...");
            //}
            //else
            //{
            //    MessageBox.Show("Lütfen Mail Adresi Giriniz...");
            //}

           




















        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton3_Click_1(object sender, EventArgs e)
        {
       
        }
    }
}
