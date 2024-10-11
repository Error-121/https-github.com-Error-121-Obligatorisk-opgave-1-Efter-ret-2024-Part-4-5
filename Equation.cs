using System;

public class Equation
{
	public string Num1 { get; set; }
	public string Num2 { get; set; }
	public string Operation { get; set; }

	//public Equation(string num1, string num2, string operation)
	//{
	//	Num1 = num1;
	//	Num2 = num2;
	//	Operation = operation;
	//}

	public override string ToString()
	{
		return $"{Num1} {Operation} {Num2}";
	}
}
