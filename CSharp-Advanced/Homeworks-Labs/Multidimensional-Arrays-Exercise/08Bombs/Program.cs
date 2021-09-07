using System;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] field = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] rows = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = rows[col];
                }
            }

            string[] coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            BombExplode(field, coordinates);

            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < size; row++) // check the alive cells and sum their values
            {
                for (int col = 0; col < size; col++)
                {
                    if (field[row, col] > 0)
                    {
                        aliveCells++;
                        sum += field[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(field[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static void BombExplode(int[,] field, string[] coordinates)
        {
            foreach (string pair in coordinates)
            {
                int[] currentCoordinates = pair.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int currentBombRow = currentCoordinates[0];
                int currentBombCol = currentCoordinates[1];
                int currentBomb = field[currentBombRow, currentBombCol];

                for (int row = currentBombRow - 1; row <= currentBombRow + 1; row++)
                {
                    for (int col = currentBombCol - 1; col <= currentBombCol + 1; col++)
                    {
                        if (row < 0) break;

                        if (row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1))
                        {
                            if (field[row, col] <= 0 || currentBomb < 0)
                            {
                                continue;
                            }
                            field[row, col] -= currentBomb;
                        }
                    }
                }
            }
        }
    }
}