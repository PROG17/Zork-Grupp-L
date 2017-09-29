using Zork_Grupp_L.Items;

namespace Zork_Grupp_L.Rooms
{
	public class RoomRepository
	{
		public Dungeon dungeon = new Dungeon();
		public Corridor corridor = new Corridor();
        public ComputerRoom computerRoom = new ComputerRoom();

		public RoomRepository()
		{
			dungeon.AddRoomExit(corridor,
				name: "exit door",
				description: "This door seems to lead to a corridor.");

			corridor.AddRoomExit(dungeon,
				name: "dungeon door",
				description: "This door seems to lead to that hideous dungeon you came from.");
            corridor.AddRoomExit(computerRoom,
                name: "Door to the computer room",
                description: "This door seems to lead to a room of computers");
                
		}
	}
}