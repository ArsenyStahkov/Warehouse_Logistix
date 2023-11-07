using System;

namespace Warehouse
{
    class WarehouseObject
    {
        private const byte _EMPTY_CELL = 0;
        private const uint _MAX_X = 70;      // Boxes + cranes + empty space (boxes are since line 6)
        private const uint _MAX_Y = 60;      // Boxes (36) + reserve + empty space
        private const uint _MAX_Z = 8;
        private const uint _CRANES_COUNT = 5;
        private const int _ID_CRANE_FREE = -2;
        private const int _ID_CRANE_BUSY = -1;
        private const int _ID_GLUE = 1;
        private const int _ID_CONSTRUCTION_MATERIALS = 2;
        private const int _ID_GROUT = 3;
        private const int _ID_FASTENERS = 4;
        private const int _ID_HOUSEHOLD_GOODS = 5;
        private const int _ID_DETERGENTS = 6;
        private const int _ID_AUTO_CHEMISTRY = 7;
        private const int _ID_HAND_TOOLS = 8;
        private const int _ID_ELECTRICAL_EQUIPMENT = 9;
        private const int _ID_AUTOMOTIVE_GOODS = 10;

        private int[,,] _coordinates;

        WarehouseObject()
        {
            _coordinates = new int[_MAX_X, _MAX_Y, _MAX_Z];

            // Set cranes
            for (int i = 0; i <= _CRANES_COUNT; i++)
                _coordinates[i * 10, 0, 0] = _ID_CRANE_FREE;

            //_coordinates[20, 0, 0] = _ID_2_CRANE_FREE;
            //_coordinates[30, 0, 0] = _ID_3_CRANE_FREE;
            //_coordinates[40, 0, 0] = _ID_4_CRANE_FREE;
            //_coordinates[50, 0, 0] = _ID_5_CRANE_FREE;
        }

        private void GetBoxCoordinates()
        {

        }

        private void SetBox(uint X, uint Y, uint Z, int id_Box)
        {
            if (_coordinates[X, Y, Z] == _ID_CRANE_FREE)
                return;

            while (X < 5)
                X++;

            while (_coordinates[X, Y - 1, Z] == _EMPTY_CELL)
                Y--;

            // If the adjacent cell is busy, try to put box on Z (upper)
            for (int i = 0; i < _MAX_Z; i++)
            {
                if (_coordinates[X, Y - 1, i] == _EMPTY_CELL && ((Y - 1) % 10 != 0))
                {
                    _coordinates[X, Y - 1, i] = id_Box;
                    _coordinates[X, Y, i] = _ID_CRANE_FREE;
                }
            }

            return;
        }

        private int TakeBox(uint X, uint Y, uint Z)
        {
            int id_Box = _ID_CRANE_BUSY;
            if (_coordinates[X, Y, Z] == _ID_CRANE_BUSY)
                return id_Box;

            while (X < 5)
                ++X;

            while (_coordinates[X, Y - 1, Z] == _EMPTY_CELL)
                Y--;

            // If the adjacent cell is free, try to take box on Z (upper)
            for (int i = 0; i < _MAX_Z; i++)
            {
                if (_coordinates[X, Y - 1, i] == _ID_CRANE_BUSY && ((Y - 1) % 10 != 0))
                {
                    id_Box = _coordinates[X, Y - 1, i];
                    _coordinates[X, Y - 1, i] = _EMPTY_CELL;
                    _coordinates[X, Y, i] = _ID_CRANE_BUSY;
                }
            }

            return id_Box;
        }

        private void ReplaceBox(uint box_X, uint box_Y, uint box_Z, uint target_X, uint target_Y, uint target_Z)
        {

        }

        static void Main(string[] args)
        {
            WarehouseObject warehouseObject = new WarehouseObject();

        }
    }
}