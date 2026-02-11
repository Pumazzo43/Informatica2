using BlaisePascal.Lessons.Domain.DiceRollerWithInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Interview.Classroom.Domain.UnitTests.DiceRollerTest
{
    public class DiceRollerTests
    {
        [Fact]
        public void GetRollStatistics_WithSequence_ReturnsCorrectCounts()
        {
            List<int> fakeSequence = new List<int> { 1, 6, 1, 3, 6 };
            var mockRandom = new MockSequenceRandomProvider(fakeSequence);
            var s = new DiceRoller(mockRandom);

            var results = s.GetRollStatistics(5);

            Assert.Equal(2, results[1]);
            Assert.Equal(2, results[6]);
            Assert.Equal(1, results[3]);
            Assert.Equal(0, results[4]);
        }
    }
}
