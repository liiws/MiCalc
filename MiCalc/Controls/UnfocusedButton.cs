using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalc.Controls
{
	public partial class UnfocusedButton : Button
	{
		public UnfocusedButton()
		{
			InitializeComponent();
		}

		public override bool Focused
		{
			get
			{
				return false;
			}
		}
	}
}
