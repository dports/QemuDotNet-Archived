using System;
using System.Xml.Serialization;

namespace QemuDotNet
{
	[XmlRoot("Settings")]
	public class Data : IDisposable
	{
		public void Dispose()
		{
			this.Dispose();
		}

		[XmlElement("General")]
		public General General
		{
			get
			{
				return this.m_Gen;
			}
			set
			{
				this.m_Gen = value;
			}
		}

		[XmlElement("Tools")]
		public Tools Tools
		{
			get
			{
				return this.m_Tools;
			}
			set
			{
				this.m_Tools = value;
			}
		}

		[XmlElement("Floppies")]
		public Floppies Floppies
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

		[XmlElement("CDROM")]
		public CDROM CDROM
		{
			get
			{
				return this.m_CDROM;
			}
			set
			{
				this.m_CDROM = value;
			}
		}

		[XmlElement("Harddisks")]
		public Harddisks Harddisks
		{
			get
			{
				return this.m_Harddisks;
			}
			set
			{
				this.m_Harddisks = value;
			}
		}

		[XmlElement("Audio")]
		public Audio Audio
		{
			get
			{
				return this.m_Audio;
			}
			set
			{
				this.m_Audio = value;
			}
		}

		[XmlElement("Paths")]
		public Paths Paths
		{
			get
			{
				return this.m_Paths;
			}
			set
			{
				this.m_Paths = value;
			}
		}

		[XmlElement("Debug")]
		public Debug Debug
		{
			get
			{
				return this.m_Debug;
			}
			set
			{
				this.m_Debug = value;
			}
		}

		[XmlElement("Network")]
		public Network Network
		{
			get
			{
				return this.m_Net;
			}
			set
			{
				this.m_Net = value;
			}
		}

		[XmlElement("Other")]
		public Other Other
		{
			get
			{
				return this.m_Other;
			}
			set
			{
				this.m_Other = value;
			}
		}

		public string GetArgv()
		{
			bool flag = this.Other.ABios.Length > 0;
			string arg;
			if (flag)
			{
				arg = "-L \"" + this.Other.ABios + "\" ";
			}
			else
			{
				arg = "-L \"" + this.Paths.Qemu + "\" ";
			}
			arg += this.General.ToString();
			arg += this.Floppies.ToString();
			arg += this.Harddisks.ToString();
			arg += this.CDROM.ToString();
			arg += this.Audio.ToString();
			arg += this.Debug.ToString();
			arg += this.Network.ToString();
			return arg + this.Other.ToString();
		}

		private General m_Gen = new General();

		private Floppies m_Floppies = new Floppies();

		private Harddisks m_Harddisks = new Harddisks();

		private Audio m_Audio = new Audio();

		private Debug m_Debug = new Debug();

		private Paths m_Paths = new Paths();

		private CDROM m_CDROM = new CDROM();

		private Tools m_Tools = new Tools();

		private Network m_Net = new Network();

		private Other m_Other = new Other();
	}
}
