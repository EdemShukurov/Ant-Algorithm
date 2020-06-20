using System;

namespace Ant_Algorithm.Helper
{
    public class Transition
    {
        public City CityFrom { get; }
       
        public City CityTo { get; }

        public uint Distance { get; }

        public uint Pheromon { get; set; }

        public Transition(City from, City to, uint distance, uint pheromon)
        {
            if(to == from)
            {
                throw new ArgumentException($"Cities ({from.ToString()} and {to.ToString()}) must not be the same");
            }

            CityFrom = from;
            CityTo = to;
            Distance = distance;
            Pheromon = pheromon;
        }

        public City GetNeighbouringCityWith(City city)
        {
            return city == CityTo ? CityFrom : CityTo;
        }
    }
}
