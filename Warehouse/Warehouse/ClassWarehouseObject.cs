using System;
using System.Linq.Expressions;

namespace Warehouse
{
    partial class WarehouseObject
    {
        // Free cells
        private const byte _EMPTY_CELL = 0;

        // Space
        private const uint _MAX_X = 70;      // Pallets (64) + cranes (1) + empty space (pallets are placed from sixth line)
        private const uint _MAX_Y = 70;      // Pallets (60) + cranes (5) + empty space
        private const uint _MAX_Z = 8;

        private const int _START_CRANES_X = 5;

        // ID of various goods in warehouse
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

        int[] _freeCranesArray;
        int[] _busyCranesArray;

        WarehouseObject()
        {
            _coordinates = new int[_MAX_X, _MAX_Y, _MAX_Z];

            // Create cranes
            _freeCranesArray = new int[5] { 101, 102, 103, 104, 105 };
            _busyCranesArray = new int[5] { -101, -102, -103, -104, -105 };

            for (int i = 0; i < 5; i++)
                _coordinates[_START_CRANES_X, (i + 1) * 10, 0] = _freeCranesArray[i];
        }
    }
}