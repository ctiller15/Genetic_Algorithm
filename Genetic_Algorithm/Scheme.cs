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
        public Individual[] breedPair;
        public int generationCount = 0;

        // Selection
        public void Selection()
        {
            // Getting all of the most fit individuals
            fittest = population.GetFittestIndividuals(10)[0];
        }

        // Crossover
        public void Crossover(int fitInd)
        {
            Random rand = new Random();

            // Select a random crossover point
            int crossOverPoint = rand.Next(Individual.geneLength);

            // Swap values

            // If even...
            int count = fittest.Count();

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
