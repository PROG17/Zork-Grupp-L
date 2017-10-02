using System;
using Zork_Grupp_L.GameFunctions;
using Zork_Grupp_L.Helpers;
using Zork_Grupp_L.Items;

namespace Zork_Grupp_L.Rooms
{
	public abstract class Room : Inventory
	{

		public virtual void OnEnterRoom()
		{
			
		}

		public virtual void OnExitRoom()
		{
			
		}

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

		public void AddRoomExit(Room nextRoom, string name, string description)
		{
			var exit = new RoomExit(nextRoom, name, description);
			this.AddToInventory(exit);
		}

    }
}
