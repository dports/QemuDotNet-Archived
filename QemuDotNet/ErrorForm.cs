using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QemuDotNet
{
	public partial class ErrorForm : Form
	{
		public ErrorForm()
		{
			this.InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void error_copy_Click(object sender, EventArgs e)
		{
			string temp = this.txtError.Text;
			Clipboard.SetText(temp);
		}
	}
}
