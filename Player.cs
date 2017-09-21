using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L
{
    class Player : NamedObject
    {
        static Player PromptUsername()
        {
            Console.WriteLine("Välkommen till spelet! woohoo!!!");
            Console.Write("Vad heter du? ");
            string username = Console.ReadLine();
            Player player = new Player();
            player.name = username;
            return player;

        }
    }
}
