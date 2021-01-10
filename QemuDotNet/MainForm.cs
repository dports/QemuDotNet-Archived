using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Win32;
using QemuDotNet.Properties;

namespace QemuDotNet
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			this.InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			ArrayList DriveLetters = new ArrayList();
			for (int i = 100; i < 123; i++)
			{
				DriveLetters.Add(Convert.ToChar(i).ToString().ToUpper() + ":\\");
			}
			DriveInfo[] drives = DriveInfo.GetDrives();
			foreach (DriveInfo drive in drives)
			{
				DriveLetters.Remove(drive.RootDirectory.ToString());
			}
			foreach (object o in DriveLetters)
			{
				this.cboVDKDrive.Items.Add(o);
			}
			this.cboVDKDrive.SelectedIndex = 0;
			this.cboBootFrom.SelectedIndex = 1;
			this.cboImageFormat.SelectedIndex = 4;
			this.cboMachine.SelectedIndex = 0;
			this.LoadDefaultConfig();
			this.chkSerialToFile_CheckedChanged(null, null);
			this.chkSerialToPipe_CheckedChanged(null, null);
		}

		private void btnBrowseHDA_Click(object sender, EventArgs e)
		{
			this.openFile.Title = "Select Harddisk Image";
			this.openFile.Filter = "Harddisk images |*.vmdk;*.cloop;*.cow;*.qcow;*.raw;*.img|All Files | *.*";
			bool flag = this.openFile.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.txtHDA.Text = this.openFile.FileName;
			}
		}

		private void btnBrowseHDB_Click(object sender, EventArgs e)
		{
			this.openFile.Title = "Select Harddisk Image";
			this.openFile.Filter = "Harddisk images |*.vmdk;*.cloop;*.cow;*.qcow;*.raw;*.img|All Files | *.*";
			bool flag = this.openFile.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.txtHDB.Text = this.openFile.FileName;
			}
		}

		private void btnBrowseHDC_Click(object sender, EventArgs e)
		{
			this.openFile.Title = "Select Harddisk Image";
			this.openFile.Filter = "Harddisk images |*.vmdk;*.cloop;*.cow;*.qcow;*.raw;*.img|All Files | *.*";
			bool flag = this.openFile.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.txtHDC.Text = this.openFile.FileName;
			}
		}

		private void btnBrowseHDD_Click(object sender, EventArgs e)
		{
			this.openFile.Title = "Select Harddisk Image";
			this.openFile.Filter = "Harddisk images |*.vmdk;*.cloop;*.cow;*.qcow;*.raw;*.img|All Files | *.*";
			bool flag = this.openFile.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.txtHDD.Text = this.openFile.FileName;
			}
		}

		private void chkUseHDA_CheckedChanged(object sender, EventArgs e)
		{
			this.btnBrowseHDA.Enabled = this.chkUseHDA.Checked;
			this.txtHDA.Enabled = this.chkUseHDA.Checked;
		}

		private void chkUseHDB_CheckedChanged(object sender, EventArgs e)
		{
			this.btnBrowseHDB.Enabled = this.chkUseHDB.Checked;
			this.txtHDB.Enabled = this.chkUseHDB.Checked;
		}

		private void chkUseHDC_CheckedChanged(object sender, EventArgs e)
		{
			this.btnBrowseHDC.Enabled = this.chkUseHDC.Checked;
			this.txtHDC.Enabled = this.chkUseHDC.Checked;
			this.txtHDC.Text = "";
		}

		private void chkUseHDD_CheckedChanged(object sender, EventArgs e)
		{
			this.btnBrowseHDD.Enabled = this.chkUseHDD.Checked;
			this.txtHDD.Enabled = this.chkUseHDD.Checked;
		}

		private void btnBrowseCDROM_Click(object sender, EventArgs e)
		{
			this.openFile.Title = "Select CD-ROM image";
			this.openFile.Filter = "CD-Images (*.iso)|*.iso";
			bool flag = this.openFile.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.txtCDROM.Text = this.openFile.FileName;
			}
		}

		private void chkUseCDROM_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.chkUseHDC.Checked;
			if (@checked)
			{
				this.btnBrowseCDROM.Enabled = false;
				this.txtCDROM.Enabled = false;
			}
			else
			{
				this.chkUseCDROM.Enabled = true;
			}
			bool checked2 = this.chkUseCDROM.Checked;
			if (checked2)
			{
				this.chkUseHDC.Enabled = false;
				this.chkUseHDC.Checked = false;
				this.txtHDC.Text = "Used for CD-ROM!";
				this.txtHDC.Enabled = false;
				this.txtCDROM.Enabled = true;
				this.btnBrowseCDROM.Enabled = true;
			}
			else
			{
				this.btnBrowseCDROM.Enabled = false;
				this.txtCDROM.Enabled = false;
				this.chkUseHDC.Enabled = true;
				this.txtHDC.Text = "";
			}
		}

		private void optHostCDROM_CheckedChanged(object sender, EventArgs e)
		{
			this.txtCDROM.Enabled = false;
		}

		private void optCDImage_CheckedChanged(object sender, EventArgs e)
		{
			this.txtCDROM.Enabled = true;
		}

		private void chkSerialToScrn_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.chkSerialToScrn.Checked;
			if (@checked)
			{
				this.btnBrowseSerial.Enabled = false;
				this.txtSerialFile.Enabled = false;
				this.txtSerialPipe.Enabled = false;
				this.data.Debug.SerialPort.SRedirect = true;
				this.data.Debug.SerialPort.FRedirect = false;
				this.data.Debug.SerialPort.PRedirect = false;
				this.chkSerialToPipe.Enabled = false;
				this.chkSerialToFile.Enabled = false;
				this.chkSerialToPipe.Checked = false;
				this.chkSerialToFile.Checked = false;
			}
			else
			{
				this.btnBrowseSerial.Enabled = true;
				this.data.Debug.SerialPort.SRedirect = false;
				this.data.Debug.SerialPort.FRedirect = false;
				this.data.Debug.SerialPort.PRedirect = false;
				this.chkSerialToPipe.Enabled = true;
				this.chkSerialToFile.Enabled = true;
			}
		}

		private void chkSerialToFile_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.chkSerialToFile.Checked;
			if (@checked)
			{
				this.btnBrowseSerial.Enabled = true;
				this.txtSerialFile.Enabled = true;
				this.txtSerialPipe.Enabled = false;
				this.data.Debug.SerialPort.FRedirect = true;
				this.data.Debug.SerialPort.PRedirect = false;
				this.chkSerialToPipe.Enabled = false;
				this.chkSerialToPipe.Checked = false;
				this.chkSerialToScrn.Enabled = false;
				this.chkSerialToScrn.Checked = false;
			}
			else
			{
				this.data.Debug.SerialPort.FRedirect = false;
				this.chkSerialToPipe.Enabled = true;
				this.chkSerialToScrn.Enabled = true;
				this.txtSerialFile.Enabled = false;
				this.btnBrowseSerial.Enabled = false;
			}
		}

		private void chkSerialToPipe_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.chkSerialToPipe.Checked;
			if (@checked)
			{
				this.txtSerialPipe.Enabled = true;
				this.data.Debug.SerialPort.FRedirect = false;
				this.data.Debug.SerialPort.PRedirect = true;
				this.chkSerialToFile.Enabled = false;
				this.chkSerialToFile.Checked = false;
				this.txtSerialFile.Enabled = false;
				this.btnBrowseSerial.Enabled = false;
			}
			else
			{
				this.chkSerialToFile.Enabled = true;
				this.data.Debug.SerialPort.PRedirect = false;
				this.txtSerialPipe.Enabled = false;
			}
		}

		private void btnBrowseSerial_Click(object sender, EventArgs e)
		{
			this.saveFileDialog.Title = "Serial output to file";
			this.saveFileDialog.FileName = "serial_ouput.txt";
			this.saveFileDialog.Filter = "Text File (*.txt)|*.txt";
			bool flag = this.saveFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.txtSerialFile.Text = this.saveFileDialog.FileName;
			}
		}

		private void btnLoadVM_Click(object sender, EventArgs e)
		{
			this.openFile.ShowDialog();
			MainForm.saved_state = this.openFile.FileName;
			this.data.Debug.EnableSavedState = true;
		}

		private void chkVNC_CheckedChanged(object sender, EventArgs e)
		{
			this.txtVNC.Enabled = this.chkVNC.Checked;
		}

		private void chkFloppyA_CheckedChanged(object sender, EventArgs e)
		{
			this.btnBrowseFloppyA.Enabled = this.chkFloppyA.Checked;
			this.txtFloppyA.Enabled = this.chkFloppyA.Checked;
		}

		private void chkFloppyB_CheckedChanged(object sender, EventArgs e)
		{
			this.btnBrowseFloppyB.Enabled = this.chkFloppyB.Checked;
			this.txtFloppyB.Enabled = this.chkFloppyB.Checked;
		}

		private void btnBrowseFloppyA_Click(object sender, EventArgs e)
		{
			this.openFile.Title = "Browse for a floppy image";
			this.openFile.Filter = "All Files | *.*";
			bool flag = this.openFile.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.txtFloppyA.Text = this.openFile.FileName;
			}
		}

		private void btnBrowseFloppyB_Click(object sender, EventArgs e)
		{
			this.openFile.Title = "Browse for a floppy image";
			this.openFile.Filter = "All Files | *.*";
			bool flag = this.openFile.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.txtFloppyB.Text = this.openFile.FileName;
			}
		}

		private void btnQEmuPath_Click(object sender, EventArgs e)
		{
			this.folderBrowserDialog1.Description = "Select Qemu path";
			this.folderBrowserDialog1.ShowNewFolderButton = false;
			bool flag = this.folderBrowserDialog1.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.txtQEmuPath.Text = this.folderBrowserDialog1.SelectedPath;
				this.data.Paths.Qemu = this.txtQEmuPath.Text;
			}
		}

		private void btnVDKBrowse_Click(object sender, EventArgs e)
		{
			this.folderBrowserDialog1.Description = "Select VDK path";
			this.folderBrowserDialog1.ShowNewFolderButton = false;
			bool flag = this.folderBrowserDialog1.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.txtVDKPath.Text = this.folderBrowserDialog1.SelectedPath;
				this.data.Paths.VDK = this.txtVDKPath.Text;
			}
		}

		private void LoadDefaultConfig()
		{
			bool bLoaded = false;
			RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("Software\\RosTE");
			bool flag = RegKey != null;
			if (flag)
			{
				string DefaultConfig = (string)RegKey.GetValue("DefaultConfig");
				bool flag2 = File.Exists(DefaultConfig);
				if (flag2)
				{
					XmlSerializer s = new XmlSerializer(typeof(Data));
					TextReader r = new StreamReader(DefaultConfig);
					this.data = (Data)s.Deserialize(r);
					r.Close();
					this.LoadSettings();
					bLoaded = true;
					this.Text = this.Text + " - " + DefaultConfig;
				}
				else
				{
					MessageBox.Show("Unable to load the default config file");
				}
				RegKey.Close();
			}
			bool flag3 = !bLoaded;
			if (flag3)
			{
				VNic nic = new VNic("", NicModel.ne2k_pci);
				VUser use = new VUser("reactos", 0);
				this.data.Network.AddNetString(nic.ToString() + use.ToString());
				string[] lans = this.data.Network.GetNetStrings();
				this.listVLANs.Items.Add(lans[0]);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			this.SaveSettings();
			this.saveFileDialog.Title = "Save settings";
			this.saveFileDialog.InitialDirectory = this.currentDir;
			this.saveFileDialog.FileName = "config.xml";
			this.saveFileDialog.Filter = "QEMU GUI Config (*.xml)|*.xml";
			bool flag = this.saveFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				try
				{
					XmlSerializer s = new XmlSerializer(typeof(Data));
					TextWriter w = new StreamWriter(this.saveFileDialog.FileName);
					s.Serialize(w, this.data);
				}
				catch (Exception ex)
				{
					ErrorForm error = new ErrorForm();
					error.txtError.Text = "Error trying to save settings!";
					TextBox txtError = error.txtError;
					txtError.Text = txtError.Text + "Exception Info:" + Environment.NewLine + ex.Message;
					TextBox txtError2 = error.txtError;
					txtError2.Text = txtError2.Text + Environment.NewLine + ex.StackTrace;
				}
			}
		}

		private void LoadSettings()
		{
			this.cboMachine.SelectedIndex = (int)this.data.General.Machine;
			try
			{
				this.numMemory.Value = this.data.General.Memory;
			}
			catch (Exception)
			{
				this.numMemory.Value = 128m;
			}
			try
			{
				this.numSMP.Value = this.data.General.CPUs;
			}
			catch (Exception)
			{
				this.numSMP.Value = 1m;
			}
			this.cboBootFrom.SelectedItem = this.data.General.BootFrom;
			this.chkSetClock.Checked = this.data.General.SetClock;
			this.chkVGAoutput.Checked = this.data.General.VGA;
			this.chkFullscreen.Checked = this.data.General.Fullscreen;
			this.chkKQEmu.Checked = this.data.General.KQEmu;
			this.chkACPI.Checked = this.data.General.ACPI;
			this.chkUseCDROM.Checked = this.data.CDROM.Enabled;
			bool @checked = this.chkUseCDROM.Checked;
			if (@checked)
			{
				this.txtHDC.Text = "Used for CD-ROM!";
				this.txtHDC.Enabled = false;
			}
			this.txtCDROM.Text = this.data.CDROM.Image;
			this.chkFloppyA.Checked = this.data.Floppies.FDD[0].Enabled;
			this.txtFloppyA.Text = this.data.Floppies.FDD[0].Path;
			this.chkFloppyB.Checked = this.data.Floppies.FDD[1].Enabled;
			this.txtFloppyB.Text = this.data.Floppies.FDD[1].Path;
			this.txtQEmuPath.Text = this.data.Paths.Qemu;
			this.txtVDKPath.Text = this.data.Paths.VDK;
			this.chkUseHDA.Checked = this.data.Harddisks.HDD[0].Enabled;
			this.txtHDA.Text = this.data.Harddisks.HDD[0].Path;
			this.chkUseHDB.Checked = this.data.Harddisks.HDD[1].Enabled;
			this.txtHDB.Text = this.data.Harddisks.HDD[1].Path;
			this.chkUseHDC.Checked = this.data.Harddisks.HDD[2].Enabled;
			this.txtHDC.Text = this.data.Harddisks.HDD[2].Path;
			this.chkUseHDD.Checked = this.data.Harddisks.HDD[3].Enabled;
			this.txtHDD.Text = this.data.Harddisks.HDD[3].Path;
			this.chkES1370.Checked = this.data.Audio.ES1370;
			this.chkSoundBlaster.Checked = this.data.Audio.Soundblaster;
			this.chkPCSpeaker.Checked = this.data.Audio.Speaker;
			this.chkOPL2.Checked = this.data.Audio.OPL2;
			this.chkSerialToFile.Checked = this.data.Debug.SerialPort.FRedirect;
			this.txtSerialFile.Text = this.data.Debug.SerialPort.FileName;
			this.chkSerialToPipe.Checked = this.data.Debug.SerialPort.PRedirect;
			this.txtSerialPipe.Text = this.data.Debug.SerialPort.PipeName;
			this.chkSerialToScrn.Checked = this.data.Debug.SerialPort.SRedirect;
			this.chkSerialToFile_CheckedChanged(null, null);
			MainForm.saved_state = this.data.Debug.SavedStatePath;
			this.chkVBE30.Checked = this.data.Debug.VBE3;
			this.txtGDBPort.Text = this.data.Debug.GDBPort.ToString();
			string[] temp = this.data.Network.GetNetStrings();
			this.listVLANs.Items.Clear();
			bool flag = temp[0] != null;
			if (flag)
			{
				for (int i = 0; i < this.data.Network.Count; i++)
				{
					this.listVLANs.Items.Add(temp[i]);
				}
			}
			this.txtVDKImage.Text = this.data.Tools.vdk.Image;
			this.cboVDKDrive.Text = this.data.Tools.vdk.DriveLetter;
			this.txtLinuxK.Text = this.data.Other.LKernel;
			this.txtABios.Text = this.data.Other.ABios;
			this.txtAppendCmd.Text = this.data.Other.AppendCmdLine;
		}

		private void SaveSettings()
		{
			this.data.General.Machine = (Platforms)this.cboMachine.SelectedIndex;
			this.data.General.Memory = (int)this.numMemory.Value;
			this.data.General.CPUs = (int)this.numSMP.Value;
			this.data.General.BootFrom = this.cboBootFrom.SelectedItem.ToString();
			this.data.General.SetClock = this.chkSetClock.Checked;
			this.data.General.VGA = this.chkVGAoutput.Checked;
			this.data.General.Fullscreen = this.chkFullscreen.Checked;
			this.data.General.KQEmu = this.chkKQEmu.Checked;
			this.data.General.ACPI = this.chkACPI.Checked;
			this.data.Paths.Qemu = this.txtQEmuPath.Text;
			this.data.Paths.VDK = this.txtVDKPath.Text;
			this.data.Floppies.FDD[0].Enabled = this.chkFloppyA.Checked;
			this.data.Floppies.FDD[0].Path = this.txtFloppyA.Text;
			this.data.Floppies.FDD[1].Enabled = this.chkFloppyB.Checked;
			this.data.Floppies.FDD[1].Path = this.txtFloppyB.Text;
			this.data.CDROM.Image = this.txtCDROM.Text;
			this.data.CDROM.Enabled = this.chkUseCDROM.Checked;
			this.data.Harddisks.HDD[0].Enabled = this.chkUseHDA.Checked;
			this.data.Harddisks.HDD[0].Path = this.txtHDA.Text;
			this.data.Harddisks.HDD[1].Enabled = this.chkUseHDB.Checked;
			this.data.Harddisks.HDD[1].Path = this.txtHDB.Text;
			this.data.Harddisks.HDD[2].Enabled = this.chkUseHDC.Checked;
			this.data.Harddisks.HDD[2].Path = this.txtHDC.Text;
			this.data.Harddisks.HDD[3].Enabled = this.chkUseHDD.Checked;
			this.data.Harddisks.HDD[3].Path = this.txtHDD.Text;
			this.data.Audio.ES1370 = this.chkES1370.Checked;
			this.data.Audio.Soundblaster = this.chkSoundBlaster.Checked;
			this.data.Audio.Speaker = this.chkPCSpeaker.Checked;
			this.data.Audio.OPL2 = this.chkOPL2.Checked;
			this.data.Debug.SerialPort.SRedirect = this.chkSerialToScrn.Checked;
			this.data.Debug.SerialPort.FRedirect = this.chkSerialToFile.Checked;
			this.data.Debug.SerialPort.FileName = this.txtSerialFile.Text;
			this.data.Debug.SerialPort.PRedirect = this.chkSerialToPipe.Checked;
			this.data.Debug.SerialPort.PipeName = this.txtSerialPipe.Text;
			this.data.Debug.SavedStatePath = MainForm.saved_state;
			this.data.Debug.VBE3 = this.chkVBE30.Checked;
			this.data.Debug.GDBPort = int.Parse(this.txtGDBPort.Text);
			for (int i = 0; i < this.listVLANs.Items.Count; i++)
			{
				bool flag = this.data.Network.GetNetStrings()[i] != this.listVLANs.Items[i].Text;
				if (flag)
				{
					this.data.Network.AddNetString(this.listVLANs.Items[i].ToString());
				}
			}
			this.data.Tools.vdk.Image = this.txtVDKImage.Text;
			this.data.Tools.vdk.DriveLetter = this.cboVDKDrive.Text;
			this.data.Other.LKernel = this.txtLinuxK.Text;
			this.data.Other.ABios = this.txtABios.Text;
			this.data.Other.AppendCmdLine = this.txtAppendCmd.Text;
		}

		private void btnVDKImage_Click(object sender, EventArgs e)
		{
			this.openFile.Title = "Virtual Hardisk Image";
			this.openFile.Filter = "Harddisk images |*.vmdk;*.cloop;*.cow;*.qcow;*.raw;*.img|All Files | *.*";
			bool flag = this.openFile.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.txtVDKImage.Text = this.openFile.FileName;
				this.data.Tools.vdk.Image = this.openFile.FileName;
			}
		}

		private void cboVDKDrive_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.data.Tools.vdk.DriveLetter = this.cboVDKDrive.SelectedItem.ToString();
		}

		private void btnUnmount_Click(object sender, EventArgs e)
		{
			this.data.Paths.VDK = this.txtVDKPath.Text;
			bool flag = this.data.Paths.VDK == "";
			if (!flag)
			{
				this.runner = new Runner(this.data);
				this.runner.UnmountImage();
			}
		}

		private void btnMount_Click(object sender, EventArgs e)
		{
			this.data.Tools.vdk.Image = this.txtVDKImage.Text;
			this.data.Paths.VDK = this.txtVDKPath.Text;
			bool flag = !File.Exists(this.data.Tools.vdk.Image) || !Directory.Exists(this.data.Paths.VDK);
			if (flag)
			{
				MessageBox.Show("Error on vdk path or image target");
			}
			else
			{
				this.runner = new Runner(this.data);
				bool flag2 = this.runner.MountImage();
				if (flag2)
				{
					Thread.Sleep(500);
					Process p = new Process();
					p.StartInfo.FileName = "explorer";
					p.StartInfo.Arguments = this.data.Tools.vdk.DriveLetter;
					try
					{
						p.Start();
					}
					catch
					{
						MessageBox.Show("Error launching explorer!", "Error!");
					}
				}
			}
		}

		private void btnNetAdd_Click(object sender, EventArgs e)
		{
		}

		private void rbtnNetUser_CheckedChanged(object sender, EventArgs e)
		{
			this.panelUser.Visible = this.rbtnNetUser.Checked;
		}

		private void rbtnNetNic_CheckedChanged(object sender, EventArgs e)
		{
			this.panelNic.Visible = this.rbtnNetNic.Checked;
		}

		private void btnNetRemove_Click(object sender, EventArgs e)
		{
		}

		private void btnCreateImage_Click(object sender, EventArgs e)
		{
			this.saveFileDialog.Title = "Create a virtual Hardisk";
			this.saveFileDialog.Filter = "Harddisk images |*.vmdk;*.cloop;*.cow;*.qcow;*.raw;*.img|All Files | *.*";
			this.saveFileDialog.FileName = "image." + this.cboImageFormat.Text;
			this.saveFileDialog.DefaultExt = this.cboImageFormat.Text;
			bool flag = this.saveFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.SaveSettings();
				this.runner = new Runner(this.data);
				bool flag2 = this.runner.CreateImage(this.saveFileDialog.FileName, (long)Convert.ToInt32(this.txtImageSize.Text), this.cboImageFormat.Text);
				if (flag2)
				{
					MessageBox.Show("Image created");
				}
			}
		}

		private void btnLaunch_Click(object sender, EventArgs e)
		{
			this.SaveSettings();
			bool HasHDisk = false;
			bool HasFDisk = false;
			bool flag = !Directory.Exists(this.data.Paths.Qemu);
			if (flag)
			{
				MessageBox.Show("Qemu path does not exist", "Error - Qemu path");
			}
			else
			{
				for (int i = 0; i < this.data.Harddisks.HDD.Length; i++)
				{
					bool enabled = this.data.Harddisks.HDD[i].Enabled;
					if (enabled)
					{
						bool flag2 = File.Exists(this.data.Harddisks.HDD[i].Path);
						if (!flag2)
						{
							MessageBox.Show("\"" + this.data.Harddisks.HDD[i].Path + "\" image does not exist", "Error - Harddisk image");
							return;
						}
						HasHDisk = true;
					}
				}
				for (int j = 0; j < this.data.Floppies.FDD.Length; j++)
				{
					bool enabled2 = this.data.Floppies.FDD[j].Enabled;
					if (enabled2)
					{
						bool flag3 = File.Exists(this.data.Floppies.FDD[j].Path);
						if (!flag3)
						{
							MessageBox.Show("\"" + this.data.Floppies.FDD[j].Path + "\" image does not exist", "Error - Floppy image");
							return;
						}
						HasFDisk = true;
					}
				}
				bool flag4 = this.txtCDROM.Text.Length > 0 && File.Exists(this.data.CDROM.Image);
				if (flag4)
				{
					this.data.CDROM.Enabled = true;
				}
				else
				{
					this.data.CDROM.Enabled = false;
				}
				bool flag5 = !HasHDisk && !this.data.CDROM.Enabled && !HasFDisk;
				if (flag5)
				{
					MessageBox.Show("Must enable atleast 1 Hard disk, CD-Rom or Floppy disk!", "Error");
				}
				else
				{
					bool flag6 = (this.data.General.BootFrom == "Floppy" && !HasFDisk) || (this.data.General.BootFrom == "Hardisk" && !HasHDisk) || (this.data.General.BootFrom == "CD-ROM" && !this.data.CDROM.Enabled);
					if (flag6)
					{
						MessageBox.Show("Booting from invalid media!", "Error");
					}
					else
					{
						this.runner = new Runner(this.data);
						this.runner.StartQemu((Platforms)this.cboMachine.SelectedIndex);
					}
				}
			}
		}

		private void loadConfigToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.openFile.Title = "Load settings";
			this.openFile.InitialDirectory = this.currentDir;
			this.openFile.FileName = "config.xml";
			this.openFile.Filter = "Config (*.xml)|*.xml";
			bool flag = this.openFile.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				try
				{
					XmlSerializer s = new XmlSerializer(typeof(Data));
					TextReader r = new StreamReader(this.openFile.FileName);
					this.data = (Data)s.Deserialize(r);
					this.LoadSettings();
					this.Text = this.Text + " - " + this.openFile.FileName;
				}
				catch (Exception ex)
				{
					ErrorForm error = new ErrorForm();
					error.txtError.Text = "Error Ocourred while loading settings! Exception Information:";
					TextBox txtError = error.txtError;
					txtError.Text += ex.Message;
					TextBox txtError2 = error.txtError;
					txtError2.Text = txtError2.Text + Environment.NewLine + "Your settings file may be corrupt.";
					error.Show();
				}
			}
		}

		private void saveConfigToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SaveSettings();
			this.saveFileDialog.Title = "Save settings";
			this.saveFileDialog.InitialDirectory = this.currentDir;
			this.saveFileDialog.FileName = "config.xml";
			this.saveFileDialog.Filter = "Config (*.xml)|*.xml";
			bool flag = this.saveFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				try
				{
					XmlSerializer s = new XmlSerializer(typeof(Data));
					TextWriter w = new StreamWriter(this.saveFileDialog.FileName);
					s.Serialize(w, this.data);
				}
				catch (Exception ex)
				{
					ErrorForm error = new ErrorForm();
					error.txtError.Text = "Error trying to save settings!";
					TextBox txtError = error.txtError;
					txtError.Text = txtError.Text + "Exception Info:" + Environment.NewLine + ex.Message;
					TextBox txtError2 = error.txtError;
					txtError2.Text = txtError2.Text + Environment.NewLine + ex.StackTrace;
				}
			}
		}

		private void helpContentsToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void aboutReactOSQEmuManagerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm Dlg = new AboutForm();
			Dlg.Show();
		}

		private void setAsDefaultToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.openFile.Title = "Default config settings";
			this.openFile.InitialDirectory = this.currentDir;
			this.openFile.FileName = "config.xml";
			this.openFile.Filter = "Config (*.xml)|*.xml";
			bool flag = this.openFile.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				RegistryKey RegKey = Registry.CurrentUser.CreateSubKey("Software\\RosTE");
				bool flag2 = RegKey != null;
				if (flag2)
				{
					RegKey.SetValue("DefaultConfig", this.openFile.FileName);
					RegKey.Close();
				}
			}
			this.LoadDefaultConfig();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			try
			{
				this.runner.StopQemu();
			}
			catch
			{
			}
		}

		private const string strRegKey = "Software\\RosTE";

		private const string strDefCon = "DefaultConfig";

		private Runner runner;

		private string currentDir = Directory.GetCurrentDirectory();

		private Data data = new Data();

		private static string saved_state;
	}
}
