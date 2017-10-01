using System;
using Zork_Grupp_L.GameFunctions;
using Zork_Grupp_L.Helpers;

namespace Zork_Grupp_L.Items.Dungeon
{
    public class ItemFrockCoat : InventoryItem
	{
		public ItemFrockCoat()
		{
			this.Name = "frock coat";
			this.Description = "It's a sweet looking frock coat, straight outta Nobelfesten.";
		}

		public override string Name { get; }
		public override string Description { get; }

		public override void OnAddedToInventory(Inventory inventory)
		{
			base.OnAddedToInventory(inventory);

			ConsoleHelper.WriteLineWrap("This coat warms your body, you enjoy not being naked anymore.");
		}

		public override void OnRemovedFromInventory()
		{
			base.OnRemovedFromInventory();
            

			ConsoleHelper.WriteLineWrap("You feel the chills approaching. You've no clothes on, you're naked!" +
			                            " Better pick up that coat again.");
		}
	}
}
