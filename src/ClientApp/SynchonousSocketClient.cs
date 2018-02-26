using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientApp
{
	public class SynchonousSocketClient
	{
		public static void Send(string host, int port, string message)
		{
			var incomingData = new byte[1024];

			try
			{
				var ipHostInfo = Dns.GetHostEntry(host);
				var ipAddress = ipHostInfo.AddressList[0];
				var remoteEndpoint = new IPEndPoint(ipAddress, port);

				var sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

				sender.Connect(remoteEndpoint);

				Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

				var messageData = Encoding.ASCII.GetBytes(message);

				_ = sender.Send(messageData);

				var bytesReceived = sender.Receive(incomingData);
				Console.WriteLine($"Received: {Encoding.ASCII.GetString(incomingData, 0, bytesReceived)}");

				sender.Shutdown(SocketShutdown.Both);
				sender.Close();
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
			}
		}
	}
}