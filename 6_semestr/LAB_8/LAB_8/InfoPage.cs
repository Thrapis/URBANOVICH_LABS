using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_8
{
	public partial class InfoPage : Form
	{
		public InfoPage(string info)
		{
			InitializeComponent();
			textBox1.Text = info;
		}
	}
}
