using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L.Items
{
    class ItemTorch : InventoryItem
    {
        public ItemTorch()
        {
            this.name = "torch";
            this.description = "This torch can be used for seeing in the dark or burning things.";
        }
    }
}
