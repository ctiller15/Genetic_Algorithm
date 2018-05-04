using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    class Population
    {
        //
        static public int PopSize = 100;
        public int fittest = 0;
        public string fittestStr = "";
        public Individual[] individuals = new Individual[PopSize];

        // Initialize population
        public void InitializePopulation(int size)
        {
            for (int i = 0; i < individuals.Count(); i++)
            {
                individuals[i] = new Individual();
                //Console.WriteLine(string.Join(",", individuals[i].genes));
            }
        }

        // Get the fittest individual(s)
        public Individual[][] GetFittestIndividuals(int percentage)
        {
            // Sort the individuals:
            var fitIndividuals = new Individual[2][];

            var individualCount = percentage * individuals.Count() / 100;
            fitIndividuals[0] = individuals.OrderByDescending(o => o.fitness).Take(individualCount).ToArray();
            // The fittest individuals
            //fitIndividuals[0] = individuals.OrderByDescending(o => o.fitness).Take(individualCount).ToList();
            fittest = fitIndividuals[0].First().fitness;
            fittestStr = fitIndividuals[0].First().genes.ToString();
            // The least fit individuals
            fitIndividuals[1] = individuals.OrderBy(o => o.fitness).Take(individualCount).ToArray();

            return fitIndividuals;
        }

        public void CalculateFitness()
        {
            // We calculate the fitness of each individual.
            for(int i = 0; i < individuals.Count(); i++)
            {
                individuals[i].FitnessCalc();
            }

            // After calculating the fitness, we find the fittest individuals.
            GetFittestIndividuals(10);
        }

    }
}
