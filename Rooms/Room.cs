using System;
using Zork_Grupp_L.GameFunctions;
using Zork_Grupp_L.Helpers;

namespace Zork_Grupp_L.Rooms
{
	public abstract class Room : Inventory
    {
        public void PrintRoomDescription()
        {
	        Console.ForegroundColor = Colors.DefaultColor;
	        if (Game.CurrentRoom == this)
	        {
		        ConsoleHelper.WriteLineWrap("You are in the {0}. {1}", this.Name, this.Description);
		        this.PrintRoomInventory();
			}
	        else
	        {
		        ConsoleHelper.WriteLineWrap("You look around the {0}. {1}", this.Name, this.Description);
	        }
        }

	    public void PrintRoomInventory()
	    {
			if (this.IsInventoryEmpty)
				ConsoleHelper.WriteLineWrap("This room is empty.");
			else
				ConsoleHelper.WriteLineWrap("In this room you see {0}.", this.InventoryListNames());
		}

    }
}
