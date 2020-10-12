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
    public partial class UrunSilForm : MaterialForm
    {
        public UrunSilForm()
        {
            InitializeComponent();
        }

        private void UrunSilForm_Load(object sender, EventArgs e)
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
                    cmd.CommandText = "select * from tbl_urun where  Barkod='" + textBox4.Text + "'";
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        DialogResult durum = MessageBox.Show(textBox4.Text + " Numaralı Ürünü silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == durum)
                        {
                            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
                            cmd = new SqlCommand();
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "Delete tbl_urun  where  Barkod='" + textBox4.Text + "'";
                            cmd.ExecuteNonQuery();
                            dr = cmd.ExecuteReader();
                            MessageBox.Show("Ürün silinmiştir. İŞLEM BAŞARILI");
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
