using System;
using System.Collections.Generic;
using System.Linq;

namespace Zork_Grupp_L.Commands
{
	using System.Text.RegularExpressions;
	using Zork_Grupp_L.Helpers;
	using Zork_Grupp_L.Items;

	public class CommandUseItemPreset<ItemType> : BaseCommand where ItemType : BaseItem
	{
		public CommandUseItemPreset(string verb)
		{
			this.command = verb.Trim().ToLower();
			this.Syntax = new[] {
				$@"(?<cmd>{this.command}){P_THE}(?<what>.+)?",
			};
		}

		private readonly string command;
		public override string[] Syntax { get; }

		public override void Execute(Match match, string pattern)
		{
			//Group g_cmd = match.Groups["cmd"];
			Group g_what = match.Groups["what"];

			List<ItemType> candidates = FindItems<ItemType>();

			if (candidates.Count != 1)
			{
				Console.ForegroundColor = Colors.ErrorColor;
				ConsoleHelper.WriteLineWrap("There's no item to {0} with!", this.command);
				return;
			}

			ItemType mainItem = candidates[0];

			if (g_what.Success)
			{
				string whatToBurn = g_what.Value;

				if (TryFindItem(whatToBurn, out BaseItem item))
				{
					CommandUse.UseItemOnItem(mainItem, item);
				}
			}
			else
			{
				Console.ForegroundColor = Colors.ErrorColor;
				ConsoleHelper.WriteLineWrap("{0} what?", this.command.ToFirstUpper());
			}
		}
	}
}