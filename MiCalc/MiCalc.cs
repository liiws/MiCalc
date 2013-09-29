using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BigNum;
using MiCalc.Forms;
using MiCalc.Properties;
using MiCalc.Runtime;

namespace MiCalc
{
	public partial class fMain : Form
	{
		private Color _bgColorNormal = Color.FromArgb(255, 255, 255);
		private Color _bgColorError = Color.FromArgb(255, 225, 225);
		//private Color _bgColorError = Color.FromArgb(255, 240, 240);
		private Color _fgColorNormal = Color.FromArgb(0, 0, 0);
		private Color _fgColorError = Color.FromArgb(255, 32, 32);


		private int _minWidth = 400;

		private bool _isWindowMoving = false;
		private int _movingX;
		private int _movingY;


		public fMain()
		{
			InitializeComponent();

			Settings.Settings.LoadSettings();
		}

		private void fMain_Load(object sender, EventArgs e)
		{
			// hide caption
			ControlBox = false;
			Text = string.Empty;

			// restore window position
			Location = Settings.Settings.GetWindowPosition();

			// restore window size
			Size = new Size(Settings.Settings.GetWindowSize().Width, Size.Height);

			// set form size limits
			var minSize = new Size(_minWidth, Size.Height);
			var maxSize = new Size(int.MaxValue, Size.Height);
			MinimumSize = minSize;
			MaximumSize = maxSize;

			SetOnTop(Settings.Settings.GetAlwaysOnTop());

			// set button images
			ubClose.Image = Resources.icon_wnd_close.ToBitmap();
			ubCopy.Image = Resources.icon_copy.ToBitmap();
			ubDegrees.Image = Resources.icon_degrees.ToBitmap();
			ubFunctions.Image = Resources.icon_functions.ToBitmap();
			ubMinimize.Image = Resources.icon_wnd_min.ToBitmap();
			ubOnTop.Image = Resources.icon_wnd_normal.ToBitmap();
			ubPaste.Image = Resources.icon_paste.ToBitmap();
			ubQuestion.Image = Resources.icon_question.ToBitmap();

			// tooltips
			new ToolTip().SetToolTip(ubClose, "Close the program");
			new ToolTip().SetToolTip(ubCopy, "Copy decimal result to clipboard");
			new ToolTip().SetToolTip(ubDegrees, "Set trigonometric functions unit");
			new ToolTip().SetToolTip(ubFunctions, "List of available functions and operators");
			new ToolTip().SetToolTip(ubMinimize, "Minimize window");
			new ToolTip().SetToolTip(ubOnTop, "Set always on top");
			new ToolTip().SetToolTip(ubPaste, "Paste from clipboard");
			new ToolTip().SetToolTip(ubQuestion, "About");
			new ToolTip().SetToolTip(lHex, "64-bit signed hexadecimal value");
			new ToolTip().SetToolTip(lBin, "64-bit signed binary value");

			rtbExpression.AutoWordSelection = false;

			// restore calculation expression
			rtbExpression.Text = Settings.Settings.GetCalculationExpression();
		}

		private void rtbExpression_TextChanged(object sender, EventArgs e)
		{
			CalcResult();
		}

		private void CalcResult()
		{
			MakeInputNormal();

			var text = rtbExpression.Text.Trim();
			if (string.IsNullOrEmpty(text))
			{
				ShowResult(CalcHelper.GetZero(), null);
				return;
			}

			using (var ms = new MemoryStream())
			{
				var data = Encoding.UTF8.GetBytes(text);
				ms.Write(data, 0, text.Length);
				ms.Position = 0L;

				var scanner = new Analyzing.Scanner(ms);
				var parser = new Analyzing.Parser(scanner);
				parser.Parse();

				if (scanner.ErrorPos != null)
				{
					MakeInputError(scanner.ErrorPos.Value < text.Length ? scanner.ErrorPos.Value : text.Length - 1);
					ShowResult(null, null);
					return;
				}


				string errorMessage = null;

				try
				{
					var result = parser.expression.Calc();
					ShowResult(result, null);
					return;
				}
				catch (DivideByZeroException)
				{
					errorMessage = "Divide by zero";
				}
				catch (Exception ex)
				{
					errorMessage = ex.Message;
				}

				ShowResult(null, errorMessage);
			}
		}

