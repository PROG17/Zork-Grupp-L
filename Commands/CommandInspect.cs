using System;
using System.Text.RegularExpressions;
using Zork_Grupp_L.Helpers;
using Zork_Grupp_L.Items;

namespace Zork_Grupp_L.Commands
{
	public class CommandInspect : BaseCommand
	{
		public override string[] Syntax { get; } =
		{
			@"look",
			@"look +around",
			@"who +am +i",
			@"whoami",
			@"(?<what>room|inventory|items)",
			$@"(?<cmd>look +at|examine|inspect|check){P_THE}(?<what>.+)?",
		};

		public override void Execute(Match match, string pattern)
		{
			Group g_what = match.Groups["what"];
			Group g_cmd = match.Groups["cmd"];

			if (pattern.StartsWith("look")) // look & look around
			{
				Game.CurrentRoom.PrintRoomDescription();
			}
			else if (pattern.StartsWith("who")) // whoami
			{
				Console.WriteLine(Game.CurrentPlayer.Name);
			}
			else
			{
				if (g_what.Success)
				{
					string whatToInspect = g_what.Value;
					string whatToInspectLower = whatToInspect.ToLower();

					if (whatToInspectLower == "room")
					{
						Game.CurrentRoom.PrintRoomDescription();
					}
					else if (StringHelper.EqualsAny(whatToInspectLower,
						"self", "myself", "me", "yourself", "player", "user"))
					{
						Game.CurrentPlayer.PrintPlayerDescription();
					}
					else if (whatToInspectLower == "inventory")
					{
						Game.CurrentPlayer.PrintPlayerInventory();
					}
					else if (whatToInspectLower == "items")
					{
						Game.CurrentRoom.PrintRoomInventory();
						Game.CurrentPlayer.PrintPlayerInventory();
					}
					else if (TryFindItem(whatToInspect, out BaseItem item))
					{ 
						item.PrintItemDescription();
					}
				}
				else
				{
					Console.ForegroundColor = Colors.ErrorColor;
					
					string cmd = g_cmd.Value.ToLower();

					// Custom check because you can type "look           at"
					if (!g_cmd.Success || cmd.StartsWith("look"))
						ConsoleHelper.WriteLineWrap("Look at what?");
					else
						ConsoleHelper.WriteLineWrap("{0} what?", cmd.ToFirstUpper());
				}
			}
		}
	}
}