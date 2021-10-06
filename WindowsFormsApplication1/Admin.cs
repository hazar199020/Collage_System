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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_new_course g = new add_new_course();
            g.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add_new_student d = new add_new_student();
            d.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reports s = new reports();
            s.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            add_new_mark d = new add_new_mark();
            d.Show();
        }
    }
}
