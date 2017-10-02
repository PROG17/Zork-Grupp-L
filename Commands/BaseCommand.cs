using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Zork_Grupp_L.Helpers;
using Zork_Grupp_L.Items;

namespace Zork_Grupp_L.Commands
{
	public abstract class BaseCommand
	{
		protected const string P_NONE = @"(?: +|$)";
		protected const string P_THE = @"(?: +the(?: +|$)|$| +)";
		protected const string P_THROUGH = @"(?: +through(?: +|$)|$| +)";
		protected const string P_THROUGHTHE = @"(?: +through" + P_THE + "|$| +)";
	    protected const string P_ANDONTHE = @"(?: +(?:and|on)" + P_THE + "|$)";

        public abstract string[] Syntax { get; }

		public abstract void Execute(Match match, string pattern);

		public bool TryExecute(string trimmedInput)
		{
			foreach (string pattern in this.Syntax)
			{
				string actualPattern = $"^{pattern.Replace(" ", @"\s")}$";

				Match match = Regex.Match(trimmedInput, actualPattern, RegexOptions.IgnoreCase);
				if (match.Success)
				{
					this.Execute(match, pattern);
					return true;
				}
			}

			return false;
		}


		public static List<BaseItem> FindItems(string needle)
		{
			List<BaseItem> items = Game.CurrentRoom.InventoryFindItems(needle);
			items.AddRange(Game.CurrentPlayer.InventoryFindItems(needle));
			return items;
		}

		public static List<BaseItem> FindItems(string needle, Func<BaseItem, string> selector)
		{
			List<BaseItem> items = Game.CurrentRoom.InventoryFindItems(needle, selector);
			items.AddRange(Game.CurrentPlayer.InventoryFindItems(needle, selector));
			return items;
		}

		public static List<ItemType> FindItems<ItemType>() where ItemType : BaseItem
		{
			List<ItemType> items = Game.CurrentRoom.InventoryFindItems<ItemType>();
			items.AddRange(Game.CurrentPlayer.InventoryFindItems<ItemType>());
			return items;
		}

		public static List<ItemType> FindItems<ItemType>(string needle) where ItemType : BaseItem
		{
			List<ItemType> items = Game.CurrentRoom.InventoryFindItems<ItemType>(needle);
			items.AddRange(Game.CurrentPlayer.InventoryFindItems<ItemType>(needle));
			return items;
		}

		public static List<ItemType> FindItems<ItemType>(string needle, Func<ItemType, string> selector) where ItemType : BaseItem
		{
			List<ItemType> items = Game.CurrentRoom.InventoryFindItems<ItemType>(needle, selector);
			items.AddRange(Game.CurrentPlayer.InventoryFindItems<ItemType>(needle, selector));
			return items;
		}

		public static bool TryFindItem(string nameMatch, out BaseItem item)
		{
			List<BaseItem> items = FindItems(nameMatch);

			if (items.Count == 1)
			{
				item = items[0];
				return true;
			}
			else if (items.Count > 1)
			{
				Console.ForegroundColor = Colors.ErrorColor;
				ConsoleHelper.WriteLineWrap("Couldn't distinguish between the {0}.", items.GetNames().Join(", the ", ", or the ", " or the "));
			}
			else
			{
				Console.ForegroundColor = Colors.ErrorColor;
				ConsoleHelper.WriteLineWrap("Can't see any '{0}', in the vicinity.", nameMatch);
			}

			item = null;
			return false;
		}
	}
}