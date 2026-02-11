namespace BlaisePascal.LessonExamples.Domain
{
    /// <summary>
    /// Estimates the area under the curve f(x) = x^2 between x=1 and x=4.
    /// Rewritten version to use an object that defines the boundaries.
    /// </summary>
    public class IntegralExperiment : MonteCarloExperiment
    {
        private readonly Random _random;
        private readonly Rectangle _bounds; // Now we use a Rectangle object

        public IntegralExperiment(Random random)
        {
            _random = random;
            // The bounding rectangle goes from x in [1, 4] and y in [0, 16]
            _bounds = new Rectangle(new Point(1, 0), 3, 16); // Width 3 (4-1), Height 16 (4^2)
        }
        public IntegralExperiment() : this(new Random()) { }

        // The function to integrate
        private double Fx(double x) => x * x;

        public override bool IsHit()
        {
            // Generates a random point within the bounding rectangle
            double randomX = _bounds.BottomLeftVertex.GetX() + _random.NextDouble() * _bounds.Width;
            double randomY = _bounds.BottomLeftVertex.GetY() + _random.NextDouble() * _bounds.Height;

            // A "hit" is a point that lies under the curve
            return randomY <= Fx(randomX);
        }

        public override double GetResult(long totalHits, long totalTrials)
        {
            if (totalTrials == 0) return 0.0;
            double ratio = (double)totalHits / totalTrials;
            // The estimated area is the ratio of "hit" points multiplied by the area of the rectangle
            return ratio * _bounds.Area;
        }
    }
}