using System;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            string[,] matrix = new string[sizes[0], sizes[1]];

            for (int row = 0; row < sizes[0]; row++) // fill matrix
            {
                var inputRow = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < sizes[1]; col++)
                {
                    matrix[row, col] += inputRow[col];
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "END") break;

                if (commands[0] == "swap" && commands.Length == 5)
                {
                    // check validation of indexes
                    int row1 = int.Parse(commands[1]);
                    int col1 = int.Parse(commands[2]);

                    int row2 = int.Parse(commands[3]);
                    int col2 = int.Parse(commands[4]);

                    if (row1 < 0 || row2 < 0 || row1 >= matrix.GetLength(0) || row2 >= matrix.GetLength(0)
                        || col1 < 0 || col2 < 0 || col1 >= matrix.GetLength(1) || col2 >= matrix.GetLength(1))
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                    // swap

                    Swap(matrix, row1, row2, col1, col2);

                    // then print each change

                    Print(matrix);
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

        }

        static void Print(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Swap(string[,] matrix, int row1, int row2, int col1, int col2)
        {
            string firstNum = matrix[row1, col1];

            matrix[row1, col1] = matrix[row2, col2];

            matrix[row2, col2] = firstNum;
        }
    }
}