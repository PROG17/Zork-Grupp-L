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
		        Console.WriteLine("You are in the {0}. {1}", this.Name, this.Description);
		        this.PrintRoomInventory();
			}
	        else
	        {
		        Console.WriteLine("You look around the {0}. {1}", this.Name, this.Description);
	        }
        }

	    public void PrintRoomInventory()
	    {
			if (this.IsInventoryEmpty)
				Console.WriteLine("This room is empty.");
			else
				Console.WriteLine("In this room you see {0}.", this.InventoryListNames());
		}

    }
}
