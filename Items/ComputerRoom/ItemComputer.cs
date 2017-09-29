using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L.Items.ComputerRoom
{
    public class ItemComputer : InventoryItem
    {       
            public ItemComputer()
            {
                this.Name = "computer";
                this.Description = "This computer seems to be running on windows vista";
            }

            public override string Name { get; }
            public override string Description { get; }
        
    }
}