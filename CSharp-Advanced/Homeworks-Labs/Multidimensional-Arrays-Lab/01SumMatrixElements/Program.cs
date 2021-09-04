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

            int sumAllElements = 0;

            for (int row = 0; row < input[0]; row++)
            {
                int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < input[1]; col++)
                {
                    matrix[row, col] = currentRow[col];
                    sumAllElements += currentRow[col];
                }
            }
            Console.WriteLine(input[0]);
            Console.WriteLine(input[1]);
            Console.WriteLine(sumAllElements);
        }
    }
}