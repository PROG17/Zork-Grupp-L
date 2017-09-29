using System;
using Zork_Grupp_L.Items;

namespace Zork_Grupp_L.Rooms
{
	public class Corridor : Room
	{
		public Corridor()
		{
			this.Name = "corridor";
			this.Description = "A long and chilly hallway.";
		}
        

		public override string Name { get; }
		public override string Description { get; }


        string frockInventory = "frock coat";
        string hatInventory = "cylinder hat";
        string torchInventory = "burning torch";
        
        public void IfUserCarriesUnauthorizedItems()            
        {   //Om spelaren inte bär på frock coat och cylinder hat så ska spelet avslutas på nåt vis
            if (!Game.CurrentPlayer.InventoryFindItem(frockInventory, out BaseItem item) 
                && !Game.CurrentPlayer.InventoryFindItem(hatInventory, out item))
            {
                    Console.WriteLine("You can't walk into school naked, you wing nut! " +
                    "You've embarrased yourself and can't get to the 'Arbetsmarknad'. Game Over!!");
            }
            //Om spelaren bär på en burning torch så ska spelet avslutas.
            if (Game.CurrentPlayer.InventoryFindItem(torchInventory, out item))
            {
                Console.WriteLine("You can't bring fire into the school!! " +
                    "You've lost all you chances in getting a job, nobody likes an arsonist. Game over!");
            }
        }
	}
}