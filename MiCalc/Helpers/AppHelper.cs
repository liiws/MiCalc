using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace MiCalc.Helpers
{
	static class AppHelper
	{
		public static CultureInfo DisplayCulture;

		static AppHelper()
		{
			DisplayCulture = new CultureInfo("en-US");
			DisplayCulture.NumberFormat.NumberDecimalSeparator = ".";
			DisplayCulture.NumberFormat.PercentDecimalSeparator = ".";
			DisplayCulture.NumberFormat.CurrencyDecimalSeparator = ".";
			DisplayCulture.NumberFormat.NumberGroupSeparator = string.Empty;
			DisplayCulture.NumberFormat.PercentGroupSeparator = string.Empty;
			DisplayCulture.NumberFormat.CurrencyGroupSeparator = string.Empty;
		}

		public static void SetProcessCulture()
		{
			Thread.CurrentThread.CurrentCulture = DisplayCulture;
			Thread.CurrentThread.CurrentUICulture = DisplayCulture;
			CultureInfo.DefaultThreadCurrentCulture = DisplayCulture;
			CultureInfo.DefaultThreadCurrentUICulture = DisplayCulture;
		}


		#region Assembly Attribute Accessors
		public static string AssemblyTitle
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "")
					{
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public static string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}
		
		public static string AssemblyCopyright
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		#endregion

	}
}
