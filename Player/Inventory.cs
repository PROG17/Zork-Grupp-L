namespace Zork_Grupp_L
{
    using System.Collections.Generic;

    public class Inventory : NamedObject
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
        /// AddToInventory an item to this inventory. Returns true on success.
        /// Fails if item already exists in this inventory.
        /// </summary>
        public bool AddToInventory(InventoryItem item)
        {
            if (item == null) return false;

            return this.items.Add(item);
        }

        /// <summary>
        /// Returns true if this inventory contain <paramref name="item"/>.
        /// </summary>
        public bool ContainsInInventory(InventoryItem item)
        {
            if (item == null) return false;

            return this.items.Contains(item);

        }

        public bool ContainsInInventory(string name)
        {
            if (name == null) return false;

            foreach (InventoryItem inventoryItem in this.items)
            {
                if (name == inventoryItem.name) return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a comma seperated list of the items in this inventory.
        /// </summary>
        public string ListByNameInInventory()
        {
            List<string> itemNames = new List<string>();
            foreach (InventoryItem inventoryItem in this.items)
            {
                itemNames.Add(inventoryItem.name);
            }
            return string.Join(", ", itemNames);
        }

        /// <summary>
        /// Removes an item from this inventory. Returns true on success.
        /// Fails if item doens't exist in this inventory.
        /// </summary>
        public bool RemoveFromInventory(InventoryItem item)
        {
            if (item == null) return false;

            return this.items.Remove(item);
        }

        /// <summary>
        /// Takes <paramref name="item"/> from an inventory, removing it in the process.
        /// Returns null if inventory does not contain <paramref name="item"/>.
        /// </summary>
        public InventoryItem TakeFromInventory(InventoryItem item)
        {
            if (item == null) return null;
            if (!this.ContainsInInventory(item)) return null;

            this.RemoveFromInventory(item);
            return item;
        }

        /// <summary>
        /// Transfer <paramref name="item"/> from this inventory to another.
        /// Returns true on success.
        /// </summary>
        public bool TransferBetweenInventories(InventoryItem item, Inventory target)
        {
            if (target == null) return false;
            if (item == null) return false;
            if (!this.ContainsInInventory(item)) return false;

            this.RemoveFromInventory(item);
            target.AddToInventory(item);

            return true;
        }
    }
}