﻿using Proje_02.ContextVeri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MusteriDbContext context = new MusteriDbContext())
            {
                context.Database.Create();
                MessageBox.Show("BAŞARILI");
            }
        }
    }
}
