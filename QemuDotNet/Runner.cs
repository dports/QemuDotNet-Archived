using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Versioning;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace QemuDotNet
{
	public class Runner
	{
		public Runner(Data In)
		{
			this.p = new Process();
			this.data = In;
			this.p.StartInfo.RedirectStandardError = true;
			this.p.StartInfo.RedirectStandardOutput = true;
			this.p.StartInfo.UseShellExecute = false;
			this.p.StartInfo.CreateNoWindow = true;
			this.p.EnableRaisingEvents = true;
			this.p.Exited += this.ProcessStop;
			this.temp_path = Application.StartupPath + "\\";
		}

		public void StopQemu()
		{
			this.p.CloseMainWindow();
		}

		public bool StartQemu(Platforms Platform)
		{
			switch (Platform)
			{
			case Platforms.x86:
			case Platforms.x86_ISA:
				this.p.StartInfo.FileName = this.data.Paths.Qemu + "\\qemu.exe";
				break;
			case Platforms.x64:
			case Platforms.x64_ISA:
				this.p.StartInfo.FileName = this.data.Paths.Qemu + "\\qemu-system-x86_64.exe";
				break;
			case Platforms.ARM_integratorcp926:
			case Platforms.ARM_integratorcp1026:
			case Platforms.ARM_versatilepb:
			case Platforms.ARM_versatileab:
				this.p.StartInfo.FileName = this.data.Paths.Qemu + "\\qemu-system-arm.exe";
				break;
			case Platforms.PPC_g3bw:
			case Platforms.PPC_mac99:
			case Platforms.PPC_prep:
				this.p.StartInfo.FileName = this.data.Paths.Qemu + "\\qemu-system-ppc.exe";
				break;
			case Platforms.Sparc_sun4m:
				this.p.StartInfo.FileName = this.data.Paths.Qemu + "\\qemu-system-sparc.exe";
				break;
			}
			bool flag = !File.Exists(this.p.StartInfo.FileName);
			bool result;
			if (flag)
			{
				MessageBox.Show("Required qemu executable does not exist in path", "Error - Qemu path");
				result = false;
			}
			else
			{
				try
				{
					this.p.StartInfo.WorkingDirectory = this.data.Paths.Qemu;
					this.p.StartInfo.Arguments = this.data.GetArgv();
				}
				catch (Exception e)
				{
					MessageBox.Show("Invalid path or arguments. Your settings may be corrupt. \nException Information: " + e.Message, "Error");
					return false;
				}
				this.ErrBuffer = string.Concat(new string[]
				{
					"Path:",
					Environment.NewLine,
					this.p.StartInfo.FileName.ToString(),
					Environment.NewLine,
					"Arguments:",
					Environment.NewLine,
					this.data.GetArgv()
				});
				try
				{
					this.p.Start();
					bool sredirect = this.data.Debug.SerialPort.SRedirect;
					if (sredirect)
					{
						this.output = new DebugForm();
						this.output.Listen();
					}
				}
				catch (Exception e2)
				{
					this.ErrBuffer = this.ErrBuffer + Environment.NewLine + "Exception: " + e2.Message;
					new ErrorForm
					{
						txtError = 
						{
							Text = this.ErrBuffer
						}
					}.Show();
					return false;
				}
				result = true;
			}
			return result;
		}

		public bool CreateImage(string FileName, long Size, string Format)
		{
			string argv = string.Concat(new string[]
			{
				" create -f ",
				Format,
				" \"",
				FileName,
				"\" ",
				(Size * 1024L).ToString()
			});
			this.p.StartInfo.FileName = this.data.Paths.Qemu + "\\qemu-img.exe";
			bool flag = !File.Exists(this.p.StartInfo.FileName);
			bool result;
			if (flag)
			{
				MessageBox.Show("qemu-img.exe does not existin path", "Error - Qemu path");
				result = false;
			}
			else
			{
				this.p.StartInfo.WorkingDirectory = this.data.Paths.Qemu;
				this.p.StartInfo.Arguments = argv;
				try
				{
					this.p.Start();
				}
				catch (Exception e)
				{
					this.ErrBuffer = this.ErrBuffer + Environment.NewLine + "Error: " + e.Message;
					ErrorForm error = new ErrorForm();
					error.txtError.Text = this.ErrBuffer;
					TextBox txtError = error.txtError;
					txtError.Text += this.p.StandardError.ReadToEnd();
					error.ShowDialog();
					return false;
				}
				result = true;
			}
			return result;
		}

		public string GetErrorBuffer()
		{
			return this.ErrBuffer;
		}

		public bool MountImage()
		{
			if (Thread.CurrentPrincipal == null || !Thread.CurrentPrincipal.IsInRole("Administrators"))
			{
				MessageBox.Show("Request for Administrator privilages failed.\n VDK may not function.", "Info");
			}
			bool success = this.StartVdkService();
			bool flag = success;
			if (flag)
			{
				this.p.StartInfo.FileName = this.data.Paths.VDK + "\\vdk.exe";
				this.p.StartInfo.WorkingDirectory = this.data.Paths.VDK;
				this.p.StartInfo.Arguments = "open 0 \"" + this.data.Tools.vdk.Image + "\" /RW /L:" + this.data.Tools.vdk.DriveLetter;
				try
				{
					this.p.Start();
				}
				catch (Exception e)
				{
					this.ErrBuffer = e.Message;
					success = false;
				}
			}
			else
			{
				ErrorForm error = new ErrorForm();
				error.txtError.Text = this.ErrBuffer;
				TextBox txtError = error.txtError;
				txtError.Text += this.p.StandardOutput.ReadToEnd();
				error.ShowDialog();
			}
			return success;
		}

		public bool UnmountImage()
		{
			this.p.StartInfo.FileName = this.data.Paths.VDK + "\\vdk.exe";
			this.p.StartInfo.WorkingDirectory = this.data.Paths.VDK;
			this.p.StartInfo.Arguments = "CLOSE * /F";
			try
			{
				this.p.Start();
			}
			catch (Exception e)
			{
				this.ErrBuffer = this.ErrBuffer + Environment.NewLine + "Error: " + e.Message;
				ErrorForm error = new ErrorForm();
				error.txtError.Text = this.ErrBuffer;
				TextBox txtError = error.txtError;
				txtError.Text += this.p.StandardError.ReadToEnd();
				error.ShowDialog();
				return false;
			}
			this.StopVdkService();
			return true;
		}

		private bool StartVdkService()
		{
			this.p.StartInfo.FileName = this.data.Paths.VDK + "\\vdk.exe";
			this.p.StartInfo.WorkingDirectory = this.data.Paths.VDK;
			this.p.StartInfo.Arguments = "start";
			try
			{
				this.p.Start();
			}
			catch (Exception e)
			{
				this.ErrBuffer = e.Message;
				return false;
			}
			string buffer = this.p.StandardOutput.ReadToEnd();
			bool flag = buffer.Contains("Failed to start the Virtual Disk Driver.");
			bool result;
			if (flag)
			{
				this.ErrBuffer = buffer;
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		private void StopVdkService()
		{
			this.p.StartInfo.FileName = this.data.Paths.VDK + "\\vdk.exe";
			this.p.StartInfo.WorkingDirectory = this.data.Paths.VDK;
			this.p.StartInfo.Arguments = "stop";
			try
			{
				this.p.Start();
			}
			catch
			{
			}
		}

		public void ProcessStop(object sender, EventArgs e)
		{
			string buff = this.p.StandardError.ReadToEnd();
			this.ErrBuffer = string.Concat(new string[]
			{
				this.ErrBuffer,
				Environment.NewLine,
				"Error:",
				Environment.NewLine,
				buff
			});
			bool flag = buff.Length > 0;
			if (flag)
			{
				new ErrorForm
				{
					txtError = 
					{
						Text = this.ErrBuffer
					}
				}.ShowDialog();
			}
		}

		private readonly Data data;

		private string ErrBuffer = "";

		private readonly Process p;

		private DebugForm output;

		public string temp_path;
	}
}
