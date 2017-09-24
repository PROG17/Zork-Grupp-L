using System;
using System.Text.RegularExpressions;
using Zork_Grupp_L.Helpers;

namespace Zork_Grupp_L.Commands
{
	public class CommandDrop : Command
	{
		public override string[] Syntax { get; } = {
			@"(drop)(?: +(?:the +)?(.+))?",
		};

		public override void Execute(Match match, string pattern)
		{
			if (match.Groups.Count == 3)
			{
				string whatToPickup = match.Groups[2].Value;

				if (Game.CurrentPlayer.InventoryFindItem(whatToPickup, out InventoryItem item))
				{
					Game.CurrentPlayer.InventoryTransferItem(item, Game.CurrentRoom);
					Console.WriteLine("You dropped up the {0}.", item.Name);
				}
				else if (Game.CurrentRoom.InventoryFindItem(whatToPickup, out item))
				{
					Console.ForegroundColor = Colors.ErrorColor;
					Console.WriteLine("You aren't even carrying {0}, silly.", item.PrefixedName);
				}
				else
				{
					Console.ForegroundColor = Colors.ErrorColor;
					Console.WriteLine("Don't know what you mean with {0}...", whatToPickup);
				}
			}
			else
			{
				string cmd = match.Groups[1].Value.ToFirstUpper();

				Console.ForegroundColor = Colors.ErrorColor;
				Console.WriteLine("{0} what?", cmd);
			}
		}
	}
}