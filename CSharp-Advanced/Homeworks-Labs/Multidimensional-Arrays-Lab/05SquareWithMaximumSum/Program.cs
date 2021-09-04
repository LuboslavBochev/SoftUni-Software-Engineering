using System;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int row = 0; row < sizes[0]; row++) // input matrix
            {
                int[] inputRows = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < sizes[1]; col++)
                {
                    matrix[row, col] = inputRows[col];
                }
            }

            int maxSquere = int.MinValue;
            int maxSquereRow = 0;
            int maxSquereCol = 0;


            for (int row = 1; row < sizes[0]; row++)
            {
                int currentSquere = 0;

                for (int col = 1; col < sizes[1]; col++)
                {
                    currentSquere = matrix[row - 1, col - 1] + matrix[row - 1, col] + matrix[row, col - 1] + matrix[row, col];

                    if (maxSquere < currentSquere)
                    {
                        maxSquere = currentSquere;
                        maxSquereRow = row;
                        maxSquereCol = col;
                    }
                }
            }

            for (int i = maxSquereRow - 1; i < maxSquereRow + 1; i++)
            {
                for (int j = maxSquereCol - 1; j < maxSquereCol + 1; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSquere);
        }
    }
}