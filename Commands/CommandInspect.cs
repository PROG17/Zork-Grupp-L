using System;
using System.Text.RegularExpressions;
using Zork_Grupp_L.Helpers;

namespace Zork_Grupp_L.Commands
{
	public class CommandInspect : Command
	{
		public override string[] Syntax { get; } = {
			@"look",
			@"look +around",
			@"who +am +i",
			@"whoami",
			@"inventory",
			@"items",
			@"(look +at|examine|inspect)(?: +(?:the +)?(.+))?",
		};

		public override void Execute(Match match, string pattern)
		{
			if (pattern == "look" || pattern == "look +around")
			{
				Game.CurrentRoom.PrintRoomDescription();
			}
			else if (pattern == "who +am +i" || pattern == "whoami")
			{
				Console.WriteLine(Game.CurrentPlayer.Name);
			}
			else if (pattern == "inventory" || pattern == "items")
			{
				Game.CurrentPlayer.PrintPlayerInventory();
			}
			else
			{
				if (match.Groups.Count == 3)
				{
					string whatToInspect = match.Groups[2].Value;
					string whatToInspectLower = whatToInspect.ToLower();

					if (StringHelper.KindaEquals(whatToInspect, Game.CurrentRoom.Name) || whatToInspectLower == "room")
					{
						Game.CurrentRoom.PrintRoomDescription();
					}
					else if (Regex.IsMatch(whatToInspect, @"\b(self|myself|me|player)\b", RegexOptions.IgnoreCase))
					{
						Game.CurrentPlayer.PrintPlayerDescription();
					}
					else if (Regex.IsMatch(whatToInspect, @"\b(inventory|items)\b", RegexOptions.IgnoreCase))
					{
						Game.CurrentPlayer.PrintPlayerInventory();
					}
					else
					{
						if (Game.CurrentRoom.InventoryFindItem(whatToInspect, out var item)
						    || Game.CurrentPlayer.InventoryFindItem(whatToInspect, out item))
						{
							item.PrintItemDescription();
						}
						else
						{
							Console.ForegroundColor = Colors.ErrorColor;
							Console.WriteLine("There's no {0} in the vicinity...", whatToInspect);
						}
					}
				}
				else
				{
					string cmd = match.Groups[1].Value.StartsWith("look") ? "Look at" : match.Groups[1].Value.ToFirstUpper();

					Console.ForegroundColor = Colors.ErrorColor;
					Console.WriteLine("{0} what?", cmd);
				}
			}
		}
	}
}
