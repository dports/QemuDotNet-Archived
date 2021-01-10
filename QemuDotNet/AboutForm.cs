using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QemuDotNet
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			this.InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
