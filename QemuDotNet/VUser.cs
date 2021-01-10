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
				"-netdev user,id=n0,hostname=",
				this.hostname,
				" "
			});
		}

		public string hostname;
	}
}
