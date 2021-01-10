using System;
using System.Xml.Serialization;

namespace QemuDotNet
{
	public class Paths
	{
		[XmlElement("Qemu")]
		public string Qemu = "";

		[XmlElement("VDK")]
		public string VDK = "";
	}
}
