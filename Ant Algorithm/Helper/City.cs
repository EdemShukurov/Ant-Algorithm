using System;
using System.Collections.Generic;

namespace Ant_Algorithm.Helper
{
    public class City
    {
        public List<Transition> Transitions { get; }

        public City(List<Transition> transitions)
        {
            Transitions = transitions;
        }
    }
}
