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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void oTOBÜS1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (button1.Visible == true)
            {
            listBox1.Items.Add("1");
            Button btn = (sender as Button);//hangi buttuna tıklandığını öğreniyoruz.
            btn.BackColor = Color.Yellow;//Tıklanan şıkkın rengini sarı yapıyoruz
            }
            if (button1.Visible==false)
            {
                listBox1.Items.Clear();
            Button btn = (sender as Button);//hangi buttuna tıklandığını öğreniyoruz.
            btn.BackColor = Color.Red;//Tıklanan şıkkın rengini sarı yapıyoruz
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("2-");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            string NERDEN = comboBox1.Text;
            string NEREYE = comboBox2.Text;
            string KOLTUKADETİ = textBox2.Text;
            string FİYAT = textBox1.Text;
            string KALKISSAAT = comboBox3.Text;
            string KALKISGÜNÜ = monthCalendar2.Text;
            string DONUSGÜNÜ = monthCalendar1.Text;
            string KOLTUKNO = listBox1.Text;
            string BİLETNO = textBox3.Text;
            con = new SqlConnection("server=MERT-BILGISAYAR\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;

            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Lütfen ilgili alanları doldurunuz");
            }
            else
            {
                cmd.CommandText = "insert into tbl_bilet(NERDEN,NEREYE,KOLTUKADET,FİYAT,KALKISSAAT,KALKISGUNU,DONUSGUNU,KOLTUKNO,BİLETNO) values (@NERDEN,@NEREYE,@KOLTUKADETİ,@FİYAT,@KALKISSAAT,@KALKISGÜNÜ,@DONUSGÜNÜ,@KOLTUKNO,@BİLETNO  )";
                cmd.Parameters.AddWithValue("@NERDEN", comboBox1.Text);
                cmd.Parameters.AddWithValue("@NEREYE", comboBox2.Text);
                cmd.Parameters.AddWithValue("@KOLTUKADETİ", textBox2.Text);
                cmd.Parameters.AddWithValue("@FİYAT", textBox1.Text);
                cmd.Parameters.AddWithValue("@KALKISSAAT", comboBox3.Text);
                cmd.Parameters.AddWithValue("@KALKISGÜNÜ", monthCalendar2.Text);
                cmd.Parameters.AddWithValue("@DONUSGÜNÜ", monthCalendar1.Text);
                cmd.Parameters.AddWithValue("@KOLTUKNO", listBox1.Items);
                cmd.Parameters.AddWithValue("@BİLETNO", textBox3.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                Form3 biletsatis = new Form3();
                this.Hide();
                biletsatis.Show();

            }

        }
    }
}
