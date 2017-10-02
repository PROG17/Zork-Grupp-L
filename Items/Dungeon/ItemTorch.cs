using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L.Items
{
    using System.Runtime.CompilerServices;

    using Zork_Grupp_L.Helpers;
    using Zork_Grupp_L.Items.Dungeon;

    public class ItemTorch : InventoryItem
	{

		public override string Name => this.IsLit
			? "burning torch"
			: "extinguished torch";

		public override string Description => this.IsLit
			? "This torch can be used for seeing in the dark or burning things."
			: "This torch is no longer burning, but it still drips of oil.";

		public bool IsLit { get; private set; } = true;
        
	    public override bool UseOnItem(BaseItem otherItem)
	    {
	        switch (otherItem)
	        {
	            case FurnishPuddle _:
	                this.IsLit = false;
	                return true;

                case ExitBurnDownableDoor door:
                    ConsoleHelper.WriteLineWrap("You burnt down that door ayao, cool.");
                    // Remove door from it's parent inventory
                    door.CurrentInventory.InventoryRemoveItem(door);
                    // Add new (and not locked) door to room
                    Game.CurrentRoom.AddRoomExit(door.NextRoom,
                        name: "burnt down door",
                        description: "This is a really burnt da0wn door. It seem to have been locked, but not anymore, fam.");

                    return true;
	        }
	        return false;
	    }
	}
}
