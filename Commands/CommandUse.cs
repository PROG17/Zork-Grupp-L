﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L.Commands
{
    using System.Text.RegularExpressions;

    using Zork_Grupp_L.Helpers;
    using Zork_Grupp_L.Items;

    class CommandUse : BaseCommand
    {
        public override string[] Syntax { get; } = {
            $@"(?<cmd>use){P_THE}(?<what1>.+)?{P_ANDON}(?<what2>.+)?",
        };

        public override void Execute(Match match, string pattern)
        {
            Group g_cmd = match.Groups["cmd"];
            Group g_what1 = match.Groups["what1"];
            Group g_what2 = match.Groups["what2"];

            if (g_what1.Success && g_what2.Success)
            {
                string whatToUse1 = g_what1.Value;
                string whatToUse2 = g_what2.Value;

                if (Game.CurrentPlayer.InventoryFindItem(whatToUse1, out BaseItem item1)
                    && (Game.CurrentPlayer.InventoryFindItem(whatToUse2, out BaseItem item2)
                        ^ Game.CurrentRoom.InventoryFindItem(whatToUse2, out BaseItem item3)))
                {
                    if (item3 != null)
                    {
                        item2 = item3;
                    }


                    Console.WriteLine("You used {0} on {1}", item1.Name, item2.Name);

                }
                /*else
                {
                    Console.ForegroundColor = Colors.ErrorColor;
                    ConsoleHelper.WriteLineWrap("You cannot use {0} on {1}", item1.PrefixedName, item2.PrefixedName);
                }*/
            }
        }
    }
}
