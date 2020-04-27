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
using System.Data;
using System.Data.OleDb;
using System.Data.Common;


namespace WindowsFormsApp1
{
    public partial class BiletSatForm : Form
    {
       
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string[] koltuklar = new string[11];
        public BiletSatForm()
        {

            
            InitializeComponent();
        }
        private void Koltuk_kontrol()

        {
            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
            con.Open();
            cmd.CommandText = "Select koltuk1,koltuk2,koltuk3,koltuk4,koltuk5,koltuk6,koltuk7,koltuk8,koltuk9,koltuk10 from Tbl_Koltuk";
            dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                koltuklar[0] = dr[0].ToString();
                koltuklar[1] = dr[1].ToString();
                koltuklar[2] = dr[2].ToString();
                koltuklar[3] = dr[3].ToString();
                koltuklar[4] = dr[4].ToString();
                koltuklar[5] = dr[5].ToString();
                koltuklar[6] = dr[6].ToString();
                koltuklar[7] = dr[7].ToString();
                koltuklar[8] = dr[8].ToString();
                koltuklar[9] = dr[9].ToString();
                koltuklar[10] = dr[10].ToString();
                if (koltuklar[0] == "Dolu")
                {
                    checkBox1.Checked = true;
                    checkBox1.BackColor = Color.Red;
                }
                if (koltuklar[1] == "Dolu")
                {
                    checkBox2.Checked = true;
                    checkBox2.BackColor = Color.Red;
                }
                if (koltuklar[2] == "Dolu")
                {
                    checkBox3.Checked = true;
                    checkBox3.BackColor = Color.Red;
                }
                if (koltuklar[3] == "Dolu")
                {
                    checkBox4.Checked = true;
                    checkBox4.BackColor = Color.Red;
                }
                if (koltuklar[4] == "Dolu")
                {
                    checkBox5.Checked = true;
                    checkBox5.BackColor = Color.Red;
                }

                if (koltuklar[5] == "Dolu")
                {
                    checkBox6.Checked = true;
                    checkBox6.BackColor = Color.Red;
                }
                if (koltuklar[6] == "Dolu")
                {
                    checkBox7.Checked = true;
                    checkBox7.BackColor = Color.Red;
                }
                if (koltuklar[7] == "Dolu")
                {
                    checkBox8.Checked = true;
                    checkBox8.BackColor = Color.Red;
                }
                if (koltuklar[8] == "Dolu")
                {
                    checkBox9.Checked = true;
                    checkBox9.BackColor = Color.Red;
                }
                if (koltuklar[9] == "Dolu")
                {
                    checkBox10.Checked = true;
                    checkBox10.BackColor = Color.Red;
                }
            }
            dr.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            try
            {

                #region kodlar
                if (textBox1.Text != "" || textBox3.Text != "" || textBox4.Text != "" || textBox10.Text != "" || comboBox5.Text != "" ||  comboBox1.Text != "" || comboBox2.Text != "" || comboBox3.Text != "" || comboBox4.Text != "")
                {


                   
                    string AdiSoyadi = textBox1.Text;
                    string cinsiyet = comboBox4.Text;
                    string TcNo = textBox3.Text;
                    string TelNo = textBox4.Text;
                    string kangrubu = comboBox5.Text;
                    string koltukno = comboBox2.Text;
                    string Biletsatıştarihi = dateTimePicker1.Text;
                    string Otobüskalkişyeri = comboBox1.Text;
                    string OtobüsVarışYeri = comboBox3.Text;
                    string BiletFiyati = textBox10.Text;
                    con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
                    cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tbl_BileterSatis(AdıSoyadı,Cinsiyet,TcNo,TelNo,KanGrubu,KoltukNo,Tarih,KalkışYeri,VarışYeri,BiletFiyati) values (@AdiSoyadi,@cinsiyet,@TcNo,@TelNo,@kangrubu,@koltukno,@Biletsatıştarihi,@Otobüskalkişyeri,@OtobüsVarışYeri,@BiletFiyati)";
                    cmd.Parameters.AddWithValue("@AdiSoyadi", textBox1.Text);
                    cmd.Parameters.AddWithValue("@cinsiyet", comboBox4.Text);
                    cmd.Parameters.AddWithValue("@TcNo", textBox3.Text);
                    cmd.Parameters.AddWithValue("@TelNo", textBox4.Text);
                    cmd.Parameters.AddWithValue("@kangrubu", comboBox5.Text);
                    cmd.Parameters.AddWithValue("@koltukno", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@Biletsatıştarihi", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@Otobüskalkişyeri", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@OtobüsVarışYeri", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@BiletFiyati", textBox10.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                   // MessageBox.Show("Müşteri Kayıt İşlemi Gerçekleşti.");







                    //       baglanti.Close();
                    label12.Text = "kayıt Altına Alınmıstır";
                    label12.ForeColor = Color.Green;
                    griddoldur();
                }

                else
                {

                    //MessageBox.Show("Lütfen  boş alanları doldurunuz!!..");
                    label12.Text = "Hata !!";
                    label12.ForeColor = Color.Red;

                }
                #endregion
            }
            catch (Exception rr)
            {

                MessageBox.Show("hata" + rr.Message);
            }
        }

        void griddoldur()
        {
            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
            da = new SqlDataAdapter("Select * From tbl_BileterSatis", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "kayıtlar");
            Grdoldur.DataSource = ds.Tables["kayıtlar"];
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();

            Color[] c = { Color.SeaShell, Color.WhiteSmoke, Color.Red };

            label13.BackColor = c[rand.Next(2, c.Length)];

            {

                label13.Text = label13.Text.Substring(1) + label13.Text.Substring(0, 1);

            }
        }

        private void BiletSatForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            griddoldur();
            // checkBox10.BackColor = Color.Red;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Koltuk_kontrol();
        }
    }
}
