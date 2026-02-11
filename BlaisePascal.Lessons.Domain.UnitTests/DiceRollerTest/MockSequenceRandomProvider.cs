using BlaisePascal.Lessons.Domain.DiceRollerWithInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Interview.Classroom.Domain.UnitTests.DiceRollerTest
{
    public class MockSequenceRandomProvider : IRandomProvider
    {
        private Queue<int> _sequence;

        public MockSequenceRandomProvider(IEnumerable<int> values)
        {
            _sequence = new Queue<int>(values);
        }

        public int Next(int min, int max)
        {
            return _sequence.Dequeue();
        }
    }
}
