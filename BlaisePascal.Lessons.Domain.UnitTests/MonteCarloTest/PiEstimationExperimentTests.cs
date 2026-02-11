namespace BlaisePascal.LessonExamples.Domain.UnitTests
{
    public class PiEstimationExperimentTests
    {
        [Fact]
        public void GetResult_CalculatePiCorrectly_ForGivenStats()
        {
            //Arrange
            PiEstimationExperiment experiment = new PiEstimationExperiment();
            long hits = 7853;
            long trials = 10000;
            double expectedPi = 3.1412;

            //Act
            double result = experiment.GetResult(hits, trials);

            Assert.Equal(expectedPi, result, 4);

        }

        [Fact]
        public void PiEstimation_ApproximatesPi_To3DecimalPlaces_WithEnoughTrials()
        {
            // Arrange
            long numberOfTrials = 100_000_000; // A very high number of trials for a good approximation
            double expectedPi = Math.PI;
            int precision = 3; // The required precision of 3 decimal places

            // To make the test deterministic, we use a Random with a fixed seed.
            var seededRandom = new Random(12345);

            // We create an instance of the specific experiment and pass it to the simulator
            MonteCarloExperiment experiment = new PiEstimationExperiment(seededRandom);
            var simulator = new MonteCarloSimulator(experiment);

            // Act
            simulator.Run(numberOfTrials);
            double estimatedPi = simulator.GetResult();

            // Assert
            // We check that the simulation result is equal to Math.PI
            // with a tolerance of 3 decimal places.
            Assert.Equal(expectedPi, estimatedPi, precision);
        }

        [Fact]
        public void IntegralEstimation_ApproximatesCorrectArea()
        {
            // Arrange
            long numberOfTrials = 2_000_000;
            double expectedArea = 21.0; // The definite integral of x^2 from 1 to 4 is (4^3/3) - (1^3/3) = 63/3 = 21

            var seededRandom = new Random(54321);

            MonteCarloExperiment experiment = new IntegralExperiment(seededRandom);
            var simulator = new MonteCarloSimulator(experiment);

            // Act
            simulator.Run(numberOfTrials);
            double estimatedArea = simulator.GetResult();

            // Assert
            // We check the result with a reasonable tolerance (e.g., 0.1)
            Assert.InRange(estimatedArea, expectedArea - 0.1, expectedArea + 0.1);
        }
    }
}