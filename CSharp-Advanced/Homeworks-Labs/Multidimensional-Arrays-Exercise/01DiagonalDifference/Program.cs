using System;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] matrix = new int[size][];

            int sumPrimary = 0;
            int sumSecondary = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                sumPrimary += matrix[i][i];
                sumSecondary += matrix[i][matrix[i].Length - 1 - i];
            }
            Console.WriteLine(Math.Abs(sumPrimary - sumSecondary));
        }
    }
}