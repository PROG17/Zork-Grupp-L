﻿namespace Zork_Grupp_L.Items.Dungeon
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
	}
}