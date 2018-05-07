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
        int[] childGene = new int[Individual.geneLength];
        public int generationCount = 0;

        // Selection
        public void Selection()
        {
            // Getting all of the most fit individuals
            fittest = population.GetFittestIndividuals(10)[0];
        }

        // Crossover
        public int[] Crossover()
        {
            // Shuffle the array of the fittest first.
            var randomizedFittest = fittest.OrderBy(x => Services.Rand.Next()).ToArray();

            // Select a random cutoff fitness
            int cutoff = Services.Rand.Next(population.secondFittest);
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

            // Select a random crossover point
            int crossOverPoint = Services.Rand.Next(Individual.geneLength);

            // Do the crossover.
            for(int i = 0; i < Individual.geneLength; i++)
            {

                //Console.WriteLine(i);
                if(i < crossOverPoint)
                {
                    childGene[i] = breedPair[0].genes[i];
                } else
                {
                    childGene[i] = breedPair[1].genes[i];
                }

            }

            return childGene;
        }

        // Mutation
        public void Mutation()
        {
            int count = fittest.Count();

            // Loop through every child in the new population
            foreach (var child in population.individuals)
            {
                // loop through every gene...
                for(int i = 0; i < child.genes.Count(); i++)
                {
                    // Check random probability...
                    // 1/10 of the time, we mutate.
                    // Free to modify % 10 <= 1 to change mutation.
                    if(Services.Rand.Next() % 10 <= 1)
                    {
                        //Flip values at the mutation point
                        if (child.genes[i] == 0)
                        {
                            child.genes[i] = 1;
                        }
                        else
                        {
                            child.genes[i] = 0;
                        }
                    }
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

        // Create new population
        public void CreateNewPopulation()
        {
            var newPop = new Population();
            for(int i = 0; i < Population.PopSize; i++)
            {
                Crossover();
                var newIndividual = new Individual(childGene);
                newPop.individuals[i] = newIndividual;
            }

            // Replace the old population with a new population.
            population = newPop;

        }
    }
}
