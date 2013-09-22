using System;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace MiCalc
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
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
									return Assembly.Load((byte[])resource.Value);
							}
						}
					}
					return null;
				};

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new fMain());
		}
	}
}
