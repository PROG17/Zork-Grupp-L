using System;
using System.Collections.Generic;
using Zork_Grupp_L.Helpers;

namespace Zork_Grupp_L
{
	using Rooms;
	using Commands;

	public static class Game
	{
		public static Player CurrentPlayer { get; private set; }
		public static Room CurrentRoom { get; private set; }
		public static RoomRepository AllRooms { get; private set; }

		private static readonly BaseCommand[] commands = {
			new CommandInspect(),
			new CommandPickup(),
			new CommandDrop(),
			new CommandExit(),
			new CommandEnter(),
		};

		public static void StartGame()
		{
			AllRooms = new RoomRepository();

			Console.ForegroundColor = Colors.ImportantColor;
			Console.WriteLine("Welcome to our game, let's play!");
			Console.ForegroundColor = Colors.DefaultColor;
			
			CurrentPlayer = new Player();
			GoToRoom(AllRooms.dungeon);
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
				foreach (BaseCommand cmd in commands)
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

		public static void GoToRoom(Room nextRoom)
		{
			CurrentRoom?.OnExitRoom();
			CurrentRoom = nextRoom;
			nextRoom.OnEnterRoom();
		}
	}
}
