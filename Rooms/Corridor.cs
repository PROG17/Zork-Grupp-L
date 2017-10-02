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

		public override void OnEnterRoom()
		{
			base.OnEnterRoom();

			CheckUserCarriesUnauthorizedItems();
		}

		private void CheckUserCarriesUnauthorizedItems()            
        {   
			//Om spelaren är naken så ska spelet avslutas på nått vis
            if (Game.CurrentPlayer.IsNaked)
            {
                ConsoleHelper.WriteLineWrap("You can't walk into school naked, you wing nut! " +
                    "You've embarrased yourself and can't get to the 'Arbetsmarknad'.");
                Game.GameOver = true;
            }
			//Om spelaren bär på en burning torch så ska spelet avslutas.
            else if (Game.CurrentPlayer.InventoryTryFindItem("torch", out BaseItem item)
				&& item is ItemTorch torch
				&& torch.IsLit)
            {
                ConsoleHelper.WriteLineWrap("You can't bring fire into the school, you wing nut! " +
                    "You've lost all you chances in getting a job, nobody likes an arsonist.");
                Game.GameOver = true;
            }
        }
	}
}