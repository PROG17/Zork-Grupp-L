using Zork_Grupp_L.Rooms;

namespace Zork_Grupp_L.Items
{
	public class RoomExit : BaseItem
	{
		public RoomExit(Room nextRoom, string name, string description)
		{
			this.Name = name;
			this.Description = description;
			this.NextRoom = nextRoom;
		}

		public override string Name { get; }
		public override string Description { get; }
		public Room NextRoom { get; }

        public bool IsLocked { get; set; }
    
    }
}