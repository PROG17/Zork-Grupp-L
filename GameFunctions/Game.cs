using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L
{
	using Zork_Grupp_L.Items;
	using Zork_Grupp_L.Rooms;

	public static class Game
	{
		public static Player CurrentPlayer { get; private set; }
		public static Room CurrentRoom { get; private set; }

		public static void StartGame()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Welcome to our game, let's play!");
			Console.ForegroundColor = ConsoleColor.Gray;

			var startRoom = new Dungeon();
			startRoom.AddToInventory(new ItemFrockCoat());
			startRoom.AddToInventory(new ItemCylinderHat());
			startRoom.AddToInventory(new ItemTorch());
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
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.Write("> ");
			Console.ForegroundColor = ConsoleColor.White;

			string rawUserInput = Console.ReadLine().Trim();
			string userInput = rawUserInput.ToLower();

			Console.ForegroundColor = ConsoleColor.Gray;

			if (userInput == "look around" || userInput == "look")
			{
				CurrentRoom.PrintRoomDescription();
			}
			else if (userInput.StartsWith("poop"))
			{
				/* CurrentPlayer.Poop(); */
			}
			else if (userInput == "inspect")
			{
				Console.WriteLine("Inspect what?");
			}
			else if (userInput.StartsWith("inspect "))
			{
				string rawWhatIsInspected = rawUserInput.Substring("inspect ".Length);
				string whatIsInspected = rawWhatIsInspected.ToLower();

				if (whatIsInspected == CurrentRoom.Name || whatIsInspected == "room")
				{
					CurrentRoom.PrintRoomDescription();
				}
				else
				{
					//kod för att hämta beskrivning av item
					InventoryItem item = CurrentRoom.InventoryFindItem(whatIsInspected);
					if (item == null) CurrentPlayer.InventoryFindItem(whatIsInspected);

					if (item == null)
					{
						Console.WriteLine("There's no {0} in the vicinity...", rawWhatIsInspected);
					}
					else
					{
						item.PrintItemDescription();
					}
				}

			}
			else if (userInput == "take" || userInput == "pick up")
			{
				//kod för att ta något från rummets inventory till spelarens.
			}
			else if (userInput == "drop")
			{
				//Tänkte nåt sånt här men gick inte so I dont know..
				//CurrentRoom.InventoryRemoveItem();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("Sorry, I don't understand.");
			}

		}
	}
}
