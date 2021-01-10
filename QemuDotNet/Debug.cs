using System;
using System.Xml.Serialization;

namespace QemuDotNet
{
	public class Debug
	{
		public override string ToString()
		{
			string buffer = "";
			bool fredirect = this.SerialPort.FRedirect;
			if (fredirect)
			{
				bool flag = this.SerialPort.FileName.Length > 0;
				if (flag)
				{
					buffer = "-serial file:\"" + this.SerialPort.FileName + "\" ";
				}
			}
			else
			{
				bool predirect = this.SerialPort.PRedirect;
				if (predirect)
				{
					bool flag2 = this.SerialPort.PipeName.Length > 0;
					if (flag2)
					{
						buffer = "-serial pipe:" + this.SerialPort.PipeName + " ";
					}
				}
				else
				{
					bool sredirect = this.SerialPort.SRedirect;
					if (sredirect)
					{
						buffer = "-serial pipe:\"com_1\" ";
					}
				}
			}
			bool fredirect2 = this.ParallelPort.FRedirect;
			if (fredirect2)
			{
				bool flag3 = this.ParallelPort.FileName.Length > 0;
				if (flag3)
				{
					buffer = buffer + "-parallel file:\"" + this.ParallelPort.FileName + "\" ";
				}
			}
			else
			{
				bool predirect2 = this.ParallelPort.PRedirect;
				if (predirect2)
				{
					bool flag4 = this.ParallelPort.PipeName.Length > 0;
					if (flag4)
					{
						buffer = buffer + "-parallel pipe:\"" + this.ParallelPort.PipeName + "\" ";
					}
				}
			}
			bool enableSavedState = this.EnableSavedState;
			if (enableSavedState)
			{
				bool flag5 = this.SavedStatePath.Length > 0;
				if (flag5)
				{
					buffer = buffer + "-loadvm \"" + this.SavedStatePath + "\" ";
				}
			}
			bool vbe = this.VBE3;
			if (vbe)
			{
				buffer += "-std-vga ";
			}
			bool flag6 = this.GDBPort != 1234;
			if (flag6)
			{
				buffer = buffer + "-p " + this.GDBPort.ToString() + " ";
			}
			return buffer;
		}

		[XmlElement("ParPort")]
		public ParPort ParallelPort = new ParPort();

		[XmlElement("SerPort")]
		public SerPort SerialPort = new SerPort();

		[XmlElement("VBE3")]
		public bool VBE3;

		[XmlElement("GDBPort")]
		public int GDBPort;

		public bool EnableSavedState;

		public string SavedStatePath;
	}
}
