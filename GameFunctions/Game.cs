using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zork_Grupp_L.Helpers;

namespace Zork_Grupp_L
{
	using Items;
	using Rooms;
	using Commands;

	public static class Game
	{
		public static Player CurrentPlayer { get; private set; }
		public static Room CurrentRoom { get; private set; }

		private static readonly Command[] commands = {
			new CommandInspect(),
			new CommandPickup(),
			new CommandDrop(),
		};

		public static void StartGame()
		{
			Console.ForegroundColor = Colors.ImportantColor;
			Console.WriteLine("Welcome to our game, let's play!");
			Console.ForegroundColor = Colors.DefaultColor;

			var startRoom = new Dungeon();
			startRoom.AddToInventory(new ItemFrockCoat());
			startRoom.AddToInventory(new ItemCylinderHat());
			startRoom.AddToInventory(new ItemTorch());
            startRoom.AddToFurnishingInventory(new ItemPuddle());
			CurrentPlayer = new Player();
			CurrentRoom = startRoom;
			CurrentRoom.PrintRoomDescription();

			while (true)
			{
				UserInput();
			}
		}

		public static void UserInput()
		{
			Console.ForegroundColor = Colors.DefaultColor;
			Console.Write("> ");
			Console.ForegroundColor = Colors.InputColor;

			string trimmedInput = Console.ReadLine().Trim();

			if (trimmedInput == string.Empty)
			{
				Console.ForegroundColor = Colors.ErrorColor;
				Console.WriteLine("I beg your pardon?");
			}
			else
			{
				Console.ForegroundColor = Colors.DefaultColor;

				bool any = false;
				foreach (Command cmd in commands)
				{
					if (cmd.TryExecute(trimmedInput))
					{
						any = true;
						break;
					}
				}

				if (!any)
				{
					Console.ForegroundColor = Colors.ErrorColor;
					Console.WriteLine("Sorry, I don't understand.");
				}
			}

		}
	}
}
