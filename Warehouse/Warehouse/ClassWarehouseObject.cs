using System;
using System.Linq.Expressions;

namespace Warehouse
{
    partial class WarehouseObject
    {
        // Free cells
        private const byte _EMPTY_CELL = 0;

        // Space
        private const uint _MAX_X = 70;      // Empty space (5) + cranes (1) + Pallets (64) (are placed from sixth line)
        private const uint _MAX_Y = 75;      // Pallets (54) + cranes (5) + empty space
        private const uint _MAX_Z = 8;

        private const int _START_CRANES_X = 5;
        private const int _ROW_PALLETS = 10;
        private const int _STORAGE_X = 64;
        private const int _STORAGE_Y = 5;

        // ID of various goods in warehouse
        private const int _ID_GLUE = 1;
        private const int _ID_GROUT = 2;
        private const int _ID_DETERGENTS = 3;
        private const int _ID_AUTO_CHEMISTRY = 4;
        private const int _ID_HAND_TOOLS = 5;
        private const int _ID_CONSTRUCTION_MATERIALS = 6;
        private const int _ID_FASTENERS = 7;
        private const int _ID_HOUSEHOLD_GOODS = 8;
        private const int _ID_ELECTRICAL_EQUIPMENT = 9;
        private const int _ID_AUTOMOTIVE_GOODS = 10;

        // Intermediate storage place for pallets
        private const int _ID_STORAGE = -1;

        private int[,,] _coordinates;

        int[] _freeCranesArr;
        int[] _busyCranesArr;

        WarehouseObject()
        {
            _coordinates = new int[_MAX_X, _MAX_Y, _MAX_Z];

            // Create cranes
            _freeCranesArr = new int[5] { 101, 102, 103, 104, 105 };
            _busyCranesArr = new int[5] { -101, -102, -103, -104, -105 };

            for (int i = 0; i < 5; i++)
                _coordinates[_START_CRANES_X, (i + 1) * _ROW_PALLETS, 0] = _freeCranesArr[i];

            // Create intermediate storage place
            for (int X = 0; X < 5; X++)
                for (int Y = 70; Y < _MAX_Y; Y++)
                    for (int Z = 0; Z < _MAX_Z; Z++)
                        _coordinates[X, Y, Z] = _ID_STORAGE;
        }
    }
}