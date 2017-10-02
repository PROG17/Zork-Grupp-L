using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L.Items.ComputerRoom
{
    using Zork_Grupp_L.Helpers;
    using Zork_Grupp_L.Items.Classroom;
    using Zork_Grupp_L.Items.Dungeon;

    using static Game;

    public class ItemComputer : InventoryItem
    {
        public override string Name => this.DisCharged ? "discharged laptop" : "working laptop";

        public override string Description => this.DisCharged
                                                  ? "This computer needs to be charged, or it won't turn on."
                                                  : "This computer is now charged and working great, since ";

        public bool DisCharged { get; private set; } = true;

        public override bool UseOnItem(BaseItem otherItem)
        {
            switch (otherItem)
            {
                case ItemCharger _:
                    this.DisCharged = false;
                    Game.Win = true;
                    Game.GameOver = true;
                    this.PrintItemDescription();
                    return true;
            }
            return false;
        }
    }
}