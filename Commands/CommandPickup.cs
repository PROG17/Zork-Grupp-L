using System;
using System.Text.RegularExpressions;
using Zork_Grupp_L.Helpers;

namespace Zork_Grupp_L.Commands
{
	public class CommandPickup : Command
	{
		public override string[] Syntax { get; } = {
			@"(pick *up|take|grab)(?: +(?:the +)?(.+))?",
		};

		public override void Execute(Match match, string pattern)
		{
			if (match.Groups.Count == 3)
			{
				string whatToPickup = match.Groups[2].Value;

				if (Game.CurrentRoom.InventoryFindItem(whatToPickup, out InventoryItem item))
				{
					Game.CurrentRoom.InventoryTransferItem(item, Game.CurrentPlayer);
					Console.WriteLine("You picked up the {0}.", item.Name);
				}
				else if (Game.CurrentPlayer.InventoryFindItem(whatToPickup, out item))
				{
					Console.ForegroundColor = Colors.ErrorColor;
					Console.WriteLine("You are already carrying {0}, dum dum.", item.PrefixedName);
				}
				else
				{
					Console.ForegroundColor = Colors.ErrorColor;
					Console.WriteLine("There's no {0} in the vicinity...", whatToPickup);
				}
			}
			else
			{
				string cmd = match.Groups[1].Value.StartsWith("pick")
					? "Pickup"
					: match.Groups[1].Value.ToFirstUpper();

				Console.ForegroundColor = Colors.ErrorColor;
				Console.WriteLine("{0} what?", cmd);
			}
		}
	}
}