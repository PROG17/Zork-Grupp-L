using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L.Items
{
    public class ItemTorch : InventoryItem
	{

		public override string Name => this.IsLit
			? "burning torch"
			: "extinguished torch";

		public override string Description => this.IsLit
			? "This torch can be used for seeing in the dark or burning things."
			: "This torch is no longer burning, but it still drips of oil.";

		public bool IsLit { get; private set; } = true;
	}
}
