namespace Zork_Grupp_L.Items.Dungeon
{
    public class FurnishChair : FurnishingItem
    {
        public FurnishChair()
        {
            this.Name = "chair";
            this.Description = "This chair looks like it's made out of metal and bolted to the ground.";
        }

        public override string Name { get; }
        public override string Description { get; }
    }
}
