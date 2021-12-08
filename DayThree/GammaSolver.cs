using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DayThree
{
    public class GammaSolver
    {
        private int _shiftSize;
        private int _bitWidth;
        private ulong bitMask;
        private ulong _gamma;
        private ulong _epsolon;
        private int _entrySize;
        private ulong[] inputValues;

        public GammaSolver(IEnumerable<string> input, int bitWidth)
        {
            _bitWidth = bitWidth;
            _shiftSize = bitWidth - 1;
            _epsolon = 0;
            _gamma = 0;
            _entrySize = input.Count();
            inputValues = input.Select(x => Convert.ToUInt64(x, 2)).ToArray();

            for (int i = 0; i < _bitWidth; i++)
            {
                bitMask |= (uint) (1 << i);
            }
        }
        
        public GammaSolver(ulong[] input, int bitWidth)
        {
            _bitWidth = bitWidth;
            _shiftSize = bitWidth - 1;
            _epsolon = 0;
            _gamma = 0;
            _entrySize = input.Count();
            inputValues = input;

            for (int i = 0; i < _bitWidth; i++)
            {
                bitMask |= (uint) (1 << i);
            }
        }

        public ulong SolveGammaEpsolon()
        {
            _gamma = CalculateGammaFor(inputValues);
            
            _epsolon = (bitMask & (~_gamma));
            
            return _epsolon * _gamma;
        }

        public ulong CalculateLifeSupport()
        {
            ulong[] oxygenWorkingArray = new ulong[inputValues.Count()]; 
            ulong[] carbonWorkingArray = new ulong[inputValues.Count()]; 
            Array.Copy(inputValues, oxygenWorkingArray, inputValues.Length);
            Array.Copy(inputValues, carbonWorkingArray, inputValues.Length);

            ulong oxygenVal = 0;
            ulong carbonDioxideVal = 0;
            
            for (int i = _shiftSize; i >= 0; i--)
            {
                if (oxygenWorkingArray.Length > 1)
                {
                    ulong[] oxygenPositionSet = CalculateBitSetPositionCount(oxygenWorkingArray);
                    bool oxygenIsOne = oxygenPositionSet[_shiftSize - i] >= (double) oxygenWorkingArray.Length / 2;
                    oxygenWorkingArray = FilterWhereBitIs(oxygenIsOne, i, oxygenWorkingArray);
                }
                if (carbonWorkingArray.Length > 1)
                {
                    ulong[] carbonSetPositionCount = CalculateBitSetPositionCount(carbonWorkingArray);
                    bool carbonIsOne = carbonSetPositionCount[_shiftSize - i] < (double) carbonWorkingArray.Length / 2;
                    carbonWorkingArray = FilterWhereBitIs(carbonIsOne, i, carbonWorkingArray);
                }
            }

            return oxygenWorkingArray[0] * carbonWorkingArray[0];
        }

        private ulong CalculateGammaFor(ulong[] startArray)
        {
            ulong calculatedGamma = 0;
            var setPosCount = CalculateBitSetPositionCount(startArray);

            for (int i = 0; i < setPosCount.Length; i++)
            {
                if (setPosCount[i] > (ulong) (_entrySize / 2))
                {
                    //Mostly 1s
                    calculatedGamma |= (uint) (1 << (_shiftSize - i));
                }
            }

            return calculatedGamma;
        }

        private ulong[] CalculateBitSetPositionCount(ulong[] startArray)
        {
            ulong[] setPosCount = new ulong[_bitWidth];
            foreach (var value in startArray)
            {
                for (int i = 0; i < _bitWidth; i++)
                {
                    setPosCount[i] += Convert.ToUInt64(CheckAtPosition(value, _shiftSize - i, true));
                }
            }

            return setPosCount;
        }

        private ulong[] FilterWhereBitIs(bool set, int position, IEnumerable<ulong> inputArray)
        {
            return inputArray.Where(v => CheckAtPosition(v, position, set)).ToArray();
        }

        private bool CheckAtPosition(ulong value, int position, bool isSet)
        {
            ulong pos = (ulong) (1L << position);
            bool set = isSet ? (value & pos) != 0 : (value & pos) == 0;
            return set;
        }
    }
}