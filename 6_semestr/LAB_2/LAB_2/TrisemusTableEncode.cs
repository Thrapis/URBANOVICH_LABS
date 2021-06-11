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
    public partial class TrisemusTableEncode : Form
    {
        public TrisemusTableEncode()
        {
            InitializeComponent();

            string alph;

            using (StreamReader sr = new StreamReader("alphabet.txt", Encoding.UTF8))
            {
                alph = sr.ReadToEnd();
            }

            comboBox1.Items.AddRange(HeightAndWidth.GetCombinations(alph.Length).ToArray());
            comboBox2.Items.AddRange(HeightAndWidth.GetCombinations(alph.Length).ToArray());
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        public char[,] GetTrisemusTable(HeightAndWidth haw, string wordkey)
        {
            string bufdict = "";
            char[,] dict = new char[haw.Y, haw.X];

            using (StreamReader sr = new StreamReader("alphabet.txt", Encoding.UTF8))
            {
                string alph = sr.ReadToEnd();

                for (int i = 0; i < wordkey.Length; i++)
                {
                    if (!bufdict.Contains(wordkey[i]))
                    {
                        bufdict += wordkey[i];
                    }
                }
                for (int i = 0; i < alph.Length; i++)
                {
                    if (!bufdict.Contains(alph[i]))
                    {
                        bufdict += alph[i];
                    }
                }
            }

            for (int i = 0; i < dict.GetLength(0); i++)
            {
                for (int j = 0; j < dict.GetLength(1); j++)
                {
                    dict[i, j] = bufdict[i * dict.GetLength(1) + j];
                }
            }

            return dict;
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

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Текстовый файл | *.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string fileName = sfd.FileName;

                using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8))
                {
                    sw.Write(textBox4.Text);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HeightAndWidth haw = (HeightAndWidth)comboBox1.SelectedItem;
            string wordkey = textBox3.Text;

            DateTime time1 = DateTime.Now;
            char[,] dict = GetTrisemusTable(haw, wordkey);
            StringBuilder newtext = new StringBuilder(textBox1.Text);
            for (int i = 0; i < newtext.Length; i++)
            {
                bool next = true;
                for (int y = 0; y < dict.GetLength(0) && next; y++)
                {
                    for (int x = 0; x < dict.GetLength(1) && next; x++)
                    {
                        if (dict[y, x] == newtext[i])
                        {
                            newtext[i] = dict[(y + 1) % dict.GetLength(0), x];
                            next = false;
                        }
                    }
                }
            }
            DateTime time2 = DateTime.Now;

            label1.Text = (time2.Millisecond - time1.Millisecond).ToString() + " ms";
            //textBox2.Text = "";
            //for (int y = 0; y < dict.GetLength(0); y++)
            //{
            //    for (int x = 0; x < dict.GetLength(1); x++)
            //    {
            //        textBox2.Text += dict[y, x] + " ";
            //    }
            //    textBox2.Text += "\r\n";
            //}

            textBox2.Text = newtext.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HeightAndWidth haw = (HeightAndWidth)comboBox2.SelectedItem;
            string wordkey = textBox5.Text;

            DateTime time1 = DateTime.Now;
            char[,] dict = GetTrisemusTable(haw, wordkey);
            StringBuilder oldtext = new StringBuilder(textBox2.Text);
            for (int i = 0; i < oldtext.Length; i++)
            {
                bool next = true;
                for (int y = 0; y < dict.GetLength(0) && next; y++)
                {
                    for (int x = 0; x < dict.GetLength(1) && next; x++)
                    {
                        if (dict[y, x] == oldtext[i])
                        {
                            int intoindex = y - 1;
                            if (intoindex < 0)
                                intoindex += dict.GetLength(0);
                            oldtext[i] = dict[intoindex, x];
                            next = false;
                        }
                    }
                }
            }
            DateTime time2 = DateTime.Now;
            label2.Text = (time2.Millisecond - time1.Millisecond).ToString() + " ms";

            textBox4.Text = oldtext.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string alph;
            using (StreamReader sr = new StreamReader("alphabet.txt", Encoding.UTF8))
            {
                alph = sr.ReadToEnd();
            }

            Histogram hist = new Histogram(alph, textBox1.Text);

            hist.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string alph;
            using (StreamReader sr = new StreamReader("alphabet.txt", Encoding.UTF8))
            {
                alph = sr.ReadToEnd();
            }

            Histogram hist = new Histogram(alph, textBox2.Text);

            hist.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string alph;
            using (StreamReader sr = new StreamReader("alphabet.txt", Encoding.UTF8))
            {
                alph = sr.ReadToEnd();
            }

            Histogram hist = new Histogram(alph, textBox4.Text);

            hist.Show();
        }
    }
}
