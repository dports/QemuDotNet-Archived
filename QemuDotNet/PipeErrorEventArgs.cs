using System;

namespace QemuDotNet
{
	public class PipeErrorEventArgs
	{
		public PipeErrorEventArgs(string error)
		{
			this.ErrorDesc = error;
		}

		public readonly string ErrorDesc;
	}
}
