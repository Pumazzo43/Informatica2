using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.DiceRollerWithInterface
{
    public class DiceRoller
    {
        private IRandomProvider _randomProvider;

        public DiceRoller(IRandomProvider randomProvider)
        {
            _randomProvider = randomProvider;
        }

        public Dictionary<int, int> GetRollStatistics(int numerOfRolls)
        {
            int roll;
            Dictionary<int, int> stats = new Dictionary<int, int>(){
                {1,0 },{2,0},{3,0},{4,0},{5,0},{6,0}
            };

            for (int i = 0; i < numerOfRolls; i++)
            {
                roll = _randomProvider.Next(1, 6);
                if (stats.ContainsKey(roll))
                {
                    stats[roll]++;
                }
            }

            return stats;
        }

    }
}
