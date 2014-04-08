using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace MiCalc
{
	public static class Program
	{
		private static int _minWidth = 400;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// to not depend on system decimal symbol
			SetCultures();

			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainOnAssemblyResolve;

			Settings.Settings.LoadSettings();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var f = new fMain();
			SetWindowDumensions(f);
			Application.Run(f);
		}

		private static Assembly CurrentDomainOnAssemblyResolve(object sender, ResolveEventArgs args)
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

		private static void SetWindowDumensions(Form f)
		{
			// hide caption
			f.ControlBox = false;
			f.Text = string.Empty;

			// restore window position
			f.StartPosition = FormStartPosition.Manual;
			f.Location = Settings.Settings.GetWindowPosition();

			// restore window size
			f.Size = new Size(Settings.Settings.GetWindowSize().Width, f.Size.Height - SystemInformation.CaptionHeight);

			// set form size limits
			var minSize = new Size(_minWidth, f.Size.Height);
			var maxSize = new Size(int.MaxValue, f.Size.Height);
			f.MinimumSize = minSize;
			f.MaximumSize = maxSize;

			f.TopMost = Settings.Settings.GetAlwaysOnTop();
		}
	}
}
