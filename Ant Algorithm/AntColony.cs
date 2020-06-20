using Ant_Algorithm.Helper;
using Ant_Algorithm.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Algorithm
{
    internal class AntColony
    {
        private List<Ant> ants;

        private Random _random;

        #region Singleton

        private static readonly Lazy<AntColony> _instance = new Lazy<AntColony>(() => new AntColony());

        public static AntColony Instance => _instance.Value;

        private AntColony()
        { }

        #endregion

        public void CreateAnts(uint commonCount, uint eliteAntCount)
        {
            ants = new List<Ant>();

            if (eliteAntCount < commonCount)
            {
                for (uint i = 0; i < commonCount - eliteAntCount; i++)
                {
                    ants.Add(new Ant(AntKind.Worker));
                }

                for (uint i = 0; i < eliteAntCount; i++)
                {
                    ants.Add(new Ant(AntKind.Elite));
                }
            }
        }

        public void GetResult()
        {

        }

        private int CommonCountOfDistanceValues(int count)
        {
            if (count == 1)
                return 1;

            return count + CommonCountOfDistanceValues(count - 1);
        }

       

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var data in AlgorithmDetails.CitiesData)
            {
                stringBuilder.Append(
                    String.Format("City From:{0} - City To:{1}, Distance:{2}", data.Key.VertexFrom.ToString(),
                                                                               data.Key.VertexTo.ToString(),
                                                                               data.Value.Distance.ToString())
                    );
            }

            return stringBuilder.ToString();
        }

    }
}
