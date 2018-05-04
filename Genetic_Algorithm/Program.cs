using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    class Program
    {

        static void Main(string[] args)
        {

            Scheme demo = new Scheme();

            // Init population
            demo.population.InitializePopulation(100);

            //for (int i = 0; i < demo.population.individuals.Count(); i++)
            //{

            //    Console.WriteLine(string.Join(",", demo.population.individuals[i].genes));
            //}

            demo.population.CalculateFitness();

            for (int i = 0; i < demo.population.individuals.Count(); i++)
            {

                Console.WriteLine($"{string.Join(",", demo.population.individuals[i].genes)} , {demo.population.individuals[i].fitness}");
            }

            Console.WriteLine($"Generation {demo.generationCount} Fittest: {demo.population.fittest}");


            Console.ReadLine();
        }
    }
}
