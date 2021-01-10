using System;
using System.Xml.Serialization;

namespace QemuDotNet
{
	public class CDROM
	{
		public override string ToString()
		{
			string buffer = "";
			bool enabled = this.Enabled;
			if (enabled)
			{
				bool flag = this.Image.Length > 0;
				if (flag)
				{
					buffer = "-cdrom \"" + this.Image + "\" ";
				}
			}
			return buffer;
		}

		[XmlAttribute("Image")]
		public string Image;

		[XmlAttribute("Enabled")]
		public bool Enabled;
	}
}
