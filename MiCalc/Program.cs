using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace MiCalc
{
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// to not depend on system decimal symbol
			SetCultures();

			AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
				{
					var requestedAssemblyName = new AssemblyName(args.Name).Name.Replace(".", "_");
					var manifestResourceName = new AssemblyName(Assembly.GetExecutingAssembly().FullName).Name +
					                           ".Properties.Resources.resources";
					using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(manifestResourceName))
					{
						using (var reader = new ResourceReader(stream))
						{
							var resource = reader.GetEnumerator();
							while (resource.MoveNext())
							{
								if ((string)resource.Key == requestedAssemblyName)
								{
									return Assembly.Load((byte[])resource.Value);
								}
							}
						}
					}
					return null;
				};

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new fMain());
		}

		public static void SetCultures()
		{
			var ci = new CultureInfo("en-US");
			ci.NumberFormat.NumberDecimalSeparator = ".";
			ci.NumberFormat.PercentDecimalSeparator = ".";
			ci.NumberFormat.CurrencyDecimalSeparator = ".";
			ci.NumberFormat.NumberGroupSeparator = string.Empty;
			ci.NumberFormat.PercentGroupSeparator = string.Empty;
			ci.NumberFormat.CurrencyGroupSeparator = string.Empty;

			Thread.CurrentThread.CurrentCulture = ci;
			Thread.CurrentThread.CurrentUICulture = ci;
		}
	}
}
