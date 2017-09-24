using System;
using Zork_Grupp_L.GameFunctions;

namespace Zork_Grupp_L.Rooms
{
	public abstract class Room : Inventory
    {
        public void PrintRoomDescription()
        {
	        Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("{0} ", this.Description);
            
            if (Game.CurrentPlayer.IsNaked)
            {
                Console.Write("You are naked. ");
            }

			Console.WriteLine();

            Console.WriteLine("In this room you see {0}", this.InventoryListNames());
        }

        public void PrintInspect()
        {
            Console.WriteLine("{0}", this.Description);
        }

    }
}
