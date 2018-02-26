using System;

namespace ClientApp
{
	internal class Program
	{
		private const string YesResponse = "Y";
		private const string NoResponse = "N";

		private static void Main(string[] args)
		{
			DisplayPrompts();

			var response = DisplayConfirmPrompt();

			if (response.Equals(YesResponse, StringComparison.CurrentCultureIgnoreCase))
				DisplayPrompts();
			else if (!response.Equals(NoResponse, StringComparison.CurrentCultureIgnoreCase))
			{
				Console.WriteLine("Invalid response.");
				DisplayConfirmPrompt();
			}
		}

		private static void DisplayPrompts()
		{
			Console.WriteLine("Host:");
			var host = Console.ReadLine();

			Console.WriteLine("Port:");
			var port = Console.ReadLine();

			Console.WriteLine("Message:");
			var message = Console.ReadLine();

			SynchonousSocketClient.Send(host, Convert.ToInt32(port), message);
		}

		private static string DisplayConfirmPrompt()
		{
			Console.WriteLine("Send another message? (Y/N):");
			return Console.ReadLine() ?? NoResponse;
		}
	}
}