using System;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                int[] inputCols = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                matrix[row] = new int[inputCols.Length];

                for (int col = 0; col < inputCols.Length; col++)
                {
                    matrix[row][col] = inputCols[col];
                }
            }

            while (true)
            {

                string[] commands = Console.ReadLine().Split(" ");

                string command = commands[0];

                if (command == "END") break;

                if (command == "Add")
                {
                    int indexRow = int.Parse(commands[1]);
                    int indexCol = int.Parse(commands[2]);
                    int value = int.Parse(commands[3]);

                    if (indexRow < 0 || indexRow >= matrix.Length || indexCol < 0 || indexCol >= matrix[indexRow].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                        continue;
                    }

                    matrix[indexRow][indexCol] += value;
                }

                else
                {
                    int indexRow = int.Parse(commands[1]);
                    int indexCol = int.Parse(commands[2]);
                    int value = int.Parse(commands[3]);

                    if (indexRow < 0 || indexRow >= matrix.Length || indexCol < 0 || indexCol >= matrix[indexRow].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                        continue;
                    }

                    matrix[indexRow][indexCol] -= value;
                }
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}