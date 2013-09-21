using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BigNum;
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
		private int _defWidth = 710;

		private bool _isWindowMoving = false;
		private int _movingX;
		private int _movingY;


		public fMain()
		{
			InitializeComponent();
		}

		private void fMain_Load(object sender, EventArgs e)
		{
			// hide caption
			ControlBox = false;
			Text = string.Empty;

			// set form size limits
			var defSize = new Size(_defWidth, Size.Height);
			var minSize = new Size(_minWidth, Size.Height);
			var maxSize = new Size(int.MaxValue, Size.Height);
			Size = defSize;
			MinimumSize = minSize;
			MaximumSize = maxSize;

			// set button images
			ubClose.Image = Resources.icon_wnd_close.ToBitmap();
			ubCopy.Image = Resources.icon_copy.ToBitmap();
			ubDegrees.Image = Resources.icon_degrees.ToBitmap();
			ubFunctions.Image = Resources.icon_functions.ToBitmap();
			ubMinimize.Image = Resources.icon_wnd_min.ToBitmap();
			ubOnTop.Image = Resources.icon_wnd_normal.ToBitmap();
			ubPaste.Image = Resources.icon_paste.ToBitmap();
			ubQuestion.Image = Resources.icon_question.ToBitmap();


			CalcResult();
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

		}

		private void ubOnTop_Click(object sender, EventArgs e)
		{
			TopMost = !TopMost;
			ubOnTop.Image = TopMost ? Resources.icon_wnd_ontop.ToBitmap() : Resources.icon_wnd_normal.ToBitmap();
		}

		private void ubCopy_Click(object sender, EventArgs e)
		{
			//tbDecimal.Text
		}

		private void ubPaste_Click(object sender, EventArgs e)
		{
			//rtbExpression.Text
		}

		private void ubDegrees_Click(object sender, EventArgs e)
		{
			CalcHelper.IsRadians = !CalcHelper.IsRadians;
			ubDegrees.Image = CalcHelper.IsRadians ? Resources.icon_radians.ToBitmap() : Resources.icon_degrees.ToBitmap();
			CalcResult();
		}

		private void ubFunctions_Click(object sender, EventArgs e)
		{

		}

		private void rtbExpression_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Escape)
			{
				rtbExpression.Text = string.Empty;
				e.Handled = true;
			}
		}

	}
}
