using System;

namespace QemuDotNet
{
	public interface Pipe
	{
		event PipeReceiveEventHandler PipeReceiveEvent;

		event PipeErrorEventHandler PipeErrorEvent;

		bool Write(string output);
	}
}
