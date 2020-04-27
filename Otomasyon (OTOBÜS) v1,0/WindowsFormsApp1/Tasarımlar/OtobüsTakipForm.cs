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
    public partial class OtobüsTakipForm : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();
       
        DataSet ds = new DataSet();
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public OtobüsTakipForm()
        {
            InitializeComponent();
        }

        
        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        void griddoldur()
        {
            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=MertTT;Integrated Security=SSPI");
            da = new SqlDataAdapter("select * from tbl_OtobusKayit", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "otobüs");
            Grdoldur.DataSource = ds.Tables["otobüs"];
            con.Close();
        }

        private void OtobüsTakipForm_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 git = new Form7();
            git.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AraçSil git = new AraçSil();
            git.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aracguncelleme git = new Aracguncelleme();
            git.Show();
        }
    }
}
