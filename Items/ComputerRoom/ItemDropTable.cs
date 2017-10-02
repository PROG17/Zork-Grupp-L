namespace Zork_Grupp_L.Items.Classroom
{
    public class ItemDropTable : InventoryItem
    {
        public ItemDropTable()
        {
            this.Name = "\"); DROP TABLE *;";
            this.Description = "OH SHI-";
        }

        public override string Name { get; }
        public override string Description { get; }
    }
}
