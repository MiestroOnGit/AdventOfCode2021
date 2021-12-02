using System.Collections.Generic;
using System.Linq;

namespace adventOfCode2021.solvers
{
    public class DayOneSonarSweep
    {
        private int sweeperWidth;
        public DayOneSonarSweep(int sweeperWidth)
        {
            this.sweeperWidth = sweeperWidth;
        }

        public int Solve(IEnumerable<int> inputValues)
        {
            var enumerable = inputValues.ToList();
            var prevInputValue = enumerable.GetRange(0, sweeperWidth).Sum();
            var greaterCount = 0;
            for (var i = 1; i < (enumerable.Count-sweeperWidth)+1; i++)
            {
                var currentValue = enumerable.GetRange(i, sweeperWidth).Sum();
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