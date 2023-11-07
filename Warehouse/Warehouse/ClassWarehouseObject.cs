using System;
using System.Linq.Expressions;

namespace Warehouse
{
    partial class WarehouseObject
    {
        private const byte _EMPTY_CELL = 0;
        private const uint _MAX_X = 70;      // Pallets + cranes + empty space (boxes are since line 6)
        private const uint _MAX_Y = 60;      // Pallets (36) + reserve + empty space
        private const uint _MAX_Z = 8;
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

            // Declare cranes
            int[] freeCranesArray = new int[5] { 11, 12, 13, 14, 15 };
            int[] busyCranesArray = new int[5] { -11, -12, -13, -14, -15 };

            //for (int i = 0; i <= _CRANES_COUNT; i++)
            //    _coordinates[i * 10, 0, 0] = _ID_CRANE_FREE;

            //_coordinates[20, 0, 0] = _ID_2_CRANE_FREE;
            //_coordinates[30, 0, 0] = _ID_3_CRANE_FREE;
            //_coordinates[40, 0, 0] = _ID_4_CRANE_FREE;
            //_coordinates[50, 0, 0] = _ID_5_CRANE_FREE;
        }
    }
}