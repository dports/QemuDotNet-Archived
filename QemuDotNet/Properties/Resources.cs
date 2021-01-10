using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace QemuDotNet.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		internal Resources()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager temp = new ResourceManager("QemuDotNet.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = temp;
				}
				return Resources.resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		internal static Bitmap advanced
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("advanced", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap audio
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("audio", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap cdrom
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("cdrom", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap copy
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("copy", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap debug
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("debug", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap harddisk
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("harddisk", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap launch
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("launch", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap machine
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("machine", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap MainSaveIcon
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("MainSaveIcon", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap memory
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("memory", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap mount
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("mount", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap network
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("network", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap power
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("power", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap preferences_system
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("preferences_system", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap save
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("save", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap screenshot
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("screenshot", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap snapshot
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("snapshot", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap stop
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("stop", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;
	}
}
