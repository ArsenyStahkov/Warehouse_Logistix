using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    partial class WarehouseObject
    {
        private void AddNewPallet(int pallet_Y, int pallet_Z, int id_Pallet)
        {
            try
            {
                int pallet_X = _START_CRANES_X;

                if (id_Pallet == _ID_GLUE || id_Pallet == _ID_GROUT || id_Pallet == _ID_DETERGENTS || id_Pallet == _ID_AUTO_CHEMISTRY)
                    pallet_X = _START_CRANES_X + 1;

                if (id_Pallet == _ID_FASTENERS || id_Pallet == _ID_HAND_TOOLS || id_Pallet == _ID_CONSTRUCTION_MATERIALS)
                    pallet_X = _START_CRANES_X + 3;

                if (id_Pallet == _ID_HOUSEHOLD_GOODS || id_Pallet == _ID_ELECTRICAL_EQUIPMENT || id_Pallet == _ID_AUTOMOTIVE_GOODS)
                    pallet_X = _START_CRANES_X + 5;

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
                    Console.WriteLine("This cell is not avaliable!");
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

        private bool AreCoordCorrect(int crane_X, int crane_Y, int crane_Z, int id_Crane)
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

        private int GetPalletGroup(int id_Pallet)
        {
            if (id_Pallet == _ID_GLUE || id_Pallet == _ID_GROUT || id_Pallet == _ID_DETERGENTS || id_Pallet == _ID_AUTO_CHEMISTRY)
                return 1;

            if (id_Pallet == _ID_FASTENERS || id_Pallet == _ID_HAND_TOOLS || id_Pallet == _ID_CONSTRUCTION_MATERIALS)
                return 3;

            if (id_Pallet == _ID_HOUSEHOLD_GOODS || id_Pallet == _ID_ELECTRICAL_EQUIPMENT || id_Pallet == _ID_AUTOMOTIVE_GOODS)
                return 5;

            return 0;
        }

        private void SendToStorage(int crane_X, int crane_Y, int crane_Z, int id_Crane, int id_Pallet)
        {
            try
            {
                //if (!AreCoordCorrect(crane_X, crane_Y, crane_Z, id_Crane))
                //    return;

                int storage_start_X = GetPalletGroup(id_Pallet);
                int storage_start_Y = 69;
                int storage_start_Z = 0;

                for (int i = 0; i < _STORAGE_Y; i++)
                {
                    if (_coordinates[storage_start_X, storage_start_Y + i + 1, storage_start_Z] == _ID_STORAGE)
                        break;

                    crane_Y++;

                    if (crane_Y == storage_start_Y + _STORAGE_Y)
                    {
                        crane_Y = storage_start_Y;
                        i = -1;
                    }

                    if (crane_X == _STORAGE_X - 1)
                    {
                        Console.WriteLine("There is no empty space in the storage!");
                        break;
                    }
                }

                for (uint i = 0; i < _MAX_Z; i++)
                {
                    if (_coordinates[storage_start_X, storage_start_Y + 1, i] == _ID_STORAGE)
                    {
                        _coordinates[storage_start_X, storage_start_Y + 1, i] = id_Pallet;

                        _coordinates[crane_X, crane_Y, crane_Z] = id_Crane * -1;
                        Console.WriteLine("Pallet (id: -{0}) was sent to the storage successfully in ({1}, {2}, {3})"
                            , id_Pallet, storage_start_X, storage_start_Y + 1, i);

                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void GetFromStorage(int crane_X, int crane_Y, int crane_Z, int id_Crane, int id_Pallet)
        {

        }

        private void SetPallet(int crane_X, int crane_Y, int crane_Z, int id_Crane, int id_Pallet)
        {
            try
            {
                if (!AreCoordCorrect(crane_X, crane_Y, crane_Z, id_Crane))
                    return;

                int initial_X = crane_X;
                int initial_Y = crane_Y;
                int initial_Z = crane_Z;

                if (crane_X < _START_CRANES_X + 1)
                    crane_X = _START_CRANES_X + 1;

                int palletGroup = GetPalletGroup(id_Pallet);
                crane_X += palletGroup - 1;

                // Move crane left until it is next to a pallet or the wall
                for (int i = 0; i < _ROW_PALLETS; i++)
                {
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
                if (!AreCoordCorrect(crane_X, crane_Y, crane_Z, id_Crane))
                    return;

                int initial_X = crane_X;
                int initial_Y = crane_Y;
                int initial_Z = crane_Z;

                if (crane_X < _START_CRANES_X + 1)
                    crane_X = _START_CRANES_X + 1;

                //for (int i = 0; i < _ROW_PALLETS; i++)
                //{
                //    if (_coordinates[crane_X, crane_Y - 1, crane_Z] != _EMPTY_CELL)
                //        break;

                //    crane_Y--;

                //    if (crane_Y == initial_Y - _ROW_PALLETS)
                //    {
                //        crane_Y += _ROW_PALLETS;
                //        crane_X += 1;
                //        i = -1;
                //    }

                //    if (crane_X == _MAX_X - 1)
                //        break;
                //}

                int palletGroup = GetPalletGroup(id_Pallet);
                crane_X += palletGroup - 1;

                //for (int i = 0; i < _ROW_PALLETS - 1; i++)
                for (int i = 0; i < _ROW_PALLETS; i++)
                {
                    if (_coordinates[crane_X, crane_Y - 1, crane_Z] == _EMPTY_CELL)
                        crane_Y--;

                    if ((_coordinates[crane_X, crane_Y - 1, crane_Z] != id_Pallet) && (_coordinates[crane_X, crane_Y - 1, crane_Z] != _EMPTY_CELL))
                    {
                        for (uint j = _MAX_Z; j > 0; j--)
                        {
                            SendToStorage(initial_X, initial_Y, initial_Z, id_Crane, id_Pallet);
                        }
                        crane_Y--;
                    }

                    if (_coordinates[crane_X, crane_Y - 1, crane_Z] == id_Pallet)
                    {
                        for (uint j = _MAX_Z; j > 0; j--)
                        {
                            if (_coordinates[crane_X, crane_Y - 1, j - 1] == id_Pallet)
                            {
                                _coordinates[crane_X, crane_Y - 1, j - 1] = _EMPTY_CELL;
                                _coordinates[initial_X, initial_Y, initial_Z] = id_Crane * -1;
                                Console.WriteLine("Pallet (id: -{0}) was received successfully. The crane (id: {1}) is in ({2}, {3}, {4}) now."
                                    , id_Pallet, _coordinates[initial_X, initial_Y, initial_Z], initial_X, initial_Y, initial_Z);

                                return;
                            }
                        }
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
    }
}
