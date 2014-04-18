using System;
using System.Deployment.Application;
using System.Linq;
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
		private static BigFloat _nFloorError = new BigFloat("1e-240", _precisionSpec);
		private static BigInt _nLongZero = new BigInt("0", _precisionSpec);




		public static bool IsRadians = false;

		public static bool IsHideDigits = false;

		public static int HideDigitsWhenMoreThan = 10;



		static CalcHelper()
		{
			BigFloat.RoundingDigits = _roundingDigits;
		}



		public static BigFloat ParseNumber(string s)
		{
			return new BigFloat(s, _precisionSpec);
		}

		public static BigFloat ParseNumberBin(string s)
		{
			var value = Convert.ToUInt64(s, 2);
			return new BigFloat(value, _precisionSpec);
		}

		public static BigFloat ParseNumberHex(string s)
		{
			var value = Convert.ToUInt64(s, 16);
			return new BigFloat(value, _precisionSpec);
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

		public static BigFloat Rsh(BigFloat n1, BigFloat n2)
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

			int1.RSH(int.Parse(int2.ToString()));
			return new BigFloat(int1.ToString(), _precisionSpec);
		}

		public static BigFloat Lsh(BigFloat n1, BigFloat n2)
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

			int1.LSH(int.Parse(int2.ToString()));
			return new BigFloat(int1.ToString(), _precisionSpec);
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
			BigFloat ret;
			var fMain = BigFloat.Floor(n);
			var fPart = BigFloat.FPart(n);

			if (fPart.IsZero())
			{
				ret = fMain;
			}
			else if (fPart.LessThan(_zero) && (fPart + _nFloorError).GreaterThan(_zero))
			{
				if (n.GreaterThan(_zero))
				{
					throw new TrustNotGrantedException("Not tested. Contact author with you expression!");
					ret = fMain + _one;
				}
				else
				{
					ret = fMain;
				}
			}
			else if (fPart.LessThan(_one) && (fPart + _nFloorError).GreaterThan(_one))
			{
				if (n.GreaterThan(_zero))
				{
					ret = fMain + _one;
				}
				else
				{
					throw new TrustNotGrantedException("Not tested. Contact author with you expression!");
					ret = fMain;
				}
			}
			else if (fPart.GreaterThan(_zero))
			{
				ret = fMain;
			}
			else
			{
				ret = fMain - _one;
			}

			return ret;
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
				// ex1 = "-12.34e-56"
				// ex2 = "-0.34e-56"

				var s = n.ToString().ToLower().Replace(",", string.Empty);
				var posE = s.IndexOf('e');
				if (posE != -1)
				{
					// ex1 = "-12.34"
					// ex2 = "-0.34"
					var stringBeforeE = s.Substring(0, posE);

					// ex1 = "-56"
					// ex2 = "-56"
					var stringAfterE = s.Substring(posE + 1);

					int exp;
					if (int.TryParse(stringAfterE, out exp))
					{
						// now:
						// ex1 = exp = -56
						// ex2 = exp = -56

						string mainPartBeforePoint;
						string mainPartAfterPoint;

						var posPoint = stringBeforeE.IndexOf('.');
						if (posPoint != -1)
						{
							// ex1 = "-12"
							// ex2 = "-0"
							mainPartBeforePoint = stringBeforeE.Substring(0, posPoint);

							// ex1 = "34"
							// ex2 = "34"
							mainPartAfterPoint = stringBeforeE.Substring(posPoint + 1);
						}
						else
						{
							mainPartBeforePoint = stringBeforeE;
							mainPartAfterPoint = string.Empty;
						}

						// remove leading 0 in mainPartBeforePoint (can be safely removed without affecting "exp")
						while (mainPartBeforePoint.StartsWith("0"))
						{
							mainPartBeforePoint = mainPartBeforePoint.Substring(1);
						}
						while (mainPartBeforePoint.StartsWith("-0"))
						{
							mainPartBeforePoint = "-" + mainPartBeforePoint.Substring(2);
						}
						// mainPartBeforePoint:
						// ex1 = "-12"
						// ex2 = "-"
						
						// merge main parts
						exp -= mainPartAfterPoint.Length;
						mainPartBeforePoint += mainPartAfterPoint;
						mainPartAfterPoint = string.Empty;

						// now we have only two things: "mainPartBeforePoint" and "exp"
						// ex1: mainPartBeforePoint = "-1234", exp = -58
						// ex2: mainPartBeforePoint = "-34", exp = -58

						// remove leading 0 because they could be in "mainPartAfterPoint" (and if "mainPartBeforePoint" was empty)
						while (mainPartBeforePoint.StartsWith("0"))
						{
							mainPartBeforePoint = mainPartBeforePoint.Substring(1);
						}
						while (mainPartBeforePoint.StartsWith("-0"))
						{
							mainPartBeforePoint = "-" + mainPartBeforePoint.Substring(2);
						}

						// remove ending 0
						while (mainPartBeforePoint.EndsWith("0"))
						{
							mainPartBeforePoint = mainPartBeforePoint.Substring(0, mainPartBeforePoint.Length - 1);
						}

						// move point
						if (exp > 0)
						{
							s = mainPartBeforePoint + new string('0', exp);
						}
						else if (exp < 0)
						{
							exp = -exp;
							s = mainPartBeforePoint;
							var sign = s.StartsWith("-") ? "-" : string.Empty;
							s = s.StartsWith("-") ? s.Substring(1) : s;
							if (exp < s.Length)
							{
								s = sign + s.Substring(0, s.Length - exp) + "." + s.Substring(s.Length - exp);
							}
							else if (exp > s.Length)
							{
								s = sign + "0." + new string('0', exp - s.Length) + s;
							}
							else
							{
								s = sign + "0." + s;
							}
						}
						else
						{
							s = mainPartBeforePoint;
						}
					}
				}

				if (IsHideDigits)
				{
					s = HideDigitsAfterPoint(s);
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


				string s = (isNegative ? "-" : string.Empty) + @base.ToString().Replace(",", string.Empty) + "e" + log10.ToString().Replace(",", string.Empty);

				if (IsHideDigits)
				{
					s = HideDigitsAfterPoint(s);
				}

				return s;
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

		private static string HideDigitsAfterPoint(string s)
		{
			var posPoint = s.IndexOf('.');
			if (posPoint != -1)
			{
				int digitsAfterPoint;

				var posE = s.IndexOf('e');
				if (posE != -1)
				{
					digitsAfterPoint = posE - posPoint - 1;
				}
				else
				{
					digitsAfterPoint = s.Length - posPoint - 1;
				}

				if (digitsAfterPoint > HideDigitsWhenMoreThan)
				{
					s =
						// whole part
						s.Substring(0, posPoint)
						// point
						+ "."
						// floating part
						+ s.Substring(posPoint + 1, HideDigitsWhenMoreThan)
						// after floating part
						+ (s.Length > posPoint + 1 + digitsAfterPoint ? s.Substring(posPoint + 1 + digitsAfterPoint) : string.Empty);
				}
			}

			return s;
		}
	}
}
