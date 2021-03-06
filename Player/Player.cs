﻿using System;
using Zork_Grupp_L.GameFunctions;
using Zork_Grupp_L.Helpers;

namespace Zork_Grupp_L
{
	public class Player : Inventory
    {
        public Player()
        {
	        Console.ForegroundColor = Colors.DefaultColor;
	        ConsoleHelper.WriteLineWrap("What's your name?");

	        string username = null;
	        while (string.IsNullOrEmpty(username))
	        {
		        if (username != null)
				{
					Console.ForegroundColor = Colors.ErrorColor;
					Console.WriteLine("At least type some name!");
				}

				Console.ForegroundColor = Colors.DefaultColor;
		        Console.Write("> ");
		        Console.ForegroundColor = Colors.InputColor;

		        username = Console.ReadLine().Trim();
	        }

		    this.Name = username;
	        Console.ForegroundColor = Colors.DefaultColor;
	        ConsoleHelper.WriteLineWrap("Be greeted, {0}!", username);
        }

	    public override string Name { get; }
	    public override string Description { get; } = null;

        public bool IsNaked => !(this.InventoryContains("frock coat") && this.InventoryContains("cylinder hat"));

	    public void PrintPlayerDescription()
	    {
			Console.ForegroundColor = Colors.DefaultColor;
		    ConsoleHelper.WriteLineWrap("You find yourself being {0}, a wild {1}adventurer in the {2}. ",
			    this.Name,
			    this.IsNaked ? "NAKED " : string.Empty,
			    Game.CurrentRoom.Name);

			this.PrintPlayerInventory();
	    }

	    public void PrintPlayerInventory()
	    {
			Console.ForegroundColor = Colors.DefaultColor;

		    if (this.IsInventoryEmpty)
			    ConsoleHelper.WriteLineWrap("You are not carrying anything.");
		    else
			    ConsoleHelper.WriteLineWrap("You are currently carrying {0}.", this.InventoryListNames());
	    }
    }
}
