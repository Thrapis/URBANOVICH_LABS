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

namespace LAB_3
{
    public partial class RoutePermutation : Form
    {
        public RoutePermutation()
        {
            InitializeComponent();
        }

        string SpiralPermutation(string text)
        {
            if (comboBox1.SelectedIndex == -1)
                return "";

            int textLen = text.Length;
            HeightAndWidth haw = (HeightAndWidth)comboBox1.SelectedItem;
            string encodedText = "";
            char[,] table = new char[haw.Y, haw.X];
            bool[,] btable = new bool[haw.Y, haw.X];
            
            for (int i = 0; i < haw.Y; i++)
            {
                for (int j = 0; j < haw.X; j++)
                {
                    table[i, j] = text[i * haw.X + j];
                }
            }

            int counter = 0;
            int ik = 1;
            int jk = 0;
            bool changeSide = false;
            for (int i = 0, j = 0; counter < textLen; i += ik, j += jk, counter++)
            {
                encodedText += table[i, j];
                btable[i, j] = true;

                if (i + ik >= haw.Y || i + ik < 0 || j + jk >= haw.X || j + jk < 0)
                    changeSide = true;
                else if (btable[i + ik, j + jk] == true)
                    changeSide = true;

                if (changeSide)
                {
                    if (ik == 1 && jk == 0)
                    {
                        ik = 0;
                        jk = 1;
                    }
                    else if (ik == 0 && jk == 1)
                    {
                        ik = -1;
                        jk = 0;
                    }
                    else if (ik == -1 && jk == 0)
                    {
                        ik = 0;
                        jk = -1;
                    }
                    else if (ik == 0 && jk == -1)
                    {
                        ik = 1;
                        jk = 0;
                    }
                    changeSide = false;
                }
                
            }

            return encodedText;
        }

        string SpiralUnPermutation(string text)
        {
            if (comboBox2.SelectedIndex == -1)
                return "";

            int textLen = text.Length;
            HeightAndWidth haw = (HeightAndWidth)comboBox2.SelectedItem;
            string encodedText = "";
            char[,] table = new char[haw.Y, haw.X];
            bool[,] btable = new bool[haw.Y, haw.X];


            int counter = 0;
            int ik = 1;
            int jk = 0;
            bool changeSide = false;
            for (int i = 0, j = 0; counter < textLen; i += ik, j += jk, counter++)
            {
                table[i, j] = text[counter];
                btable[i, j] = true;

                if (i + ik >= haw.Y || i + ik < 0 || j + jk >= haw.X || j + jk < 0)
                    changeSide = true;
                else if (btable[i + ik, j + jk] == true)
                    changeSide = true;

                if (changeSide)
                {
                    if (ik == 1 && jk == 0)
                    {
                        ik = 0;
                        jk = 1;
                    }
                    else if (ik == 0 && jk == 1)
                    {
                        ik = -1;
                        jk = 0;
                    }
                    else if (ik == -1 && jk == 0)
                    {
                        ik = 0;
                        jk = -1;
                    }
                    else if (ik == 0 && jk == -1)
                    {
                        ik = 1;
                        jk = 0;
                    }
                    changeSide = false;
                }
            }

            for (int i = 0; i < haw.Y; i++)
            {
                for (int j = 0; j < haw.X; j++)
                {
                    encodedText += table[i, j];
                }
            }

            return encodedText;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string alph = new string(textBox1.Text.Distinct<char>().ToArray());

            Histogram hist = new Histogram(alph, textBox1.Text);

            hist.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string alph = new string(textBox2.Text.Distinct<char>().ToArray());

            Histogram hist = new Histogram(alph, textBox2.Text);

            hist.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string alph = new string(textBox3.Text.Distinct<char>().ToArray());

            Histogram hist = new Histogram(alph, textBox3.Text);

            hist.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Текстовый файл | *.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;

                using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
                {

                    string text = sr.ReadToEnd();

                    DialogResult res = MessageBox.Show("Чтобы вставить текст в первый блок, нажмите \"Да\", \"Нет\" -" +
                        " произойдёт вствка во второй блок, \"Отмена\" - отмена вставки."
                        , "Вставка текста", MessageBoxButtons.YesNoCancel);

                    if (res == DialogResult.Yes)
                    {

                        textBox1.Text = text;
                    }
                    else if (res == DialogResult.No)
                    {
                        textBox2.Text = text;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Текстовый файл | *.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string fileName = sfd.FileName;

                using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8))
                {
                    sw.Write(textBox2.Text);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Текстовый файл | *.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string fileName = sfd.FileName;

                using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8))
                {
                    sw.Write(textBox3.Text);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            List<HeightAndWidth> list = HeightAndWidth.GetCombinations(textBox1.Text.Length, 2);
            comboBox1.Items.AddRange(list.ToArray());
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            List<HeightAndWidth> list = HeightAndWidth.GetCombinations(textBox2.Text.Length, 2);
            comboBox2.Items.AddRange(list.ToArray());
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime time1 = DateTime.Now;
            textBox2.Text = SpiralPermutation(textBox1.Text);
            DateTime time2 = DateTime.Now;
            label1.Text = (time2.Millisecond - time1.Millisecond).ToString() + " ms";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime time1 = DateTime.Now;
            textBox3.Text = SpiralUnPermutation(textBox2.Text);
            DateTime time2 = DateTime.Now;
            label2.Text = (time2.Millisecond - time1.Millisecond).ToString() + " ms";
        }
    }
}
