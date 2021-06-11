using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //      Belski Artyom Alexandrovich Бельский Артём Александрович Бельскі Арцём Аляксандравіч
            //      Belski Artyom Alexandrovich
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = HashTable512.GetHashTable(Encoding.GetEncoding(1251), textBox2.Text);
            DateTime time1 = DateTime.Now;
            HashBox.Text = MD5.GetHash(textBox2.Text);
            DateTime time2 = DateTime.Now;
            TimeRange.Text = (time2 - time1).Milliseconds.ToString() + " ms";
        }
    }
}
