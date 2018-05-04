using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    class Scheme
    {
        public Population population = new Population();
        public Individual[] fittest;
        public int generationCount = 0;

        // Selection
        public void Selection()
        {
            // Getting all of the most fit individuals
            fittest = population.GetFittestIndividuals(10)[0];

        }

        // Crossover
        public void Crossover()
        {
            // Shuffle the array of the fittest first.
            var randomizedFittest = fittest.OrderBy(x => Services.Rand.Next()).ToArray();

            // Select a random cutoff fitness
            int cutoff = Services.Rand.Next(population.fittest);
            Console.WriteLine(cutoff);
            int count = fittest.Count();

            // Get two members of the current generation that are above or equal to this fitness.

            Individual[] breedPair = new Individual[2];

            for (int i = 0; i < count; i++)
            {
                // This is the first to breed.
                if(fittest[i].fitness >= cutoff)
                {
                    if (breedPair[0] != null)
                    {
                        breedPair[1] = randomizedFittest[i];
                    } else
                    {
                        breedPair[0] = randomizedFittest[i];
                    }
                }
            }

            Console.WriteLine("The first pair to be bred.");
            foreach(var individual in breedPair)
            {
                Console.WriteLine($"{string.Join(",", individual.genes)} , {individual.fitness}");
            }

            Console.ReadLine();

            // Select a random crossover point
            int crossOverPoint = Services.Rand.Next(Individual.geneLength);

            // Swap values
            
 

            for(int i = 0; i < crossOverPoint; i ++)
            {
                // afterwards, fittest[i] should be the new child.
                int temp = fittest[i].genes[crossOverPoint];
                fittest[i].genes[crossOverPoint] = fittest[i + 1].genes[crossOverPoint];
                fittest[i + 1].genes[crossOverPoint] = temp;
            }
        }

        // Mutation
        public void Mutation()
        {
            Random rand = new Random();

            // Select a random mutation point
            int mutationPoint = rand.Next(Individual.geneLength);

            int count = fittest.Count();

            for (int i = 0; i < count; i++)
            {
                if(fittest[i].genes[mutationPoint] == 0)
                {
                    fittest[i].genes[mutationPoint] = 1;
                } else
                {
                    fittest[i].genes[mutationPoint] = 0;
                }
            }
            
        }

        // Get fittest offspring
        public Individual GetFittestOffspring()
        {
            if (fittest[0].fitness > fittest[1].fitness)
            {
                return fittest[0];
            }
            return fittest[1];

        }
    }
}
