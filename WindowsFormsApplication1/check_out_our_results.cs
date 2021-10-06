using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;
using System.Web;


namespace WindowsFormsApplication1
{
    public partial class check_out_our_results : Form
    {
        int id=0;
        public check_out_our_results(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void check_out_our_results_Load(object sender, EventArgs e)
        {

            string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\SVU.accdb";
            OleDbConnection con = new OleDbConnection(connection);

            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Marks WHERE student_id="+id, con);

            OleDbDataReader reader = cmd.ExecuteReader();
            string h = " ";
            while (reader.Read())
            {
                
                OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM Course", con);

                OleDbDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    
                    if (Convert.ToUInt32(reader2.GetValue(0)) == Convert.ToInt32( reader.GetValue(0)))
                        h = reader2.GetValue(1).ToString();
                }

                if ((Convert.ToUInt32(reader.GetValue(2))) >= 50)
                {
                    this.dataGridView1.Rows.Add(reader.GetValue(0), h, reader.GetValue(2), "successed");
                }
                else
                {
                    this.dataGridView1.Rows.Add(reader.GetValue(0), h, reader.GetValue(2), "Failed");
                }
            }
                con.Close();

            }
        
    }
}
