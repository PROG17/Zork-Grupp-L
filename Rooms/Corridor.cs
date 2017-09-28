namespace Zork_Grupp_L.Rooms
{
	public class Corridor : Room
	{
		public Corridor()
		{
			this.Name = "corridor";
			this.Description = "A long and chilly hallway.";
		}

		public override string Name { get; }
		public override string Description { get; }
	}
}