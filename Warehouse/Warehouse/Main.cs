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

            warehouse.AddNewPallet(6, 19, 0, _ID_GLUE);
            //warehouse.SetPallet(2, 10, 0, -11, _ID_GLUE);
            warehouse.GetPallet(_START_CRANES_X, 20, 0, 102, _ID_GLUE);
        }
    }
}
