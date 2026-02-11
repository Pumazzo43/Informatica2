namespace BlaisePascal.LessonExamples.Domain
{
    /// <summary>
    /// Simulates Buffon's Coin problem using the Square and Point classes.
    /// Estimates the probability that a coin falls entirely within a tile.
    /// </summary>
    public class BuffonsCoinExperiment : MonteCarloExperiment
    {
        private readonly Random _random;
        private readonly Square _tile;       // Represents the floor tile
        private readonly Square _safeZone;   // Represents the area where the coin's center must land
        private readonly double _coinRadius;

        public BuffonsCoinExperiment(double tileWidth, double coinDiameter, Random random)
        {
            _random = random;
            _coinRadius = coinDiameter / 2.0;

            if (coinDiameter > tileWidth)
            {
                throw new ArgumentException("The coin's diameter cannot be greater than the tile's width.");
            }

            // 1. We define the tile as a square from (0,0) to (tileWidth, tileWidth)
            _tile = new Square(new Point(0, 0), tileWidth);

            // 2. We define the "safe zone".
            // A coin does not touch the edges if its center is at least 'radius' away from the edges.
            // Therefore, the safe zone is a smaller square, shifted by 'radius' from each side.
            double safeZoneSide = tileWidth - coinDiameter;
            Point safeZoneStartPoint = new Point(_coinRadius, _coinRadius);
            _safeZone = new Square(safeZoneStartPoint, safeZoneSide);
        }

        // Default constructor for simplicity
        public BuffonsCoinExperiment() : this(2.0, 1.0, new Random()) { }

        /// <summary>
        /// Performs one trial: tosses a coin and sees where its center lands.
        /// </summary>
        public override bool IsHit()
        {
            // We generate a random point for the coin's center, within the tile.
            double randomX = _tile._bottomLeftVertex.GetX() + _random.NextDouble() * _tile._side;
            double randomY = _tile._bottomLeftVertex.GetY() + _random.NextDouble() * _tile._side;
            Point coinCenter = new Point(randomX, randomY);

            // A "hit" occurs if the coin's center falls inside the "safe zone".
            // We reuse the IsInside method from your Square class!
            return _safeZone.IsInside(coinCenter);
        }

        /// <summary>
        /// Calculates the estimated probability. The logic does not change.
        /// </summary>
        public override double GetResult(long totalHits, long totalTrials)
        {
            if (totalTrials == 0) return 0.0;

            // The result is the estimated probability that the coin falls entirely within the tile.
            return (double)totalHits / totalTrials;
        }
    }
}