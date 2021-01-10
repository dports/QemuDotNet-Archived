using System;
using System.Xml.Serialization;

namespace QemuDotNet
{
	public class Tools
	{
		[XmlElement("VDK")]
		public VDK vdk
		{
			get
			{
				return this.m_VDK;
			}
			set
			{
				this.m_VDK = value;
			}
		}

		private VDK m_VDK = new VDK();
	}
}
