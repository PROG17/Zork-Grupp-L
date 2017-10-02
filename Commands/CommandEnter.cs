using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Zork_Grupp_L.Helpers;
using Zork_Grupp_L.Items;

namespace Zork_Grupp_L.Commands
{
	public class CommandEnter : BaseCommand
	{
		public override string[] Syntax { get; } =
		{
			$@"(?<cmd>go *to|enter){P_THE}(?<what>.+)?",
		};

		public override void Execute(Match match, string pattern)
		{
			Group g_cmd = match.Groups["cmd"];
			Group g_what = match.Groups["what"];

			if (g_what.Success)
			{
				string whatToEnter = g_what.Value;

				// The search algo

				List<RoomExit> exits = FindItems(i => i is RoomExit e && StringHelper.KindaEquals(e.NextRoom.Name, whatToEnter))
					.Cast<RoomExit>().ToList();

				if (exits.Count == 1)
				{
					RoomExit exit = exits[0];
					CommandExit.ExitThroughDoor(exit);
				}
				else if (exits.Count > 1)
				{
					string joinedString = exits.Select(e=>e.NextRoom.Name).ToArray().Join(", ", ", or ", " or ");

					Console.ForegroundColor = Colors.ErrorColor;
					ConsoleHelper.WriteLineWrap("Couldn't distinguish between {0}.", joinedString);
				}
				else
				{
					if (!TryFindItem(whatToEnter, out BaseItem item)) return;
				    CommandExit.ExitThroughDoor(item);
				}
			}
			else
			{
				Console.ForegroundColor = Colors.ErrorColor;
				string cmd = g_cmd.Value.ToLower();
				if (cmd.StartsWith("go"))
					ConsoleHelper.WriteLineWrap("Go to what?");

				ConsoleHelper.WriteLineWrap("{0} what?", cmd.ToFirstUpper());
			}
		}
	}
}