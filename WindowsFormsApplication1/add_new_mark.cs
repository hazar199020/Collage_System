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
    public partial class add_new_mark : Form
    {
        public add_new_mark()
        {
            InitializeComponent();
        }

        private void add_new_mark_Load(object sender, EventArgs e)
        {
            string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\SVU.accdb";

            using (OleDbConnection con = new OleDbConnection(connection))
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Course", con);
                 OleDbDataReader reader = cmd.ExecuteReader();

                 while (reader.Read())
                 {
                    
                     this.comboBox1.Items.Add(reader.GetValue(1));
                 }
                

                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i=0;
            int ii=0;
            string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\SVU.accdb";

            using (OleDbConnection con = new OleDbConnection(connection))
            {
                con.Open();


                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Course", con);
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (this.comboBox1.Text.Equals(reader.GetValue(1).ToString()))
                        i = Convert.ToInt32(reader.GetValue(0));
                }
                cmd = new OleDbCommand("SELECT * FROM Student", con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (this.comboBox2.Text.Equals(reader.GetValue(1).ToString()))
                        ii = Convert.ToInt32(reader.GetValue(0));
                }

                cmd = new OleDbCommand("SELECT * FROM Marks", con);
                reader = cmd.ExecuteReader();
                int g = 0;
                while (reader.Read())
                {
                    if (i==Convert.ToInt32(reader.GetValue(0).ToString()))
                        if (ii == Convert.ToInt32(reader.GetValue(1).ToString()))
                        {
                            MessageBox.Show("This Mark Is Aleardy Been Set To The Database");
                            g = 1;
                            break;
                        }
                        
                }
                if (g == 0)
                {
                    cmd = new OleDbCommand("INSERT INTO Marks VALUES(" + i + "," + ii + "," + textBox1.Text + ",'" + textBox2.Text + "')", con);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\SVU.accdb";

            using (OleDbConnection con = new OleDbConnection(connection))
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Student", con);
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmd = new OleDbCommand("SELECT * FROM Course WHERE course_name = '" + this.comboBox1.Text.ToString() + "'", con);
                    OleDbDataReader reader2 = cmd.ExecuteReader();
                    while (reader2.Read())
                    {
                        if (reader.GetValue(4).ToString().Contains(reader2.GetValue(0).ToString()))
                        {
                            this.comboBox2.Items.Add(reader.GetValue(1));
                            break;
                        }
                    }
                }
            }
            
        }
    }
}
