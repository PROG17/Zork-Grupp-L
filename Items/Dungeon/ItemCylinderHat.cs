using Zork_Grupp_L.GameFunctions;
using Zork_Grupp_L.Helpers;

namespace Zork_Grupp_L.Items.Dungeon
{
    public class ItemCylinderHat : InventoryItem
    {
        public ItemCylinderHat()
        {
            this.Name = "cylinder hat";
            this.Description = "This is a fancy hat for fancy people.";

            AddedToInventory += OnAddedToInventory;
            RemovedFromInventory += OnRemovedFromInventory;
        }

        public override string Name { get; }

        public override string Description { get; }


        private void OnAddedToInventory(Inventory inventory)
        {
            if (inventory is Player)
            {
                ConsoleHelper.WriteLineWrap(
                    inventory.InventoryContains<ItemFrockCoat>()
                        ? "This hat fits nicley with your coat, you enjoy not being naked anymore."
                        : "This hat sits neatly on your head, you feel slightly less naked.");
            }
        }

        private void OnRemovedFromInventory(Inventory inventory)
        {
            if (inventory is Player)
                ConsoleHelper.WriteLineWrap(
                    "You feel the chills approaching. You've no clothes on, you're naked!"
                    + " Better pick up that hat again.");
        }
    }
}
