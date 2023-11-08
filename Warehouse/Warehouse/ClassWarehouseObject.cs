using System;
using System.Linq.Expressions;

namespace Warehouse
{
    partial class WarehouseObject
    {
        // Free cells
        private const byte _EMPTY_CELL = 0;

        // Space
        private const uint _MAX_X = 70;      // Pallets + cranes + empty space (pallets are since line 5)
        private const uint _MAX_Y = 70;      // Pallets (36) + reserve + empty space
        private const uint _MAX_Z = 8;

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

            // Declare cranes
            _freeCranesArray = new int[5] { 11, 12, 13, 14, 15 };
            _busyCranesArray = new int[5] { -11, -12, -13, -14, -15 };

            for (int i = 0; i < 5; i++)
                _coordinates[0, (i + 1) * 10, 0] = _freeCranesArray[i];

            //_coordinates[20, 0, 0] = _ID_2_CRANE_FREE;
            //_coordinates[30, 0, 0] = _ID_3_CRANE_FREE;
            //_coordinates[40, 0, 0] = _ID_4_CRANE_FREE;
            //_coordinates[50, 0, 0] = _ID_5_CRANE_FREE;
        }
    }
}