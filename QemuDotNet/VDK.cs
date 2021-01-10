using System;
using System.Xml.Serialization;

namespace QemuDotNet
{
	public class VDK
	{
		[XmlElement("Image")]
		public string Image = "";

		[XmlElement("DriveLetter")]
		public string DriveLetter = "";
	}
}
