using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using QemuDotNet.Properties;

namespace QemuDotNet
{
	public partial class DebugForm : Form
	{
		public DebugForm()
		{
			this.InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		public void Listen()
		{
			base.Show();
			BackgroundWorker work = new BackgroundWorker();
			work.DoWork += this.work_DoWork;
			work.RunWorkerAsync();
		}

		private void work_DoWork(object sender, DoWorkEventArgs e)
		{
			NamedPipe pipe = new NamedPipe();
			Thread.Sleep(1000);
			pipe.CreateClientPipe("com_1");
			pipe.PipeReceiveEvent += this.PipeRecievedHandler;
			pipe.PipeErrorEvent += this.PipeErrorHandler;
			pipe.ReadLoop();
		}

		private void PipeErrorHandler(object sender, PipeErrorEventArgs args)
		{
			ErrorForm err = new ErrorForm();
			TextBox txtError = err.txtError;
			txtError.Text = txtError.Text + "PipeErrorHandler:" + Environment.NewLine;
			TextBox txtError2 = err.txtError;
			txtError2.Text += args.ErrorDesc;
			err.Show();
		}

		private void PipeRecievedHandler(object sender, PipeReceiveEventArgs args)
		{
			this.WriteString(args.Received);
		}

		public void WriteString(string text)
		{
			bool invokeRequired = this.txtDebug.InvokeRequired;
			if (invokeRequired)
			{
				this.txtDebug.Invoke(new DebugForm.WriteStringDelegate(this.WriteString), new object[]
				{
					text
				});
			}
			else
			{
				this.txtDebug.AppendText(text);
				this.txtDebug.ScrollToCaret();
			}
		}

		private void tsbuttonCopy_Click(object sender, EventArgs e)
		{
			bool flag = this.txtDebug.Text != "";
			if (flag)
			{
				Clipboard.SetText(this.txtDebug.Text);
			}
		}

		private void tsButton_save_Click(object sender, EventArgs e)
		{
			StreamWriter log = null;
			ErrorForm error;
			FileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Save file";
			saveFileDialog.Filter = "Text file (*.txt)|*.txt";
			bool flag = saveFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				try
				{
					log = new StreamWriter(saveFileDialog.FileName);
					log.Write(this.txtDebug.Text);
				}
				catch (Exception ex)
				{
					error = new ErrorForm();
					error.txtError.Text = "Exception while trying to save file!" + Environment.NewLine;
					error.txtError.Text = ex.Message;
					error.Show();
				}
				log.Close();
			}
		}

		private delegate void WriteStringDelegate(string text);
	}
}
