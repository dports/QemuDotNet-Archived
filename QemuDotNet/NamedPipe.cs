using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Text;
using System.Threading;

namespace QemuDotNet
{
	public class NamedPipe : Pipe
	{
		public event PipeReceiveEventHandler PipeReceiveEvent;

		public event PipeErrorEventHandler PipeErrorEvent;

		public NamedPipe()
		{
			this.cmdList = new List<string>();
		}

		public bool CreateServerPipe(string name)
		{
			NamedPipeServerStream sStream = new NamedPipeServerStream(name, PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, 1024, 1024);
			sStream.WaitForConnection();
			bool isConnected = sStream.IsConnected;
			bool result;
			if (isConnected)
			{
				this.ioStream = sStream;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public bool CreateClientPipe(string name)
		{
			bool result;
			try
			{
				NamedPipeClientStream cStream = new NamedPipeClientStream(".", name, PipeDirection.InOut, PipeOptions.Asynchronous);
				cStream.Connect(100);
				bool isConnected = cStream.IsConnected;
				if (isConnected)
				{
					this.ioStream = cStream;
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public bool CreatePipe(string name, ConnectionMode mode)
		{
			bool flag = name == "" || name == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				switch (mode)
				{
				case ConnectionMode.MODE_CLIENT:
					while (!this.CreateClientPipe(name))
					{
					}
					return true;
				case ConnectionMode.MODE_SERVER:
				{
					bool flag2 = this.CreateServerPipe(name);
					if (flag2)
					{
						return true;
					}
					break;
				}
				case ConnectionMode.MODE_AUTO:
				{
					bool flag4;
					do
					{
						bool flag3 = this.CreateClientPipe(name);
						if (flag3)
						{
							break;
						}
						flag4 = this.CreateServerPipe(name);
					}
					while (!flag4);
					return true;
				}
				}
				result = false;
			}
			return result;
		}

		public void Close()
		{
			bool flag = this.ioStream != null;
			if (flag)
			{
				this.ioStream.Close();
			}
		}

		public void WriteLoop()
		{
			try
			{
				for (;;)
				{
					bool flag = this.cmdList.Count > 0;
					if (flag)
					{
						byte[] wBuf = new byte[this.cmdList[0].Length];
						Encoding.UTF8.GetBytes(this.cmdList[0], 0, this.cmdList[0].Length, wBuf, 0);
						this.ioStream.Write(wBuf, 0, this.cmdList[0].Length);
						this.cmdList.RemoveAt(0);
					}
					else
					{
						bool flag2 = this.cmdList.Count == 0;
						if (flag2)
						{
							NamedPipe.newWriteData.Reset();
							NamedPipe.newWriteData.WaitOne();
						}
					}
				}
			}
			catch (Exception e)
			{
				bool flag3 = this.PipeErrorEvent != null;
				if (flag3)
				{
					this.PipeErrorEvent(this, new PipeErrorEventArgs(e.Message));
				}
			}
		}

		public void ReadLoop()
		{
			byte[] buf = new byte[1024];
			try
			{
				for (;;)
				{
					int read = this.ioStream.Read(buf, 0, 1024);
					bool flag = read > 0;
					if (!flag)
					{
						break;
					}
					bool flag2 = this.PipeReceiveEvent != null;
					if (flag2)
					{
						this.PipeReceiveEvent(this, new PipeReceiveEventArgs(Encoding.UTF8.GetString(buf, 0, read)));
					}
				}
			}
			catch (Exception e)
			{
				bool flag3 = this.PipeErrorEvent != null;
				if (flag3)
				{
					this.PipeErrorEvent(this, new PipeErrorEventArgs(e.Message));
				}
			}
		}

		public bool Write(string str)
		{
			this.wCommand += str;
			bool flag = str[^1] == '\r';
			if (flag)
			{
				this.cmdList.Add(this.wCommand);
				this.wCommand = null;
				NamedPipe.newWriteData.Set();
			}
			return true;
		}

		public const int PIPE_SIZE = 1024;

		private PipeStream ioStream;

		private string wCommand;

		private readonly List<string> cmdList;

		private static readonly ManualResetEvent newWriteData = new ManualResetEvent(false);
	}
}
