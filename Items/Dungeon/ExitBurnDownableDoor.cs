namespace Zork_Grupp_L.Items.Dungeon
{
    using Zork_Grupp_L.Rooms;

    public class ExitBurnDownableDoor : RoomExit
    {
        public ExitBurnDownableDoor(Room nextRoom)
            : base(
                nextRoom,
                name: "locked door",
                description: "This door appears to made out of a highly flammable material and won't open.")
        {
            this.IsLocked = true;
        }

    }
}
