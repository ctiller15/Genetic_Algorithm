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

            // Initialize population
            demo.population.InitializePopulation(Population.PopSize);

            demo.population.CalculateFitness();

            Console.WriteLine($"Generation: {demo.generationCount} , Fittest: {string.Join(",", demo.population.individuals.OrderByDescending(x => x.fitness).First().genes)} : {demo.population.fittest}");

            while(demo.population.fittest < Individual.geneLength && demo.generationCount < 100)
            {
                demo.generationCount++;

                // Do selection.
                demo.Selection();

                // Breed and create a new population.
                demo.CreateNewPopulation();

                // Mutate new population.
                demo.Mutation();

                // Calculate fitness and log to console.
                demo.population.CalculateFitness();
                Console.WriteLine($"Generation: {demo.generationCount} , Fittest: {string.Join(",",demo.population.individuals.OrderByDescending(x => x.fitness).First().genes)} : {demo.population.fittest}");

                //Console.ReadLine();

            }
            Console.ReadLine();
        }
    }
}
