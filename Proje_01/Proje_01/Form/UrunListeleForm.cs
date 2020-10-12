﻿using System;
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
    public partial class UrunListeleForm : MaterialForm
    {
        public UrunListeleForm()
        {
            InitializeComponent();
        }

       
        private void UrunListeleForm_Load(object sender, EventArgs e)
        {
            griddoldur();

            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM tbl_urun";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Adi"]);
            }
            baglanti.Close();
        }
       

        SqlConnection con = new SqlConnection();

        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
       
        void griddoldur()
        {

            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
            da = new SqlDataAdapter("Select * From tbl_urun", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Personel");
            dataGridView1.DataSource = ds.Tables["Personel"];
            con.Close();

        }
        void griddoldur1()
        {

            con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
            da = new SqlDataAdapter("Select * From tbl_urun where Adi = '" + comboBox1.Text + "'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Personel");
            dataGridView1.DataSource = ds.Tables["Personel"];
            con.Close();

        }

        //void combo()
        //{
        //    con = new SqlConnection("server=DESKTOP-8JE6KH6\\SQLEXPRESS; Initial Catalog=Proje_01;Integrated Security=SSPI");
        //    con.Open();
        //    da = new SqlDataAdapter("Select * From tbl_urun", con);

        //}




        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            griddoldur1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UrunEkleForm gecis = new UrunEkleForm();
            gecis.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UrunSilForm gecis = new UrunSilForm();
            gecis.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UrunGuncelleForm gecis = new UrunGuncelleForm();
            gecis.Show();
        }
    }
}
