using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using JSON_TDP_Server.Model;
using JSON_TDP_Client.Model;

Console.WriteLine("JSON Sever");

TcpListener listener = new TcpListener(IPAddress.Any, 7);
listener.Start();

while (true)
{
	TcpClient socket = listener.AcceptTcpClient();
	Task.Run(() => HandleClient(socket));
}

listener.Stop();

void HandleClient(TcpClient socket)
{
	NetworkStream ns = socket.GetStream();
	StreamReader reader = new StreamReader(ns);
	StreamWriter writer = new StreamWriter(ns) { AutoFlush = true };

	bool keepListening = true;

	while (keepListening)
	{
		string message = reader.ReadLine();
        Console.WriteLine(message);
		var jsonMassage = JsonSerializer.Deserialize<Equation>(message);
		
		Console.WriteLine(jsonMassage);
		
		//writer.WriteLine(message);

		if (jsonMassage.Operation.Equals("close", StringComparison.OrdinalIgnoreCase))
		{
			keepListening = false;
		}

		Console.WriteLine("Equation is received");

		int result = 0;
		//string[] parts = jsonMassage.Split(' ');
		//if (parts.Length == 3)
		if (jsonMassage.Operation != null)
		{
			int a = int.Parse(jsonMassage.Num1);
			int b = int.Parse(jsonMassage.Num2);
			switch (jsonMassage.Operation)
			{
				case "+":
					result = a + b;
					break;
				case "-":
					result = a - b;
					break;
				case "*":
					result = a * b;
					break;
				case "/":
					result = a / b;
					break;
				case "random":
					result = new Random().Next(a, b);
					break;
				default:
					break;
			}
            Console.WriteLine("Equation calculated");
			string response = result.ToString();
			var jsonresponse = JsonSerializer.Serialize(response);
			writer.WriteLine(jsonresponse);
            Console.WriteLine("answer sent");
		}
		else
		{
			writer.WriteLine("Invalid Equation");
		}
	}

	socket.Close();
}