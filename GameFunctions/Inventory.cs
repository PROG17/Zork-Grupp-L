using System;
using System.Collections.Generic;
using System.Linq;
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

			item.SetCurrentInventory(this);
	        return true;
        }

        /// <summary>
        /// Returns true if this inventory contains the item.
        /// </summary>
        public bool InventoryContains(BaseItem item)
        {
            if (item == null) return false;

            return this.items.Contains(item);
        }

	    /// <summary>
	    /// Returns true if this inventory contains an item where its name matches the <paramref name="needle"/> using NameHelper.FindUniqueMatches.
	    /// </summary>
	    public bool InventoryContains(string needle)
	    {
		    var matches = this.items.FindUniqueMatches(needle);
		    return matches.Count == 1;
	    }

		/// <summary>
		/// Returns true if this inventory contains an item of said type.
		/// </summary>
		public bool InventoryContains<ItemType>() where ItemType : BaseItem
		{
			return this.items.Any(i => i is ItemType);
		}

	    /// <summary>
	    /// Returns true if this inventory contains an item of said type
	    /// and its name matches the <paramref name="needle"/> using NameHelper.FindUniqueMatches.
	    /// </summary>
	    public bool InventoryContains<ItemType>(string needle) where ItemType : BaseItem
	    {
		    List<ItemType> matches = this.items.OfType<ItemType>().FindUniqueMatches(needle);
		    return matches.Count == 1;
	    }

		/// <summary>
		/// Returns a comma seperated list of the items in this inventory.
		/// </summary>
		public string InventoryListNames(bool addPrefix = true)
		{
			if (this.items.Count == 0) return null;

			string[] itemNames = addPrefix ? items.GetPrefixedNames() : items.GetNames();
			return itemNames.Join();
		}

		/// <summary>
		/// Removes an item from this inventory. Returns true on success.
		/// Fails if item doens't exist in this inventory.
		/// </summary>
		public bool InventoryRemoveItem(BaseItem item)
        {
            if (item == null) return false;

	        if (!this.items.Remove(item)) return false;

	        item.SetCurrentInventory(null);
			return true;
        }

        /// <summary>
        /// Takes <paramref Name="item"/> from an inventory, removing it in the process.
        /// Returns null if inventory does not contain <paramref Name="item"/>.
        /// </summary>
        public BaseItem InventoryTakeItem(BaseItem item)
        {
            if (item == null) return null;
            if (!this.InventoryContains(item)) return null;

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
            if (!this.InventoryContains(item)) return false;

            this.InventoryRemoveItem(item);
            target.AddToInventory(item);

            return true;
        }

		/// <summary>
		/// Try find an item in the inventory. Returns list of all matching items. Returns empty list if none.
		/// </summary>
		public List<BaseItem> InventoryFindItems(string needle)
		{
			return this.InventoryFindItems(needle, i => i.Name);
		}

		/// <summary>
		/// Try find an item in the inventory. Returns list of all matching items. Returns empty list if none.
		/// </summary>
		public List<BaseItem> InventoryFindItems(string needle, Func<BaseItem, string> selector)
		{
			return items.FindUniqueMatches(needle, selector);
		}

	    /// <summary>
	    /// Try find an item type in the inventory. Returns list of all matching items. Returns empty list if none.
	    /// </summary>
	    public List<ItemType> InventoryFindItems<ItemType>() where ItemType : BaseItem
	    {
		    return items.OfType<ItemType>().ToList();
	    }

	    /// <summary>
	    /// Try find an item type in the inventory. Returns list of all matching items. Returns empty list if none.
	    /// </summary>
	    public List<ItemType> InventoryFindItems<ItemType>(string needle) where ItemType : BaseItem
	    {
		    return this.InventoryFindItems<ItemType>(needle, i => i.Name);
	    }

		/// <summary>
		/// Try find an item by its type and a predicate in the inventory. Returns list of all matching items. Returns empty list if none.
		/// </summary>
		public List<ItemType> InventoryFindItems<ItemType>(string needle, Func<ItemType, string> selector) where ItemType : BaseItem
		{
			return this.items.OfType<ItemType>().FindUniqueMatches(needle, selector);
	    }

		/// <summary>
		/// Try find an item in the inventory. Gives null if not a clear match.
		/// </summary>
		public bool InventoryTryFindItem(string needle, out BaseItem item)
	    {
		    List<BaseItem> items = this.InventoryFindItems(needle);

		    item = items.Count == 1 ? items[0] : null;
		    return item != null;
	    }

		/// <summary>
		/// Try find an item in the inventory. Gives null if not a clear match.
		/// </summary>
		public bool InventoryTryFindItem(string needle, Func<BaseItem, string> selector, out BaseItem item)
		{
			List<BaseItem> items = this.InventoryFindItems(needle, selector);

			item = items.Count == 1 ? items[0] : null;
			return item != null;
		}

	    public bool InventoryTryFindItem<ItemType>(out ItemType item) where ItemType : BaseItem
	    {
		    List<ItemType> items = this.InventoryFindItems<ItemType>();

		    item = items.Count == 1 ? items[0] : null;
		    return item != null;
	    }

	    public bool InventoryTryFindItem<ItemType>(string needle, out ItemType item) where ItemType : BaseItem
	    {
		    List<ItemType> items = InventoryFindItems<ItemType>(needle);

		    item = items.Count == 1 ? items[0] : null;
		    return item != null;
	    }

	    public bool InventoryTryFindItem<ItemType>(string needle, Func<ItemType, string> selector, out ItemType item) where ItemType : BaseItem
	    {
		    List<ItemType> items = InventoryFindItems<ItemType>(needle, selector);

		    item = items.Count == 1 ? items[0] : null;
		    return item != null;
	    }

	}
}