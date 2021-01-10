using System;

namespace QemuDotNet
{
	public abstract class VLan
	{
		public abstract override string ToString();

		public VLan()
		{
		}

		public int vlan;
	}
}
