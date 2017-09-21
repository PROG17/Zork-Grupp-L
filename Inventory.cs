namespace Zork_Grupp_L
{
    using System.Collections.Generic;

    public class Inventory
    {
        private readonly HashSet<InventoryItem> items;

        public Inventory()
        {
            this.items = new HashSet<InventoryItem>();
        }

        public Inventory(params InventoryItem[] items)
        {
            this.items = new HashSet<InventoryItem>(items);
        }

        /// <summary>
        /// Add an item to this inventory. Returns true on success.
        /// Fails if item already exists in this inventory.
        /// </summary>
        public bool Add(InventoryItem item)
        {
            if (item == null) return false;

            return this.items.Add(item);
        }

        /// <summary>
        /// Returns true if this inventory contain <paramref name="item"/>.
        /// </summary>
        public bool Contains(InventoryItem item)
        {
            if (item == null) return false;

            return this.items.Contains(item);
        }

        /// <summary>
        /// Returns a comma seperated list of the items in this inventory.
        /// </summary>
        public string ListByName()
        {
            return string.Join(", ", this.items);
        }

        /// <summary>
        /// Removes an item from this inventory. Returns true on success.
        /// Fails if item doens't exist in this inventory.
        /// </summary>
        public bool Remove(InventoryItem item)
        {
            if (item == null) return false;

            return this.items.Remove(item);
        }

        /// <summary>
        /// Takes <paramref name="item"/> from an inventory, removing it in the process.
        /// Returns null if inventory does not contain <paramref name="item"/>.
        /// </summary>
        public InventoryItem Take(InventoryItem item)
        {
            if (item == null) return null;
            if (!this.Contains(item)) return null;

            this.Remove(item);
            return item;
        }

        /// <summary>
        /// Transfer <paramref name="item"/> from this inventory to another.
        /// Returns true on success.
        /// </summary>
        public bool Transfer(InventoryItem item, Inventory target)
        {
            if (target == null) return false;
            if (item == null) return false;
            if (!this.Contains(item)) return false;

            this.Remove(item);
            target.Add(item);

            return true;
        }
    }
}