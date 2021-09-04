using System;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            int sumDiagonal = 0;

            for (int row = 0; row < n; row++)
            {
                int[] currentRowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    if (row == col)
                    {
                        sumDiagonal += currentRowInput[col];
                    }
                    matrix[row, col] = currentRowInput[col];
                }
            }
            Console.WriteLine(sumDiagonal);
        }
    }
}