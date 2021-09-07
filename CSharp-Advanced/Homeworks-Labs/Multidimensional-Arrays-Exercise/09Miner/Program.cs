using System;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());

            char[,] field = new char[size, size];

            string[] commands = Console.ReadLine().Split(" ");

            int coalCount = 0;
            int startIndexRow = 0;
            int startIndexCol = 0;

            for (int row = 0; row < size; row++) // filling the field, coal count and getting the position of the miner
            {
                char[] rows = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    if (rows[col] == '*' || rows[col] == 'e' || rows[col] == 'c' || rows[col] == 's')
                    {
                        if (rows[col] == 'c')
                        {
                            coalCount++;
                        }

                        if (rows[col] == 's')
                        {
                            startIndexRow = row;
                            startIndexCol = col;
                        }
                        field[row, col] = rows[col];
                    }
                }
            }

            int inc = 0;
            bool reachedEnd = false;
            bool coalsCollected = false;

            while (true)
            {
                if (inc == commands.Length) break;

                string commandType = commands[inc];

                if (commandType == "up")
                {
                    if (startIndexRow - 1 >= 0)
                    {
                        if (field[startIndexRow - 1, startIndexCol] == 'e')
                        {
                            reachedEnd = true;
                            startIndexRow = startIndexRow - 1;
                            break;
                        }

                        else if (field[startIndexRow - 1, startIndexCol] == 'c')
                        {
                            coalCount--;
                            field[startIndexRow - 1, startIndexCol] = '*';
                            startIndexRow = startIndexRow - 1;

                            if (coalCount == 0)
                            {
                                coalsCollected = true;
                                break;
                            }
                        }

                        else
                        {
                            startIndexRow = startIndexRow - 1;
                        }
                    }
                }

                else if (commandType == "right")
                {
                    if (startIndexCol + 1 < field.GetLength(1))
                    {
                        if (field[startIndexRow, startIndexCol + 1] == 'e')
                        {
                            reachedEnd = true;
                            startIndexCol = startIndexCol + 1;
                            break;
                        }

                        else if (field[startIndexRow, startIndexCol + 1] == 'c')
                        {
                            coalCount--;
                            field[startIndexRow, startIndexCol + 1] = '*';
                            startIndexCol = startIndexCol + 1;

                            if (coalCount == 0)
                            {
                                coalsCollected = true;
                                break;
                            }
                        }

                        else
                        {
                            startIndexCol = startIndexCol + 1;
                        }
                    }
                }

                else if (commandType == "down")
                {
                    if (startIndexRow + 1 < field.GetLength(0))
                    {
                        if (field[startIndexRow + 1, startIndexCol] == 'e')
                        {
                            reachedEnd = true;
                            startIndexRow = startIndexRow + 1;
                            break;
                        }

                        else if (field[startIndexRow + 1, startIndexCol] == 'c')
                        {
                            coalCount--;
                            field[startIndexRow + 1, startIndexCol] = '*';
                            startIndexRow = startIndexRow + 1;

                            if (coalCount == 0)
                            {
                                coalsCollected = true;
                                break;
                            }
                        }

                        else
                        {
                            startIndexRow = startIndexRow + 1;
                        }
                    }
                }

                else if (commandType == "left")
                {
                    if (startIndexCol - 1 >= 0)
                    {
                        if (field[startIndexRow, startIndexCol - 1] == 'e')
                        {
                            reachedEnd = true;
                            startIndexCol = startIndexCol - 1;
                            break;
                        }

                        else if (field[startIndexRow, startIndexCol - 1] == 'c')
                        {
                            coalCount--;
                            field[startIndexRow, startIndexCol - 1] = '*';
                            startIndexCol = startIndexCol - 1;

                            if (coalCount == 0)
                            {
                                coalsCollected = true;
                                break;
                            }
                        }
                        else
                        {
                            startIndexCol = startIndexCol - 1;
                        }
                    }
                }

                inc++;

                if (reachedEnd || coalsCollected) break;
            }

            if (reachedEnd)
            {
                Console.WriteLine($"Game over! ({startIndexRow}, {startIndexCol})");
            }

            if (coalsCollected)
            {
                Console.WriteLine($"You collected all coals! ({startIndexRow}, {startIndexCol})");
            }
            else if (!reachedEnd && !coalsCollected)
            {
                Console.WriteLine($"{coalCount} coals left. ({startIndexRow}, {startIndexCol})");
            }
        }
    }
}