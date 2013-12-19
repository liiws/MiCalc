using System;
using System.Globalization;
using System.Text;
using System.Threading;
using BigNum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MiCalc.Tests
{
	[TestClass]
	public class UnitTest1
	{
		private double _maxError = 1.0e-10;



		public UnitTest1()
		{
			Program.SetCultures();
		}



		private double GetResult(string expression, bool isRadians = false, bool isHideDigits = false)
		{
			return double.Parse(MiCalc.Runtime.CalcHelper.GetAsDecimal(GetResultAsBigFloat(expression, isRadians, isHideDigits)));
		}

		private BigFloat GetResultAsBigFloat(string expression, bool isRadians = false, bool isHideDigits = false)
		{
			MiCalc.Runtime.CalcHelper.IsRadians = isRadians;
			MiCalc.Runtime.CalcHelper.IsHideDigits = isHideDigits;

			using (var ms = new System.IO.MemoryStream())
			{
				var data = Encoding.ASCII.GetBytes(expression);
				ms.Write(data, 0, expression.Length);
				ms.Position = 0L;

				var scanner = new Analyzing.Scanner(ms);
				var parser = new Analyzing.Parser(scanner);
				parser.Parse();

				var result = parser.expression.Calc();

				return result;
			}
		}

		[TestMethod]
		public void Number()
		{
			var input = "123";
			var result = GetResult(input);
			Assert.AreEqual(result, 123);
		}

		[TestMethod]
		public void NumberFloat()
		{
			var input = "0.5";
			var result = GetResult(input);
			Assert.AreEqual(result, 0.5);
		}

		[TestMethod]
		public void NumberExp()
		{
			var input = "123e1";
			var result = GetResult(input);
			Assert.AreEqual(result, 1230);
		}

		[TestMethod]
		public void NegativeNumber()
		{
			var input = "-123";
			var result = GetResult(input);
			Assert.AreEqual(result, -123);
		}

		[TestMethod]
		public void NumberBin()
		{
			var input = "11b";
			var result = GetResult(input);
			Assert.AreEqual(result, 3);
		}

		[TestMethod]
		public void NumberHex()
		{
			var input = "1Fh";
			var result = GetResult(input);
			Assert.AreEqual(result, 15+16);
		}

		[TestMethod]
		public void Add()
		{
			var input = "1+2";
			var result = GetResult(input);
			Assert.AreEqual(3, result);
		}

		[TestMethod]
		public void Sub()
		{
			var input = "1-2";
			var result = GetResult(input);
			Assert.AreEqual(-1, result);
		}

		[TestMethod]
		public void AddUnaryMinus()
		{
			var input = "1+-2";
			var result = GetResult(input);
			Assert.AreEqual(-1, result);
		}

		[TestMethod]
		public void AddUnaryPlus()
		{
			var input = "1++2";
			var result = GetResult(input);
			Assert.AreEqual(3, result);
		}

		[TestMethod]
		public void SubUnaryMinus()
		{
			var input = "1--2";
			var result = GetResult(input);
			Assert.AreEqual(3, result);
		}

		[TestMethod]
		public void SubUnaryPlus()
		{
			var input = "1-+2";
			var result = GetResult(input);
			Assert.AreEqual(-1, result);
		}

		[TestMethod]
		public void Mul()
		{
			var input = "3*4";
			var result = GetResult(input);
			Assert.AreEqual(12, result);
		}

		[TestMethod]
		public void Div()
		{
			var input = "3/4";
			var result = GetResult(input);
			Assert.AreEqual(3f/4, result);
		}

		[TestMethod]
		public void MulUnaryMinus()
		{
			var input = "3*-4";
			var result = GetResult(input);
			Assert.AreEqual(-12, result);
		}

		[TestMethod]
		public void DivUnaryMinus()
		{
			var input = "3/-4";
			var result = GetResult(input);
			Assert.AreEqual(-3f/4, result);
		}

		[TestMethod]
		public void AddMul()
		{
			var input = "2+3*4";
			var result = GetResult(input);
			Assert.AreEqual(14, result);
		}

		[TestMethod]
		public void SubDiv()
		{
			var input = "2-3/4";
			var result = GetResult(input);
			Assert.AreEqual(2-3f/4, result);
		}

		[TestMethod]
		public void MulAdd()
		{
			var input = "2*3+4";
			var result = GetResult(input);
			Assert.AreEqual(10, result);
		}

		[TestMethod]
		public void Mod()
		{
			var input = "7%3";
			var result = GetResult(input);
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void And()
		{
			var input = "5&3";
			var result = GetResult(input);
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void Or()
		{
			var input = "5|3";
			var result = GetResult(input);
			Assert.AreEqual(7, result);
		}

		[TestMethod]
		public void Not()
		{
			var input = "~-2";
			var result = GetResult(input);
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void Xor()
		{
			var input = "5:3";
			var result = GetResult(input);
			Assert.AreEqual(6, result);
		}

		[TestMethod]
		public void Rsh()
		{
			var input = "2>>1";
			var result = GetResult(input);
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void Lsh()
		{
			var input = "2<<1";
			var result = GetResult(input);
			Assert.AreEqual(4, result);
		}

		[TestMethod]
		public void Brackets()
		{
			var input = "(2+3)*4";
			var result = GetResult(input);
			Assert.AreEqual(20, result);
		}

		[TestMethod]
		public void Space()
		{
			var input = "3 + 4";
			var result = GetResult(input);
			Assert.AreEqual(7, result);
		}

		[TestMethod]
		public void Spaces()
		{
			var input = "3   + 4";
			var result = GetResult(input);
			Assert.AreEqual(7, result);
		}

		[TestMethod]
		public void Tab()
		{
			var input = "3+\t4";
			var result = GetResult(input);
			Assert.AreEqual(7, result);
		}

		[TestMethod]
		public void Pi()
		{
			var input = "pi";
			var result = GetResult(input);
			Assert.AreEqual(Math.PI, result);
		}

		[TestMethod]
		public void E()
		{
			var input = "e";
			var result = GetResult(input);
			Assert.AreEqual(Math.E, result);
		}

		[TestMethod]
		public void Floor1()
		{
			var input = "floor(2.3)";
			var result = GetResult(input);
			Assert.AreEqual(2.0, result);
		}

		[TestMethod]
		public void Floor2()
		{
			var input = "floor(2.7)";
			var result = GetResult(input);
			Assert.AreEqual(2.0, result);
		}

		[TestMethod]
		public void Floor3()
		{
			var input = "floor(-2.3)";
			var result = GetResult(input);
			Assert.AreEqual(-3.0, result);
		}

		[TestMethod]
		public void Floor4()
		{
			var input = "floor(-2.7)";
			var result = GetResult(input);
			Assert.AreEqual(-3.0, result);
		}

		[TestMethod]
		public void Floor5()
		{
			var input = "floor(1)";
			var result = GetResult(input);
			Assert.AreEqual(1.0, result);
		}

		[TestMethod]
		public void Floor6()
		{
			var input = "floor(-1)";
			var result = GetResult(input);
			Assert.AreEqual(-1.0, result);
		}

		[TestMethod]
		public void Ceil1()
		{
			var input = "ceil(2.3)";
			var result = GetResult(input);
			Assert.AreEqual(3.0, result);
		}

		[TestMethod]
		public void Ceil2()
		{
			var input = "ceil(2.7)";
			var result = GetResult(input);
			Assert.AreEqual(3.0, result);
		}

		[TestMethod]
		public void Ceil3()
		{
			var input = "ceil(-2.3)";
			var result = GetResult(input);
			Assert.AreEqual(-2.0, result);
		}

		[TestMethod]
		public void Ceil4()
		{
			var input = "ceil(-2.7)";
			var result = GetResult(input);
			Assert.AreEqual(-2.0, result);
		}

		[TestMethod]
		public void Ceil5()
		{
			var input = "ceil(1)";
			var result = GetResult(input);
			Assert.AreEqual(1.0, result);
		}

		[TestMethod]
		public void Ceil6()
		{
			var input = "ceil(-1)";
			var result = GetResult(input);
			Assert.AreEqual(-1.0, result);
		}

		[TestMethod]
		public void Round1()
		{
			var input = "round(2.3)";
			var result = GetResult(input);
			Assert.AreEqual(2.0, result);
		}

		[TestMethod]
		public void Round2()
		{
			var input = "round(2.7)";
			var result = GetResult(input);
			Assert.AreEqual(3.0, result);
		}

		[TestMethod]
		public void Round3()
		{
			var input = "round(-2.3)";
			var result = GetResult(input);
			Assert.AreEqual(-2.0, result);
		}

		[TestMethod]
		public void Round4()
		{
			var input = "round(-2.7)";
			var result = GetResult(input);
			Assert.AreEqual(-3.0, result);
		}

		[TestMethod]
		public void Round5()
		{
			var input = "round(1)";
			var result = GetResult(input);
			Assert.AreEqual(1.0, result);
		}

		[TestMethod]
		public void Round6()
		{
			var input = "round(-1)";
			var result = GetResult(input);
			Assert.AreEqual(-1.0, result);
		}

		[TestMethod]
		public void Pow()
		{
			var input = "2^8";
			var result = GetResult(input);
			Assert.AreEqual(256, result);
		}

		[TestMethod]
		public void Fac()
		{
			var input = "4!";
			var result = GetResult(input);
			Assert.AreEqual(1*2*3*4, result);
		}

		[TestMethod]
		public void Sin1()
		{
			var input = "sin(30)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Abs(0.5 - result) < _maxError);
			Assert.AreEqual(0.5, result);
		}

		[TestMethod]
		public void Sin2()
		{
			var input = "sin(60)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Abs(Math.Sin(Math.PI*60.0/180.0) - result) < _maxError);
		}

		[TestMethod]
		public void Sin3()
		{
			var input = "sin(90)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Abs(1.0 - result) < _maxError);
		}

		[TestMethod]
		public void Cos1()
		{
			var input = "cos(30)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Abs(Math.Cos(Math.PI*30.0/180.0) - result) < _maxError);
		}

		[TestMethod]
		public void Cos2()
		{
			var input = "cos(60)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Abs(0.5 - result) < _maxError);
		}

		[TestMethod]
		public void Cos3()
		{
			var input = "cos(90)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Abs(0.0 - result) < _maxError);
		}

		[TestMethod]
		public void Tan1()
		{
			var input = "tan(45)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Abs(1.0 - result) < _maxError);
		}

		[TestMethod]
		public void Asin1()
		{
			var input = "asin(0.5)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Abs(30.0 - result) < _maxError);
		}

		[TestMethod]
		public void Acos1()
		{
			var input = "acos(0.5)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Abs(60.0 - result) < _maxError);
		}

		[TestMethod]
		public void Atan1()
		{
			var input = "atan(1)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Abs(45.0 - result) < _maxError);
		}

		[TestMethod]
		public void Sinh1()
		{
			var input = "sinh(1)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Sinh(Math.Sinh(1) - result) < _maxError);
		}

		[TestMethod]
		public void Cosh1()
		{
			var input = "cosh(1)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Abs(Math.Cosh(1) - result) < _maxError);
		}

		[TestMethod]
		public void Tanh1()
		{
			var input = "tanh(1)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Abs(Math.Tanh(1) - result) < _maxError);
		}

		[TestMethod]
		public void Asinh1()
		{
			var input = "asinh(2)";
			var result = GetResult(input);
			var expected = Math.Log(2 + Math.Sqrt(2*2 + 1));
			Assert.IsTrue(Math.Abs(expected - result) < _maxError);
		}

		[TestMethod]
		public void Acosh1()
		{
			var input = "acosh(2)";
			var result = GetResult(input);
			var expected = Math.Log(2 + Math.Sqrt(2*2 - 1));
			Assert.IsTrue(Math.Abs(expected - result) < _maxError);
		}

		[TestMethod]
		public void Atanh1()
		{
			var input = "atanh(0.5)";
			var result = GetResult(input);
			var expected = Math.Log(Math.Sqrt((1.0+0.5)/(1.0-0.5)));
			Assert.IsTrue(Math.Abs(expected - result) < _maxError);
		}

		[TestMethod]
		public void Ln1()
		{
			var input = "ln(5)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Abs(Math.Log(5) - result) < _maxError);
		}

		[TestMethod]
		public void Lg1()
		{
			var input = "lg(5)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Abs(Math.Log10(5) - result) < _maxError);
		}

		[TestMethod]
		public void Exp1()
		{
			var input = "exp(5)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Abs(Math.Exp(5) - result) < _maxError);
		}

		[TestMethod]
		public void Sqrt1()
		{
			var input = "sqrt(5)";
			var result = GetResult(input);
			Assert.IsTrue(Math.Abs(Math.Sqrt(5) - result) < _maxError);
		}

		[TestMethod]
		public void GetAsDecimal1()
		{
			var input = "123";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsDecimal(result);
			Assert.AreEqual("123", s);
		}

		[TestMethod]
		public void GetAsDecimal2()
		{
			var input = "-123";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsDecimal(result);
			Assert.AreEqual("-123", s);
		}

		[TestMethod]
		public void GetAsDecimal3()
		{
			var input = "123.456";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsDecimal(result);
			Assert.AreEqual("123.456", s);
		}

		[TestMethod]
		public void GetAsDecimal4()
		{
			var input = "-123.456";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsDecimal(result);
			Assert.AreEqual("-123.456", s);
		}

		[TestMethod]
		public void GetAsDecimal5()
		{
			var input = "0.123";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsDecimal(result);
			Assert.AreEqual("0.123", s);
		}

		[TestMethod]
		public void GetAsDecimal6()
		{
			var input = "-0.123";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsDecimal(result);
			Assert.AreEqual("-0.123", s);
		}

		[TestMethod]
		public void GetAsDecimal7()
		{
			var input = "2^64";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsDecimal(result);
			Assert.AreEqual("18446744073709551616", s);
		}

		[TestMethod]
		public void GetAsDecimal8()
		{
			var input = "2^64-1";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsDecimal(result);
			Assert.AreEqual("18446744073709551615", s);
		}

		[TestMethod]
		public void GetAsScience1()
		{
			var input = "123";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsScience(result);
			Assert.AreEqual("1.23e2", s);
		}

		[TestMethod]
		public void GetAsScience2()
		{
			var input = "-123";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsScience(result);
			Assert.AreEqual("-1.23e2", s);
		}

		[TestMethod]
		public void GetAsScience3()
		{
			var input = "123.456";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsScience(result);
			Assert.AreEqual("1.23456e2", s);
		}

		[TestMethod]
		public void GetAsScience4()
		{
			var input = "-123.456";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsScience(result);
			Assert.AreEqual("-1.23456e2", s);
		}

		[TestMethod]
		public void GetAsScience5()
		{
			var input = "0.123";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsScience(result);
			Assert.AreEqual("1.23e-1", s);
		}

		[TestMethod]
		public void GetAsScience6()
		{
			var input = "-0.123";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsScience(result);
			Assert.AreEqual("-1.23e-1", s);
		}

		[TestMethod]
		public void GetAsHex1()
		{
			var input = "2^64-1";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsHex(result);
			Assert.AreEqual("FFFFFFFF FFFFFFFF", s);
		}

		[TestMethod]
		public void GetAsHex2()
		{
			var input = "2^64-2";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsHex(result);
			Assert.AreEqual("FFFFFFFF FFFFFFFE", s);
		}

		[TestMethod]
		public void GetAsHex3()
		{
			var input = "-1";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsHex(result);
			Assert.AreEqual("FFFFFFFF FFFFFFFF", s);
		}

		[TestMethod]
		public void GetAsBin1()
		{
			var input = "2^64-1";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsBin(result);
			Assert.AreEqual("11111111 11111111 11111111 11111111 11111111 11111111 11111111 11111111", s);
		}

		[TestMethod]
		public void GetAsBin2()
		{
			var input = "2^64-2";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsBin(result);
			Assert.AreEqual("11111111 11111111 11111111 11111111 11111111 11111111 11111111 11111110", s);
		}

		[TestMethod]
		public void GetAsBin3()
		{
			var input = "-1";
			var result = GetResultAsBigFloat(input);
			var s = Runtime.CalcHelper.GetAsBin(result);
			Assert.AreEqual("11111111 11111111 11111111 11111111 11111111 11111111 11111111 11111111", s);
		}
	}
}
