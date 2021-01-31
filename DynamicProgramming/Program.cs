using System;

namespace DynamicProgramming
{
    class Program
    {

        static double [] calculateMaxValueContiguousSubsequence(double[] array)
        {
            double[] F = new double[array.Length];
            double maxValue = F[0];
            int minIndex = 0;
            int maxIndex = 0;
            F[0] = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                minIndex = array[i] + F[i - 1] < array[i] ? i : minIndex;
                F[i] = Math.Max(array[i] + F[i - 1], array[i]);
                if (F[i] > maxValue)
                {
                    maxValue = F[i];
                    maxIndex = i;
                }
            }
            double[] result = { minIndex, maxIndex, maxValue };
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("-------------------Maximum Value Contiguous Subsequence----------------------\n\n");
            Console.Write("Please enter array by seperating the elements by comma: ");
            string inputArray = Console.ReadLine();

            Array.ConvertAll(inputArray.Split(","), int.Parse);
            double[] array = Array.ConvertAll(inputArray.Split(","), Double.Parse); //{ 5, 3, 6, -6, 9, 12, -5, 3, 5, 8, -1 };
            double[] maxValueContiguousSubsequence = calculateMaxValueContiguousSubsequence(array);

            for (int i = (int)maxValueContiguousSubsequence[0]; i <= (int)maxValueContiguousSubsequence[1]; i++)
                Console.Write(array[i] + "\t");

            Console.WriteLine("\n\nMaximal value is " + maxValueContiguousSubsequence[2] +", produced by F[" + (maxValueContiguousSubsequence[1] + 1) + "].");
        }
    }
}
