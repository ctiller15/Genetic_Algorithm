using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    class Program
    {
        static public Random Rand { get; set; } = new Random();
        static void Main(string[] args)
        {

            Scheme demo = new Scheme();

            // Init population
            demo.population.InitializePopulation(100);

            //for(int i = 0; i < demo.population.individuals.Count(); i++)
            //{

            //    Console.WriteLine(string.Join(",",demo.population.individuals[i].genes));
            //}
            //Console.WriteLine(demo);

            Console.ReadLine();
        }
    }
}
