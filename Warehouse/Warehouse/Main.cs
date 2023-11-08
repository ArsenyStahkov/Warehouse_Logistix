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
            warehouse.AddNewPallet(8, 9, 0, _ID_GLUE);
            //warehouse.SetPallet(2, 10, 0, -11, _ID_GLUE);
            warehouse.GetPallet(0, 10, 0, 11, _ID_GLUE);
        }
    }
}
