using System.Collections.Generic;
using Zork_Grupp_L.Helpers;

namespace Zork_Grupp_L.GameFunctions
{
	public abstract class Inventory : NamedObject
    {
        private readonly HashSet<InventoryItem> items;

        protected Inventory()
        {
            this.items = new HashSet<InventoryItem>();
        }

        protected Inventory(params InventoryItem[] items)
        {
            this.items = new HashSet<InventoryItem>(items);
        }

		/// <summary>
		/// Gets the number of items in this inventory.
		/// </summary>
	    public int Count => this.items.Count;

		/// <summary>
		/// Gives true if there's no items in this inventory.
		/// </summary>
	    public bool IsEmpty => this.items.Count == 0;

        /// <summary>
        /// AddToInventory an item to this inventory. Returns true on success.
        /// Fails if item already exists in this inventory.
        /// </summary>
        public bool AddToInventory(InventoryItem item)
        {
            if (item == null) return false;

	        if (!this.items.Add(item)) return false;

	        item.OnAddedToInventory(this);
	        return true;
        }

        /// <summary>
        /// Returns true if this inventory contain <paramref Name="item"/>.
        /// </summary>
        public bool ContainsInInventory(InventoryItem item)
        {
            if (item == null) return false;

            return this.items.Contains(item);
        }

        /// <summary>
        /// Returns a comma seperated list of the items in this inventory.
        /// </summary>
        public string InventoryListNames(bool addPrefix = true)
		{
			if (this.items.Count == 0) return null;

			string[] itemNames = this.InventoryGetNames(addPrefix);
			return StringHelper.Join(itemNames);
		}

		/// <summary>
		/// Returns an array of all the items names in this inventory.
		/// </summary>
		public string[] InventoryGetNames(bool addPrefix = false)
		{
			var itemNames = new List<string>(this.Count);

			foreach (InventoryItem inventoryItem in this.items)
			{

				if (addPrefix)
				{
					string prefix = inventoryItem.ListPrefix;
					itemNames.Add(prefix == null ? inventoryItem.Name.AutoAorAn() : $"{prefix} {inventoryItem.Name}");
				}
				else
					itemNames.Add(inventoryItem.Name);
			}

			return itemNames.ToArray();
		}

		/// <summary>
		/// Removes an item from this inventory. Returns true on success.
		/// Fails if item doens't exist in this inventory.
		/// </summary>
		public bool InventoryRemoveItem(InventoryItem item)
        {
            if (item == null) return false;

            return this.items.Remove(item);
        }

        /// <summary>
        /// Takes <paramref Name="item"/> from an inventory, removing it in the process.
        /// Returns null if inventory does not contain <paramref Name="item"/>.
        /// </summary>
        public InventoryItem InventoryTakeItem(InventoryItem item)
        {
            if (item == null) return null;
            if (!this.ContainsInInventory(item)) return null;

            this.InventoryRemoveItem(item);
            return item;
        }

        /// <summary>
        /// Transfer <paramref Name="item"/> from this inventory to another.
        /// Returns true on success.
        /// </summary>
        public bool InventoryTransferItem(InventoryItem item, Inventory target)
        {
            if (target == null) return false;
            if (item == null) return false;
            if (!this.ContainsInInventory(item)) return false;

            this.InventoryRemoveItem(item);
            target.AddToInventory(item);

            return true;
        }

		/// <summary>
		/// Try find an item in the inventory. Returns null if not found.
		/// </summary>
	    public InventoryItem InventoryFindItem(string needle)
	    {
		    if (needle == null) return null;
			
			foreach (InventoryItem inventoryItem in this.items)
			{
				if (StringHelper.KindaEquals(needle, inventoryItem.Name))
					return inventoryItem;
			}

		    return null;
	    }
    }
}