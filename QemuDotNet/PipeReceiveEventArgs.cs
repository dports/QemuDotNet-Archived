using System;

namespace QemuDotNet
{
	public class PipeReceiveEventArgs
	{
		public PipeReceiveEventArgs(string received)
		{
			this.Received = received;
		}

		public readonly string Received;
	}
}
