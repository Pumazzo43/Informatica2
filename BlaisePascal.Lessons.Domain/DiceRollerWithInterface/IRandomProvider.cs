using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.DiceRollerWithInterface
{
    public interface IRandomProvider
    {
        int Next(int min, int max);
    }
}
