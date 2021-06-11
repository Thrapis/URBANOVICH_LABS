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
    public partial class SetValue : Form
    {
        Form1 Form;
        int RotorIndex;
        string Alph = "";
        public SetValue(int rotorindex, int curval, string alph, Form1 form)
        {
            InitializeComponent();

            Alph = alph;
            numericUpDown1.Maximum = alph.Length - 1;
            numericUpDown1.Value = curval;
            Form = form;
            RotorIndex = rotorindex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form.SetRotorPosition(RotorIndex, (int)numericUpDown1.Value);
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = Alph[(int)numericUpDown1.Value].ToString();
        }
    }
}
