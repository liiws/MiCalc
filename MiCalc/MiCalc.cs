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




		public fMain()
		{
			InitializeComponent();
		}

		private void fMain_Load(object sender, EventArgs e)
		{
			//Icon = Resources.icon;

			var result = string.Empty;

			//var input = "1+2*3";
			//var input = "floor(2.3)";
			//var input = "(2+3)*4";
			//var input = "170!";
			//var input = "( 2 )";
			//using (var ms = new System.IO.MemoryStream())
			//{
			//	var data = Encoding.UTF8.GetBytes(input);
			//	ms.Write(data, 0, input.Length);
			//	ms.Position = 0L;

			//	var scanner = new Analyzing.Scanner(ms);
			//	var parser = new Analyzing.Parser(scanner);
			//	parser.Parse();

			//	result = parser.expression.Calc().ToString();

			//	rtbExpression.Text = result;

			//	rtbExpression.Text = "abcdefgh";
			//	rtbExpression.Select(1, 1);
			//	rtbExpression.SelectionColor = Color.Red;
			//	rtbExpression.SelectionFont = new Font(rtbExpression.SelectionFont, FontStyle.Bold);
			//	rtbExpression.BackColor = Color.FromArgb(255, 225, 225);
			//	rtbExpression.Select(1, 0);

			//	rtbExpression.RichTextShortcutsEnabled = false;
			//	//rtb1.
			//}


			//BigInteger bi = BigInteger.Parse(string.Join("", Enumerable.Repeat("5", 40000)));
			//result = bi.ToString();
			////BigInteger.
			//IntXLib.IntX ix = new IntX("101");
			//var ix2 = IntXLib.IntX.Pow(ix, 100);
			//result = ix2.ToString();

			//BigFloat bn = new BigNumDec("101.5");
			////var bn2 = W3b.Sine.BigMath.Pow(bn, 100);
			//var bn2 = BigFloatDec.Divide(new BigNumDec(bn.ToString()), new BigNumDec("3"));
			////var bn2 = BigFloatDec.Pi;
			//result = bn2.ToString();


			double d1 = Math.Exp(5.5);
			double d2 = Math.Exp(105.27);
			double d3 = Math.Exp(-105.27);
			double d4 = Math.Exp(1234567890.987);

			//BigNum n1 = new BigNumDec("5.5");
			//BigNum n2 = new BigNumDec("105.27");
			//BigNum n3 = new BigNumDec("-105.27");
			//BigNum n4 = new BigNumDec("1234567890.987");

			//var sw = new Stopwatch();
			//sw.Start();
			//var q1 = CalcE(n2);
			//var elapsed = sw.ElapsedMilliseconds;
			//var q2 = double.Parse(q1.ToString()) - d2;

			//MPCLI.Primality.

			//var qwe = 1/BigInteger.Pow(new BigInteger(15), 10);


			var q1 = BigFloat.RoundingMode;
			var q2 = BigFloat.RoundingDigits;

			var ps = new PrecisionSpec(128, new PrecisionSpec.BaseType());
			var n2 = new BigFloat("105.123456789", ps);
			//var n2 = new BN.BigFloat("105.27", ps);
			var n2c = n2;
			n2c.Exp();



			//textBox1.Text = result;

			var vrgvdgvdsg = 1;
		}


		//private BigFloat CalcE(BigFloat x)
		//{
		//	BigFloat result = new BigFloatDec(0);
		//	x = x - 104;

		//	BigFloat big = W3b.Sine.BigMath.Pow(CalcHelper.GetE(), 104);

		//	result += 1;
		//	result += x;

		//	for (int n = 2; n < 20; n++)
		//	{
		//		var xToN = W3b.Sine.BigMath.Pow(x, n);
		//		var xFac = new BigFloatDec("5.5");// BigMath.Factorial(new BigNumDec(n));
		//		result += xToN/xFac;
		//	}

		//	return result*big;
		//}





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
