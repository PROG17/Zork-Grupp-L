using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L
{
    public abstract class FurnishingItem : NamedObject
    {
        //Basically copy paste från inventoryitem-klassen (aningen förvirrad om jag gör rätt.)
        public GameFunctions.Inventory CurrentInventory { get; private set; }

        public void PrintItemDescription()
        {         
            Console.WriteLine("You take a closer look at the {0}. {1}", this.Name, this.Description);
        }
        public virtual void OnAddedToInventory(GameFunctions.Inventory inventory)
        {
            this.CurrentInventory = inventory;
    
        }
    }
}
