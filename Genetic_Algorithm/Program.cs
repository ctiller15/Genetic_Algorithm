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

            while(demo.population.fittest < Individual.geneLength)
            {
                demo.generationCount++;

                // Do selection.
                demo.Selection();

                // Selection check.
                //for(int i = 0; i < demo.fittest.Count(); i++)
                //{
                //    Console.WriteLine($"{string.Join(",", demo.fittest[i].genes)} , {demo.fittest[i].fitness}");
                //}

                //demo.Crossover();

                demo.CreateNewPopulation();
                for(int i = 0; i < 10; i++)
                {
                    Console.WriteLine(string.Join(",", demo.population.individuals[i].genes));
                }


                //for (int i = 0; i < demo.population.individuals.Count(); i++)
                //{

                //    Console.WriteLine(string.Join(",", demo.population.individuals[i].genes));
                //}

                //Console.ReadLine();

                demo.Mutation();
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(string.Join(",", demo.population.individuals[i].genes));
                }

                Console.ReadLine();

            }


            Console.ReadLine();
        }
    }
}
