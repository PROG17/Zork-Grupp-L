using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L
{
    using Zork_Grupp_L.Rooms;

    class Player : Inventory
    {
        public Player()
        {
            Console.WriteLine("Welcome to our game, let's play!");
            Console.Write("What's your name? ");
            string username = Console.ReadLine();
            this.name = username;
        }

        public bool isNaked
        {
            get
            {
                if (this.ContainsInInventory("Frock coat"))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

    }
}
