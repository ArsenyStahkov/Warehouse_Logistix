using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    partial class WarehouseObject
    {
        static void Main(string[] args)
        {
            WarehouseObject warehouse = new WarehouseObject();

            warehouse.AddNewPallet(7, 0, _ID_GLUE);
            warehouse.AddNewPallet(14, 0, _ID_CONSTRUCTION_MATERIALS);
            warehouse.AddNewPallet(28, 0, _ID_AUTOMOTIVE_GOODS);


            //warehouse.GetPallet(_START_CRANES_X, 10, 0, 101, _ID_CONSTRUCTION_MATERIALS);
            //warehouse.SetPallet(_START_CRANES_X, 10, 0, -101, _ID_CONSTRUCTION_MATERIALS);


        }
    }
}
