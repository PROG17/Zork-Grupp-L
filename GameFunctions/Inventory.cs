using System.Collections.Generic;
using Zork_Grupp_L.Helpers;
using Zork_Grupp_L.Items;

namespace Zork_Grupp_L.GameFunctions
{
	public abstract class Inventory : NamedObject
    {
        private readonly HashSet<BaseItem> items;

        protected Inventory()
        {
            this.items = new HashSet<BaseItem>();
        }

        protected Inventory(params BaseItem[] items)
        {
            this.items = new HashSet<BaseItem>(items);
        }
    
        /// <summary>
        /// Gets the number of items in this inventory.
        /// </summary>
        public int InventoryItemsCount => this.items.Count;

		/// <summary>
		/// Gives true if there's no items in this inventory.
		/// </summary>
	    public bool IsInventoryEmpty => this.items.Count == 0;

        /// <summary>
        /// AddToInventory an item to this inventory. Returns true on success.
        /// Fails if item already exists in this inventory.
        /// </summary>
        public bool AddToInventory(BaseItem item)
        {
            if (item == null) return false;

	        if (!this.items.Add(item)) return false;

	        item.OnAddedToInventory(this);
	        return true;
        }

        /// <summary>
        /// Returns true if this inventory contain <paramref Name="item"/>.
        /// </summary>
        public bool ContainsInInventory(BaseItem item)
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
			var itemNames = new List<string>(this.InventoryItemsCount);

			foreach (BaseItem inventoryItem in this.items)
			{
				itemNames.Add(addPrefix ? inventoryItem.PrefixedName : inventoryItem.Name);
			}

			return itemNames.ToArray();
		}

		/// <summary>
		/// Removes an item from this inventory. Returns true on success.
		/// Fails if item doens't exist in this inventory.
		/// </summary>
		public bool InventoryRemoveItem(BaseItem item)
        {
            if (item == null) return false;

            return this.items.Remove(item);
        }

        /// <summary>
        /// Takes <paramref Name="item"/> from an inventory, removing it in the process.
        /// Returns null if inventory does not contain <paramref Name="item"/>.
        /// </summary>
        public BaseItem InventoryTakeItem(BaseItem item)
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
        public bool InventoryTransferItem(BaseItem item, Inventory target)
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
	    public BaseItem InventoryFindItem(string needle)
	    {
		    if (needle == null) return null;
			
			foreach (BaseItem inventoryItem in this.items)
			{
				if (StringHelper.KindaEquals(needle, inventoryItem.Name))
					return inventoryItem;
			}

		    return null;
	    }

	    /// <summary>
	    /// Try find an item in the inventory. Returns false if not found.
	    /// </summary>
		public bool InventoryFindItem(string needle, out BaseItem item)
	    {
		    item = InventoryFindItem(needle);
		    return item != null;
	    }
    }
}