using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L.Rooms
{
    public class Dungeon : Room
    {
        public Dungeon()
        {
            this.Name = "dungeon";
            this.Description = "You're in an adequate-assed dungeon.";
        }

	    public override string Name { get; }
	    public override string Description { get; }
    }
}
