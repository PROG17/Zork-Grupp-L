namespace Zork_Grupp_L.Items
{
    public class ItemPuddle : FurnishingItem
    {   //Nytt item för furnishing objects.
        public ItemPuddle()
        {
            this.Name = "puddle";
            this.Description = "You can use this puddle as a mirror.";
        }
        public override string Name { get; }
        public override string Description { get; }
    }
}
