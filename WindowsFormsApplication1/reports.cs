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
    public partial class reports : Form
    {
        public reports()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int su = 0;
            int fa = 0;
            try
            {
                string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\SVU.accdb";
                
                using (OleDbConnection con = new OleDbConnection(connection))
                {
                    con.Open();
                    OleDbCommand command = new OleDbCommand("SELECT * FROM Course", con);

                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        if (reader.GetValue(1).Equals(this.comboBox1.Text.ToString()))
                        {


                            OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM Marks WHERE course_id=" + Convert.ToInt32(reader.GetValue(0)), con);

                OleDbDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    if(Convert.ToInt32(reader2.GetValue(2))>=50)
                        su++;
                    else
                        fa++;
                        }
                    }
                    con.Close();
                }

            }
            }
            catch (Exception ee)
            { 
                //MessageBox.Show(ee.Message); 
            }
   
            this.richTextBox1.Text="The Number Of Failed Students Is "+fa+"And The Number Of Successed Students Is "+su;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void reports_Load(object sender, EventArgs e)
        {
            string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\SVU.accdb";
            OleDbConnection con = new OleDbConnection(connection);

            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Course", con);

            OleDbDataReader reader = cmd.ExecuteReader();
            //string h = " ";
            while (reader.Read())
            {
                this.comboBox1.Items.Add(reader.GetValue(1));
            }
            con.Close();
        }
    }
}
