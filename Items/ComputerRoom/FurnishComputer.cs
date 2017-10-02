using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L.Items.ComputerRoom
{
    class FurnishComputer : FurnishingItem
    {        
        public FurnishComputer()
        {
            this.Name = "stationary computer";
            this.Description = "This computer seems old and awfully heavy.";
        }

        public override string Name { get; }
        public override string Description { get; }
       
    }
}

