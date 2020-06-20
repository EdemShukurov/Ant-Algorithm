using Ant_Algorithm.POCO;
using Ant_Algorithm.Helper;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Ant_Algorithm
{
    internal class Ant
    {
        private AlgorithmDetails _detail;

        private List<City> _tabuList;

        private uint _lengthOfPath;

        private double _alpha;

        private City _currentCity;

        private Dictionary<double, City> _cityTransitionProbabilities;

        private double _sumInverseResult;

        private bool _isTransitionDenominatorDetermined;

        public Ant(AlgorithmDetails detail, AntKind kind)
        {
            _detail = detail;

            _alpha = kind == AntKind.Elite ? 0 : _detail.Alpha;

            _tabuList = new List<City>();

            _currentCity = _detail.StartCity;

            _isTransitionDenominatorDetermined = true;

           // _cityTransitionProbability = new Dictionary<double, Vertexes>();
        }

        public void ClearAntMemory()
        {
            _tabuList.Clear();
            _cityTransitionProbabilities.Clear();
        }

        public void TTT()
        {
            double incrementPosibilityValue = 0d;

            for (int i = 0; i < _currentCity.Transitions.Count; i++)
            {
                var neighbouringCity = _currentCity.Transitions[i].GetNeighbouringCityWith(_currentCity);

                incrementPosibilityValue += TransitionPossibility(neighbouringCity);

                _cityTransitionProbabilities.Add(incrementPosibilityValue, neighbouringCity);
            }
        }

        /// <summary>
        /// Inverse of the distance
        /// </summary>
        /// <param name="data"></param>
        /// <returns> Inverse of the distance </returns>
        private static double Nu(Transition info)
        {
            return 1d / info.Distance;
        }

        /// <summary>
        /// Pheromon
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static uint Tau(Transition info)
        {
            return info.Pheromon;
        }


        private double TransitionPossibility(City cityTo)
        {
            double numerator = 0d, denominator = 0d;

            var transitions = _currentCity.Transitions;
            
            if(_isTransitionDenominatorDetermined)
            {
                _isTransitionDenominatorDetermined = false;

                for (int i = 0; i < transitions.Count; i++)
                {
                    var neighbouringCity = transitions[i].GetNeighbouringCityWith(_currentCity);

                    if (_tabuList.Contains(neighbouringCity))
                    {
                        continue;
                    }

                    if (neighbouringCity == cityTo)
                    {
                        numerator = Math.Pow(Nu(transitions[i]), _detail.Beta) * Math.Pow(Tau(transitions[i]), _alpha);
                        denominator += numerator;
                        continue;
                    }

                    denominator += Math.Pow(Nu(transitions[i]), _detail.Beta) * Math.Pow(Tau(transitions[i]), _alpha);
                }

            }


            return numerator / denominator;
        }

        



        public void Run()
        {
            if(_currentCity == _detail.StartCity)
            {
                LayPheromones();
                return;
            }


            for (int i = 0; i < allowedCities.Count; i++)
            {
                P(allowedCities[i], _tabuList);
            }

            DeterminePath();
        }

        private void P(Vertexes cities, List<Vertexes> tabuList)
        {
            _cityTransitionProbability.Add(PreviousResult() + AlgorithmDetails.TransitionPossibility(cities, tabuList),
                                           cities);
        }

        private double PreviousResult()
        {
            double result = 0d;

            foreach (var sector in _cityTransitionProbability.Keys)
            {
                result += sector;
            }

            return result;
        }

        private void DeterminePath()
        {
            double ball = AlgorithmDetails.GetBallValue();

            var vertexes = _cityTransitionProbability.Where(x => x.Key < ball).Select(v => v.Value).FirstOrDefault();
            _currentCity = vertexes.GetNextVertex(_currentCity);
        }

        private void LayPheromones()
        {

        }
    }
}
