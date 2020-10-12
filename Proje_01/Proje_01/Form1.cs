using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected virtual void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            DialogResult Cikis;
            Cikis = MessageBox.Show("Program Kapatılacak Emin siniz?", "Kapatma Uyarısı!", MessageBoxButtons.YesNo);
            if (Cikis == DialogResult.Yes)
            {
                Application.Exit();
            }
            if (Cikis == DialogResult.No)
            {
                Application.Run();
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn dgvId = new DataGridViewTextBoxColumn();
            dgvId.HeaderText = "Id";
            DataGridViewTextBoxColumn dgvFn = new DataGridViewTextBoxColumn();
            dgvFn.HeaderText = "First Name";
            DataGridViewTextBoxColumn dgvLn = new DataGridViewTextBoxColumn();
            dgvLn.HeaderText = "Last Name";


            DataGridViewCheckBoxColumn dgvCheckBox = new DataGridViewCheckBoxColumn();
            dgvCheckBox.HeaderText = "Select";

            dataGridView1.Columns.Add(dgvId);
            dataGridView1.Columns.Add(dgvFn);
            dataGridView1.Columns.Add(dgvLn);
            dataGridView1.Columns.Add(dgvCheckBox);


            dataGridView1.Rows.Add("1", "First Name 1", "Last Name 1", false);
            dataGridView1.Rows.Add("2", "First Name 2", "Last Name 2", false);
            dataGridView1.Rows.Add("3", "First Name 3", "Last Name 3", false);
            dataGridView1.Rows.Add("4", "First Name 4", "Last Name 4", false);
            dataGridView1.Rows.Add("5", "First Name 5", "Last Name 5", false);
            dataGridView1.Rows.Add("6", "First Name 6", "Last Name 6", false);
            dataGridView1.Rows.Add("7", "First Name 7", "Last Name 7", false);
            dataGridView1.Rows.Add("8", "First Name 8", "Last Name 8", false);
            dataGridView1.Rows.Add("9", "First Name 9", "Last Name 9", false);
            dataGridView1.Rows.Add("10", "First Name 10", "Last Name 10", false);
            dataGridView1.Rows.Add("11", "First Name 11", "Last Name 10", false);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;

            //dataGridView2
            DataGridViewTextBoxColumn dgvcId2 = new DataGridViewTextBoxColumn();
            dgvcId2.HeaderText = "Id";
            DataGridViewTextBoxColumn dgvcFn2 = new DataGridViewTextBoxColumn();
            dgvcFn2.HeaderText = "First Name";
            DataGridViewTextBoxColumn dgvcLn2 = new DataGridViewTextBoxColumn();
            dgvcLn2.HeaderText = "Last Name";
            dataGridView2.Columns.Add(dgvcId2);
            dataGridView2.Columns.Add(dgvcFn2);
            dataGridView2.Columns.Add(dgvcLn2);
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                // rowAlreadyExist => if the row already exist on dataGridView2
                bool rowAlreadyExist = false;
                bool checkedCell = (bool)dataGridView1.Rows[i].Cells[3].Value;
                if (checkedCell == true)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];

                    // the dataGridView2 have one row or more
                    if (dataGridView2.Rows.Count != 0)
                    {
                        // loop to see if the row already exist on dataGridView2
                        for (int j = 0; j <= dataGridView2.Rows.Count - 1; j++)
                        {
                            if (row.Cells[0].Value.ToString() == dataGridView2.Rows[j].Cells[0].Value.ToString())
                            {
                                rowAlreadyExist = true;
                                break;
                            }
                        }

                        // add if the row ont exist on dataGridView2
                        if (rowAlreadyExist == false)
                        {
                            dataGridView2.Rows.Add(row.Cells[0].Value.ToString(),
                                                   row.Cells[1].Value.ToString(),
                                                   row.Cells[2].Value.ToString()
                                                   );
                        }
                    }

                    // add if the dataGridView2 have no row 
                    else
                    {
                        dataGridView2.Rows.Add(row.Cells[0].Value.ToString(),
                                                   row.Cells[1].Value.ToString(),
                                                   row.Cells[2].Value.ToString()
                                                   );
                    }
                }
            }
        }
    }
}
