using System;
using System.Xml.Serialization;

namespace QemuDotNet
{
	public class Network
	{
		public Network()
		{
			this.VNicStrings = new string[1];
			this.Count = 0;
		}

		public void AddNetString(string lan)
		{
			this.Enabled = true;
			this.Count++;
			string[] temp = new string[this.Count];
			for (int i = 0; i < this.Count; i++)
			{
				bool flag = i == this.Count - 1;
				if (flag)
				{
					temp[i] = lan;
				}
				else
				{
					temp[i] = this.VNicStrings[i];
				}
			}
			this.VNicStrings = temp;
		}

		public string[] GetNetStrings()
		{
			return this.VNicStrings;
		}

		public override string ToString()
		{
			string buffer = "";
			foreach (string lan in this.VNicStrings)
			{
				buffer += lan;
			}
			return buffer;
		}

		[XmlAttribute("Enabled")]
		public bool Enabled;

		[XmlAttribute("Count")]
		public int Count;

		[XmlArray("VNicStrings")]
		[XmlArrayItem("VNicString")]
		public string[] VNicStrings;
	}
}
