using System;

namespace NumericsConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numerics = new double[25];
            InitNumericsRandom(numerics, 0, 15);
            CalculateLastValue(numerics, 3);
            PrintNumerics(numerics);
            Console.WriteLine("Using formula: ");
            double alpha = 0.1;
            Console.WriteLine($"Using alpha: {alpha}");
            double[] formulaResults = Formula(numerics, alpha);
            PrintResults(numerics, formulaResults);
            Console.WriteLine($"New result using formula with alpha: {formulaResults[formulaResults.Length - 1]}");
        }

        private static void PrintNumerics(double[] numerics)
        {
            for (int i = 0; i < numerics.Length - 1; i++)
            {
                Console.WriteLine($"{i + 1}th of March the numeric value is: {numerics[i]}");
            }
            Console.WriteLine();
        }

        private static void PrintResults(double[] numerics, double[] formulaResults)
        {
            for (int i = 0; i < numerics.Length; i++)
            {
                Console.WriteLine($"The numeric value is: {numerics[i]} \tand using the formula is: {formulaResults[i]}");
            }
            Console.WriteLine();
        }

        private static void InitNumericsRandom(double[] numerics, int min, int max)
        {
            Random r = new Random();
            for (int i = 0; i < numerics.Length - 1; i++)
            {
                numerics[i] = r.Next(min, max);
            }
        }

        private static double[] Formula(double[] numerics, double alpha)
        {
            double prev = numerics[0];
            double[] generated = new double[numerics.Length];
            generated[1] = prev;

            for (int i = 2; i < numerics.Length; i++)
            {
                double next = (numerics[i - 1] * alpha) + (prev * (1 - alpha));
                generated[i] = next;
                prev = next;
            }

            return generated;
        }

        private static void CalculateLastValue(double[] numerics, int num)
        {
            double sum = 0;
            for (int i = numerics.Length - 1; i >= numerics.Length - (num + 1); i--)
            {
                sum += numerics[i];
            }

            numerics[numerics.Length - 1] = sum / 3;
        }
    }
}
