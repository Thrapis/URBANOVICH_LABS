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

namespace LAB_11
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            //ECEquationMod equation = new ECEquationMod(4, 1, 7);
            //ECPoint p1 = new ECPoint(0, 6);
            //ECPoint p2 = new ECPoint(4, 5);
            //Console.WriteLine( equation.ECMult(p2, 5));

            /*ECEquationMod equation = new ECEquationMod(2, 3, 67);
            ECPoint G = new ECPoint(2, 22);
            int d = 4;
            ECPoint Q = equation.ECMult(G, d);
            Console.WriteLine(Q);
            ECPoint P = new ECPoint(24, 26);
            int k = 2;

            ECPoint c1 = equation.ECMult(G, k);
            ECPoint c2 = equation.ECAdd(P, equation.ECMult(Q, k));
            Console.WriteLine($"C1 = {c1}; C2 = {c2}");
            ECPoint dc1 = equation.ECMult(c1, d);
            ECPoint dc1r = equation.ECMult(c1, d).GetReversed();
            while (dc1r.Y < 0)
                dc1r.Y += 67;
            Console.WriteLine($"dC1 = {dc1}; -dC2 = {dc1r}");
            ECPoint Pd = equation.ECSub(c2, dc1);
            Console.WriteLine($"P = {Pd}");*/
        }

        

        private void task1_Click(object sender, EventArgs e)
        {
            new Task1().Show();
        }

        private void task2_Click(object sender, EventArgs e)
        {
            new Task2().Show();
        }

        private void task3_Click(object sender, EventArgs e)
        {
            new Task3().Show();
        }
    }
}
