using System;
using System.Xml.Serialization;

namespace QemuDotNet
{
	public class ParPort
	{
		[XmlAttribute("FRedirect")]
		public bool FRedirect;

		[XmlAttribute("FileName")]
		public string FileName;

		[XmlAttribute("PRedirect")]
		public bool PRedirect;

		[XmlAttribute("PipeName")]
		public string PipeName;
	}
}
