namespace Zork_Grupp_L.Items.Classroom
{
    public class ItemCharger : InventoryItem
    {
        public ItemCharger()
        {
            this.Name = "charger";
            this.Description = "This charger can be used to charge a computer.";
        }

        public override string Name { get; }
        public override string Description { get; }
    }
}
