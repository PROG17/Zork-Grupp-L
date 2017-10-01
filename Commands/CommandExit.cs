using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Zork_Grupp_L.Helpers;
using Zork_Grupp_L.Items;

namespace Zork_Grupp_L.Commands
{
	public class CommandExit : BaseCommand
	{
		public override string[] Syntax { get; } =
		{
			$@"(?<cmd>go +through|go +out){P_THE}(?<what>.+)?",
			$@"(?<cmd>leave|exit){P_THROUGHTHE}(?<what>.+)?",
		};

		public override void Execute(Match match, string pattern)
		{
			Group g_cmd = match.Groups["cmd"];
			Group g_what = match.Groups["what"];

			if (g_what.Success)
			{
				string whatToFind = g_what.Value;

				if (!TryFindItem(whatToFind, out BaseItem item)) return;

				if (item is RoomExit exit)
				{
					ConsoleHelper.WriteLineWrap(
						"You go through the {0} and end up in the {1}.", exit.Name, exit.NextRoom.Name);
					Game.GoToRoom(exit.NextRoom);
				}
				else
				{
					Console.ForegroundColor = Colors.ErrorColor;
					ConsoleHelper.WriteLineWrap("You can't exit through {0}, you scoot boot.", item.PrefixedName);
				}
			}
			else
			{
				Console.ForegroundColor = Colors.ErrorColor;
				string cmd = g_cmd.Value.ToLower();
				if (cmd.StartsWith("go"))
					ConsoleHelper.WriteLineWrap("Go through what?");
				else
					ConsoleHelper.WriteLineWrap("{0} through what?", cmd.ToFirstUpper());
			}
		}
	}
}