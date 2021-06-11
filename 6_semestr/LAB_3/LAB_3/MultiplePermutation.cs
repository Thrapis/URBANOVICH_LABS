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
    public partial class MultiplePermutation : Form
    {
        public MultiplePermutation()
        {
            InitializeComponent();
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
        }

        string MultipleKeyPermutation(string text, string key1, string key2)
        {
            if (comboBox1.SelectedIndex == -1)
                return "";

            string alph = "";
            using (StreamReader sr = new StreamReader("alphabet.txt", Encoding.UTF8))
            {
                alph = sr.ReadToEnd();
            }

            string encoded = "";
            int[] vert = new int[key1.Length];
            int[] horiz = new int[key2.Length];

            int numberv = 1;
            int numberh = 1;
            for (int i = 0; i < alph.Length; i++)
            {
                for (int j = 0; j < key1.Length; j++)
                {
                    if (key1[j] == alph[i])
                    {
                        vert[j] = numberv;
                        numberv++;
                    }
                }
                for (int j = 0; j < key2.Length; j++)
                {
                    if (key2[j] == alph[i])
                    {
                        horiz[j] = numberh;
                        numberh++;
                    }
                }
            }

            char[,] encodeArr = new char[key1.Length, key2.Length];

            for (int i = 0; i < key1.Length; i++)
            {
                for (int j = 0; j < key2.Length; j++)
                {
                    encodeArr[i, j] = text[i * key2.Length + j];
                }
            }

            encodeArr = Additions.SortByRows(encodeArr, vert);
            encodeArr = Additions.SortByColoumns(encodeArr, horiz);

            for (int i = 0; i < key2.Length; i++)
            {
                for (int j = 0; j < key1.Length; j++)
                {
                    encoded += encodeArr[j, i];
                }
            }

            return encoded;
        }

        string MultipleKeyUnPermutation(string text, string key1, string key2)
        {
            if (comboBox2.SelectedIndex == -1)
                return "";

            string alph = "";
            using (StreamReader sr = new StreamReader("alphabet.txt", Encoding.UTF8))
            {
                alph = sr.ReadToEnd();
            }

            string encoded = "";
            int[] vert = new int[key1.Length];
            int[] horiz = new int[key2.Length];

            int numberv = 1;
            int numberh = 1;
            for (int i = 0; i < alph.Length; i++)
            {
                for (int j = 0; j < key1.Length; j++)
                {
                    if (key1[j] == alph[i])
                    {
                        vert[j] = numberv;
                        numberv++;
                    }
                }
                for (int j = 0; j < key2.Length; j++)
                {
                    if (key2[j] == alph[i])
                    {
                        horiz[j] = numberh;
                        numberh++;
                    }
                }
            }

            char[,] encodeArr = new char[key1.Length, key2.Length];

            for (int i = 0; i < key2.Length; i++)
            {
                for (int j = 0; j < key1.Length; j++)
                {
                    encodeArr[j, i] = text[i * key1.Length + j];
                }
            }

            encodeArr = Additions.RestoreByColoumns(encodeArr, horiz);
            encodeArr = Additions.RestoreByRows(encodeArr, vert);
            
            for (int i = 0; i < key1.Length; i++)
            {
                for (int j = 0; j < key2.Length; j++)
                {
                    encoded += encodeArr[i, j];
                }
            }

            return encoded;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string alph = "";
            using (StreamReader sr = new StreamReader("alphabet.txt", Encoding.UTF8))
            {
                alph = sr.ReadToEnd();
            }

            Histogram hist = new Histogram(alph, textBox1.Text);

            hist.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string alph = "";
            using (StreamReader sr = new StreamReader("alphabet.txt", Encoding.UTF8))
            {
                alph = sr.ReadToEnd();
            }

            Histogram hist = new Histogram(alph, textBox2.Text);

            hist.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string alph = "";
            using (StreamReader sr = new StreamReader("alphabet.txt", Encoding.UTF8))
            {
                alph = sr.ReadToEnd();
            }

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

        private void Encode(object sender, EventArgs e)
        {
            DateTime time1 = DateTime.Now;
            string encoded = "";
            if (comboBox1.SelectedIndex != -1)
            {
                HeightAndWidth haw = (HeightAndWidth)comboBox1.SelectedItem;
                while (textBox4.Text.Length < haw.Y)
                    textBox4.Text = textBox4.Text.Insert(textBox4.Text.Length, " ");
                while (textBox5.Text.Length < haw.X)
                    textBox5.Text = textBox5.Text.Insert(textBox5.Text.Length, " ");

                string text = textBox1.Text;
                string[] blocks = text.SplitToBlocks((BlockShape)Blocks1.SelectedItem);
                string key1 = textBox4.Text;
                string key2 = textBox5.Text;

                for (int i = 0; i < blocks.Length; i++)
                {
                    encoded += MultipleKeyPermutation(blocks[i], key1, key2);
                }
            }
            textBox2.Text = encoded;
            DateTime time2 = DateTime.Now;
            label1.Text = (time2.Millisecond - time1.Millisecond).ToString() + " ms";
        }

        private void Decode(object sender, EventArgs e)
        {
            DateTime time1 = DateTime.Now;
            string decoded = "";
            if (comboBox2.SelectedIndex != -1)
            {
                HeightAndWidth haw = (HeightAndWidth)comboBox2.SelectedItem;
                while (textBox6.Text.Length < haw.Y)
                    textBox6.Text = textBox6.Text.Insert(textBox6.Text.Length, " ");
                while (textBox7.Text.Length < haw.X)
                    textBox7.Text = textBox7.Text.Insert(textBox7.Text.Length, " ");

                string text = textBox2.Text;
                string[] blocks = text.SplitToBlocks((BlockShape)Blocks2.SelectedItem);
                string key1 = textBox6.Text;
                string key2 = textBox7.Text;

                for (int i = 0; i < blocks.Length; i++)
                {
                    decoded += MultipleKeyUnPermutation(blocks[i], key1, key2);
                }
            }
            textBox3.Text = decoded;
            DateTime time2 = DateTime.Now;
            label2.Text = (time2.Millisecond - time1.Millisecond).ToString() + " ms";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Blocks1.Items.Clear();
            List<BlockShape> list = BlockShape.GetCombinations(textBox1.Text.Length, 1);
            Blocks1.Items.AddRange(list.ToArray());
            if (Blocks1.Items.Count > 0)
            {
                Blocks1.SelectedIndex = 0;
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
                comboBox1.Items.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Blocks2.Items.Clear();
            List<BlockShape> list = BlockShape.GetCombinations(textBox2.Text.Length, 1);
            Blocks2.Items.AddRange(list.ToArray());
            if (Blocks2.Items.Count > 0)
            {
                Blocks2.SelectedIndex = 0;
                comboBox2.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = false;
                comboBox2.Items.Clear();
            }
        }

        private void Blocks1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            List<HeightAndWidth> list = HeightAndWidth.GetCombinations(((BlockShape)Blocks1.SelectedItem).Size, 1);
            comboBox1.Items.AddRange(list.ToArray());
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            else
            {
                textBox4.Enabled = false;
                textBox5.Enabled = false;
            }
        }

        private void Blocks2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            List<HeightAndWidth> list = HeightAndWidth.GetCombinations(((BlockShape)Blocks2.SelectedItem).Size, 1);
            comboBox2.Items.AddRange(list.ToArray());
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
            else
            {
                textBox6.Enabled = false;
                textBox7.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                textBox4.Enabled = true;
                textBox5.Enabled = true;

                HeightAndWidth haw = (HeightAndWidth)comboBox1.SelectedItem;
                textBox4.MaxLength = haw.Y;
                textBox5.MaxLength = haw.X;

                if (textBox4.Text.Length > haw.Y)
                    textBox4.Text = textBox4.Text.Substring(0, haw.Y);
                if (textBox5.Text.Length > haw.X)
                    textBox5.Text = textBox5.Text.Substring(0, haw.X);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                textBox6.Enabled = true;
                textBox7.Enabled = true;

                HeightAndWidth haw = (HeightAndWidth)comboBox2.SelectedItem;
                textBox6.MaxLength = haw.Y;
                textBox7.MaxLength = haw.X;

                if (textBox6.Text.Length > haw.Y)
                    textBox6.Text = textBox6.Text.Substring(0, haw.Y);
                if (textBox7.Text.Length > haw.X)
                    textBox7.Text = textBox7.Text.Substring(0, haw.X);
            }
        }
    }
}
