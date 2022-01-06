using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int[,] garden = new int[dimensions[0], dimensions[1]];

            garden = FillInitialGarden(garden);

            List<string> commands = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Bloom Bloom Plow") break;

                commands.Add(input);
            }

            foreach (var command in commands)
            {
                int flowerRow = int.Parse(command[0].ToString());
                int flowerCol = int.Parse(command[0].ToString());

                if (CheckIndexes(flowerRow, flowerCol, garden))
                {
                    garden = BloomFlowers(flowerRow, flowerCol, garden);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }
            Print(garden);
        }

        private static void Print(int[,] garden)
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    if (col + 1 == garden.GetLength(1)) Console.Write(garden[row, col]);

                    else Console.Write(garden[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] BloomFlowers(int flowerRow, int flowerCol, int[,] garden)
        {
            garden[flowerRow, flowerCol]++;
            // up
            for (int row = 1; row < garden.GetLength(0); row++)
            {
                if (CheckIndexes(flowerRow - row, flowerCol, garden))
                {
                    garden[flowerRow - row, flowerCol]++;
                }
                else break;
            }
            // down
            for (int row = 1; row < garden.GetLength(0); row++)
            {
                if (CheckIndexes(flowerRow + row, flowerCol, garden))
                {
                    garden[flowerRow + row, flowerCol]++;
                }
                else break;
            }
            // right
            for (int col = 1; col < garden.GetLength(1); col++)
            {
                if (CheckIndexes(flowerRow, flowerCol + col, garden))
                {
                    garden[flowerRow, flowerCol + col]++;
                }
                else break;
            }
            //left
            for (int col = 1; col < garden.GetLength(1); col++)
            {
                if (CheckIndexes(flowerRow, flowerCol - col, garden))
                {
                    garden[flowerRow, flowerCol - col]++;
                }
                else break;
            }
            return garden;
        }

        private static bool CheckIndexes(int flowerRow, int flowerCol, int[,] garden)
        {
            return flowerRow >= 0 && flowerRow < garden.GetLength(0)
                && flowerCol >= 0 && flowerCol < garden.GetLength(1);
        }

        private static int[,] FillInitialGarden(int[,] garden)
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    garden[row, col] += 0;
                }
            }
            return garden;
        }
    }
}