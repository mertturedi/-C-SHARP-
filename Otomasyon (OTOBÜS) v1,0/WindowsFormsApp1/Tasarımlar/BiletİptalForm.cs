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
    public partial class Biletİptal : Form
    {
        public Biletİptal()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            SqlCommand cmd, cmk;
            SqlDataReader dr;
            try
            {
                if (textBox5.Text != "" && textBox4.Text != "")
                {
                    con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
                    cmd = new SqlCommand();
                    cmk = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmk.Connection = con;
                    cmd.CommandText = "select * from tbl_biletersatis where  TcNo='" + textBox5.Text + "' AND KoltukNo='" + textBox4.Text + "'";
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        DialogResult durum = MessageBox.Show(textBox4.Text + "numaralı koltuğu silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == durum)
                        {
                            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
                            cmd = new SqlCommand();
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "Delete tbl_BileterSatis where  TcNo='" + textBox5.Text + "' AND KoltukNo='" + textBox4.Text + "'";
                            cmd.ExecuteNonQuery();
                            dr = cmd.ExecuteReader();
                            MessageBox.Show("Bilet Silinmiştir. İŞLEM BAŞARILI");
                            textBox5.Text = " ";
                            textBox4.Text = " ";
                        }
                    }
                    else
                    {
                        MessageBox.Show("UYUŞMAYAN BİLGİ");
                    }





                }
                else
                {
                    MessageBox.Show("LÜTFEN TÜM ALANLARI DOLU OLUP OLMADIĞINI KONTROL EDİNİZ... ");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata(YANLIŞ BİLGİ)");

            }
        }
    }
}
