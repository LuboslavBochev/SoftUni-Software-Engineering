using System;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] sizes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            string strSnake = Console.ReadLine();

            string[,] snakeMovements = new string[sizes[0], sizes[1]];

            int inc = 0;

            for (int row = 0; row < sizes[0]; row++)
            {

                if (row % 2 == 0)
                {
                    for (int col = 0; col < sizes[1]; col++)
                    {
                        if (inc == strSnake.Length)
                        {
                            inc = 0;
                        }

                        snakeMovements[row, col] = strSnake[inc].ToString();
                        inc++;
                    }
                }

                else
                {
                    for (int col = sizes[1] - 1; col >= 0; col--)
                    {
                        if (inc == strSnake.Length)
                        {
                            inc = 0;
                        }

                        snakeMovements[row, col] = strSnake[inc].ToString();
                        inc++;
                    }
                }
            }

            for (int row = 0; row < sizes[0]; row++)
            {
                for (int col = 0; col < sizes[1]; col++)
                {
                    Console.Write(snakeMovements[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}