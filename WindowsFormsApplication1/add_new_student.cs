using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class add_new_student : Form
    {
        public add_new_student()
        {
            InitializeComponent();
        }

        private void add_new_student_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\SVU.accdb";

                using (OleDbConnection con = new OleDbConnection(connection))
                {
                    con.Open();
                    OleDbCommand command = new OleDbCommand("INSERT INTO Student VALUES(" + Convert.ToInt32(this.textBox1.Text.ToString()) + ",'" + this.textBox2.Text.ToString() + "','"+this.dateTimePicker1.Text.ToString()+"','"+ this.textBox3.Text.ToString() +"','1,2,3,4')", con);
                    command.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }
    }
}
