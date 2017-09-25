using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zork_Grupp_L.Items;

namespace Zork_Grupp_L.Rooms
{
    public class Dungeon : Room
    {
        public Dungeon()
        {
            this.Name = "dungeon";
            this.Description = "You're in an adequate-assed dungeon.";


	        this.AddToInventory(new ItemFrockCoat());
	        this.AddToInventory(new ItemCylinderHat());
	        this.AddToInventory(new ItemTorch());
	        this.AddToFurnishingInventory(new ItemPuddle());
		}

	    public override string Name { get; }
	    public override string Description { get; }
    }
}
