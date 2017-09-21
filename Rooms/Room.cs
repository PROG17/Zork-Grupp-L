using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L
{
    class Room : Inventory
    {
        public void PrintDescription()
        {
            Console.Write("{0}", this.description);
            
            if (Game.player.isNaked)
            {
                Console.WriteLine(" You are naked.");
            }

            Console.WriteLine("In this room you see {0}", this.ListByNameInInventory());
        }

        public void PrintInspect()
        {
            Console.WriteLine("{0}", this.description);
        }

    }
}
