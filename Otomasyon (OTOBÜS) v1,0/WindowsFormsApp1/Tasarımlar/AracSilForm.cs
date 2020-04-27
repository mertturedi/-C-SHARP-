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
    public partial class AraçSil : Form
    {
        public AraçSil()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        { 
            //SqlConnection con;
            //SqlCommand cmd;
            //SqlDataReader dr;
            //string Adi = textBox1.Text;
            //string Soyadi = textBox2.Text;
            //string Mail = textBox4.Text;
            //string TelNo = textBox3.Text;
            //string TcNo = textBox8.Text;
            //con = new SqlConnection("server=MERT-BILGISAYAR\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
            //cmd = new SqlCommand();
            //con.Open();
            //cmd.Connection = con;

            //if (textBox1.Text == "" && textBox2.Text == "")
            //{
            //    MessageBox.Show("Lütfen ilgili alanları doldurunuz");
            //}
            //else {
            //cmd.CommandText = "insert into tbl_MusteriBilgi(AD,SOYAD,MAİL,TELNO,TCNO) values (@adi,@soyadi,@mail,@telno,@tcno)";
            //cmd.Parameters.AddWithValue("@adi", textBox1.Text);
            //cmd.Parameters.AddWithValue("@soyadi", textBox2.Text);
            //cmd.Parameters.AddWithValue("@mail", textBox4.Text);
            //cmd.Parameters.AddWithValue("@telno", textBox3.Text);
            //cmd.Parameters.AddWithValue("@tcno", textBox8.Text); 
            
            //cmd.ExecuteNonQuery();
            //con.Close();
            //Form3 biletsatis = new Form3();
            //this.Hide();
            //biletsatis.Show();

            //}
        
           
            
        }

        private void button21_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            SqlCommand cmd, cmk;
            SqlDataReader dr;
            try
            {
                if (textBox5.Text != "" )
                {
                 
                   
                    

                        con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
                        cmd = new SqlCommand();
                        cmk = new SqlCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmk.Connection = con;
                        cmd.CommandText = "select * from tbl_OtobusKayit where  Plaka='" + textBox5.Text + "'";
                        cmd.ExecuteNonQuery();
                        dr = cmd.ExecuteReader();
                        if (dr.Read()==true)
                        {
                         DialogResult durum = MessageBox.Show(textBox5.Text + " plakalı aracı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == durum)
                        {
                            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
                            cmd = new SqlCommand();
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "Delete tbl_OtobusKayit where  Plaka='" + textBox5.Text + "'";
                            cmd.ExecuteNonQuery();
                            dr = cmd.ExecuteReader();
                            MessageBox.Show("Araç Silinmiştir. İŞLEM BAŞARILI");
                            textBox5.Text = " ";
                        }
                    }
                        else
                        {
                            MessageBox.Show("UYUŞMAYAN BİLGİ");
                        }


                       
                        
                    
                }
                else
                {
                    MessageBox.Show("ALANLAR BOŞ");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata");
             
            }
        }
    }
}
