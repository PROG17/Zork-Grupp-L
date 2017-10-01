using System;
using Zork_Grupp_L.Helpers;
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
        
        public void IfUserCarriesUnauthorizedItems()            
        {   //Om spelaren är naken så ska spelet avslutas på nåt vis
            if (Game.CurrentPlayer.IsNaked)
            {
                ConsoleHelper.WriteLineWrap("You can't walk into school naked, you wing nut! " +
                    "You've embarrased yourself and can't get to the 'Arbetsmarknad'.");
                Game.EndGame();
                
            }
            string torchInventory = "burning torch";
            //Om spelaren bär på en burning torch så ska spelet avslutas.
            if (Game.CurrentPlayer.InventoryFindItem(torchInventory, out BaseItem item))
            {
                ConsoleHelper.WriteLineWrap("You can't bring fire into the school, you wing nut! " +
                    "You've lost all you chances in getting a job, nobody likes an arsonist.");
                Game.EndGame();
            }
        }
	}
}