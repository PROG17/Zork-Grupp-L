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
            Console.WriteLine("{0} ", this.Description);

			if (!this.IsInventoryEmpty)
				Console.WriteLine("In this room you see {0}", this.InventoryListNames());
        }

    }
}
