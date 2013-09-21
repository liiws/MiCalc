using System;
using BigNum;

namespace MiCalc.Runtime
{
	public static class CalcHelper
	{
		private static int _roundingDigits = 100;
		private static PrecisionSpec _precisionSpec = new PrecisionSpec(250, PrecisionSpec.BaseType.DEC);

		private static BigFloat _pi = BigFloat.GetPi(_precisionSpec);
		private static BigFloat _e = BigFloat.GetE(_precisionSpec);
		private static BigFloat _zero = new BigFloat(0.0d, _precisionSpec);
		private static BigFloat _half = new BigFloat(0.5d, _precisionSpec);
		private static BigFloat _one = new BigFloat(1.0d, _precisionSpec);
		private static BigFloat _ten = new BigFloat(10.0d, _precisionSpec);
		private static BigFloat _n180 = new BigFloat(180.0d, _precisionSpec);
		private static BigFloat _nLongUnsignedMax = new BigFloat("18446744073709551615", _precisionSpec);
		private static BigInt _nLongUnsignedMaxInt = new BigInt("18446744073709551615", _precisionSpec);
		private static BigFloat _nLongSignedMin = new BigFloat("-9223372036854775808", _precisionSpec);
		private static BigInt _nLongUnsignedMaxPlusOne = new BigInt("18446744073709551616", _precisionSpec);
		private static BigInt _nLongZero = new BigInt("0", _precisionSpec);


		public static bool IsRadians = false;



		static CalcHelper()
		{
			BigFloat.RoundingDigits = _roundingDigits;
		}



		public static BigFloat ParseNumber(string s)
		{
			return new BigFloat(s, _precisionSpec);
		}

		public static BigFloat ChangeSign(BigFloat n)
		{
			var n1 = new BigFloat(n);
			n1.Sign = !n1.Sign;
			return n1;
		}

		public static BigFloat GetPi()
		{
			return new BigFloat(_pi);
		}

		public static BigFloat GetE()
		{
			return new BigFloat(_e);
		}

		public static BigFloat GetZero()
		{
			return new BigFloat(_zero);
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
			if (n1.IsZero())
			{
				throw new DivideByZeroException();
			}
			return n1/n2;
		}

		public static BigFloat Mod(BigFloat n1, BigFloat n2)
		{
			var whole = Floor(n1/n2);
			var mod = n1 - whole*n2;
			return mod;
		}

		public static BigFloat And(BigFloat n1, BigFloat n2)
		{
			if (n1.GreaterThan(_nLongUnsignedMax) || n2.GreaterThan(_nLongUnsignedMax))
			{
				throw new Exception("Error: bitwise operator for Number > Unsigned QWORD");
			}
			else if (n1.LessThan(_nLongSignedMin) || n2.LessThan(_nLongSignedMin))
			{
				throw new Exception("Error: bitwise operator for Number < Signed QWORD");
			}
			var int1 = BigFloat.ConvertToInt(Round(n1), _precisionSpec, false);
			var int2 = BigFloat.ConvertToInt(Round(n2), _precisionSpec, false);

			if (int1.Sign)
			{
				int1.Sign = false;
				int1 = _nLongUnsignedMaxPlusOne - int1;
			}
			if (int2.Sign)
			{
				int2.Sign = false;
				int2 = _nLongUnsignedMaxPlusOne - int2;
			}

			return new BigFloat(BigInt.And(int1, int2).ToString(), _precisionSpec);
		}

		public static BigFloat Or(BigFloat n1, BigFloat n2)
		{
			if (n1.GreaterThan(_nLongUnsignedMax) || n2.GreaterThan(_nLongUnsignedMax))
			{
				throw new Exception("Error: bitwise operator for Number > Unsigned QWORD");
			}
			else if (n1.LessThan(_nLongSignedMin) || n2.LessThan(_nLongSignedMin))
			{
				throw new Exception("Error: bitwise operator for Number < Signed QWORD");
			}
			var int1 = BigFloat.ConvertToInt(Round(n1), _precisionSpec, false);
			var int2 = BigFloat.ConvertToInt(Round(n2), _precisionSpec, false);

			if (int1.Sign)
			{
				int1.Sign = false;
				int1 = _nLongUnsignedMaxPlusOne - int1;
			}
			if (int2.Sign)
			{
				int2.Sign = false;
				int2 = _nLongUnsignedMaxPlusOne - int2;
			}

			return new BigFloat(BigInt.Or(int1, int2).ToString(), _precisionSpec);
		}

