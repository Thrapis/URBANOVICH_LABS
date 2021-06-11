using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int EuclidsAlgorithmOfTwo(int a, int b)
        {
            int q = 0;
            int r = 0;

            do
            {
                if (a > b)
                {
                    q = a / b;
                    r = a - b * q;
                    textBox2.Text += a + " = " + b + " * " + q + " + " + r + "\r\n";
                    if (r == 0)
                        return b;
                    a = r;
                }
                else
                {
                    q = b / a;
                    r = b - a * q;
                    textBox2.Text += b + " = " + a + " * " + q + " + " + r + "\r\n";
                    if (r == 0)
                        return a;
                    b = r;
                }
            } while (r != 0);
            return a;
        }

        public void Erathosphen()
        {
            int under_value = (int)numericUpDown4.Value;

            List<int> list = new List<int>();
            List<int> deletetions = new List<int>();
            for (int i = 2; i < under_value; i++)
            {
                list.Add(i);
            }

            for (int i = 2; i < under_value; i++)
            {
                if (list.Contains(i))
                {
                    deletetions.Clear();
                    foreach (int val in list)
                    {
                        if (val % i == 0 && i < val)
                        {
                            deletetions.Add(val);
                        }
                    }
                    foreach (var val in deletetions)
                    {
                        list.Remove(val);
                    }
                } 
            }

            int from = (int)numericUpDown5.Value;
            textBox3.Text = "";
            foreach (int val in list)
            {
                if (from <= val)
                    textBox3.Text += val.ToString() + " ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            if (radioButton1.Checked)
                textBox1.Text = EuclidsAlgorithmOfTwo(
                    (int)numericUpDown1.Value, (int)numericUpDown2.Value).ToString();
            if (radioButton2.Checked)
            {
                int ab_nod = EuclidsAlgorithmOfTwo(
                    (int)numericUpDown1.Value, (int)numericUpDown2.Value);
                textBox2.Text += "-----------------\r\n";
                textBox1.Text = EuclidsAlgorithmOfTwo(
                    ab_nod, (int)numericUpDown3.Value).ToString();
            }
                
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown3.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Erathosphen();
        }
    }
}
