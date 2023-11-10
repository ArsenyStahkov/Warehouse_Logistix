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
                {
                    Console.WriteLine("The coordinates are beyond the space!");
                    return;
                }

                if (pallet_Y % _ROW_PALLETS == 0)
                {
                    Console.WriteLine("Pallet cannot be placed on a crane line!");
                    return;
                }

                if (_coordinates[pallet_X, pallet_Y, pallet_Z] != _EMPTY_CELL)
                {
                    Console.WriteLine("This cell is not empty!");
                    return;
                }

                if (pallet_Z != 0 && _coordinates[pallet_X, pallet_Y, pallet_Z - 1] == _EMPTY_CELL)
                {
                    Console.WriteLine("You cannot put the pallet on empty cell! You need to change Z coordinate.");
                    return;
                }

                _coordinates[pallet_X, pallet_Y, pallet_Z] = id_Pallet;
                Console.WriteLine("Pallet (id: -{0}) was added successfully in ({1}, {2}, {3}).", id_Pallet, pallet_X, pallet_Y, pallet_Z);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool IsCoordinatesCorrect(int crane_X, int crane_Y, int crane_Z, int id_Crane)
        {
            if (crane_X >= _MAX_X || crane_Y >= _MAX_Y || crane_Z >= _MAX_Z)
            {
                Console.WriteLine("The crane coordinates are beyond the space!");
                return false;
            }

            if (_coordinates[crane_X, crane_Y, crane_Z] != id_Crane)
            {
                Console.WriteLine("The number of crane is incorrect!");
                return false;
            }

            if (crane_Z != 0)
            {
                Console.WriteLine("Z coordinate of the crane is incorrect!");
                return false;
            }

            return true;
        }

        private void UseStorage(int crane_X, int crane_Y, int crane_Z, int id_Crane, int id_Pallet)
        {
            if (!IsCoordinatesCorrect(crane_X, crane_Y, crane_Z, id_Crane))
                return;

            int storage_start_X = 5;
            int storage_start_Y = 69;
            int storage_start_Z = 0;

            for (int i = 0; i < 5; i++)
            {
                if (_coordinates[storage_start_X, storage_start_Y + i + 1, storage_start_Z] == _ID_STORAGE)
                    break;

                crane_Y++;

                if (crane_Y == storage_start_Y + 5)
                {
                    crane_Y = storage_start_Y;
                    crane_X -= 1;
                    i = -1;
                }

                if (crane_X == 0)
                    break;
            }

            for (uint i = _MAX_Z; i > 0; i--)
            {
                if (_coordinates[crane_X, crane_Y + 1, i - 1] == _ID_STORAGE)
                {
                    _coordinates[crane_X, crane_Y + 1, i - 1] = id_Pallet;

                    _coordinates[storage_start_X, storage_start_Y, storage_start_Z] = id_Crane * -1;
                    Console.WriteLine("Pallet (id: -{0}) was received successfully. The crane (id: {1}) is in ({2}, {3}, {4}) now."
                        , id_Pallet, _coordinates[storage_start_X, storage_start_Y, storage_start_Z]
                        , storage_start_X, storage_start_Y, storage_start_Z);

                    return;
                }
            }
        }

        private void SetPallet(int crane_X, int crane_Y, int crane_Z, int id_Crane, int id_Pallet)
        {
            try
            {
                if (!IsCoordinatesCorrect(crane_X, crane_Y, crane_Z, id_Crane))
                    return;

                int initial_X = crane_X;
                int initial_Y = crane_Y;
                int initial_Z = crane_Z;

                if (crane_X < _START_CRANES_X + 1)
                    crane_X = _START_CRANES_X + 1;

                // Move crane left until it is next to a pallet or the wall
                for (int i = 0; i < _ROW_PALLETS; i++)
                {
                    // We need to check the type of goods in the row (check X). If the type is OK, check each column (Y) to find the goods.
                    if (_coordinates[crane_X, crane_Y - 1, crane_Z] != _EMPTY_CELL)
                        break;

                    crane_Y--;

                    if (crane_Y == initial_Y - _ROW_PALLETS)
                    {
                        crane_Y = initial_Y - _ROW_PALLETS + 1;
                        break;
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
                        Console.WriteLine("Pallet (id: -{0}) was put successfully. The crane (id: {1}) is in ({2}, {3}, {4}) now."
                            , id_Pallet, _coordinates[initial_X, initial_Y, initial_Z], initial_X, initial_Y, initial_Z);

                        Console.WriteLine(crane_X.ToString() + " " + (crane_Y).ToString() + " " + crane_Z.ToString());

                        return;
                    }
                }
                Console.WriteLine("No empty cells found!");

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

                if (crane_X < _START_CRANES_X + 1)
                    crane_X = _START_CRANES_X + 1;

                for (int i = 0; i < _ROW_PALLETS; i++)
                {
                    // We need to check the type of goods in the row (check X). If the type is OK, check each column (Y) to find the goods.
                    if (_coordinates[crane_X, crane_Y - 1, crane_Z] != _EMPTY_CELL)
                        break;

                    crane_Y--;

                    if (crane_Y == initial_Y - _ROW_PALLETS)
                    {
                        crane_Y += _ROW_PALLETS;
                        crane_X += 1;
                        i = -1;
                    }

                    if (crane_X == _MAX_X - 1)
                        break;
                }

                for (uint i = _MAX_Z; i > 0; i--)
                {
                    if (_coordinates[crane_X, crane_Y - 1, i - 1] == id_Pallet)
                    {
                        _coordinates[crane_X, crane_Y - 1, i - 1] = _EMPTY_CELL;

                        _coordinates[initial_X, initial_Y, initial_Z] = id_Crane * -1;
                        Console.WriteLine("Pallet (id: -{0}) was received successfully. The crane (id: {1}) is in ({2}, {3}, {4}) now."
                            , id_Pallet, _coordinates[initial_X, initial_Y, initial_Z], initial_X, initial_Y, initial_Z);

                        return;
                    }
                }
                Console.WriteLine("The pallet was not found!");

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
    }
}
