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
    public partial class CaesarEncode : Form
    {
        public CaesarEncode()
        {
            InitializeComponent();
        }

        public string GetCaesarTable(int key, string wordkey)
        {
            string bufdict = "";
            string dict = "";

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
                for (int i = (bufdict.Length - key) % bufdict.Length, counter = bufdict.Length;
                    counter > 0; i = (i + 1) % bufdict.Length, counter--)
                {
                    dict += bufdict[i];
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

                using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8)) {

                    string text = sr.ReadToEnd();

                    DialogResult res = MessageBox.Show("Чтобы вставить текст в первый блок, нажмите \"Да\", \"Нет\" -" +
                        " произойдёт вствка во второй блок, \"Отмена\" - отмена вставки."
                        , "Вставка текста", MessageBoxButtons.YesNoCancel);

                    if (res == DialogResult.Yes) {

                        textBox1.Text = text;
                    }
                    else if (res == DialogResult.No)
                    {
                        textBox2.Text = text;
                    }   
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int key = (int)numericUpDown1.Value;
            string wordkey = textBox3.Text;

            DateTime time1 = DateTime.Now;
            string dict = GetCaesarTable(key, wordkey);
            string alph;
            StringBuilder newtext = new StringBuilder(textBox1.Text);
            using (StreamReader sr = new StreamReader("alphabet.txt", Encoding.UTF8))
            {
                alph = sr.ReadToEnd();
            }
            for (int i = 0; i < newtext.Length; i++)
            {
                //char c = newtext[i];
                int indx = alph.IndexOf(newtext[i]);
                if (indx != -1)
                    newtext[i] = dict[indx];
            }
            DateTime time2 = DateTime.Now;
            label1.Text = (time2.Millisecond - time1.Millisecond).ToString() + " ms";

            textBox2.Text = newtext.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int key = (int)numericUpDown2.Value;
            string wordkey = textBox5.Text;

            DateTime time1 = DateTime.Now;
            string dict = GetCaesarTable(key, wordkey);
            string alph;
            StringBuilder oldtext = new StringBuilder(textBox2.Text);
            using (StreamReader sr = new StreamReader("alphabet.txt", Encoding.UTF8))
            {
                alph = sr.ReadToEnd();
            }
            for (int i = 0; i < oldtext.Length; i++)
            {
                int indx = dict.IndexOf(oldtext[i]);
                if (indx != -1)
                    oldtext[i] = alph[indx];
            }
            DateTime time2 = DateTime.Now;
            label2.Text = (time2.Millisecond - time1.Millisecond).ToString() + " ms";

            textBox4.Text = oldtext.ToString();
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
