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
        private int[] _setPosCount;
        private ulong _gamma;
        private ulong _epsolon;
        private int _entrySize;
        private ulong[] inputValues;

        public GammaSolver(IEnumerable<string> input, int bitWidth)
        {
            _bitWidth = bitWidth;
            _shiftSize = bitWidth - 1;
            _setPosCount = new int[bitWidth];
            _epsolon = 0;
            _gamma = 0;
            _entrySize = input.Count();
            inputValues = input.Select(x => Convert.ToUInt64(x, 2)).ToArray();

            for (int i = 0; i < _bitWidth; i++)
            {
                bitMask |= (uint) (1 << i);
            }
        }

        public ulong solve()
        {
            foreach (var value in inputValues)
            {
                for (int i = 0; i < _bitWidth; i++)
                {
                    ulong pos = (ulong) (1L << (_shiftSize - i));
                    bool set = (value & pos) != 0; 
                    _setPosCount[i] += Convert.ToInt32(set);
                }
            }

            _gamma = 0;

            for (int i = 0; i < _setPosCount.Length; i++)
            {
                if (_setPosCount[i] > (_entrySize/2))
                {
                    //Mostly 1s
                    _gamma |= (uint) (1 << (_shiftSize - i));
                }
            }

            _epsolon = (bitMask & (~_gamma));
            
            return _epsolon * _gamma;
        } 

    }
}