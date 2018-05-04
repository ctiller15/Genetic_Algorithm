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
            Random rand = new Random();

            // Select a random crossover point
            int crossOverPoint = rand.Next(Individual.geneLength);

            // Swap values

            // If even...
            int count = fittest.Count();
            if(count % 2 == 0)
            {
                // Grab every two elements, and swap their genes.
                for(int i = 0; i < count; i += 2)
                {
                    int temp = fittest[i].genes[crossOverPoint];
                    fittest[i].genes[crossOverPoint] = fittest[i + 1].genes[crossOverPoint];
                    fittest[i + 1].genes[crossOverPoint] = temp;
                }
            }
        }
    }
}
