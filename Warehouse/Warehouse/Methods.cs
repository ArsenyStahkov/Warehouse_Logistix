using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    partial class WarehouseObject
    {
        private void SetPallet(int crane_X, int crane_Y, int crane_Z, int id_Crane, int id_Pallet)
        {
            try
            {
                int initial_X = crane_X;
                int initial_Y = crane_Y;
                int initial_Z = crane_Z;

                if (_coordinates[crane_X, crane_Y, crane_Z] != id_Crane)
                {
                    Console.WriteLine("The number of crane is incorrect!");
                    return;
                }

                if (crane_Z != 0)
                {
                    Console.WriteLine("Z coordinate is incorrect!");
                    return;
                }

                while (crane_X < 5)
                    crane_X++;

                // While there are pallets on the right from the crane, move it down (X coordinate)
                while ((_coordinates[crane_X, crane_Y - 1, crane_Z] != _EMPTY_CELL) && (crane_X != _MAX_X))
                    crane_X++;

                // Move crane left until it is next to a pallet or the wall
                for (int i = 0; i < 10; i++)
                {
                    if (_coordinates[crane_X, crane_Y - 1, crane_Z] != _EMPTY_CELL)
                        break;
                    crane_Y--;
                }

                // If the adjacent cell is busy, try to put the pallet upper (Z coordinate)
                for (int i = 0; i < _MAX_Z; i++)
                {
                    if (_coordinates[crane_X, crane_Y - 1, i] == _EMPTY_CELL)
                    {
                        _coordinates[crane_X, crane_Y - 1, i] = id_Pallet;

                        // Return crane on the initial place but with opposite id
                        _coordinates[initial_X, initial_Y, initial_Z] = id_Crane * -1;
                    }
                }

                return;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //private int GetPallet(int X, int Y, int Z, int crane_Z, int id_Pallet)
        //{
        //    try
        //    {
        //        int id_Box = _ID_CRANE_BUSY;
        //        if (_coordinates[X, Y, Z] != _ID_CRANE_FREE)
        //            return id_Box;

        //        while (X < 5)
        //            ++X;

        //        while (_coordinates[X, Y - 1, Z] == _EMPTY_CELL)
        //            Y--;

        //        // If the adjacent cell is free, try to take the pallet on Z (upper)
        //        for (int i = 0; i < _MAX_Z; i++)
        //        {
        //            if (_coordinates[X, Y - 1, i] == _ID_CRANE_BUSY && ((Y - 1) % 10 != 0))
        //            {
        //                id_Box = _coordinates[X, Y - 1, i];
        //                _coordinates[X, Y - 1, i] = _EMPTY_CELL;
        //                _coordinates[X, Y, i] = _ID_CRANE_BUSY;
        //            }
        //        }

        //        return id_Box;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        private void ReplacePallet(int box_X, int box_Y, int box_Z, int target_X, int target_Y, int target_Z)
        {

        }

        static void Main(string[] args)
        {
            WarehouseObject warehouseObject = new WarehouseObject();

        }
    }
}
