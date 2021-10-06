using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class register_for_new_course : Form
    {
        int id;
        int course_num = 0;
        ArrayList list = new ArrayList();
        ArrayList list2 = new ArrayList();
        public register_for_new_course(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\SVU.accdb";

                using (OleDbConnection con = new OleDbConnection(connection))
                {
                    con.Open();

         
                OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM Course", con);

                OleDbDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    if (comboBox1.Text.ToString().Equals(reader2.GetValue(1).ToString()))
                    {
                        course_num =Convert.ToInt32( reader2.GetValue(0));
                    }
                    
                    
                }
             cmd2 = new OleDbCommand("SELECT * FROM Student WHERE id="+id, con);
             bool g = false;
             reader2 = cmd2.ExecuteReader();
            string h = " ";
            while (reader2.Read())
            {
                 h=reader2.GetValue(4).ToString();
                 if (h.Contains(Convert.ToString(course_num)))
                     g = true;
            }
            h = h.Insert(h.Length,"," + course_num);
            if (g)
            {
                MessageBox.Show("Sorry You'r  Registered in this course");
            }
            else
            {
                OleDbCommand command = new OleDbCommand("UPDATE Student SET courses='" + h + "' WHERE id=" + id, con);
                command.ExecuteNonQuery();
            }


                con.Close();
            }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }           

         

        }

        private void register_for_new_course_Load(object sender, EventArgs e)
        {

            try
            {
                string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\SVU.accdb";

                using (OleDbConnection con = new OleDbConnection(connection))
                {

                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM Marks WHERE student_id=" + id, con);

                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader.GetValue(2)) >= 60)
                            list.Add(reader.GetValue(0));

                    }

                    OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM Course", con);

                    OleDbDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        int y = 0;


                        OleDbCommand cmd3 = new OleDbCommand("SELECT * FROM Register WHERE course_id=" + Convert.ToInt32(reader2.GetValue(0).ToString()), con);

                        OleDbDataReader reader3 = cmd3.ExecuteReader();
                      
                        while (reader3.Read())
                        {
                          
                            string[] words = (reader3.GetValue(1).ToString()).Split(',');
                            foreach (string word in words)
                            {
                                list2.Add(word);
                            }
                                //list2.Add(D[1]);
                                
                          //  }
                        }
                        if (list2.Count != 0)
                        {
                            //MessageBox.Show(list2.Count.ToString());
                            for (int j = 0; j < list2.Count; j++)
                            {
                                String num=list2[j].ToString();
                                for (int i = 0; i < list.Count; i++)
                                {
                                    //MessageBox.Show(reader2.GetValue(1).ToString());
                                    if (num.Equals(list[j].ToString()))
                                    {

                                        //
                                    }
                                    else
                                    {
                                        y = 1;
                                    }

                                }
                            }
                            if (y == 0)
                            {
                                this.comboBox1.Items.Add(reader2.GetValue(1).ToString());
                            }
                            list2.Clear();
                        }
                        

                    }
                    con.Close();
                }
            }
            catch (Exception df) { MessageBox.Show(df.Message.ToString()); }   
        }
    }
}
