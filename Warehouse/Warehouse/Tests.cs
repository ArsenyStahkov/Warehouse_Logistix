using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    partial class WarehouseObject
    {
        static void TestRowFilling()
        {
            WarehouseObject warehouse = new WarehouseObject();

            for (int i = 1; i < 10; i++)
                warehouse.AddNewPallet(i, 0, _ID_GLUE);

            warehouse.SendToStorage(_START_CRANES_X, 10, 0, 101, _ID_GLUE);
            warehouse.GetFromStorage(_START_CRANES_X, 10, 0, 101, _ID_GLUE);
        }

        static void TestAllRowsFilling()
        {

        }

        static void TestStorageGetAndSet()
        {

        }

        static void TestColumnFilling()
        {

        }
    }
}
