using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_7_REAL
{
    public partial class EncryptionInfo : Form
    {
        BackpackEncryptor BackpackEncryptor;
        public EncryptionInfo(BackpackEncryptor backpackEncryptor)
        {
            InitializeComponent();
            BackpackEncryptor = backpackEncryptor;

            numericUpDown1.Maximum = backpackEncryptor.ClosedKey.Length - 1;

            Update();
        }

        private void Update()
        {
            textBox2.Text = BackpackEncryptor.A.ToString();
            textBox3.Text = BackpackEncryptor.AR.ToString();
            textBox4.Text = BackpackEncryptor.Modulus.ToString();
            textBox1.Text = BackpackEncryptor.Type.ToString();

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            for (int i = 0; i < BackpackEncryptor.ClosedKey.Length; i++)
            {
                dataGridView1.Rows.Add(i, BackpackEncryptor.ClosedKey[i]);
            }
            for (int i = 0; i < BackpackEncryptor.OpenKey.Length; i++)
            {
                dataGridView2.Rows.Add(i, BackpackEncryptor.OpenKey[i]);
            }
        }

        private void Regex(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = (int)numericUpDown1.Value;
            BigInteger value = BigInteger.Parse(textBox5.Text);
            BackpackEncryptor.SetClosedKeyValue(index, value);
            textBox5.Text = "";

            if (numericUpDown1.Value != numericUpDown1.Maximum)
                numericUpDown1.Value += 1;
            Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BigInteger value = BigInteger.Parse(textBox7.Text);
            BackpackEncryptor.SetA(value);

            Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BackpackEncryptor.RegenerateAR();

            Update();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BigInteger value = BigInteger.Parse(textBox9.Text);
            BackpackEncryptor.SetModulus(value);

            Update();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            BackpackEncryptor.RegenerateOpenKey();

            Update();
        }
    }
}
