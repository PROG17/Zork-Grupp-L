namespace Zork_Grupp_L.Items.Dungeon
{
    public class FurnishPuddle : FurnishingItem
    {   //Nytt item för furnishing objects.
        public FurnishPuddle()
        {
            this.Name = "puddle";
            this.Description = "You can use this puddle as a mirror.";
        }
        public override string Name { get; }
        public override string Description { get; }
    }
}
