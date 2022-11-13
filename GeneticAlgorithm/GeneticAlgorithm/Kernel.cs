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
            public GA(double XoverRate, double mutRate, int popSize, int genSize, int ChromLength, string infixPhrase, double max, double min)
            {
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
                FitnessList = new ArrayList();
                CurrentGenerationList = new ArrayList(GenerationSize);
                NextGenerationList = new ArrayList(GenerationSize);
                Chromosome.ChromosomeMutationRate = MutationRate;

                for (int i = 0; i < PopulationSize; i++)
                {
                    Chromosome g = new Chromosome(ChromosomeLength,this.Max,this.Min);
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
            public Chromosome(int length, double max, double min)
            {
                ChromosomeLength = length;
                ChromosomeGenes = new double[length];
                    for (int i = 0; i < ChromosomeLength; i++)
                        ChromosomeGenes[i] = rand.NextDouble() * (Math.Abs(max) + Math.Abs(min)) - (Math.Abs(max) + Math.Abs(min))/2;
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

            //return (15 * x * y * (1 - x) * (1 - y) * Math.Sin(Math.PI * x) * Math.Sin(Math.PI * y));
            return MathParserSpace.MathParser.calculate(x, y, infixPhrase);
        }

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("\nFinding global optimum values to the function:\n");
        //    Console.WriteLine("f(x,y) = 15xy(1-x)(1-y)sin(pi*x)sin(pi*y)\n");
        //    Console.WriteLine("by using a genetic algorithm with initial parameters: \n");
        //    Console.WriteLine("Crossover\t=80%");
        //    Console.WriteLine("Mutation\t=5%");
        //    Console.WriteLine("Population size\t=100");
        //    Console.WriteLine("Generations\t=2000");
        //    Console.WriteLine("Chromosome size\t=2\n");
        //    Console.WriteLine("Actual max values are: x_max = 0.5 and y_max = 0.5\n");

        //    GA ga = new GA(0.8, 0.05, 100, 2000, 2);
        //    ga.FitnessFunction = new GAFunction(GenAlgTestFcn);
        //    ga.Elitism = true;
        //    ga.LaunchGA();

        //    double[] values; double fitness;
        //    ga.GetBestValues(out values, out fitness);

        //    Console.WriteLine("Calculated max values are: \nx_max = {0} \ny_max = {1}\n", values[0], values[1]);
        //    Console.WriteLine("f(x_max,y_max) = f({0},{1}) = {2}", values[0], values[1], fitness);
        //    Console.WriteLine("\nPress ENTER to continue program");
        //    Console.ReadLine();
        //}
    }
}
