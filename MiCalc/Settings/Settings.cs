using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MiCalc.Settings
{
	public static class Settings
	{
		private static string _configFilename = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "micalc.cfg");
		private static InternalSettings _settingInstance = new InternalSettings();

		public static readonly Point DefaultWndLocation = new Point(400, 400);
		public static readonly Size DefaultWndSize = new Size(550, 0);

		[Serializable]
		public class InternalSettings
		{
			public Point WndLocation { get; set; }
			public Size WndSize { get; set; }
			public bool AlwaysOnTop { get; set; }
			public string Expression { get; set; }
			public bool IsRadians { get; set; }
			public bool IsHideDigits { get; set; }
		}

		public static void LoadSettings()
		{
			try
			{
				using (var reader = XmlReader.Create(_configFilename))
				{
					_settingInstance = (InternalSettings)(new XmlSerializer(typeof(InternalSettings)).Deserialize(reader));
				}
			}
			catch
			{
				// default settings
				_settingInstance.WndLocation = DefaultWndLocation;
				_settingInstance.WndSize = DefaultWndSize;
				_settingInstance.AlwaysOnTop = false;
				_settingInstance.Expression = string.Empty;
				_settingInstance.IsRadians = false;
				_settingInstance.IsHideDigits = false;

				SaveSettings();
			}
		}

		public static void SaveSettings()
		{
			try
			{
				using (var writer = XmlWriter.Create(_configFilename, new XmlWriterSettings() { Indent = true, NewLineChars = "\r\n" }))
				{
					new XmlSerializer(typeof(InternalSettings)).Serialize(writer, _settingInstance);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error saving settings:\n\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		public static Point GetWindowPosition()
		{
			return _settingInstance.WndLocation;
		}

		public static void SetWindowLocation(Point location)
		{
			_settingInstance.WndLocation = location;
		}

		public static Size GetWindowSize()
		{
			return _settingInstance.WndSize;
		}

		public static void SetWindowSize(Size size)
		{
			_settingInstance.WndSize = size;
		}

		public static bool GetAlwaysOnTop()
		{
			return _settingInstance.AlwaysOnTop;
		}

		public static void SetAlwaysOnTop(bool alwaysOnTop)
		{
			_settingInstance.AlwaysOnTop = alwaysOnTop;
		}

		public static string GetCalculationExpression()
		{
			return _settingInstance.Expression;
		}

		public static void SetCalculationExpression(string expression)
		{
			_settingInstance.Expression = expression.Trim();
		}

		public static bool GetCalculationIsRadians()
		{
			return _settingInstance.IsRadians;
		}

		public static void SetCalculationIsRadians(bool isRadians)
		{
			_settingInstance.IsRadians = isRadians;
		}

		public static bool GetCalculationIsHideDigits()
		{
			return _settingInstance.IsHideDigits;
		}

		public static void SetCalculationIsHideDigits(bool isHideDigits)
		{
			_settingInstance.IsHideDigits = isHideDigits;
		}
	}
}
