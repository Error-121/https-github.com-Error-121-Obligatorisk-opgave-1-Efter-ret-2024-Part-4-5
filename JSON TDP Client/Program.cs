using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text.Json;
using JSON_TDP_Client.Model;


Console.WriteLine("JSON Client");

TcpClient client = new TcpClient("localhost", 7);
Console.WriteLine("client is ready");

NetworkStream ns = client.GetStream();
StreamReader reader = new StreamReader(ns);
StreamWriter writer = new StreamWriter(ns) { AutoFlush = true };
Equation equation = new Equation("","","");

while (true)
{
	Console.WriteLine("Write Equation");
	Console.WriteLine("Operration ( '+', '-', '/', '*', 'random', or type 'close' to exit )");
	equation.Operation = Console.ReadLine();
	Console.WriteLine("First Number");
	equation.Num1 = Console.ReadLine();
	Console.WriteLine("Second Number");
	equation.Num2 = Console.ReadLine();
	equation.ToString();

	var json = JsonSerializer.Serialize(equation);
	writer.WriteLine(json);

	if (equation.Operation.Equals("close", StringComparison.OrdinalIgnoreCase))
	{
		break;
	}

	string response = reader.ReadLine();
	var result = JsonSerializer.Deserialize<string>(response);
	Console.WriteLine("result: " + result);
	Console.WriteLine();
}

ns.Close();
client.Close();