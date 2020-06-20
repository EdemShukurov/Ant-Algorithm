using Ant_Algorithm.Helper;
using Ant_Algorithm.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Algorithm
{
    internal class AntColony2
    {
        private List<Ant2> ants;

        private Random _random;

        #region Singleton

        private static readonly Lazy<AntColony2> _instance = new Lazy<AntColony2>(() => new AntColony2());

        public static AntColony2 Instance => _instance.Value;

        private AntColony2()
        { }

        #endregion

        public void CreateAnts(uint commonCount, uint eliteAntCount)
        {
            ants = new List<Ant2>();

            if (eliteAntCount < commonCount)
            {
                for (uint i = 0; i < commonCount - eliteAntCount; i++)
                {
                    ants.Add(new Ant2(AntKind.Worker));
                }

                for (uint i = 0; i < eliteAntCount; i++)
                {
                    ants.Add(new Ant2(AntKind.Elite));
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
