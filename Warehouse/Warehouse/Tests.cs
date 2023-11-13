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

            Console.WriteLine("---Y: 0, 3, 6(_ID_GLUE)");

            for (int j = 0; j < 8; j++)
                warehouse.AddNewPallet(0, j, _ID_GLUE);

            for (int j = 0; j < 8; j++)
                warehouse.AddNewPallet(3, j, _ID_GLUE);

            for (int j = 0; j < 8; j++)
                warehouse.AddNewPallet(6, j, _ID_GLUE);

            Console.WriteLine("--- Y: 1, 4, 7 (_ID_GROUT)");

            for (int j = 0; j < 8; j++)
                warehouse.AddNewPallet(1, j, _ID_GROUT);

            for (int j = 0; j < 8; j++)
                warehouse.AddNewPallet(4, j, _ID_GROUT);

            for (int j = 0; j < 8; j++)
                warehouse.AddNewPallet(7, j, _ID_GROUT);

            Console.WriteLine("--- Y: 2, 5, 8 (_ID_DETERGENTS)");

            for (int j = 0; j < 8; j++)
                warehouse.AddNewPallet(2, j, _ID_DETERGENTS);

            for (int j = 0; j < 8; j++)
                warehouse.AddNewPallet(5, j, _ID_DETERGENTS);

            for (int j = 0; j < 8; j++)
                warehouse.AddNewPallet(8, j, _ID_DETERGENTS);

            Console.WriteLine("--- Y: 9 (_ID_AUTO_CHEMISTRY)");

            for (int j = 0; j < 8; j++)
                warehouse.AddNewPallet(9, j, _ID_AUTO_CHEMISTRY);

            // ---------------------------------------------------

            for (int i = 1; i < 10; i++)
                warehouse.SendToStorage(_START_CRANES_X, i, 0, 101, _ID_DETERGENTS);

            for (int i = 1; i < 10; i++)
                warehouse.GetFromStorage(_START_CRANES_X, i, 0, 101, _ID_DETERGENTS);
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
