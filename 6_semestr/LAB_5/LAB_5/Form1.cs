using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add(DESType.DES);
            comboBox1.Items.Add(DESType.DES_EEE2);
            comboBox1.Items.Add(DESType.DES_EDE2);
            comboBox1.Items.Add(DESType.DES_EEE3);
            comboBox1.Items.Add(DESType.DES_EDE3);
            comboBox1.SelectedItem = DESType.DES_EDE3;

            //Console.WriteLine(DES.FromBinaryToHex(DES.ToBinaryOctoplets("Hello Nigga")));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text;
            DESType selectedType = (DESType)comboBox1.SelectedItem;
            if (selectedType == DESType.DES)
            {
                if (Key1.Text.Length == 8)
                {
                    string keyplus = Key1.Text;
                    textBox2.Text = DES.Encrypt(selectedType, message, keyplus);
                }
            }
            else if (selectedType == DESType.DES_EDE2 || selectedType == DESType.DES_EEE2)
            {
                if (Key1.Text.Length == 8 && Key2.Text.Length == 8)
                {
                    string[] keyplus = { Key1.Text, Key2.Text };
                    textBox2.Text = DES.Encrypt(selectedType, message, keyplus);
                }
            }
            else if (selectedType == DESType.DES_EDE3 || selectedType == DESType.DES_EEE3)
            {
                if (Key1.Text.Length == 8 && Key2.Text.Length == 8 && Key3.Text.Length == 8)
                {
                    string[] keyplus = { Key1.Text, Key2.Text, Key3.Text };
                    textBox2.Text = DES.Encrypt(selectedType, message, keyplus);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string encryption = DES.ToText(textBox2.Text);
            DESType selectedType = (DESType)comboBox1.SelectedItem;
            if (selectedType == DESType.DES)
            {
                if (Key1.Text.Length == 8)
                {
                    string keyplus = Key1.Text;
                    textBox3.Text = DES.Decrypt(selectedType, encryption, keyplus);
                }
            }
            else if (selectedType == DESType.DES_EDE2 || selectedType == DESType.DES_EEE2)
            {
                if (Key1.Text.Length == 8 && Key2.Text.Length == 8)
                {
                    string[] keyplus = { Key1.Text, Key2.Text };
                    textBox3.Text = DES.Decrypt(selectedType, encryption, keyplus);
                }
            }
            else if (selectedType == DESType.DES_EDE3 || selectedType == DESType.DES_EEE3)
            {
                if (Key1.Text.Length == 8 && Key2.Text.Length == 8 && Key3.Text.Length == 8)
                {
                    string[] keyplus = { Key1.Text, Key2.Text, Key3.Text };
                    textBox3.Text = DES.Decrypt(selectedType, encryption, keyplus);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 7)
            {
                string key7byte = textBox6.Text;
                string safeKey = DES.KeyToSafeKey(key7byte);
                textBox7.Text = safeKey;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DESType)comboBox1.SelectedItem == DESType.DES)
            {
                Key2.Enabled = false;
                Key3.Enabled = false;
            }
            else if ((DESType)comboBox1.SelectedItem == DESType.DES_EDE2 || (DESType)comboBox1.SelectedItem == DESType.DES_EEE2)
            {
                Key2.Enabled = true;
                Key3.Enabled = false;
            }
            else if ((DESType)comboBox1.SelectedItem == DESType.DES_EDE3 || (DESType)comboBox1.SelectedItem == DESType.DES_EEE3)
            {
                Key2.Enabled = true;
                Key3.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Key1.Text = textBox7.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Key2.Text = textBox7.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Key3.Text = textBox7.Text;
        }
    }
}
