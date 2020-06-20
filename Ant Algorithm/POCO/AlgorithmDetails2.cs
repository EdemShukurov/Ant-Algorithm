using Ant_Algorithm.Helper;


namespace Ant_Algorithm.POCO
{
    public class AlgorithmDetails
    {
        /// <summary>
        /// Count of the cities
        /// </summary>
        public uint CountOfCities { get; set; }

        /// <summary>
        /// Count of the ants
        /// </summary>
        public uint CountOfAnts { get; set; }

        /// <summary>
        /// Pheromon influation on the direction
        /// </summary>
        public double Alpha
        {
            get => _alpha;
            set => _alpha = value < 0 ? 0 : value;
        }

        /// <summary>
        /// Influence on the distance between vertexes
        /// </summary>
        public double Beta
        {
            get => _beta;
            set => _beta = value < 0 ? 0 : value;
        }

        /// <summary>
        /// 
        /// </summary>
        public double AbsentMindedCoefficient { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Q { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public City StartCity { get; set; }

        private double _alpha, _beta;
    }
}
