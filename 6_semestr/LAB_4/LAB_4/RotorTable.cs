using LAB_4.Enigma;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_4
{
    public partial class RotorTable : Form
    {
        Rotor Rotor;
        int[] Connection;
        string Alph = "";
        RotorType NewType;

        public RotorTable(Rotor rotor, string alph)
        {
            InitializeComponent();

            if (rotor.SymbolsCount != alph.Length)
                throw new Exception("Different symbols count");

            Alph = alph;

            Connection = rotor.GetInputOutputConnection();
            Rotor = rotor;
            NewType = Rotor.Type;

            for (int i = 0; i < Rotor.SymbolsCount; i++)
            {
                dataGridView1.Rows.Add($"{i} ( {Alph[i]} )", $"{Connection[i]} ( {Alph[Connection[i]]} )");
            }

            numericUpDown1.Maximum = rotor.SymbolsCount - 1;
            numericUpDown2.Maximum = rotor.SymbolsCount - 1;
            numericUpDown3.Maximum = rotor.SymbolsCount - 1;
            numericUpDown3.Value = rotor.Step;
            textBox1.Text = Rotor.Type.ToString();

            comboBox1.Items.Add(RotorType.CustomRotor);
            comboBox1.Items.Add(RotorType.RotorI);
            comboBox1.Items.Add(RotorType.RotorII);
            comboBox1.Items.Add(RotorType.RotorIII);
            comboBox1.Items.Add(RotorType.RotorIV);
            comboBox1.Items.Add(RotorType.RotorV);
            comboBox1.Items.Add(RotorType.RotorVI);
            comboBox1.Items.Add(RotorType.RotorVII);
            comboBox1.Items.Add(RotorType.RotorVIII);
            comboBox1.Items.Add(RotorType.BetaRotor);
            comboBox1.Items.Add(RotorType.GammaRotor);

            if (alph.Length != 26)
            {
                comboBox1.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                comboBox1.SelectedItem = NewType;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int key = (int)numericUpDown1.Value;
            int oldvalue = Connection[key];

            int newvalue = (int)numericUpDown2.Value;
            int anotherkey = (new List<int>(Connection)).IndexOf(newvalue);

            if(key == newvalue)
                return;

            Connection[key] = newvalue;
            Connection[anotherkey] = oldvalue;

            dataGridView1.Rows.Clear();
            for (int i = 0; i < Rotor.SymbolsCount; i++)
            {
                dataGridView1.Rows.Add($"{i} ( {Alph[i]} )", $"{Connection[i]} ( {Alph[Connection[i]]} )");
            }

            NewType = RotorType.CustomRotor;
            textBox1.Text = NewType.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rotor.SetInputOutputConnection(Connection);
            Rotor.Type = NewType;
            Rotor.Step = (int)numericUpDown3.Value;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RotorType type = (RotorType)comboBox1.SelectedItem;

            Connection = EnigmaShop.GetRotor(type).GetInputOutputConnection();
            NewType = type;

            dataGridView1.Rows.Clear();
            for (int i = 0; i < Rotor.SymbolsCount; i++)
            {
                dataGridView1.Rows.Add($"{i} ( {Alph[i]} )", $"{Connection[i]} ( {Alph[Connection[i]]} )");
            }
            textBox1.Text = NewType.ToString();
        }
    }
}
