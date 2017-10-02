using System;
using Zork_Grupp_L.Helpers;

namespace Zork_Grupp_L
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			do {
				Game.RunGame();
			} while (PromptRestart());

			Console.ReadKey();
		}

		private static bool PromptRestart()
		{
			while (true)
			{
				Console.ForegroundColor = Colors.DefaultColor;
				ConsoleHelper.WriteLineWrap("\nDo you wanna play again? Y/N");
				Console.Write("> ");
				Console.ForegroundColor = Colors.InputColor;

				string menuInput = Console.ReadLine().Trim().ToLower();

				if (menuInput == "y")
				{
					return true;
				}
				if (menuInput == "n")
				{
					return false;
				}

				Console.ForegroundColor = Colors.ErrorColor;
				ConsoleHelper.WriteLineWrap("You have to type Y or N.");
			}
		}
	}
}
