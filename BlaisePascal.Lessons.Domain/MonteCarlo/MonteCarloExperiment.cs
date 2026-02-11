using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonExamples.Domain
{
    public abstract class MonteCarloExperiment
    {
        public abstract bool IsHit();
        public abstract double GetResult(long nrHits, long nrTrials);
    }
}
