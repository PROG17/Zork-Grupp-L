using System;
using Zork_Grupp_L.GameFunctions;
using Zork_Grupp_L.Helpers;

namespace Zork_Grupp_L.Items
{
	public abstract class BaseItem : NamedObject
	{
		/// <summary>
		/// Example: "a" or "an". If null it will use the <see cref="StringHelper.AutoAorAn"/>
		/// </summary>
		public virtual string ListPrefix { get; } = null;

		/// <summary>
		/// <see cref="NamedObject.Name"/> combined with <see cref="ListPrefix"/>.
		/// </summary>
		public string PrefixedName => ListPrefix == null ? this.Name.AutoAorAn() : $"{ListPrefix} {this.Name}";

		/// <summary>
		/// The inventory this item belongs to.
		/// </summary>
		public Inventory CurrentInventory { get; private set; }

		public void PrintItemDescription()
		{
			Console.ForegroundColor = Colors.DefaultColor;
			Console.WriteLine("You take a closer look at the {0}. {1}", this.Name, this.Description);
		}

		public virtual void OnAddedToInventory(Inventory inventory)
		{
			this.CurrentInventory = inventory;
		}

		public virtual void OnRemovedFromInventory()
		{
			this.CurrentInventory = null;
		}
	}
}