﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace QemuDotNet
{
	public class Harddisks
	{
		public Harddisks()
		{
			for (int i = 0; i < 4; i++)
			{
				this.m_HardDisks[i] = new Drive();
			}
		}

		public override string ToString()
		{
			string buffer = "";
			//string FilePath = "";
			//Uri uriFilePath = new Uri("file://");
			for (int i = 0; i < 4; i++)
			{
				bool flag = this.HDD[i].Enabled && this.HDD[i].Path.Length > 0;
				if (flag)
				{
					buffer = string.Concat(new string[]
					{
						buffer,
						"-hd",
						Convert.ToChar(97 + i).ToString(),
						" \"",
						this.HDD[i].Path,
						/*
						"-drive format=",
						this.HDD[i].Path.ToString().Split('.')[1],
						",file=",
						"\"",
						FilePath = "",//uriFilePath + this.HDD[i].Path.ToString() + Regex.Replace(FilePath, "\"", "//"),
						*/
						"\" "
					});
				}
			}
			return buffer;
		}

		[XmlElement("Harddisk")]
		public Drive[] HDD
		{
			get
			{
				return this.m_HardDisks;
			}
			set
			{
				this.m_HardDisks = value;
			}
		}

		private Drive[] m_HardDisks = new Drive[4];
	}
}
