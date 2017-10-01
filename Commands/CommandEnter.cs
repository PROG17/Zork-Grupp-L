using System;
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
				Predicate<BaseItem> search = i => 
					i is RoomExit e && StringHelper.KindaEquals(e.NextRoom.Name, whatToEnter);

				if (Game.CurrentRoom.InventoryFindItem(search, out BaseItem item))
				{
					var exit = (RoomExit) item;

					ConsoleHelper.WriteLineWrap(
						"You leave through the {0} and end up in the {1}.", exit.Name, exit.NextRoom.Name);
					Game.GoToRoom(exit.NextRoom);
				}
				else
				{
					Console.ForegroundColor = Colors.ErrorColor;
					ConsoleHelper.WriteLineWrap("You can't see any exits that goes to '{0}'", whatToEnter);
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