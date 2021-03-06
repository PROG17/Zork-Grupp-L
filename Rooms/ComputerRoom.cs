﻿using Zork_Grupp_L.Items.ComputerRoom;

namespace Zork_Grupp_L.Rooms
{
    using Zork_Grupp_L.Items.Classroom;

    public class ComputerRoom : Room
    {
        public ComputerRoom()
        {
            this.Name = "Computer Room";
            this.Description = "A room with old computers.";
            this.AddToInventory(new ItemComputer());
            this.AddToInventory(new FurnishComputer());
            this.AddToInventory(new ItemDropTable());
        }


        public override string Name { get; }
        public override string Description { get; }
    }
}
