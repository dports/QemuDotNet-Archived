using System;
using System.Xml.Serialization;

namespace QemuDotNet
{
	public class General
	{
		public override string ToString()
		{
			string buffer = "-m " + this.Memory.ToString() + " ";
			bool flag = this.CPUs > 1;
			if (flag)
			{
				buffer = buffer + "-smp " + this.CPUs.ToString() + " ";
			}
			bool setClock = this.SetClock;
			if (setClock)
			{
				buffer += "-localtime ";
			}
			bool vga = this.VGA;
			if (vga)
			{
				buffer += "-nographic ";
			}
			bool fullscreen = this.Fullscreen;
			if (fullscreen)
			{
				buffer += "-full-screen ";
			}
			bool flag2 = !this.ACPI;
			if (flag2)
			{
				buffer += "-no-acpi ";
			}
			switch (this.Machine)
			{
			case Platforms.x86:
				buffer += "-M pc ";
				this.KqemuAllowed = true;
				break;
			case Platforms.x86_ISA:
				buffer += "-M isapc ";
				this.KqemuAllowed = true;
				break;
			case Platforms.x64:
				buffer += "-M pc ";
				this.KqemuAllowed = false;
				break;
			case Platforms.x64_ISA:
				buffer += "-M isapc ";
				this.KqemuAllowed = false;
				break;
			case Platforms.ARM_integratorcp926:
				buffer += "-M integratorcp926 ";
				this.KqemuAllowed = false;
				break;
			case Platforms.ARM_integratorcp1026:
				buffer += "-M integratorcp1026 ";
				this.KqemuAllowed = false;
				break;
			case Platforms.ARM_versatilepb:
				buffer += "-M versatilepb ";
				this.KqemuAllowed = false;
				break;
			case Platforms.ARM_versatileab:
				buffer += "-M versatileab ";
				this.KqemuAllowed = false;
				break;
			case Platforms.PPC_g3bw:
				buffer += "-M g3bw ";
				this.KqemuAllowed = false;
				break;
			case Platforms.PPC_mac99:
				buffer += "-M mac99 ";
				this.KqemuAllowed = false;
				break;
			case Platforms.PPC_prep:
				buffer += "-M prep ";
				this.KqemuAllowed = false;
				break;
			}
			bool kqemuAllowed = this.KqemuAllowed;
			if (kqemuAllowed)
			{
				bool kqemu = this.KQEmu;
				if (kqemu)
				{
					buffer += "-kernel-kqemu ";
				}
				else
				{
					buffer += "-no-kqemu ";
				}
			}
			string bootFrom = this.BootFrom;
			string a = bootFrom;
			if (!(a == "Floppy"))
			{
				if (!(a == "Harddisk"))
				{
					if (a == "CD-ROM")
					{
						buffer += "-boot d ";
					}
				}
				else
				{
					buffer += "-boot c ";
				}
			}
			else
			{
				buffer += "-boot a ";
			}
			return buffer;
		}

		[XmlElement("Machine")]
		public Platforms Machine;

		[XmlElement("Memory")]
		public int Memory;

		[XmlElement("CPUs")]
		public int CPUs;

		[XmlElement("BootFrom")]
		public string BootFrom;

		[XmlElement("SetClock")]
		public bool SetClock;

		[XmlElement("Fullscreen")]
		public bool Fullscreen;

		[XmlElement("VGA")]
		public bool VGA;

		[XmlElement("KQEmu")]
		public bool KQEmu;

		[XmlElement("ACPI")]
		public bool ACPI;

		private bool KqemuAllowed = false;
	}
}
