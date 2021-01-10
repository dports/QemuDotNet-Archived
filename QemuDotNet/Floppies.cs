using System;
using System.Xml.Serialization;

namespace QemuDotNet
{
	public class Floppies
	{
		public Floppies()
		{
			for (int i = 0; i < 2; i++)
			{
				this.m_Floppies[i] = new Drive();
			}
		}

		public override string ToString()
		{
			string buffer = "";
			bool flag = this.FDD[0].Enabled && this.FDD[0].Path.Length > 0;
			if (flag)
			{
				buffer = buffer + "-fda \"" + this.FDD[0].Path + "\" ";
			}
			bool flag2 = this.FDD[1].Enabled && this.FDD[1].Path.Length > 0;
			if (flag2)
			{
				buffer = buffer + "-fdb \"" + this.FDD[1].Path + "\" ";
			}
			return buffer;
		}

		[XmlElement("Floppy")]
		public Drive[] FDD
		{
			get
			{
				return this.m_Floppies;
			}
			set
			{
				this.m_Floppies = value;
			}
		}

		private Drive[] m_Floppies = new Drive[2];
	}
}
