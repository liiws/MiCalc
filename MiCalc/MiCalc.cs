using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
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



		public fMain()
		{
			InitializeComponent();
		}

		private void fMain_Load(object sender, EventArgs e)
		{
			// set form size limits
			var defSize = new Size(_defWidth, Size.Height);
			var minSize = new Size(_minWidth, Size.Height);
			var maxSize = new Size(int.MaxValue, Size.Height);
			Size = defSize;
			MinimumSize = minSize;
			MaximumSize = maxSize;

			// hide caption
			ControlBox = false;
			Text = string.Empty;
		}

		private void rtbExpression_TextChanged(object sender, EventArgs e)
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
				//MakeInputNormal();
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
				//MakeInputNormal();
				MakeInputError(null);
				tbDecimal.Text = errorMessage;
				tbScience.Text = errorMessage;
				tbHex.Text = errorMessage;
				tbBin.Text = errorMessage;
			}
		}

	}
}
