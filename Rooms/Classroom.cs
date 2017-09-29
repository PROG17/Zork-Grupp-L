using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zork_Grupp_L.Items.Classroom;

namespace Zork_Grupp_L.Rooms
{
    public class Classroom : Room
    {
        public Classroom()
        {
            this.Name = "classroom";
            this.Description = "This is a classroom where you will spend your time before entering the arbetsmarknad.";
            this.AddToInventory(new ItemCharger());
        }


        public override string Name { get; }
        public override string Description { get; }
    }
}

