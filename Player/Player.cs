using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zork_Grupp_L.GameFunctions;

namespace Zork_Grupp_L
{
    using Zork_Grupp_L.Rooms;

    public class Player : Inventory
    {
        public Player()
        {
	        Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("What's your Name?");
			Console.Write("> ");
	        Console.ForegroundColor = ConsoleColor.White;

            string username = Console.ReadLine();
            this.Name = username;
        }

	    public override string Name { get; }
	    public override string Description => $"This is you, {this.Name}.";

        public bool IsNaked => !this.InventoryFindItem("Frock coat");
    }
}
