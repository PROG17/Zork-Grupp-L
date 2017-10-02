﻿using Zork_Grupp_L.Items;
using Zork_Grupp_L.Items.Dungeon;

namespace Zork_Grupp_L.Rooms
{
    using System;
    using System.Runtime.CompilerServices;

    using Zork_Grupp_L.GameFunctions;
    using Zork_Grupp_L.Helpers;

    public class Dungeon : Room
    {
        public Dungeon()
        {
            this.Name = "dungeon";
            this.Description = "An adequate-assed dungeon.";

	        this.AddToInventory(new ItemFrockCoat());
	        this.AddToInventory(new ItemCylinderHat());
	        this.AddToInventory(new ItemTorch());

	        this.AddToInventory(new FurnishPuddle());
	        this.AddToInventory(new FurnishChair());
        }

	    public override string Name { get; }
	    public override string Description { get; }
        

        
    }
}
