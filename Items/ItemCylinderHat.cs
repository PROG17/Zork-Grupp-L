using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L.Items
{
    public class ItemCylinderHat : InventoryItem
	{
		public ItemCylinderHat()
		{
			this.Name = "cylinder hat";
			this.Description = "This is a fancy hat for fancy people.";
		}

		public override string Name { get; }
		public override string Description { get; }
    }
}
