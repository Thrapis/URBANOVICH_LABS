using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_11
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
            FillChart();
        }

        private void FillChart()
        {
            ECEquationMod equation = new ECEquationMod(-1, 1, 751);
            ECPoint[] points = equation.GetAllPoints().Select(t => t).Where(t => t.X >= 71 && t.X <= 105).ToArray();

            foreach (var p in points)
            {
                Console.WriteLine(p);
                chart1.Series[0].Points.Add(p.Y, p.X);
            }
        }

        private void calculate_button_Click(object sender, EventArgs e)
        {
            double a = (double)A.Value;
            double b = (double)B.Value;
            int k = (int)K.Value;
            int l = (int)L.Value;
            double mod = (double)MOD.Value;
            double px = (double)PX.Value;
            double py = (double)PY.Value;
            double qx = (double)QX.Value;
            double qy = (double)QY.Value;
            double rx = (double)RX.Value;
            double ry = (double)RY.Value;

            ECEquationMod equation = new ECEquationMod(a, b, mod);
            ECPoint P = new ECPoint(px, py);
            ECPoint Q = new ECPoint(qx, qy);
            ECPoint R = new ECPoint(rx, ry);

            ECPoint kP = equation.ECMult(P, k);
            ECPoint lQ = equation.ECMult(Q, l);

            KP.Text = kP.ToString();
            PQ.Text = equation.ECAdd(P, Q).ToString();
            KPLQR.Text = equation.ECSub(equation.ECAdd(kP, lQ), R).ToString();
            PQR.Text = equation.ECAdd(equation.ECSub(P, Q), R).ToString();
        }
    }
}
