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

namespace LAB_8
{
	public partial class Form1 : Form
	{
		RSA RSA;
		ElGamal ElGamal;

		BigInteger[] lastRsaAnswer;
		ElGamalBlock[] lastElGamalAnswer;

		public Form1()
		{
			InitializeComponent();
			string res = CalculationOfTheParameter.GetSatistics();
			Console.Clear();
			Console.WriteLine(res);
			/*Console.WriteLine("---------------------------");
			RSA rsa = new RSA(23, 107, 47);
			BigInteger[] otv = rsa.Ecryption(((char)23).ToString());
			Console.WriteLine(otv[0]);
			Console.WriteLine((int)rsa.Decryption(otv)[0]);
			Console.WriteLine("---------------------------");
			ElGamal elGamal = new ElGamal(109, 29);
			ElGamalBlock[] elGamalBlocks = elGamal.Ecryption("Hello, World!");
			Console.WriteLine(elGamal.Decryption(elGamalBlocks));*/
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
			BigInteger p = BigInteger.Parse(textBox7.Text);
			BigInteger q = BigInteger.Parse(textBox8.Text);
			BigInteger d = BigInteger.Parse(textBox9.Text);
			RSA = new RSA(p, q, d);
        }

        private void button4_Click(object sender, EventArgs e)
        {
			BigInteger p = BigInteger.Parse(textBox10.Text);
			BigInteger x = BigInteger.Parse(textBox11.Text);
			ElGamal = new ElGamal(p, x);
		}

        private void button2_Click(object sender, EventArgs e)
        {
			if (RSA != null)
            {
				string text = textBox1.Text;
				lastRsaAnswer = RSA.Ecryption(text);
				textBox2.Text = lastRsaAnswer.ToStringArray();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
			if (RSA != null)
			{
				ReloadEncryptedRSA();
				string text = RSA.Decryption(lastRsaAnswer);
				textBox3.Text = text;
			}
		}

        private void button5_Click(object sender, EventArgs e)
        {
			if (ElGamal != null)
            {
				string text = textBox4.Text;
				lastElGamalAnswer = ElGamal.Ecryption(text);
				textBox5.Text = lastElGamalAnswer.ToStringArray();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
			if (ElGamal != null)
			{
				ReloadEncryptedElGamal();
				string text = ElGamal.Decryption(lastElGamalAnswer);
				textBox6.Text = text;
			}
		}

		private void ReloadEncryptedRSA()
		{
			string encr = textBox2.Text;
			encr = encr.Replace("\r\n", ";");
			string[] nums = encr.Split(';');
			List<BigInteger> encrNumsList = new List<BigInteger>();
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] != "")
				{
					nums[i] = nums[i].Replace("[", "").Replace("]", "");
					encrNumsList.Add(BigInteger.Parse(nums[i]));
				}
			}
			lastRsaAnswer = encrNumsList.ToArray();
		}

		private void ReloadEncryptedElGamal()
		{
			string encr = textBox5.Text;
			encr = encr.Replace("\r\n", ";");
			string[] nums = encr.Split(';');
			List<ElGamalBlock> encrBlocksList = new List<ElGamalBlock>();
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] != "")
				{
					nums[i] = nums[i].Replace("][", ";")
						.Replace("[", "")
						.Replace("]", "")
						.Replace("{", "")
						.Replace("}", "");
					string[] parts = nums[i].Split(';');

					encrBlocksList.Add(new ElGamalBlock(
						BigInteger.Parse(parts[0]),
						BigInteger.Parse(parts[1])
						));
				}
			}
			lastElGamalAnswer = encrBlocksList.ToArray();
		}

        private void button7_Click(object sender, EventArgs e)
        {
			if (RSA != null)
            {
				string info = "";
				info += "RSA Info\r\n";
				info += $"P = {RSA.P}\r\n";
				info += $"Q = {RSA.Q}\r\n";
				info += $"N = {RSA.N}\r\n";
				info += $"D = {RSA.D}\r\n";
				info += $"E = {RSA.E}";

				InfoPage infoPage = new InfoPage(info);
				infoPage.Show();
			}
        }

        private void button8_Click(object sender, EventArgs e)
        {
			if (ElGamal != null)
			{
				string info = "";
				info += "ElGamal Info\r\n";
				info += $"P = {ElGamal.P}\r\n";
				info += $"G = {ElGamal.G}\r\n";
				info += $"X = {ElGamal.X}\r\n";
				info += $"Y = {ElGamal.Y}";

				InfoPage infoPage = new InfoPage(info);
				infoPage.Show();
			}
		}
    }
}
