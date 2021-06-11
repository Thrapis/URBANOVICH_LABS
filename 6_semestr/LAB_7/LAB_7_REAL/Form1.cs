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
	public partial class Form1 : Form
	{
		BackpackEncryptor BackpackEncryptor;
		BigInteger[] lastEn;

		public Form1()
		{
			InitializeComponent();

			comboBox1.Items.Add(BPEType.ASCII);
			comboBox1.Items.Add(BPEType.Base64);
			comboBox1.SelectedIndex = 0;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (BackpackEncryptor != null)
			{
				EncryptionInfo ei = new EncryptionInfo(BackpackEncryptor);
				ei.ShowDialog();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			BackpackEncryptor = new BackpackEncryptor((BPEType)comboBox1.SelectedItem);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (BackpackEncryptor != null)
			{
				DateTime time1 = DateTime.Now;
				lastEn = BackpackEncryptor.Encrypt(textBox1.Text);
				DateTime time2 = DateTime.Now;
				label1.Text = (time2 - time1).TotalMilliseconds.ToString() + " ms";

				textBox2.Text = lastEn.ToStringArray();
			} 
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (BackpackEncryptor != null && lastEn != null)
			{
				ReloadEncrypted();
				DateTime time1 = DateTime.Now;
				string result = BackpackEncryptor.Decrypt(lastEn);
				DateTime time2 = DateTime.Now;
				label2.Text = (time2 - time1).TotalMilliseconds.ToString() + " ms";

				textBox3.Text = result;
			}
		}

		private void ReloadEncrypted()
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
			lastEn = encrNumsList.ToArray();
		}
	}
}
