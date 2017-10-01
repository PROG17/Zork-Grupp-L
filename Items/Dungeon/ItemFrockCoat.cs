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

			AddedToInventory += OnAddedToInventory;
			RemovedFromInventory += OnRemovedFromInventory;
		}

		public override string Name { get; }
		public override string Description { get; }

		private void OnAddedToInventory(Inventory inventory)
		{
			if (inventory is Player)
			{
				ConsoleHelper.WriteLineWrap(inventory.InventoryContains<ItemCylinderHat>()
					? "This coat warms your body, you enjoy not being naked anymore."
					: "This coat warms your body, you feel slightly less naked.");
			}
		}

		private void OnRemovedFromInventory(Inventory inventory)
		{
			if (inventory is Player)
				ConsoleHelper.WriteLineWrap("You feel the chills approaching. You've no clothes on, you're naked!" +
				                            " Better pick up that coat again.");
		}
	}
}
