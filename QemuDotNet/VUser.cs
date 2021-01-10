using System;

namespace QemuDotNet
{
	public class VUser : VLan
	{
		public VUser()
		{
		}

		public VUser(string host, int vl)
		{
			this.hostname = host;
			this.vlan = vl;
		}

		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"-net user,-net vlan=",
				this.vlan.ToString(),
				",hostname=",
				this.hostname,
				" "
			});
		}

		public string hostname;
	}
}
