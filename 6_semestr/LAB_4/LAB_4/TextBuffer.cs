using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_4
{
    public partial class TextBuffer : Form
    {
        public TextBuffer(string text)
        {
            InitializeComponent();
            textBox1.Text = text;
        }
    }
}
