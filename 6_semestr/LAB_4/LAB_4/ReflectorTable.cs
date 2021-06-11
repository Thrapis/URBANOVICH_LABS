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
    public partial class ReflectorTable : Form
    {
        Reflector Reflector;
        Dictionary<int, int> Connection;
        ReflectorType NewType;
        string Alph = "";

        public ReflectorTable(Reflector reflector, string alph)
        {
            InitializeComponent();

            if (reflector.SymbolsCount != alph.Length)
                throw new Exception("Different symbols count");

            Alph = alph;

            Connection = reflector.GetConnection();
            Reflector = reflector;
            NewType = Reflector.Type;

            for (int i = 0; i < Reflector.SymbolsCount; i++)
            {
                dataGridView1.Rows.Add($"{i} ( {Alph[i]} )", $"{Connection[i]} ( {Alph[Connection[i]]} )");
            }

            numericUpDown1.Maximum = reflector.SymbolsCount - 1;
            numericUpDown2.Maximum = reflector.SymbolsCount - 1;
            textBox1.Text = Reflector.Type.ToString();

            comboBox1.Items.Add(ReflectorType.CustomReflector);
            comboBox1.Items.Add(ReflectorType.ReflectorB);
            comboBox1.Items.Add(ReflectorType.ReflectorC);
            comboBox1.Items.Add(ReflectorType.ReflectorBDunn);
            comboBox1.Items.Add(ReflectorType.ReflectorCDunn);

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
            int anotherkey = Connection[newvalue];

            if (key == newvalue)
                return;

            Connection[key] = newvalue;
            Connection[newvalue] = key;
            Connection[anotherkey] = oldvalue;
            Connection[oldvalue] = anotherkey;

            dataGridView1.Rows.Clear();
            for (int i = 0; i < Reflector.SymbolsCount; i++)
            {
                dataGridView1.Rows.Add($"{i} ( {Alph[i]} )", $"{Connection[i]} ( {Alph[Connection[i]]} )");
            }

            NewType = ReflectorType.CustomReflector;
            textBox1.Text = NewType.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reflector.SetConnection(Connection);
            Reflector.Type = NewType;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReflectorType type = (ReflectorType)comboBox1.SelectedItem;

            Connection = EnigmaShop.GetReflector(type).GetConnection();
            NewType = type;

            dataGridView1.Rows.Clear();
            for (int i = 0; i < Reflector.SymbolsCount; i++)
            {
                dataGridView1.Rows.Add($"{i} ( {Alph[i]} )", $"{Connection[i]} ( {Alph[Connection[i]]} )");
            }
            textBox1.Text = NewType.ToString();
        }
    }
}
