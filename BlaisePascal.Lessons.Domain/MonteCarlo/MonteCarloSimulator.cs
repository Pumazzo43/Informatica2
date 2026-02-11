using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonExamples.Domain
{
    public class MonteCarloSimulator
    {
        private MonteCarloExperiment _experiment;

        private long _hits;
        private long _totalTrials;

        public MonteCarloSimulator(MonteCarloExperiment experiment)
        {
            _experiment = experiment;
        }

        public void Run(long numberOfTrials)
        {
            for (long i = 0; i < numberOfTrials; i++)
            {
                if (_experiment.IsHit())
                {
                    _hits++;
                }
                _totalTrials++;
            }
        }

        public double GetResult()
        {
            return _experiment.GetResult(_hits, _totalTrials);
        }
    }
}
