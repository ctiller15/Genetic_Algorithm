using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    class Individual
    {
        public int fitness = 0;
        // Free to modify geneLength
        static public int geneLength = 20;
        public int[] genes = new int[geneLength];

        // Calculates the fitness for this individual.
        // If the gene value matches our desired binary, then the fitness increases.
        public void FitnessCalc()
        {
            for(int i = 0; i < geneLength; i++)
            {
                if(genes[i] == 1)
                {
                    fitness++;
                }
            }
        }

        // The individual constructor.
        public Individual()
        {
            for(int i = 0; i < genes.Length; i++)
            {
                // Generates a bit that is either 1 or 0.
                genes[i] = Services.Rand.Next() % 2;
            }
        }

        //individual overload, takes an array.
        public Individual(int[] genecombination)
        {
            for(int i = 0; i < geneLength; i++)
            {
                //genes = genecombination
                //genes[i] = genecombination[i];
                // Clone to avoid pass by reference issues.
                genes = (int[])genecombination.Clone();           
            }
        }
    }
}
