using MathNet.Numerics.LinearAlgebra;
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
        }
        int[] Array;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string text = Info.Text;
            Array = text.GetBinaries();
            var sizes = BinaryAdditions.GetCombinations(Array.Length);
            Combinations.Items.Clear();
            Combinations.Items.AddRange(sizes.ToArray());
            if (sizes.Count > 0)
                Combinations.SelectedIndex = 0;
            else
                Combinations.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selection = Combinations.SelectedIndex;
            var haw = (HeightAndWidth)Combinations.Items[selection];
            Matrix<double> matrix = Array.ToMatrix(haw.X, haw.Y);
            //Matrix<double> matrixPlus = matrix.GetMatrixWithParities();
            AddParities ap = AddParities.Null;
            if (checkBox1.Checked)
                ap |= AddParities.DiagonalFromTopLeft;
            if (checkBox2.Checked)
                ap |= AddParities.DiagonalFromBottomLeft;

            MatrixWithParities matrixPlus = matrix.GetMatrixWithParities(ap);

            GenMatrix.Text = "";
            DTL.Text = "";
            DBL.Text = "";

            GenMatrix.Text = matrixPlus.Matrix.ToStringPlus();
            Block.Text = matrixPlus.GetInfoBlock().ToArrayString();
            if (matrixPlus.DiagonalTopLeft != null)
            {
                DTL.Text = matrixPlus.DiagonalTopLeft.ToArrayString();
            }
            if (matrixPlus.DiagonalBottomLeft != null)
            {
                DBL.Text = matrixPlus.DiagonalBottomLeft.ToArrayString();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string bin = "";
            byte[] binBytes = Encoding.GetEncoding(1251).GetBytes(text);
            for (int i = 0; i < binBytes.Length; i++)
            {
                bin += Convert.ToString(binBytes[i], 2).PadLeft(8, '0');
            }
            Info.Text = bin;
        }
    }
}
