using System;
using System.Text.RegularExpressions;
using Zork_Grupp_L.Helpers;
using Zork_Grupp_L.Items;

namespace Zork_Grupp_L.Commands
{
	public class CommandPickup : BaseCommand
	{
		public override string[] Syntax { get; } = {
			$@"(?<cmd>pick *up|take|grab){P_THE}(?<what>.+)?",
		};

		public override void Execute(Match match, string pattern)
		{
			Group g_cmd = match.Groups["cmd"];
			Group g_what = match.Groups["what"];

			if (g_what.Success)
			{
				string whatToPickup = g_what.Value;

				if (TryFindItem(whatToPickup, out BaseItem item))
				{
					if (item is InventoryItem)
					{
						if (item.CurrentInventory is Player)
						{
							Console.ForegroundColor = Colors.ErrorColor;
							ConsoleHelper.WriteLineWrap("You are already carrying {0}, dum dum.", item.PrefixedName);
						}
						else
						{
							ConsoleHelper.WriteLineWrap("You picked up the {0}.", item.Name);
							Game.CurrentRoom.InventoryTransferItem(item, Game.CurrentPlayer);
						}
					}
					else
					{
						Console.ForegroundColor = Colors.ErrorColor;
						ConsoleHelper.WriteLineWrap("You cannot pick up {0}. Sorry.", item.PrefixedName);
					}
				}
			}
			else
			{
				Console.ForegroundColor = Colors.ErrorColor;
				string cmd = g_cmd.Value.ToLower();

				// Custom check because you can type "pick        up"
				if (!g_cmd.Success || cmd.StartsWith("pick"))
					ConsoleHelper.WriteLineWrap("Pick up what?");
				else
					ConsoleHelper.WriteLineWrap("{0} what?", cmd.ToFirstUpper());
			}
		}
	}
}