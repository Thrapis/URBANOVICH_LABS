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

namespace LAB_2
{
    public partial class Form1 : Form
    {
        private string file = "";
        private string alfabet = "";
        private double entr;
        private double entrb;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSF_Click(object sender, EventArgs e)
        {
            var form = new OpenFileDialog();
            if (form.ShowDialog() == DialogResult.OK)
            {
                file = File.ReadAllText(form.FileName);

                checkBoxF.Checked = true;
            }
            else
            {
                checkBoxF.Checked = false;
            }
            CalcEntropy();
            CalcEntropyBin();
        }

        private void buttonAF_Click(object sender, EventArgs e)
        {
            var form = new OpenFileDialog();
            if (form.ShowDialog() == DialogResult.OK)
            {
                alfabet = File.ReadAllText(form.FileName);

                alfabet = String.Join("", alfabet.Distinct());
                checkBoA.Checked = true;
            }
            else
            {
                checkBoA.Checked = false;
            }
            CalcEntropy();
        }

        private void CalcEntropy()
        {
            double entrCh = 0;
            if (checkBoA.Checked)
            {
                entrCh = Math.Log(alfabet.Length, 2);
                textBoxEnCh.Text = entrCh.ToString();
            }
            if (checkBoA.Checked && checkBoxF.Checked)
            {
                var dict = new Dictionary<char, int>();
                foreach (char c in alfabet.Concat(file.Distinct()).Distinct())
                {
                    dict.Add(c, 0);
                }
                foreach (char c in file)
                {
                    dict[c]++;
                }
                double n = file.Length;
                entr = 0d;
                this.chart1.Series[0].Points.Clear();
                foreach (var kv in dict)
                {

                    this.chart1.Series[0].Points.AddXY(kv.Key, kv.Value);
                    if (kv.Value != 0)
                    {
                        entr += (kv.Value / n) * Math.Log(kv.Value / n, 2);
                    }
                }
                entr *= -1;
                textBoxEn.Text = entr.ToString();
                double R = (1 - entr / entrCh) * 100;
                textBoxR.Text = Math.Round(R, 4).ToString();
            }


        }

        private void CalcEntropyBin()
        {
            if (checkBoxF.Checked)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(file);
                double _1 = 0;
                foreach (var b in bytes)
                {
                    _1 += Convert.ToString(b, 2).Count(x => x == '1');
                }
                this.chart2.Series[0].Points.Clear();
                double n = bytes.Length * 8;
                this.chart2.Series[0].Points.AddXY(0, n - _1);
                this.chart2.Series[0].Points.AddXY(1, _1);
                entrb = (_1 / n) * Math.Log(_1 / n, 2) + ((n - _1) / n) * Math.Log((n - _1) / n, 2);
                entrb *= -1;
                textBoxEB.Text = entrb.ToString();
            }
        }

        private void textBoxFIO_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFIO.TextLength > 0 || entr != 0 || entrb != 0)
            {
                textBoxT.Text = Convert.ToString(entr * textBoxFIO.TextLength);
                textBoxA.Text = Convert.ToString(entrb * textBoxFIO.TextLength * 8);
                double n = textBoxFIO.TextLength;
                double p = 0.1d;
                double h = 1 - (-p * Math.Log(p, 2) - (1 - p) * Math.Log((1 - p), 2));
                textBoxP01.Text = Convert.ToString(h * n * 8);
                p = 0.5d;
                h = 1 - (-p * Math.Log(p, 2) - (1 - p) * Math.Log((1 - p), 2));
                textBoxP05.Text = Convert.ToString(h * n * 8);
                p = 1d;
                h = 1 - (-p * Math.Log(p, 2) - (1 - p) * Math.Log((1 - p), 2));
                if (double.IsNaN(h))
                {
                    h = 1;
                }
                textBoxP1.Text = Convert.ToString(h * n * 8);
            }
        }
    }
}
