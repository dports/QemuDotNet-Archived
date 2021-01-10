using System;
using System.Xml.Serialization;

namespace QemuDotNet
{
	public class Other
	{
		public override string ToString()
		{
			string buffer = "";
			bool flag = this.LKernel.Length > 0;
			if (flag)
			{
				buffer = buffer + "-kernel " + this.LKernel + " ";
			}
			bool flag2 = this.AppendCmdLine.Length > 0;
			if (flag2)
			{
				buffer = buffer + "-append " + this.AppendCmdLine + " ";
			}
			return buffer;
		}

		[XmlAttribute("LKernel")]
		public string LKernel;

		[XmlAttribute("ABios")]
		public string ABios;

		[XmlAttribute("AppendCmdLine")]
		public string AppendCmdLine;
	}
}
