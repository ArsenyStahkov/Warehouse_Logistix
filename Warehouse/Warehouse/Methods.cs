using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    partial class WarehouseObject
    {
        private void AddNewPallet(int pallet_X, int pallet_Y, int pallet_Z, int id_Pallet)
        {
            try
            {
                if (pallet_X > _MAX_X || pallet_Y > _MAX_Y || pallet_Z > _MAX_Z)
                    Console.WriteLine("The coordinates are beyond the space!");

                if (_coordinates[pallet_X, pallet_Y, pallet_Z] != _EMPTY_CELL)
                {
                    Console.WriteLine("This cell is not empty!");
                    return;
                }

                _coordinates[pallet_X, pallet_Y, pallet_Z] = id_Pallet;
                Console.WriteLine("Pallet {0} was added successfully in ({1}, {2}, {3}).", id_Pallet, pallet_X, pallet_Y, pallet_Z);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool IsCoordinatesCorrect(int X, int Y, int Z, int id_Crane)
        {
            if (X >= _MAX_X || Y >= _MAX_Y || Z >= _MAX_Z)
            {
                Console.WriteLine("The coordinates are beyond the space!");
                return false;
            }

            if (_coordinates[X, Y, Z] != id_Crane)
            {
                Console.WriteLine("The number of crane is incorrect!");
                return false;
            }

            if (Z != 0)
            {
                Console.WriteLine("Z coordinate is incorrect!");
                return false;
            }

            return true;
        }

        //private void MoveCraneToFindPallet(int X, int Y, int Z, int id_Crane)
        //{
        //    while (crane_X < 5)
        //        crane_X++;

        //    // While there are pallets on the right from the crane, move it down (X coordinate)
        //    while ((_coordinates[crane_X, crane_Y - 1, crane_Z] != _EMPTY_CELL) && (crane_X != _MAX_X))
        //        crane_X++;

        //    // Move crane left until it is next to a pallet or the wall
        //    for (int i = 0; i < 10; i++)
        //    {
        //        if (_coordinates[crane_X, crane_Y - 1, crane_Z] == _EMPTY_CELL)
        //            break;

        //        crane_Y--;
        //    }

        //    for (int i = 0; i < 10; i++)
        //    {
        //        if (_coordinates[crane_X, crane_Y - 1, crane_Z] != _EMPTY_CELL)
        //            break;

        //        crane_Y--;

        //        if (crane_Y == 0)
        //        {
        //            crane_Y = 10;
        //            crane_X += 1;
        //            i = -1;
        //        }
        //    }
        //}

        private void SetPallet(int crane_X, int crane_Y, int crane_Z, int id_Crane, int id_Pallet)
        {
            try
            {
                if (!IsCoordinatesCorrect(crane_X, crane_Y, crane_Z, id_Crane))
                    return;

                int initial_X = crane_X;
                int initial_Y = crane_Y;
                int initial_Z = crane_Z;

                while (crane_X < 5)
                    crane_X++;

                // While there are pallets on the right from the crane, move it down (X coordinate)
                while ((_coordinates[crane_X, crane_Y - 1, crane_Z] != _EMPTY_CELL) && (crane_X != _MAX_X))
                    crane_X++;

                // Move crane left until it is next to a pallet or the wall
                for (int i = 0; i < 10; i++)
                {
                    if (_coordinates[crane_X, crane_Y - 1, crane_Z] == _EMPTY_CELL)
                        break;

                    crane_Y--;
                }

                for (int i = 0; i < 10; i++)
                {
                    if (_coordinates[crane_X, crane_Y - 1, crane_Z] != _EMPTY_CELL)
                        break;

                    crane_Y--;

                    if (crane_Y == 0)
                    {
                        crane_Y = 10;
                        crane_X += 1;
                        i = -1;
                    }
                }

                // If the adjacent cell is busy, try to put the pallet upper (Z coordinate)
                for (uint i = 0; i < _MAX_Z; i++)
                {
                    if (_coordinates[crane_X, crane_Y - 1, i] == _EMPTY_CELL)
                    {
                        _coordinates[crane_X, crane_Y - 1, i] = id_Pallet;

                        // Return crane on the initial place but with opposite id
                        _coordinates[initial_X, initial_Y, initial_Z] = id_Crane * -1;
                        Console.WriteLine("Pallet {0} was put successfully. The crane (id: {1}) is in ({2}, {3}, {4}) now."
                            , id_Pallet, _coordinates[initial_X, initial_Y, initial_Z], initial_X, initial_Y, initial_Z);

                        break;
                    }
                }

                return;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void GetPallet(int crane_X, int crane_Y, int crane_Z, int id_Crane, int id_Pallet)
        {
            try
            {
                if (!IsCoordinatesCorrect(crane_X, crane_Y, crane_Z, id_Crane))
                    return;

                int initial_X = crane_X;
                int initial_Y = crane_Y;
                int initial_Z = crane_Z;

                while (crane_X < 5)
                    crane_X++;

                while ((_coordinates[crane_X, crane_Y - 1, crane_Z] != _EMPTY_CELL) && (crane_X != _MAX_X))
                    crane_X++;

                for (int i = 0; i < 10; i++)
                {
                    if (_coordinates[crane_X, crane_Y - 1, crane_Z] != _EMPTY_CELL)
                        break;

                    crane_Y--;

                    if (crane_Y == 0)
                    {
                        crane_Y = 10;
                        crane_X += 1;
                        i = -1;
                    }
                }

                for (uint i = _MAX_Z - 1; i >= 0; i--)
                {
                    if (_coordinates[crane_X, crane_Y - 1, i] == id_Pallet)
                    {
                        _coordinates[crane_X, crane_Y - 1, i] = _EMPTY_CELL;

                        _coordinates[initial_X, initial_Y, initial_Z] = id_Crane * -1;
                        Console.WriteLine("Pallet {0} was received successfully. The crane (id: {1}) is in ({2}, {3}, {4}) now."
                            , id_Pallet, _coordinates[initial_X, initial_Y, initial_Z], initial_X, initial_Y, initial_Z);

                        // We need to save id_Pallet somwhere or return it
                        break;
                    }
                }

                return;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CheckAdjacentPallet()
        {

        }

        //private void ReplacePallet(int box_X, int box_Y, int box_Z, int target_X, int target_Y, int target_Z)
        //{

        //}
    }
}
