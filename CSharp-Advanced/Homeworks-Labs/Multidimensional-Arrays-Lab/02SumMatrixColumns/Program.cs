using System;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[input[0], input[1]];

            for (int row = 0; row < input[0]; row++) // matrix input
            {
                int[] currentRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < input[1]; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            for (int col = 0; col < input[1]; col++)
            {
                int currentColSum = 0;

                for (int row = 0; row < input[0]; row++)
                {
                    currentColSum += matrix[row, col];
                }
                Console.WriteLine(currentColSum);
            }
        }
    }
}