		public static BigFloat Not(BigFloat n)
		{
			if (n.GreaterThan(_nLongUnsignedMax))
			{
				throw new Exception("Error: bitwise operator for Number > Unsigned QWORD");
			}
			else if (n.LessThan(_nLongSignedMin))
			{
				throw new Exception("Error: bitwise operator for Number < Signed QWORD");
			}
			var int1 = BigFloat.ConvertToInt(Round(n), _precisionSpec, false);

			if (int1.Sign)
			{
				int1.Sign = false;
				int1 = _nLongUnsignedMaxPlusOne - int1;
			}

			return new BigFloat(BigInt.Xor(int1, _nLongUnsignedMaxInt).ToString(), _precisionSpec);
		}

		public static BigFloat Xor(BigFloat n1, BigFloat n2)
		{
			if (n1.GreaterThan(_nLongUnsignedMax) || n2.GreaterThan(_nLongUnsignedMax))
			{
				throw new Exception("Error: bitwise operator for Number > Unsigned QWORD");
			}
			else if (n1.LessThan(_nLongSignedMin) || n2.LessThan(_nLongSignedMin))
			{
				throw new Exception("Error: bitwise operator for Number < Signed QWORD");
			}
			var int1 = BigFloat.ConvertToInt(Round(n1), _precisionSpec, false);
			var int2 = BigFloat.ConvertToInt(Round(n2), _precisionSpec, false);

			if (int1.Sign)
			{
				int1.Sign = false;
				int1 = _nLongUnsignedMaxPlusOne - int1;
			}
			if (int2.Sign)
			{
				int2.Sign = false;
				int2 = _nLongUnsignedMaxPlusOne - int2;
			}

			return new BigFloat(BigInt.Xor(int1, int2).ToString(), _precisionSpec);
		}

		public static BigFloat Pow(BigFloat n1, BigFloat n2)
		{
			return BigFloat.Pow(n1, n2);
		}

		public static BigFloat Fac(BigFloat n)
		{
			var fac = BigFloat.ConvertToInt(Round(n), _precisionSpec, false);
			fac.Factorial();
			return new BigFloat(fac.ToString(), _precisionSpec);
		}

		public static BigFloat Floor(BigFloat n)
		{
			if (n.LessThan(_zero) && BigFloat.FPart(n).LessThan(_zero))
			{
				return BigFloat.Floor(n) - _one;
			}
			else
			{
				return BigFloat.Floor(n);
			}
		}

		public static BigFloat Ceil(BigFloat n)
		{
			var floored = Floor(n);
			var fPart = BigFloat.FPart(n);
			return fPart.IsZero() ? floored : floored + _one;
		}

		public static BigFloat Round(BigFloat n)
		{
			var floored = Floor(n);
			var fPart = BigFloat.FPart(n);
			fPart.Sign = false;

			if (fPart.IsZero())
			{
				// n is integer
				return floored;
			}
			else if (n.GreaterThan(_zero))
			{
				// n > 0
				return fPart == _half || fPart.GreaterThan(_half) ? floored + _one : floored;
			}
			else
			{
				// n < 0
				return fPart == _half || fPart.GreaterThan(_half) ? floored : floored + _one;
			}
		}

		public static BigFloat Sin(BigFloat n)
		{
			return BigFloat.Sin(GetRadiansFromCurrent(n));
		}

		public static BigFloat Cos(BigFloat n)
		{
			return BigFloat.Cos(GetRadiansFromCurrent(n));
		}

		public static BigFloat Tan(BigFloat n)
		{
			return BigFloat.Tan(GetRadiansFromCurrent(n));
		}

		public static BigFloat Asin(BigFloat n)
		{
			return GetCurrentFromRadians(BigFloat.Arcsin(n));
		}

		public static BigFloat Acos(BigFloat n)
		{
			return GetCurrentFromRadians(BigFloat.Arccos(n));
		}

		public static BigFloat Atan(BigFloat n)
		{
			return GetCurrentFromRadians(BigFloat.Arctan(n));
		}

		public static BigFloat Sinh(BigFloat n)
		{
			return BigFloat.Sinh(n);
		}

		public static BigFloat Cosh(BigFloat n)
		{
			return BigFloat.Cosh(n);
		}

		public static BigFloat Tanh(BigFloat n)
		{
			return BigFloat.Tanh(n);
		}

		public static BigFloat Asinh(BigFloat n)
		{
			return BigFloat.Arcsinh(n);
		}

		public static BigFloat Acosh(BigFloat n)
		{
			return BigFloat.Arccosh(n);
		}

		public static BigFloat Atanh(BigFloat n)
		{
			return BigFloat.Arctanh(n);
		}

