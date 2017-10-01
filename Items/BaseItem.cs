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

		protected event Action<Inventory> AddedToInventory;
		protected event Action<Inventory> RemovedFromInventory; 

		public void PrintItemDescription()
		{
			Console.ForegroundColor = Colors.DefaultColor;
			ConsoleHelper.WriteLineWrap("You take a closer look at the {0}. {1}", this.Name, this.Description);
		}

		internal void SetCurrentInventory(Inventory newInventory)
		{
			Inventory oldInventory = this.CurrentInventory;
			this.CurrentInventory = newInventory;

			if (newInventory != oldInventory && oldInventory != null)
				RemovedFromInventory?.Invoke(oldInventory);

			if (newInventory != oldInventory && newInventory != null)
				AddedToInventory?.Invoke(newInventory);
		}
	}
}