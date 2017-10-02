using System;

namespace Zork_Grupp_L.Commands
{
    using System.Text.RegularExpressions;

    using Zork_Grupp_L.Helpers;
    using Zork_Grupp_L.Items;

    class CommandUse : BaseCommand
    {
        public override string[] Syntax { get; } = {
            $@"(?<cmd>use){P_THE}(?<what1>.+?)?{P_ANDONTHE}(?<what2>.+)?",
        };

        public override void Execute(Match match, string pattern)
        {
            Group g_what1 = match.Groups["what1"];
            Group g_what2 = match.Groups["what2"];

	        if (g_what1.Success && g_what2.Success)
	        {
		        string whatToUse1 = g_what1.Value;
		        string whatToUse2 = g_what2.Value;

		        if (TryFindItem(whatToUse1, out BaseItem item1)
		            && TryFindItem(whatToUse2, out BaseItem item2))
		        {
			        //if (item1 is InventoryItem && (item2 is InventoryItem || item2 is FurnishingItem))
			        //{
			            string tempName1 = item1.Name;
			            string tempName2 = item2.Name;
			            if (item1.UseOnItem(item2) == true)
			            {

                            ConsoleHelper.WriteLineWrap("You used {0} on {1}. ", tempName1, tempName2);
                        }
                        else if (item2.UseOnItem(item1) == true)
			            {
			                ConsoleHelper.WriteLineWrap("You used {0} on {1}. ", tempName1, tempName2);
                        }
                        else
                        {
                            ConsoleHelper.WriteLineWrap("Nothing happened.");
                        }

			        //}
			        //else
			        //{
				       // Console.ForegroundColor = Colors.ErrorColor;
				       // ConsoleHelper.WriteLineWrap(
					      //  "You cannot use {0} on {1}",
					      //  item1.PrefixedName,
					      //  item2.PrefixedName);
			        //}
		        }
	        }
	        else if (g_what1.Success)
	        {
		        string whatToUse1 = g_what1.Value;
		        if (TryFindItem(whatToUse1, out BaseItem item1))
		        {
					Console.ForegroundColor = Colors.ErrorColor;
					ConsoleHelper.WriteLineWrap("Use the {0} on what?", item1.Name);
		        }
			}
			else
	        {
		        Console.ForegroundColor = Colors.ErrorColor;
		        ConsoleHelper.WriteLineWrap("Use what?");
	        }
        }
    }
}
