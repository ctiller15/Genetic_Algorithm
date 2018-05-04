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
        static public int geneLength = 5;
        public int[] genes = new int[geneLength];

        // Calculates the fitness for this individual.
        // If the gene value matches our desired binary, then the fitness increases.
        public void FitnessCalc()
        {
            for(int i = 0; i < 5; i++)
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
                genes[i] = Program.Rand.Next() % 2;
            }
        }
    }
}
