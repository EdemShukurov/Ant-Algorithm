using Ant_Algorithm.Helper;
using Ant_Algorithm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ant_Algorithm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _alpha, _beta, _Q;

        private List<double> _pheromones;

        private double _absentMindedCoefficient;

        private uint _countOfCities;
        private uint _countOfAnts;

        private Dictionary<Vertexes, EdgeInfo> _citiesData;

        private Random _random;
        private bool _useRandomGeneration;

        public MainWindow()
        {
            InitializeComponent();
            _random = new Random();
        }

        private void DrawGraph()
        {

        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            if (_useRandomGeneration)
            {
                GenerateRandomDistances();
            }
                
            Init();

        }

        private void GenerateRandomDistances()
        {
            _citiesData = new Dictionary<Vertexes, EdgeInfo>();

            for (uint i = 1; i < _countOfCities + 1; i++)
            {
                for (uint j = i + 1; j < _countOfCities + 1; j++)
                {
                    var vertexes = new Vertexes(i, j);
                    var data = new EdgeInfo((uint)_random.Next(10, 100), (uint)_random.Next(0, 5));

                    _citiesData.Add(vertexes, data);
                }
            }
        }

        private void Init()
        {
            AlgorithmDetails.AbsentMindedCoefficient = _absentMindedCoefficient;
            AlgorithmDetails.Alpha = _alpha;
            AlgorithmDetails.Beta = _beta;
            AlgorithmDetails.Q = _Q;
            AlgorithmDetails.CountOfAnts = _countOfAnts;
            AlgorithmDetails.CountOfCities = _countOfCities;
            AlgorithmDetails.CountOfCities = _countOfCities;
            AlgorithmDetails.CitiesData = _citiesData;
        }

        private void DrawEdge(int form, int to, byte distance)
        {

        }
    }
}
