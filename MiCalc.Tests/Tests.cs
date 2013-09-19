using System;
using System.Text;
using BigNum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MiCalc.Tests
{
	[TestClass]
	public class UnitTest1
	{
		private double GetResult(string expression)
		{
			using (var ms = new System.IO.MemoryStream())
			{
				var data = Encoding.ASCII.GetBytes(expression);
				ms.Write(data, 0, expression.Length);
				ms.Position = 0L;

				var scanner = new Analyzing.Scanner(ms);
				var parser = new Analyzing.Parser(scanner);
				parser.Parse();

				var result = parser.expression.Calc();

				return double.Parse(result.ToString());
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
		public void NegativeNumber()
		{
			var input = "-123";
			var result = GetResult(input);
			Assert.AreEqual(result, -123);
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
			Assert.AreEqual(2, result);
		}

		[TestMethod]
		public void Floor2()
		{
			var input = "floor(2.7)";
			var result = GetResult(input);
			Assert.AreEqual(2, result);
		}

		[TestMethod]
		public void Ceil1()
		{
			var input = "ceil(2.3)";
			var result = GetResult(input);
			Assert.AreEqual(3, result);
		}

		[TestMethod]
		public void Ceil2()
		{
			var input = "ceil(2.7)";
			var result = GetResult(input);
			Assert.AreEqual(3, result);
		}

		[TestMethod]
		public void Round1()
		{
			var input = "round(2.3)";
			var result = GetResult(input);
			Assert.AreEqual(2, result);
		}

		[TestMethod]
		public void Round2()
		{
			var input = "round(2.7)";
			var result = GetResult(input);
			Assert.AreEqual(3, result);
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
	}
}
