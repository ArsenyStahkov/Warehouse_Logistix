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

            Console.WriteLine("---Y: 0, 3, 6 (_ID_GLUE)");

            for (int i = 0, Y = 0; i < 3; i++)
            {
                for (int Z = 0; Z < 8; Z++)
                    warehouse.AddNewPallet(Y, Z, _ID_GLUE);
                Y += 3;
            }

            Console.WriteLine("--- Y: 1, 4, 7 (_ID_GROUT)");

            for (int i = 0, Y = 1; i < 3; i++)
            {
                for (int Z = 0; Z < 8; Z++)
                    warehouse.AddNewPallet(Y, Z, _ID_GROUT);
                Y += 3;
            }

            Console.WriteLine("--- Y: 2, 5, 8 (_ID_DETERGENTS)");

            for (int i = 0, Y = 2; i < 3; i++)
            {
                for (int Z = 0; Z < 8; Z++)
                    warehouse.AddNewPallet(Y, Z, _ID_DETERGENTS);
                Y += 3;
            }

            Console.WriteLine("--- Y: 9 (_ID_AUTO_CHEMISTRY)");

            for (int j = 0; j < 8; j++)
                warehouse.AddNewPallet(9, j, _ID_AUTO_CHEMISTRY);

            Console.WriteLine();

            // ---------------------------------------------------

            for (int i = 1; i < 10; i++)
                warehouse.SendToStorage(_START_CRANES_X, i, 0, 101, _ID_GLUE);

            for (int i = 1; i < 10; i++)
                warehouse.SendToStorage(_START_CRANES_X, i, 0, 101, _ID_GROUT);

            for (int X = 1; X < 6; X++)
                for (int Y = 70; Y < _MAX_Y; Y++)
                    for (int Z = 0; Z < _MAX_Z; Z++)
                    {
                        Console.Write(warehouse._coordinates[X, Y, Z] + " ");
                    }

            for (int i = 1; i < 5; i++)
                warehouse.GetFromStorage(_START_CRANES_X, i, 0, 101, _ID_GLUE);

            for (int i = 1; i < 5; i++)
                warehouse.GetFromStorage(_START_CRANES_X, i, 0, 101, _ID_GROUT);
        }

        static void TestAllRowsFilling()
        {
            WarehouseObject warehouse = new WarehouseObject();

            Console.WriteLine("---_ID_GLUE");

            for (int i = 0, Y = 0; i < 18; i++)
            {
                for (int Z = 0; Z < 8; Z++)
                    warehouse.AddNewPallet(Y, Z, _ID_GLUE);
                Y += 3;
            }
        }

        static void TestStorageGetAndSet()
        {

        }

        static void TestColumnFilling()
        {

        }
    }
}
