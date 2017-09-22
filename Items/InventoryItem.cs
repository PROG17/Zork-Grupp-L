using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L
{
    public class InventoryItem : Inventory // NamedObjects//Borde inte inventoryItem ärva från Inventory så vi kommer åt den för items också???
    {
        //Tänker att inventoryitem bör ha en printfunktion också..
        public void PrintInspect()
        {
            Console.WriteLine("{0}", this.description);
        }
    }



}
