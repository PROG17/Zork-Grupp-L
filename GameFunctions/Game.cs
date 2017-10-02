using System;
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
        public static bool GameOver { get; set; }
        public static bool Win { get; set; }
        
		private static readonly BaseCommand[] commands = {
			new CommandInspect(),
			new CommandPickup(),
			new CommandDrop(),
			new CommandExit(),
			new CommandEnter(),
            new CommandUse()
		};

		public static void RunGame()
		{
			Console.Clear();
			Console.ForegroundColor = Colors.ImportantColor;
			Console.WriteLine("Welcome to our game, let's play!");
		    Console.WriteLine("Please try your best to get 'ut på arbetsmarknaden'!");
            Console.ForegroundColor = Colors.DefaultColor;

			// Initialize variables
            GameOver = false;
			AllRooms = new RoomRepository();
			CurrentPlayer = new Player();

			GoToRoom(AllRooms.dungeon);
			CurrentRoom.PrintRoomDescription();
            CurrentPlayer.PrintPlayerDescription();
			
			GameLoop();
		}

		private static void GameLoop()
		{
		    while (!GameOver)
			{
				UserInput();
			}

		    if (Win)
		    {
		        Console.ForegroundColor = Colors.WinAtLifeColor;
                ConsoleHelper.WriteLineWrap("You can now do stuff in school, I guess. You will be able to enter the 'Arbetsmarknaden' (probably).");
	            Console.WriteLine("[ Y O U   W I N ! ]");
		        Console.ForegroundColor = Colors.DefaultColor;
		    }
		    else
		    {
		        Console.ForegroundColor = Colors.GameOverColor;
		        Console.WriteLine("[ G A M E   O V E R ]");
		        Console.ForegroundColor = Colors.DefaultColor;
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
