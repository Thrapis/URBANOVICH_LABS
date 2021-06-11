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
    public partial class CommutationPanelTable : Form
    {
        CommutationPanel CommutationPanel;
        Dictionary<int, int> buffer;
        string Alph = "";

        public CommutationPanelTable(CommutationPanel commutationPanel, string alph)
        {
            InitializeComponent();

            numericUpDown1.Maximum = alph.Length - 1;
            numericUpDown2.Maximum = alph.Length - 1;
            numericUpDown3.Maximum = alph.Length - 1;

            CommutationPanel = commutationPanel;
            Alph = alph;
            buffer = CommutationPanel.GetCommutations();

            foreach (var pair in buffer)
            {
                dataGridView1.Rows.Add($"{pair.Key} ( {Alph[pair.Key]} )", $"{pair.Value} ( {Alph[pair.Value]} )");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int key_1 = (int)numericUpDown1.Value;
            int key_2 = (int)numericUpDown2.Value;

            if (!CommutationPanel.Contains(key_1) && !CommutationPanel.Contains(key_2) && key_1 != key_2)
            {
                CommutationPanel.AddCommutation(key_1, key_2);

                dataGridView1.Rows.Clear();
                buffer = CommutationPanel.GetCommutations();
                foreach (var pair in buffer)
                {
                    dataGridView1.Rows.Add($"{pair.Key} ( {Alph[pair.Key]} )", $"{pair.Value} ( {Alph[pair.Value]} )");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int key = (int)numericUpDown3.Value;

            if (CommutationPanel.Contains(key))
            {
                CommutationPanel.RemoveCommutationWith(key);

                dataGridView1.Rows.Clear();
                buffer = CommutationPanel.GetCommutations();
                foreach (var pair in buffer)
                {
                    dataGridView1.Rows.Add($"{pair.Key} ( {Alph[pair.Key]} )", $"{pair.Value} ( {Alph[pair.Value]} )");
                }
            }
        }
    }
}
