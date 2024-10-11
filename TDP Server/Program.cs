using System.Net;
using System.Net.Sockets;

Console.WriteLine("TDP Server");

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
		//writer.WriteLine(message);

		if (message.Equals("close", StringComparison.OrdinalIgnoreCase))
		{
			keepListening = false;
		}

		Console.WriteLine("Equation is received");
		
		int result = 0;
		string[] parts = message.Split(' ');
		if (parts.Length == 3)
		{
			int a = int.Parse(parts[0]);
			int b = int.Parse(parts[2]);
			switch (parts[1])
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
			string response = result.ToString();
			writer.WriteLine(response);
		}
		else
		{
			writer.WriteLine("Invalid Equation");
		}
	}

	socket.Close();
}
