using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Regex(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
        private void RegexArray(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int p = int.Parse(textBox4.Text);
            int q = int.Parse(textBox5.Text);
            int x = int.Parse(textBox6.Text);
            int n = int.Parse(textBox7.Text);

            BBS bbs = new BBS(p, q, x);
            textBox1.Text = "";
            for (int i = 0; i < n; i++)
            {
                int num = bbs.GetNext();
                int bit = BBS.GetLowestBit(num) == true ? 1 : 0;
                textBox1.Text += $"{num} => {bit}\r\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox8.Text);
            string keysString = textBox9.Text;
            string[] keysArray = keysString.Split(',');
            List<int> keys = new List<int>();
            foreach (string key in keysArray)
            {
                keys.Add(int.Parse(key));
            }
            RC4 rc4 = new RC4(n, keys.ToArray());
            string crypted = rc4.Crypt(textBox2.Text);
            
            using (StreamWriter sw = new StreamWriter("buf.txt"))
            {
                sw.Write(crypted);
            }
            textBox3.Text = crypted;
        }
    }
}
