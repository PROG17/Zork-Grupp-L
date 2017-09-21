using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L
{
    using Zork_Grupp_L.Items;
    using Zork_Grupp_L.Rooms;

    static class Game 
    {
        public static Player player;
        public static Room currentRoom;

        public static void StartGame()
        {
            var startRoom = new Dungeon();
            startRoom.AddToInventory(new ItemFrockCoat());
            startRoom.AddToInventory(new ItemCylinderHat());
            startRoom.AddToInventory(new ItemTorch());

            player = new Player();
            currentRoom = startRoom;
            currentRoom.PrintDescription();
            while (true)
            {
                UserInput();
            }
        }

        public static void UserInput()
        {
            string userInput = Console.ReadLine().ToLower().Trim();

            if (userInput == "look around" || userInput == "look")
            {
                currentRoom.PrintDescription();
            }
            else if (userInput.StartsWith("poop"))
            {
               /* player.Poop(); */
            }
            else if (userInput == "inspect")
            {
                Console.WriteLine("Inspect what?");
            }
            else if (userInput.StartsWith("inspect "))
            {
                string whatIsInspected = userInput.Substring(userInput.IndexOf(" ") + 1);
                if (whatIsInspected == currentRoom.name || whatIsInspected == "room")
                {
                    currentRoom.PrintDescription();
                }

            else if (userInput == "take" || userInput == "pick up")
            {
                   //kod för att ta något från rummets inventory till spelarens.
            }
            else if (userInput == "drop")
            {
                    /*Tänkte nåt sånt här men gick inte so I dont know..
                   TakeFromInventory(userInput);*/
            }
            }
            else
            {
                Console.WriteLine("Sorry, I don't understand.");
            }

        }
    }
}
