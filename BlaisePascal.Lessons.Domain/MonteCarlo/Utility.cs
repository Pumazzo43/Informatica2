using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonExamples.Domain
{
    internal class Utility
    {
    }
    // --- 2. FRAMEWORK ASTRATTO PER L'ESPERIMENTO ---

    /// <summary>
    /// Definisce il "template" per qualsiasi esperimento Monte Carlo.
    /// </summary>
    //public abstract class MonteCarloExperiment
    //{
    //    /// <summary>
    //    /// Esegue un singolo "trial" (lancio).
    //    /// </summary>
    //    public abstract bool IsHit();

    //    /// <summary>
    //    /// Calcola il risultato finale dell'esperimento.
    //    /// </summary>
    //    public abstract double GetResult(long totalHits, long totalTrials);
    //}

    ///// <summary>
    ///// Esegue un qualsiasi esperimento Monte Carlo.
    ///// </summary>
    //public class MonteCarloSimulator
    //{
    //    private readonly MonteCarloExperiment _experiment;

    //    public long Hits { get; private set; }
    //    public long TotalTrials { get; private set; }

    //    public MonteCarloSimulator(MonteCarloExperiment experiment)
    //    {
    //        _experiment = experiment ?? throw new ArgumentNullException(nameof(experiment));
    //    }

    //    public void Run(long numberOfTrials)
    //    {
    //        for (long i = 0; i < numberOfTrials; i++)
    //        {
    //            if (_experiment.IsHit())
    //            {
    //                Hits++;
    //            }
    //            TotalTrials++;
    //        }
    //    }

    //    public double GetResult()
    //    {
    //        return _experiment.GetResult(Hits, TotalTrials);
    //    }
    //}

    //// --- 3. IMPLEMENTAZIONE CONCRETA PER LA STIMA DI PI ---

    //public class PiEstimationExperiment : MonteCarloExperiment
    //{
    //    private readonly Square _bounds;
    //    private readonly Circle _target;
    //    private readonly Random _random;

    //    public PiEstimationExperiment() : this(new Random()) { }

    //    public PiEstimationExperiment(Random randomGenerator)
    //    {
    //        _bounds = new Square(new Point(-1, -1), 2);
    //        _target = new Circle(new Point(0, 0), 1);
    //        _random = randomGenerator;
    //    }

    //    public override bool IsHit()
    //    {
    //        double x = _bounds.TopLeft.X + _random.NextDouble() * _bounds.SideLength;
    //        double y = _bounds.TopLeft.Y + _random.NextDouble() * _bounds.SideLength;
    //        var point = new Point(x, y);

    //        return _target.Contains(point);
    //    }

    //    public override double GetResult(long totalHits, long totalTrials)
    //    {
    //        if (totalTrials == 0) return 0.0;
    //        return 4.0 * (double)totalHits / totalTrials;
    //    }
    //}
}
