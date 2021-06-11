using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_3
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RoutePermutation form = new RoutePermutation();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MultiplePermutation form = new MultiplePermutation();
            form.Show();
        }
    }
}
