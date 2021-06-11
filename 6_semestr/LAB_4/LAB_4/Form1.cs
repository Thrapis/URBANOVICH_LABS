using LAB_4.Enigma;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_4
{
    public partial class Form1 : Form
    {
        EnigmaMachine Enigma;
        List<Rotor> Rotors;
        string Alph = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Rotor> rotors = new List<Rotor>();
            rotors.Add(EnigmaShop.GetRotor(RotorType.RotorI, 1));
            rotors.Add(EnigmaShop.GetRotor(RotorType.RotorVII, 0));
            rotors.Add(EnigmaShop.GetRotor(RotorType.RotorIII, 1));

            Reflector reflector = EnigmaShop.GetReflector(ReflectorType.ReflectorBDunn);

            Enigma = new EnigmaMachine(Alph.ToArray(), rotors, reflector);


            Rotors = Enigma.GetRotors();

            label1.Text = Rotors[0].GetRotorPosition().ToString();
            label2.Text = Rotors[1].GetRotorPosition().ToString();
            label3.Text = Rotors[2].GetRotorPosition().ToString();

            for (int i = 0; i < Alph.Length; i++)
            {
                dataGridView1.Rows.Add(i, Alph[i].ToString());
            }
        }

        public void SetRotorPosition(int index, int position)
        {
            Rotors[index].SetRotorPosition(position);
            label1.Text = Rotors[0].GetRotorPosition().ToString();
            label2.Text = Rotors[1].GetRotorPosition().ToString();
            label3.Text = Rotors[2].GetRotorPosition().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RotorTable rt = new RotorTable(Enigma.GetRotors()[0], Alph);
            rt.ShowDialog();

            var res = rt.DialogResult;
            label1.Text = Rotors[0].GetRotorPosition().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RotorTable rt = new RotorTable(Enigma.GetRotors()[1], Alph);
            rt.ShowDialog();

            var res = rt.DialogResult;
            label2.Text = Rotors[1].GetRotorPosition().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RotorTable rt = new RotorTable(Enigma.GetRotors()[2], Alph);
            rt.ShowDialog();

            var res = rt.DialogResult;
            label3.Text = Rotors[2].GetRotorPosition().ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReflectorTable rt = new ReflectorTable(Enigma.GetReflector(), Alph);
            rt.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            char symbol = e.KeyChar;

            if (Alph.Contains(symbol))
            {
                textBox2.Text += Enigma.NewClickTheButton(symbol);
                textBox1.Text += symbol;
            }
            else if (Char.IsControl(symbol))
            {
                if (symbol == '\b' && textBox1.Text.Length > 0)
                {
                    Enigma.NewRollBackRotors();
                    if (textBox2.Text.Length > 0)
                        textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
                    e.Handled = false;
                }
            }
            textBox1.SelectionStart = textBox1.Text.Length;

            label1.Text = Rotors[0].GetRotorPosition().ToString();
            label2.Text = Rotors[1].GetRotorPosition().ToString();
            label3.Text = Rotors[2].GetRotorPosition().ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetValue sv = new SetValue(0, Rotors[0].GetRotorPosition(), Alph, this);
            sv.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetValue sv = new SetValue(1, Rotors[1].GetRotorPosition(), Alph, this);
            sv.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SetValue sv = new SetValue(2, Rotors[2].GetRotorPosition(), Alph, this);
            sv.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TextBuffer tb = new TextBuffer(textBox2.Text);
            tb.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Текстовый файл | *.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;

                using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
                {

                    string readedText = sr.ReadToEnd();

                    for (int i = 0; i < readedText.Length; i++)
                    {
                        textBox2.Text += Enigma.NewClickTheButton(readedText[i]);
                        textBox1.Text += readedText[i];
                    }
                }
            }

            label1.Text = Rotors[0].GetRotorPosition().ToString();
            label2.Text = Rotors[1].GetRotorPosition().ToString();
            label3.Text = Rotors[2].GetRotorPosition().ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Текстовый файл | *.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string fileName = sfd.FileName;

                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8))
                {
                    sw.Write(textBox2.Text);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            CommutationPanelTable cpt = new CommutationPanelTable(Enigma.GetCommutationPanel(), Alph);
            cpt.ShowDialog();
        }
    }
}
