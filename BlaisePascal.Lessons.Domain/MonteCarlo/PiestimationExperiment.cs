namespace BlaisePascal.LessonExamples.Domain
{
    public class PiEstimationExperiment : MonteCarloExperiment
    {
        private Square _bounds;
        private Circle _target;
        private Random _random;

        public PiEstimationExperiment(Random random)
        {
            _bounds = new Square(new Point(-1, -1), 2.0);
            _target = new Circle(1.0);
            _random = random;
        }
        public PiEstimationExperiment() : this(new Random())
        {

        }
        /// <summary>
        /// Genera un punto casuale nel quadrato e controlla se e' dentro il cerchio
        /// </summary>
        /// <returns></returns>
        public override bool IsHit()
        {
            double x = _bounds._bottomLeftVertex.GetX() + _random.NextDouble() * _bounds._side;
            double y = _bounds._bottomLeftVertex.GetY() + _random.NextDouble() * _bounds._side;
            return _target.IsInside(x, y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalHits"></param>
        /// <param name="totalTrials"></param>
        /// <returns></returns>
        public override double GetResult(long totalHits, long totalTrials)
        {
            if (totalTrials == 0) return 0.0;
            return 4.0 * ((double)totalHits / totalTrials);
        }
    }
}