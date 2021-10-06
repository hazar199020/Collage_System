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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text.ToString();
            string name = textBox2.Text.ToString();

            string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\SVU.accdb";

            using (OleDbConnection con = new OleDbConnection(connection))
            {
                con.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM Student", con);
                OleDbDataReader rt=command.ExecuteReader();
                while(rt.Read())
                {
                    if (rt.GetValue(0).ToString().Equals(id))
                    {
                        if (rt.GetValue(1).ToString().Equals(name))
                        {
                            Student f = new Student(Convert.ToInt32(id));
                            f.Show();
                        }
                    }
                }

                con.Close();
            }

            
        }
    }
}
