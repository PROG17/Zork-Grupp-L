using System;
using System.Text.RegularExpressions;
using Zork_Grupp_L.Helpers;
using Zork_Grupp_L.Items;

namespace Zork_Grupp_L.Commands
{
	public class CommandDrop : BaseCommand
	{
		public override string[] Syntax { get; } = {
			$@"(?<cmd>drop){P_THE}(?<what>.+)?",
		};

		public override void Execute(Match match, string pattern)
		{
			Group g_cmd = match.Groups["cmd"];
			Group g_what = match.Groups["what"];

			if (g_what.Success)
			{
				string whatToPickup = g_what.Value;

				if (Game.CurrentPlayer.InventoryFindItem(whatToPickup, out BaseItem item))
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
					Console.WriteLine("You can't see any '{0}' nearby...", whatToPickup);
				}
			}
			else
			{
				string cmd = g_cmd.Value.ToLower().ToFirstUpper();

				Console.ForegroundColor = Colors.ErrorColor;
				Console.WriteLine("{0} what?", cmd);
			}
		}
	}
}