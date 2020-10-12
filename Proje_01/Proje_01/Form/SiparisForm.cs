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
using MaterialSkin;
using MaterialSkin.Controls;
using SortOrder = System.Windows.Forms.SortOrder;

namespace Proje_01
{
    public partial class SiparisForm : MaterialForm
    {
        public static string gonder;
        public SiparisForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        private void SiparisForm_Load(object sender, EventArgs e)
        {

            griddoldur3();
        }
        void griddoldur3()
        {


            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
            da = new SqlDataAdapter("Select  distinct MüşteriAdi,MüşteriCariNo,SiparişNo From tbl_sipariş", con);
            DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = false;
                dataGridView1.Rows[n].Cells[1].Value = item["MüşteriAdi"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["MüşteriCariNo"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["SiparişNo"].ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SiparisGoruntuleForm gecis = new SiparisGoruntuleForm();
            gecis.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string deger1 = dataGridView1.CurrentRow.Cells["SiparişNo"].Value.ToString();
            textBox1.Text = deger1;
            gonder = textBox1.Text;
       
        }



        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            
                SqlConnection con;
                SqlCommand cmk;
                SqlDataReader dr;
                con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");

                cmk = new SqlCommand();
                con.Open();

                cmk.Connection = con;


                con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");


                foreach (DataGridViewRow item in dataGridView1.Rows)
                {

               
                    if (item.Cells[0].Value != null)
                    {
                        if (bool.Parse(item.Cells[0].Value.ToString()))
                        {

                            con.Open();
                            SqlCommand cmd = new SqlCommand("Delete tbl_sipariş  where  SiparişNo='" + item.Cells[3].Value.ToString() + "'", con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Sipariş silinmiştir. İŞLEM BAŞARILI");

                    }
                    
                }
              
            }




        
           griddoldur3();
            

          






















        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SiparisGoruntuleForm gecis = new SiparisGoruntuleForm();
                gecis.Show();
            }
            else
            {
                MessageBox.Show("Lütfen Sipariş Seçiniz");
            }
           
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {

        }
    }
}

