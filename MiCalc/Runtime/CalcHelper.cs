using System;
using BigNum;

namespace MiCalc.Runtime
{
	static class CalcHelper
	{
		private static PrecisionSpec _precisionSpec = new PrecisionSpec(256, new PrecisionSpec.BaseType());

		private static BigFloat _zero = new BigFloat(0.0d, _precisionSpec);
		private static BigFloat _half = new BigFloat(0.5d, _precisionSpec);
		private static BigFloat _one  = new BigFloat(1.0d, _precisionSpec);
		private static BigFloat _ten  = new BigFloat(10.0d, _precisionSpec);


		public static bool IsRadians = false;


		public static BigFloat ParseNumber(string s)
		{
			return new BigFloat(s, _precisionSpec);
		}

		public static BigFloat ChangeSign(BigFloat n)
		{
			n.Sign = !n.Sign;
			return n;
		}

		public static BigFloat GetPi()
		{
			return BigFloat.GetPi(_precisionSpec);
		}

		public static BigFloat GetE()
		{
			return BigFloat.GetE(_precisionSpec);
		}

		public static BigFloat GetZero()
		{
			return _zero;
		}

		public static BigFloat Add(BigFloat n1, BigFloat n2)
		{
			return n1 + n2;
		}

		public static BigFloat Sub(BigFloat n1, BigFloat n2)
		{
			return n1 - n2;
		}

		public static BigFloat Mul(BigFloat n1, BigFloat n2)
		{
			return n1*n2;
		}

		public static BigFloat Div(BigFloat n1, BigFloat n2)
		{
			if (n2 == _zero)
			{
				throw new DivideByZeroException();
			}
			return n1/n2;
		}

		public static BigFloat Mod(BigFloat n1, BigFloat n2)
		{
			var whole = n1/n2;
			whole.Floor();
			var mod = n1 - whole*n2;
			return mod;
		}

		public static BigFloat Pow(BigFloat n1, BigFloat n2)
		{
			return BigFloat.Pow(n1, n2);
		}

		public static BigFloat Fac(BigFloat n1)
		{
			var fac = BigFloat.ConvertToInt(n1, _precisionSpec, false);
			fac.Factorial();
			return new BigFloat(fac, _precisionSpec);
		}

		public static BigFloat Floor(BigFloat n1)
		{
			return BigFloat.Floor(n1);
		}

		public static BigFloat Ceil(BigFloat n1)
		{
			var floored = BigFloat.Floor(n1);
			var fPart = new BigFloat(n1);
			fPart.FPart();
			return fPart == _zero ? floored : floored + _one;
		}

		public static BigFloat Round(BigFloat n1)
		{
			var floored = BigFloat.Floor(n1);
			var fPart = new BigFloat(n1);
			fPart.FPart();
			fPart.Sign = false;

			return fPart == _half || fPart.GreaterThan(_half) ? floored + _one : floored;
		}

		public static string GetAsDecimal(BigFloat n)
		{
			return n.ToString().ToLower();
		}

		public static string GetAsScience(BigFloat n)
		{
			var n1 = new BigFloat(n, _precisionSpec);
			var isNegative = n1.Sign;
			n1.Sign = false;

			var log10 = BigFloat.Log10(n1);
			if (log10.IsSpecialValue && log10.SpecialValue == BigFloat.SpecialValueType.INF_MINUS)
			{
				return "0e0";
			}

			log10.Floor();
			var @base = n1/BigFloat.Pow(_ten, log10);
			
			return (isNegative ? "-" : string.Empty) + @base.ToString() + "e" + log10.ToString();
		}

		public static string GetAsHex(BigFloat n)
		{
			return n.ToString().ToLower();
		}

		public static string GetAsBin(BigFloat n)
		{
			return n.ToString().ToLower();
		}
	}
}
