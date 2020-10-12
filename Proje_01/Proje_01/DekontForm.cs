using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Proje_01
{
    public partial class DekontForm : Form
    {
        public DekontForm()
        {
            InitializeComponent();
        }




        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                MailMessage message = new MailMessage();
                SmtpClient istemci = new SmtpClient();
                istemci.Credentials = new NetworkCredential("iksvinfo@gmail.com", "iksvESTP34");
                istemci.Port = 587;
                istemci.Host = "smtp.gmail.com";
                istemci.EnableSsl = true;
                message.To.Add(label1.Text);
                message.From = new MailAddress(label1.Text);
                message.Subject = "E-FATURA";
                message.Body = "Müşteri Adı   : " + label15.Text + "\n" + "Müşteri Cari No    :" + label14.Text + "\n" + " Toplam Ürün Miktarı   :" + label11.Text + "\n" + "Toplam Fiyat    :" + label10.Text;
                istemci.Send(message);
                MessageBox.Show("Dekont Gönderildi...");
                güncelle();
            }
            else
            {
                MessageBox.Show("Lütfen Mail Adresi Giriniz...");
            }
        }

        private void DekontForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = SiparisForm.gonder;
            griddoldur1();
            labeldoldur();
            griddoldur2();
        }
        void griddoldur1()
        {


            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
            da = new SqlDataAdapter("Select MüşteriAdi,MüşteriCariNo,SUM(ToplamFiyat) AS Fiyat ,COUNT(ÜrünAdi) AS ÜRÜNADET from tbl_sipariş where siparişNo =  '" + textBox1.Text + "' group by MüşteriAdi,MüşteriCariNo ", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Personel");
            dataGridView1.DataSource = ds.Tables["Personel"];
            con.Close();

        }
        void griddoldur2()
        {


            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
            da = new SqlDataAdapter("Select Mail,Tel from tbl_musteri where Cari =  '" + label14.Text + "'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Personel");
            dataGridView2.DataSource = ds.Tables["Personel"];
            con.Close();
            string deger4 = dataGridView2.CurrentRow.Cells["Mail"].Value.ToString();
            label1.Text = deger4;
            string deger5 = dataGridView2.CurrentRow.Cells["Tel"].Value.ToString();
            label2.Text = deger5;

        }
        void labeldoldur()
        {

            if (textBox1.Text != "")
            {
                string deger1 = dataGridView1.CurrentRow.Cells["MüşteriAdi"].Value.ToString();
                label15.Text = deger1;
                string deger2 = dataGridView1.CurrentRow.Cells["MüşteriCariNo"].Value.ToString();
                label14.Text = deger2;
                string deger3 = dataGridView1.CurrentRow.Cells["Fiyat"].Value.ToString();
                label10.Text = deger3;
                string deger4 = dataGridView1.CurrentRow.Cells["ÜRÜNADET"].Value.ToString();
                label11.Text = deger4;
            }



        }
        void güncelle (){

            con.Open();
            SqlCommand cmd = new SqlCommand("Delete tbl_sipariş  where  SiparişNo='" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("İŞLEM BAŞARILI");

        }
    }
}
