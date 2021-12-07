using System.Collections.Generic;
using System.Linq;

namespace DayOne.solvers
{
    public class DayOneSonarSweep
    {
        private readonly int _sweeperWidth;
        public DayOneSonarSweep(int sweeperWidth)
        {
            _sweeperWidth = sweeperWidth;
        }

        public int Solve(IEnumerable<int> inputValues)
        {
            var enumerable = inputValues.ToList();
            var prevInputValue = enumerable.GetRange(0, _sweeperWidth).Sum();
            var greaterCount = 0;
            for (var i = 1; i < (enumerable.Count-_sweeperWidth)+1; i++)
            {
                var currentValue = enumerable.GetRange(i, _sweeperWidth).Sum();
                if (prevInputValue < currentValue)
                {
                    greaterCount++;
                }

                prevInputValue = currentValue;
            }

            return greaterCount;
        }
    }
}