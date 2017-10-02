using System;
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

                ExitThroughDoor(item);
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

        public static void ExitThroughDoor(BaseItem item)
        {
            if (item is RoomExit exit)
            {
                if (exit.IsLocked)
                {
                    ConsoleHelper.WriteLineWrap("You can't go through the {0}, it is locked!", exit.Name);
                }
                else
                {
                    ConsoleHelper.WriteLineWrap(
                        "You go through the {0} and end up in the {1}. {2}. \nIn this room you see {3}",
                        exit.Name,
                        exit.NextRoom.Name,
                        exit.NextRoom.Description,
                        exit.NextRoom.InventoryListNames());
                    Game.GoToRoom(exit.NextRoom);
                }
            }
            else
            {
                Console.ForegroundColor = Colors.ErrorColor;
                ConsoleHelper.WriteLineWrap("You can't exit through {0}, you scoot boot.", item.PrefixedName);
            }
        }
    }
}