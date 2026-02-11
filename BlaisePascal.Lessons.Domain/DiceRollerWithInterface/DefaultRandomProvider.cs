using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.DiceRollerWithInterface
{
    public class DefaultRandomProvider : IRandomProvider
    {
        private Random Random { get; set; }
        public DefaultRandomProvider()
        {
            Random = new Random();
        }
        public int Next(int min, int max)
        {
            return Random.Next(min, max + 1);
        }
    }
}
