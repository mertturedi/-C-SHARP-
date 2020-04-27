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
    public partial class Aracguncelleme : Form
    {
        public Aracguncelleme()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con;
            SqlCommand cmd, cmk;
            SqlDataReader dr;
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {

                    con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
                    cmd = new SqlCommand();
                    cmk = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmk.Connection = con;
                    cmd.CommandText = "select * from tbl_OtobusKayit where  Plaka='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        DialogResult durum = MessageBox.Show(textBox1.Text + " plakalı aracı güncellemek istediğinizden emin misiniz?", "Güncelleme Onayı", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == durum)
                        {
                            string plaka = textBox1.Text;
                            string km = textBox2.Text;
                            string not = richTextBox1.Text;
                            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
                            cmd = new SqlCommand();
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "UPDATE tbl_OtobusKayit SET km=@km , Bilgi= @not where plaka=@plaka";
                            cmd.Parameters.AddWithValue("@plaka", textBox1.Text);
                            cmd.Parameters.AddWithValue("@km", textBox2.Text);
                            cmd.Parameters.AddWithValue("@not", richTextBox1.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("ARAÇ Güncelleme İşlemi Gerçekleşti...");
                            textBox2.Text = " ";
                            richTextBox1.Text = " ";
                            textBox1.Text = " ";
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