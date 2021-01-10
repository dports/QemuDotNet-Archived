using System;
using System.Xml.Serialization;

namespace QemuDotNet
{
	public class SerPort
	{
		[XmlAttribute("SRedirect")]
		public bool SRedirect;

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
