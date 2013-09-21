using System;
using System.Diagnostics;
using BigNum;

namespace MiCalc.Runtime
{
	[DebuggerDisplay("Number = {Number}, Constant = {Constant}, Operation = {Operation}, Left = {Left}, Right = {Right}, IsNegative = {IsNegative}, Function = {Function}")]
	public class Expression
	{
		/// <summary>
		/// Whether this whole expression is negative.
		/// </summary>
		public bool IsNegative = false;

		public string Number = null;

		public Constant Constant = Constant.None;

		public Operation Operation = Operation.None;
		public Expression Left = null;
		public Expression Right = null;

		/// <summary>
		/// Left expresssion is the argument.
		/// </summary>
		public Function Function = Function.None;



		public Expression()
		{
		}

		public Expression(Expression expression)
		{
			Left = expression;
		}

		public Expression(Operation operation, Expression left, Expression right)
		{
			Operation = operation;
			Left = left;
			Right = right;
		}

		public Expression(Constant c)
		{
			Constant = c;
		}

		public Expression(string s)
		{
			Number = s;
		}

		public Expression(Function f, Expression expression)
		{
			Function = f;
			Left = expression;
		}

		public BigFloat Calc()
		{
			BigFloat result;

			// number
			if (Number != null)
			{
				result = CalcHelper.ParseNumber(Number);
			}

			// operation
			else if (Operation == Operation.Add)
			{
				result = CalcHelper.Add(Left.Calc(), Right.Calc());
			}
			else if (Operation == Operation.Sub)
			{
				result = CalcHelper.Sub(Left.Calc(), Right.Calc());
			}
			else if (Operation == Operation.Mul)
			{
				result = CalcHelper.Mul(Left.Calc(), Right.Calc());
			}
			else if (Operation == Operation.Div)
			{
				result = CalcHelper.Div(Left.Calc(), Right.Calc());
			}
			else if (Operation == Operation.Mod)
			{
				result = CalcHelper.Mod(Left.Calc(), Right.Calc());
			}
			else if (Operation == Operation.And)
			{
				result = CalcHelper.And(Left.Calc(), Right.Calc());
			}
			else if (Operation == Operation.Or)
			{
				result = CalcHelper.Or(Left.Calc(), Right.Calc());
			}
			else if (Operation == Operation.Not)
			{
				result = CalcHelper.Not(Left.Calc());
			}
			else if (Operation == Operation.Xor)
			{
				result = CalcHelper.Xor(Left.Calc(), Right.Calc());
			}
			else if (Operation == Operation.Rsh)
			{
				result = CalcHelper.Rsh(Left.Calc(), Right.Calc());
			}
			else if (Operation == Operation.Lsh)
			{
				result = CalcHelper.Lsh(Left.Calc(), Right.Calc());
			}
			else if (Operation == Operation.Pow)
			{
				result = CalcHelper.Pow(Left.Calc(), Right.Calc());
			}
			else if (Operation == Operation.Fac)
			{
				result = CalcHelper.Fac(Left.Calc());
			}

			// constant
			else if (Constant == Constant.Pi)
			{
				result = CalcHelper.GetPi();
			}
			else if (Constant == Constant.E)
			{
				result = CalcHelper.GetE();
			}

			// function
			else if (Function == Function.Floor)
			{
				result = CalcHelper.Floor(Left.Calc());
			}
			else if (Function == Function.Ceil)
			{
				result = CalcHelper.Ceil(Left.Calc());
			}
			else if (Function == Function.Round)
			{
				result = CalcHelper.Round(Left.Calc());
			}
			else if (Function == Function.Sin)
			{
				result = CalcHelper.Sin(Left.Calc());
			}
			else if (Function == Function.Cos)
			{
				result = CalcHelper.Cos(Left.Calc());
			}
			else if (Function == Function.Tan)
			{
				result = CalcHelper.Tan(Left.Calc());
			}
			else if (Function == Function.Asin)
			{
				result = CalcHelper.Asin(Left.Calc());
			}
			else if (Function == Function.Acos)
			{
				result = CalcHelper.Acos(Left.Calc());
			}
			else if (Function == Function.Atan)
			{
				result = CalcHelper.Atan(Left.Calc());
			}
			else if (Function == Function.Sinh)
			{
				result = CalcHelper.Sinh(Left.Calc());
			}
			else if (Function == Function.Cosh)
			{
				result = CalcHelper.Cosh(Left.Calc());
			}
			else if (Function == Function.Tanh)
			{
				result = CalcHelper.Tanh(Left.Calc());
			}
			else if (Function == Function.Asinh)
			{
				result = CalcHelper.Asinh(Left.Calc());
			}
			else if (Function == Function.Acosh)
			{
				result = CalcHelper.Acosh(Left.Calc());
			}
			else if (Function == Function.Atanh)
			{
				result = CalcHelper.Atanh(Left.Calc());
			}
			else if (Function == Function.Ln)
			{
				result = CalcHelper.Ln(Left.Calc());
			}
			else if (Function == Function.Lg)
			{
				result = CalcHelper.Lg(Left.Calc());
			}
			else if (Function == Function.Exp)
			{
				result = CalcHelper.Exp(Left.Calc());
			}
			else if (Function == Function.Sqrt)
			{
				result = CalcHelper.Sqrt(Left.Calc());
			}

			// error
			else
			{
				throw new Exception();
			}

			if (IsNegative)
			{
				result = CalcHelper.ChangeSign(result);
			}

			return result;
		}
	}
}
