using System;

namespace QemuDotNet
{
	public class VNic : VLan
	{
		public VNic()
		{
		}

		public VNic(string mac, NicModel mod)
		{
			this.macAddress = mac;
			this._NicModel = mod;
		}

		public override string ToString()
		{
			bool flag = this.macAddress != "";
			string result;
			if (flag)
			{
				result = string.Concat(new string[]
				{
					"-nic -net vlan=",
					this.vlan.ToString(),
					",macaddr=",
					this.macAddress,
					",model=",
					this._NicModel.ToString(),
					" "
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"-nic -net vlan=",
					this.vlan.ToString(),
					",model=",
					this._NicModel.ToString(),
					" "
				});
			}
			return result;
		}

		public string macAddress;

		public NicModel _NicModel;
	}
}
