using Ant_Algorithm.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ant_Algorithm
{
    internal static class Calculation
    {
        public static List<City> GetNeighbourCities(City cuttentCity)
        {
            List<City> neighbourCities= new List<City>();

            foreach (var city in cuttentCity.Transitions)
            {
                neighbourCities.Add(city.GetNeighbouringCityWith(cuttentCity));
            }

            return neighbourCities;
        }

        public static void TransitionPossibility()
        {

        }
    }
}
