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
				string buffer = "";
				string speakerSwitch = "";
				bool soundblaster = this.Soundblaster;
				if (soundblaster)
				{
					buffer += " -device sb16 ";
				}
				bool opl = this.OPL2;
				if (opl)
				{
					buffer += " -device adlib ";
				}
				bool es = this.ES1370;
				if (es)
				{
					buffer += " -device es1370 ";
				}
				bool speaker = this.Speaker;
				if (speaker)
				{
					speakerSwitch = ""; // " -machine pcspk-audiodev= ";
				}
				result = buffer[0..^1] + speakerSwitch + " ";
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
