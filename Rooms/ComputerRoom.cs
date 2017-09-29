using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zork_Grupp_L.Items.ComputerRoom;

namespace Zork_Grupp_L.Rooms
{
    public class ComputerRoom : Room
    {
        public ComputerRoom()
        {
            this.Name = "Computer Room";
            this.Description = "A room with old computers.";
            this.AddToInventory(new ItemComputer());
        }


        public override string Name { get; }
        public override string Description { get; }
    }
}
