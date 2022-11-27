using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    internal class Kernel
    {
        private static Random rand = new Random();
        public delegate double GAFunction(double[] values, string infixPhrase);

        public class GA
        {
            public bool isBit;
            public string infixPhrase;
            public double MutationRate;
            public double CrossoverRate;
            public int ChromosomeLength;
            public int PopulationSize;
            public int GenerationSize;
            public double TotalFitness;
            public double Max;
            public double Min;
            public bool Elitism;
            private ArrayList CurrentGenerationList;
            private ArrayList NextGenerationList;
            private ArrayList FitnessList;
            static private GAFunction getFitness;
            public GAFunction FitnessFunction
            {
                get { return getFitness; }
                set { getFitness = value; }
            }
            public GA(bool _isBit, double XoverRate, double mutRate, int popSize, int genSize, int ChromLength, string infixPhrase, double max, double min)
            {
                isBit = _isBit;
                Elitism = false;
                MutationRate = mutRate;
                CrossoverRate = XoverRate;
                PopulationSize = popSize;
                GenerationSize = genSize;
                ChromosomeLength = ChromLength;
                this.infixPhrase = infixPhrase;
                Max = max;
                Min = min;
            }

            public void LaunchGA()
            {
                if (ChromosomeLength == 0b101)
                    ChromosomeLength -= 0b011;
                FitnessList = new ArrayList();
                CurrentGenerationList = new ArrayList(GenerationSize);
                NextGenerationList = new ArrayList(GenerationSize);
                Chromosome.ChromosomeMutationRate = MutationRate;

                for (int i = 0; i < PopulationSize; i++)
                {
                    Chromosome g = new Chromosome(ChromosomeLength,this.Max,this.Min, false);
                    CurrentGenerationList.Add(g);
                }

                RankPopulation();

                for (int i = 0; i < GenerationSize; i++)
                {
                    CreateNextGeneration();
                    RankPopulation();
                }
            }

            private int RouletteSelection()
            {
                double randomFitness = rand.NextDouble() * TotalFitness;
                int idx = -1;
                int mid;
                int first = 0;
                int last = PopulationSize - 1;
                mid = (last - first) / 2;
                while (idx == -1 && first <= last)
                {
                    if (randomFitness < (double)FitnessList[mid])
                    { last = mid; }
                    else if (randomFitness > (double)FitnessList[mid])
                    { first = mid; }
                    mid = (first + last) / 2;
                    if ((last - first) == 1) idx = last;
                }
                return idx;
            }

            private void RankPopulation()
            {
                TotalFitness = 0;
                for (int i = 0; i < PopulationSize; i++)
                {
                    Chromosome g = ((Chromosome)CurrentGenerationList[i]);
                    g.ChromosomeFitness = FitnessFunction(g.ChromosomeGenes, infixPhrase);
                    TotalFitness += g.ChromosomeFitness;
                }
                CurrentGenerationList.Sort(new ChromosomeComparer());
                double fitness = 0.0;
                FitnessList.Clear();
                for (int i = 0; i < PopulationSize; i++)
                {
                    fitness += ((Chromosome)CurrentGenerationList[i]).ChromosomeFitness;
                    FitnessList.Add((double)fitness);
                }
            }

            private void CreateNextGeneration()
            {
                NextGenerationList.Clear();
                Chromosome g = null;
                if (Elitism)
                    g = (Chromosome)CurrentGenerationList[PopulationSize - 1];
                for (int i = 0; i < PopulationSize; i += 2)
                {
                    int pidx1 = RouletteSelection();
                    int pidx2 = RouletteSelection();
                    Chromosome parent1, parent2, child1, child2;
                    parent1 = ((Chromosome)CurrentGenerationList[pidx1]);
                    parent2 = ((Chromosome)CurrentGenerationList[pidx2]);

                    if (rand.NextDouble() < CrossoverRate)
                    { parent1.Crossover(ref parent2, out child1, out child2); }
                    else
                    {
                        child1 = parent1;
                        child2 = parent2;
                    }
                    child1.Mutate();
                    child2.Mutate();
                    NextGenerationList.Add(child1);
                    NextGenerationList.Add(child2);
                }
                if (Elitism && g != null) NextGenerationList[0] = g;
                CurrentGenerationList.Clear();
                for (int i = 0; i < PopulationSize; i++)
                    CurrentGenerationList.Add(NextGenerationList[i]);
            }

            public void GetBestValues(out double[] values, out double fitness)
            {
                Chromosome g = ((Chromosome)CurrentGenerationList[PopulationSize - 1]);
                values = new double[g.ChromosomeLength];
                g.ExtractChromosomeValues(ref values);
                fitness = (double)g.ChromosomeFitness;
            }
        }

        public class Chromosome
        {
            public double[] ChromosomeGenes;
            public int ChromosomeLength;
            public double ChromosomeFitness;
            public static double ChromosomeMutationRate;

            public Chromosome(int length)
            {
                ChromosomeLength = length;
                ChromosomeGenes = new double[length];
            }
            public Chromosome(int length, double max, double min, bool isBit)
            {
                ChromosomeLength = length;
                ChromosomeGenes = new double[length];
                for (int i = 0; i < ChromosomeLength; i++)
                {
                    double value = rand.NextDouble() * (Math.Abs(max) + Math.Abs(min)) - (Math.Abs(max) + Math.Abs(min)) / 2;
                    if (!isBit)
                        ChromosomeGenes[i] = value;
                    else
                        ChromosomeGenes = DecimalToBit(value);
                }
            }

            public void Crossover(ref Chromosome Chromosome2, out Chromosome child1, out Chromosome child2)
            {
                int position = (int)(rand.NextDouble() * (double)ChromosomeLength);
                child1 = new Chromosome(ChromosomeLength);
                child2 = new Chromosome(ChromosomeLength);
                for (int i = 0; i < ChromosomeLength; i++)
                {
                    if (i < position)
                    {
                        child1.ChromosomeGenes[i] = ChromosomeGenes[i];
                        child2.ChromosomeGenes[i] = Chromosome2.ChromosomeGenes[i];
                    }
                    else
                    {
                        child1.ChromosomeGenes[i] = Chromosome2.ChromosomeGenes[i];
                        child2.ChromosomeGenes[i] = ChromosomeGenes[i];
                    }
                }
            }

            public void Mutate()
            {
                for (int position = 0; position < ChromosomeLength; position++)
                {
                    if (rand.NextDouble() < ChromosomeMutationRate)
                        ChromosomeGenes[position] = (ChromosomeGenes[position] + rand.NextDouble()) / 2.0;
                }
            }

            public void ExtractChromosomeValues(ref double[] values)
            {
                for (int i = 0; i < ChromosomeLength; i++)
                    values[i] = ChromosomeGenes[i];
            }
        }

        public sealed class ChromosomeComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                if (!(x is Chromosome) || !(y is Chromosome))
                    throw new ArgumentException("Not of type Chromosome");
                if (((Chromosome)x).ChromosomeFitness > ((Chromosome)y).ChromosomeFitness)
                    return -1;
                else if (((Chromosome)x).ChromosomeFitness == ((Chromosome)y).ChromosomeFitness)
                    return 0;
                else
                    return 1;
            }
        }

        public static double GenAlgTestFcn(double[] values, string infixPhrase)
        {
            if (values.GetLength(0) != 2)
                throw new Exception("should only have 2 args");

            double x = values[0]; double y = values[1];
            return MathParserSpace.MathParser.calculate(x, y, infixPhrase);
        }

        private double bitToDecimal(double[] bitValue, int amountOfBits)
        {
            double result = 0;
            int powValue = 0;
            for(int i = amountOfBits - 1; i >= 0; --i)
            {
                result += bitValue[i] * Math.Pow(2, powValue);
                ++powValue;
            }
            return result;
        }

        static private double[] DecimalToBit(double value)
        {
            int temp = 1;

            for (int i = 0; i < 4; ++i)
                temp *= 2;

            int intValue = (int)value;
            int idx = 0;
            double[] result = new double[5];

            for (int i = temp; temp > 0; temp = temp / 2)
            {
                if ((temp & intValue) > 0)
                    result[idx] = 1;
                else
                    result[idx] = 0;
            }
            return result;
        }
    }
}
