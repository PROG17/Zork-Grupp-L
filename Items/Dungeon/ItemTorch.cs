using System;

namespace Zork_Grupp_L.Items
{
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
		    if (otherItem is FurnishPuddle)
		    {
			    this.IsLit = false;
			    return true;
		    }

			if (otherItem is ExitBurnDownableDoor door)
		    {
			    if (this.IsLit)
			    {
				    ConsoleHelper.WriteLineWrap("You burnt down that door ayao, cool.");
				    // Remove door from it's parent inventory
				    door.CurrentInventory.InventoryRemoveItem(door);
				    // Add new (and not locked) door to room
				    Game.CurrentRoom.AddRoomExit(door.NextRoom,
					    name: "burnt down door",
					    description: "This is a really burnt da0wn door. It seem to have been locked, but not anymore, fam.");
			    }
			    else
			    {
				    Console.ForegroundColor = Colors.ErrorColor;
				    ConsoleHelper.WriteLineWrap("The torch is not burning, but in your frustration you bash the door open with the {0}.", this.Name);

				    // Remove door from it's parent inventory
				    door.CurrentInventory.InventoryRemoveItem(door);
				    // Add new (and not locked) door to room
				    Game.CurrentRoom.AddRoomExit(door.NextRoom,
					    name: "broken door",
					    description: "A collection of smitherines on the floor. It seem to have been locked, but you can just walk over the crumbs.");
				}
			    return true;
		    }

		    return false;
	    }
	}
}
