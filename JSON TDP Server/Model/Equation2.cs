using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_TDP_Server.Model
{
	public class Equation2
	{
		public string Num1 { get; set; }
		public string Num2 { get; set; }
		public string Operation { get; set; }

		public Equation2()
		{
		}

		public Equation2(string num1, string num2, string operation)
		{
			Num1 = num1;
			Num2 = num2;
			Operation = operation;
		}

		public override string ToString()
		{
			return $"{Num1} {Operation} {Num2}";
		}
	}
}
