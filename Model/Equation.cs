using System;

public class Equations
{
	public string Num1 { get; set; }
	public string Op { get; set; }
	public string Num2 { get; set; }

	//public Equations(string num1, string op, string num2)
	//{
	//	Num1 = num1;
	//	Op = op;
	//	Num2 = num2;
	//}
	public override string ToString()
	{
		return $"{Num1} {Op} {Num2}";
	}
}