		private void MakeInputNormal()
		{
			var cursorPos = rtbExpression.SelectionStart;

			rtbExpression.BackColor = _bgColorNormal;
			rtbExpression.SelectAll();
			rtbExpression.SelectionColor = _fgColorNormal;

			rtbExpression.Select(cursorPos, 0);
		}

		private void MakeInputError(int? pos)
		{
			var cursorPos = rtbExpression.SelectionStart;

			rtbExpression.BackColor = _bgColorError;
			if (pos.HasValue)
			{
				rtbExpression.Select(pos.Value, 1);
				rtbExpression.SelectionColor = _fgColorError;
			}

			rtbExpression.Select(cursorPos, 0);
		}

		/// <summary>
		/// Set ErrorMessage to null if no error.
		/// </summary>
		/// <param name="result"></param>
		/// <param name="errorMessage"></param>
		private void ShowResult(BigFloat result, string errorMessage)
		{
			if (result != null && errorMessage == null)
			{
				tbDecimal.Text = CalcHelper.GetAsDecimal(result);
				tbScience.Text = CalcHelper.GetAsScience(result);
				tbHex.Text = CalcHelper.GetAsHex(result);
				tbBin.Text = CalcHelper.GetAsBin(result);
			}
			else
			{
				if (string.IsNullOrEmpty(errorMessage))
				{
					errorMessage = "Error";
				}
				MakeInputError(null);
				tbDecimal.Text = errorMessage;
				tbScience.Text = errorMessage;
				tbHex.Text = errorMessage;
				tbBin.Text = errorMessage;
			}
		}

		private void fMain_MouseDown(object sender, MouseEventArgs e)
		{
			_isWindowMoving = true;
			_movingX = e.X;
			_movingY = e.Y;
		}

		private void fMain_MouseUp(object sender, MouseEventArgs e)
		{
			_isWindowMoving = false;
		}

		private void fMain_MouseMove(object sender, MouseEventArgs e)
		{
			if (!_isWindowMoving)
			{
				return;
			}

			Left += e.X - _movingX;
			Top += e.Y - _movingY;
		}

		private void ubClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ubMinimize_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}

		private void ubQuestion_Click(object sender, EventArgs e)
		{
			var form = new fAbout();
			form.ShowDialog();
		}

		private void ubOnTop_Click(object sender, EventArgs e)
		{
			SetOnTop(!TopMost);
		}

		private void SetOnTop(bool onTop)
		{
			TopMost = onTop;
			ubOnTop.Image = onTop ? Resources.icon_wnd_ontop.ToBitmap() : Resources.icon_wnd_normal.ToBitmap();
		}

		private void ubCopy_Click(object sender, EventArgs e)
		{
			try
			{
				Clipboard.SetText(tbDecimal.Text);
			}
			catch (System.Runtime.InteropServices.ExternalException)
			{
				MessageBox.Show(
					"Error copying text to the clipboard. Try to close all programs that can block clipboard (like PuntoSwitcher).",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);
			}
		}

		private void ubPaste_Click(object sender, EventArgs e)
		{
			var cbText = Clipboard.GetText();
			var s = rtbExpression.Text;
			if (rtbExpression.SelectionLength > 0)
			{
				s = s.Remove(rtbExpression.SelectionStart, rtbExpression.SelectionLength);
			}
			s = s.Insert(rtbExpression.SelectionStart, cbText);
			rtbExpression.Text = s;
			rtbExpression.SelectionStart = rtbExpression.SelectionStart + cbText.Length;
			rtbExpression.SelectionLength = 0;
		}

		private void ubDegrees_Click(object sender, EventArgs e)
		{
			CalcHelper.IsRadians = !CalcHelper.IsRadians;
			ubDegrees.Image = CalcHelper.IsRadians ? Resources.icon_radians.ToBitmap() : Resources.icon_degrees.ToBitmap();
			CalcResult();
		}

		private void ubFunctions_Click(object sender, EventArgs e)
		{
			var form = new fFunctions();
			form.ShowDialog();
		}

		private void rtbExpression_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Escape)
			{
				rtbExpression.Text = string.Empty;
				e.Handled = true;
			}
		}

		private void fMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			Settings.Settings.SetWindowLocation(Location);
			Settings.Settings.SetWindowSize(Size);
			Settings.Settings.SetAlwaysOnTop(TopMost);
			Settings.Settings.SetCalculationExpression(rtbExpression.Text);

			Settings.Settings.SaveSettings();
		}
	}
}
