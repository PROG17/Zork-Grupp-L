﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L.Rooms
{
    class Dungeon : Room
    {
        public Dungeon()
        {
            this.name = "Dungeon";
            this.description = "You're in an adequate-assed dungeon. Naked.";
            this.roomInventory = new HashSet<Inventory>();
        }
    }
}