using System;
using System.Xml.Serialization;

namespace QemuDotNet
{
	public class Audio
	{
		public override string ToString()
		{
			bool audio_on = this.ES1370 | this.OPL2 | this.Soundblaster | this.Speaker;
			bool flag = !audio_on;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				string buffer = "-soundhw ";
				bool speaker = this.Speaker;
				if (speaker)
				{
					buffer += "pcspk,";
				}
				bool soundblaster = this.Soundblaster;
				if (soundblaster)
				{
					buffer += "sb16,";
				}
				bool opl = this.OPL2;
				if (opl)
				{
					buffer += "adlib,";
				}
				bool es = this.ES1370;
				if (es)
				{
					buffer += "es1370,";
				}
				result = buffer[0..^1] + " ";
			}
			return result;
		}

		[XmlElement("Soundblaster")]
		public bool Soundblaster;

		[XmlElement("OPL2")]
		public bool OPL2;

		[XmlElement("ES1370")]
		public bool ES1370;

		[XmlElement("Speaker")]
		public bool Speaker;
	}
}
