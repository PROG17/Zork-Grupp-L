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

				if (!TryFindItem(whatToPickup, out BaseItem item)) return;

				if (item.CurrentInventory is Player)
				{
					ConsoleHelper.WriteLineWrap("You dropped the {0}.", item.Name);
					Game.CurrentPlayer.InventoryTransferItem(item, Game.CurrentRoom);
				}
				else
				{
					Console.ForegroundColor = Colors.ErrorColor;
					ConsoleHelper.WriteLineWrap("You aren't even carrying {0}, silly.", item.PrefixedName);
				}
			}
			else
			{
				string cmd = g_cmd.Value.ToLower().ToFirstUpper();

				Console.ForegroundColor = Colors.ErrorColor;
				ConsoleHelper.WriteLineWrap("{0} what?", cmd);
			}
		}
	}
}