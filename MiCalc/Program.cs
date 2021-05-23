using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using MiCalc.Helpers;

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
			SetWindowDimensions(f);
			Application.Run(f);
		}

		[SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
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
			AppHelper.SetProcessCulture();
		}

		private static void SetWindowDimensions(Form f)
		{
			// hide caption
			f.ControlBox = false;
			f.Text = string.Empty;

			// restore window position
			f.StartPosition = FormStartPosition.Manual;
			f.Location = Settings.Settings.GetWindowPosition();

			// restore window size
			f.Size = new Size(Settings.Settings.GetWindowSize().Width, f.Size.Height - SystemInformation.CaptionHeight);

			// correct window position if it's outside the screen
			FixWindowOutsidePosition(f);

			// set form size limits
			var minSize = new Size(_minWidth, f.Size.Height);
			var maxSize = new Size(int.MaxValue, f.Size.Height);
			f.MinimumSize = minSize;
			f.MaximumSize = maxSize;

			f.TopMost = Settings.Settings.GetAlwaysOnTop();
		}

		private static void FixWindowOutsidePosition(Form f)
		{
			var isInsideAnyScreen = Screen.AllScreens.Any(IsInsideScreen);
			if (!isInsideAnyScreen)
			{
				f.Location = new Point(Settings.Settings.DefaultWndLocation.X, Settings.Settings.DefaultWndLocation.Y);
				f.Size = new Size(Settings.Settings.DefaultWndSize.Width, f.Size.Height);
			}

			bool IsInsideScreen(Screen screen)
			{
				return f.Left >= screen.WorkingArea.X
					&& f.Top >= screen.WorkingArea.Y
					&& f.Left + f.Width <= screen.WorkingArea.X + screen.WorkingArea.Width
					&& f.Top + f.Height <= screen.WorkingArea.Y + screen.WorkingArea.Height;


			}
		}
	}
}
