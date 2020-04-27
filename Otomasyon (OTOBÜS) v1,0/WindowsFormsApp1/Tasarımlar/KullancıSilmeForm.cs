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
    public partial class KayıtSilmeForm : Form
    {
        public KayıtSilmeForm()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
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
                    cmd.CommandText = "select * from tbl_kullaniciKayit where  KADI='" + textBox1.Text + "' AND TCNO='" + textBox2.Text + "'";
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        DialogResult durum = MessageBox.Show(textBox1.Text + " adlı kullanıcıyı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == durum)
                        {
                            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
                            cmd = new SqlCommand();
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "Delete tbl_kullaniciKayit where  KADI='" + textBox1.Text + "' AND TCNO='" + textBox2.Text + "'";
                            cmd.ExecuteNonQuery();
                            dr = cmd.ExecuteReader();
                            MessageBox.Show("kullanıcı silinmiştir. İŞLEM BAŞARILI");
                            textBox1.Text = " ";
                            textBox2.Text = " ";
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
    




private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}
    }
}