		public static BigFloat Ln(BigFloat n)
		{
			return BigFloat.Log(n);
		}

		public static BigFloat Lg(BigFloat n)
		{
			return BigFloat.Log10(n);
		}

		public static BigFloat Exp(BigFloat n)
		{
			return BigFloat.Exp(n);
		}

		public static BigFloat Sqrt(BigFloat n)
		{
			return BigFloat.Sqrt(n);
		}

		/// <summary>
		/// Creates new variable from n, returning it in radians depending on <see cref="IsRadians"/>.
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		private static BigFloat GetRadiansFromCurrent(BigFloat n)
		{
			return IsRadians ? new BigFloat(n) : GetPi()*n/_n180;
		}

		/// <summary>
		/// Creates new variable from n, returning it in radians/degrees depending on <see cref="IsRadians"/>.
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		private static BigFloat GetCurrentFromRadians(BigFloat n)
		{
			return IsRadians ? new BigFloat(n) : _n180*n/GetPi();
		}

		public static string GetAsDecimal(BigFloat n)
		{
			try
			{
				var s = n.ToString().ToLower().Replace(",", string.Empty);
				var posE = s.IndexOf('e');
				if (posE != -1)
				{
					var posPoint = s.IndexOf('.');
					if (posPoint != -1)
					{
						var digitsAfterPoint = posE - posPoint - 1;
						var sAfterE = s.Substring(posE + 1);
						long exp;
						if (long.TryParse(sAfterE, out exp))
						{
							if (exp > 0)
							{
								if (exp > digitsAfterPoint)
								{
									s = s.Substring(0, posPoint) + s.Substring(posPoint + 1, digitsAfterPoint) + "e" + (exp - digitsAfterPoint).ToString();
								}
								else if (exp == digitsAfterPoint)
								{
									s = s.Substring(0, posPoint) + s.Substring(posPoint + 1, digitsAfterPoint);
								}
								else
								{
									s = (s.Substring(0, posPoint) + s.Substring(posPoint + 1, digitsAfterPoint)).Insert(posPoint + (int)exp, ".");
								}
							}
							else
							{
								// may be will implement later
								s = s;
							}
						}
					}
				}
				return s;
			}
			catch
			{
				return "Unexpected error";
			}
		}

		public static string GetAsScience(BigFloat n)
		{
			try
			{
				var n1 = new BigFloat(n, _precisionSpec);
				var isNegative = n1.Sign;
				n1.Sign = false;

				var log10 = BigFloat.Log10(n1);
				if (log10.IsSpecialValue && log10.SpecialValue == BigFloat.SpecialValueType.INF_MINUS)
				{
					return "0e0";
				}

				log10 = Floor(log10);
				var @base = n1/BigFloat.Pow(_ten, log10);

				return (isNegative ? "-" : string.Empty) + @base.ToString().Replace(",", string.Empty) + "e" + log10.ToString().Replace(",", string.Empty);
			}
			catch
			{
				return "Unexpected error";
			}
		}

		public static string GetAsHex(BigFloat n)
		{
			try
			{
				string result;

				if (n.GreaterThan(_nLongUnsignedMax))
				{
					result = "Number > Unsigned QWORD";
				}
				else if (n.LessThan(_nLongSignedMin))
				{
					result = "Number < Signed QWORD";
				}
				else if (n.Sign == false)
				{
					// >= 0
					var floored = BigFloat.ConvertToInt(Round(n), _precisionSpec, false);
					result = floored.ToString(16);
				}
				else
				{
					// < 0
					var floored = BigFloat.ConvertToInt(Round(n), _precisionSpec, false);
					floored.Sign = false;
					result = (_nLongUnsignedMaxPlusOne - floored).ToString(16);
				}

				return result;
			}
			catch
			{
				return "Unexpected error";
			}
		}

		public static string GetAsBin(BigFloat n)
		{
			try
			{
				string result;

				if (n.GreaterThan(_nLongUnsignedMax))
				{
					result = "Number > Unsigned QWORD";
				}
				else if (n.LessThan(_nLongSignedMin))
				{
					result = "Number < Signed QWORD";
				}
				else if (n.Sign == false)
				{
					// >= 0
					var floored = BigFloat.ConvertToInt(Round(n), _precisionSpec, false);
					result = floored.ToString(2);
				}
				else
				{
					// < 0
					var floored = BigFloat.ConvertToInt(Round(n), _precisionSpec, false);
					floored.Sign = false;
					result = (_nLongUnsignedMaxPlusOne - floored).ToString(2);
				}

				return result;
			}
			catch
			{
				return "Unexpected error";
			}
		}
	}
}
