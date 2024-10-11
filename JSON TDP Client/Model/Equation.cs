using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_TDP_Client.Model
{
	public class Equation
	{
		public string Num1 { get; set; }
		public string Num2 { get; set; }
		public string Operation { get; set; }
		//public string Result { get; set; }

		public Equation()
		{
		}

		public Equation(string num1, string num2, string operation)
		{
			Num1 = num1;
			Num2 = num2;
			Operation = operation;
			//Result = result;
		}

		public override string ToString()
		{
			return $"{Num1} {Operation} {Num2}";
		}
	}
}
