using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
   
    public partial class Student : Form
    {
        int id;
        public Student(int id)
        {
            this.id=id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            register_for_new_course h = new register_for_new_course(id);
            h.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            check_out_our_results f = new check_out_our_results(id);
            f.Show();
        }

        private void Student_Load(object sender, EventArgs e)
        {

        }
    }
}
