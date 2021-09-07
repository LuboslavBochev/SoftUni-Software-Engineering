using System;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            string[,] matrix = new string[input[0], input[1]];

            for (int row = 0; row < matrix.GetLength(0); row++) // matrix input
            {
                string[] rowInput = Console.ReadLine().Split(" ");

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            int squeresCount = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++) // find squeres
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && matrix[row + 1, col] == matrix[row + 1, col + 1] && matrix[row, col] == matrix[row + 1, col])
                    {
                        squeresCount++;
                    }
                }
            }
            Console.WriteLine(squeresCount);
        }
    }
}