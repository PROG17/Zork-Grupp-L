using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zork_Grupp_L.GameFunctions;
using Zork_Grupp_L.Helpers;

namespace Zork_Grupp_L
{
    public abstract class InventoryItem : NamedObject
    {
	    /// <summary>
	    /// Example: "a" or "an". If null it will use the <see cref="StringHelper.AutoAorAn"/>
	    /// </summary>
	    public virtual string ListPrefix { get; } = null;

		/// <summary>
		/// The inventory this item belongs to.
		/// </summary>
		public Inventory CurrentInventory { get; private set; }
		
        public void PrintItemDescription()
        {
	        Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("You take a closer look at the {0}. {1}", this.Name, this.Description);
        }

	    public virtual void OnAddedToInventory(Inventory inventory)
	    {
		    this.CurrentInventory = inventory;
	    }

	    public virtual void OnRemovedFromInventory()
	    {
		    this.CurrentInventory = null;
	    }

    }

}
