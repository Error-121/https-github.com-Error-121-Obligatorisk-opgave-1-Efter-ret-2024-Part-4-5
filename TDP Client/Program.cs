using System.Net.Sockets;

Console.WriteLine("TDP Client");

TcpClient client = new TcpClient("localhost", 7);
Console.WriteLine("client is ready");

NetworkStream ns = client.GetStream();
StreamReader reader = new StreamReader(ns);
StreamWriter writer = new StreamWriter(ns) { AutoFlush = true };

while (true)
{
    Console.WriteLine("Write Equation");
    Console.WriteLine("Example: 4 + 5");
	string message = Console.ReadLine();
	writer.WriteLine(message);

	if (message.Equals("close", StringComparison.OrdinalIgnoreCase))
	{
		break;
	}

	string response = reader.ReadLine();
	Console.WriteLine("result: " + response);
    Console.WriteLine();
}

ns.Close();
client.Close();