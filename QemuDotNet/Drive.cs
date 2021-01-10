using System;
using System.Xml.Serialization;

namespace QemuDotNet
{
	public class Drive
	{
		[XmlAttribute("Path")]
		public string Path;

		[XmlAttribute("Enabled")]
		public bool Enabled;
	}
}
