using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCalc.Analyzing
{
	public sealed partial class Scanner : ScanBase
	{
		/// <summary>
		/// null if no error.
		/// </summary>
		public int? ErrorPos = null;

		public override void yyerror(string format, params object[] args)
		{
			//Console.Error.WriteLine("Error: line {0} - " + format, yyline);
			ErrorPos = yypos;
		}
	}
}
