using System;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int numRows = int.Parse(Console.ReadLine());

            double[][] matrix = new double[numRows][];

            for (int row = 0; row < matrix.Length; row++) // fill the matrix
            {
                int[] rows = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = new double[rows.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = rows[col];
                }
            }

            // analyzing

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                int firstRow = matrix[row].Length;
                int secondRow = matrix[row + 1].Length;

                if (firstRow == secondRow)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }

                else
                {
                    for (int col = 0; col < Math.Max(firstRow, secondRow); col++)
                    {
                        if (col >= matrix[row].Length)
                        {
                            double value = matrix[row + 1][col];

                            if (value != 0)
                            {
                                matrix[row + 1][col] /= 2;
                            }
                        }

                        else if (col >= matrix[row + 1].Length)
                        {
                            double value = matrix[row][col];

                            if (value != 0)
                            {
                                matrix[row][col] /= 2;
                            }
                        }

                        else
                        {
                            double firstValue = matrix[row][col];
                            double secondValue = matrix[row + 1][col];

                            if (firstValue != 0)
                            {
                                matrix[row][col] /= 2;
                            }

                            if (secondValue != 0)
                            {
                                matrix[row + 1][col] /= 2;
                            }
                        }
                    }
                }
            }

            // commands

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "End") break;

                int row = int.Parse(tokens[1]);
                int column = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                bool isValid = CheckIndexes(row, column, matrix);

                if (isValid)
                {
                    if (command == "Add")
                    {
                        matrix[row][column] += value;
                    }

                    else if (command == "Subtract")
                    {
                        matrix[row][column] -= value;
                    }
                }
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        static bool CheckIndexes(int row, int column, double[][] matrix)
        {
            bool isValid = true;

            if (row < 0 || row >= matrix.Length)
            {
                isValid = false;
                return isValid;
            }

            int length = matrix[row].Length;

            if (column < 0 || column >= length)
            {
                isValid = false;
                return isValid;
            }

            return isValid;
        }
    }
}