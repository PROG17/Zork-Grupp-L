using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L
{
    class Room : NamedObject
    {
        internal HashSet<Inventory> roomInventory = new HashSet<Inventory>();
    }
}
