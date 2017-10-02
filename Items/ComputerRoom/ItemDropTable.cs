using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L.Items.Classroom
{
    public class ItemDropTable : InventoryItem
    {
        public ItemDropTable()
        {
            this.Name = "\"); DROP TABLE *;";
            this.Description = "OH SHI-";
        }

        public override string Name { get; }
        public override string Description { get; }
    }
}
