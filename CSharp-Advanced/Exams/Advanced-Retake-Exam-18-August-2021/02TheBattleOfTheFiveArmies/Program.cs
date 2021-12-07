using System;

namespace Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int row = int.Parse(Console.ReadLine());

            string[][] map = new string[row][];

            int rowPlayerIndex = 0;
            int colPlayerIndex = 0;

            for (int rows = 0; rows < map.GetLength(0); rows++) // filling map
            {
                string elements = Console.ReadLine();
                map[rows] = new string[elements.Length];

                for (int col = 0; col < elements.Length; col++)
                {
                    if (elements[col] == 'A')
                    {
                        rowPlayerIndex = rows;
                        colPlayerIndex = col;
                    }
                    map[rows][col] = elements[col].ToString();
                }
            }

            bool reachedThrone = false;
            bool isDied = false;

            while (armor > 0 && !reachedThrone && !isDied) // commands
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int orcRowIndex = int.Parse(command[1]);
                int orcColIndex = int.Parse(command[2]);

                map[orcRowIndex][orcColIndex] = "O";

                switch (command[0])
                {
                    case "up":

                        if (isSave(rowPlayerIndex - 1, colPlayerIndex, map))
                        {
                            rowPlayerIndex--;
                            armor--;

                            if (map[rowPlayerIndex][colPlayerIndex] == "O")
                            {
                                armor -= 2;
                            }

                            if (map[rowPlayerIndex][colPlayerIndex] == "M")
                            {
                                map[rowPlayerIndex][colPlayerIndex] = "-";
                                map[rowPlayerIndex + 1][colPlayerIndex] = "-";
                                reachedThrone = true;
                                break;
                            }

                            if (armor <= 0)
                            {
                                map[rowPlayerIndex][colPlayerIndex] = "X";
                                map[rowPlayerIndex + 1][colPlayerIndex] = "-";

                                isDied = true;
                                break;
                            }

                            map[rowPlayerIndex][colPlayerIndex] = "A";
                            map[rowPlayerIndex + 1][colPlayerIndex] = "-";
                        }
                        else
                        {
                            armor--;
                        }

                        break;

                    case "down":

                        if (isSave(rowPlayerIndex + 1, colPlayerIndex, map))
                        {
                            rowPlayerIndex++;
                            armor--;

                            if (map[rowPlayerIndex][colPlayerIndex] == "O")
                            {
                                armor -= 2;
                            }

                            if (map[rowPlayerIndex][colPlayerIndex] == "M")
                            {
                                map[rowPlayerIndex][colPlayerIndex] = "-";
                                map[rowPlayerIndex - 1][colPlayerIndex] = "-";
                                reachedThrone = true;
                                break;
                            }

                            if (armor <= 0)
                            {
                                map[rowPlayerIndex][colPlayerIndex] = "X";
                                map[rowPlayerIndex - 1][colPlayerIndex] = "-";

                                isDied = true;
                                break;
                            }

                            map[rowPlayerIndex][colPlayerIndex] = "A";
                            map[rowPlayerIndex - 1][colPlayerIndex] = "-";
                        }

                        else
                        {
                            armor--;
                        }
                        break;

                    case "left":

                        if (isSave(rowPlayerIndex, colPlayerIndex - 1, map))
                        {
                            colPlayerIndex--;
                            armor--;

                            if (map[rowPlayerIndex][colPlayerIndex] == "O")
                            {
                                armor -= 2;
                            }

                            if (map[rowPlayerIndex][colPlayerIndex] == "M")
                            {
                                map[rowPlayerIndex][colPlayerIndex] = "-";
                                map[rowPlayerIndex][colPlayerIndex + 1] = "-";
                                reachedThrone = true;
                                break;
                            }

                            if (armor <= 0)
                            {
                                map[rowPlayerIndex][colPlayerIndex] = "X";
                                map[rowPlayerIndex][colPlayerIndex + 1] = "-";

                                isDied = true;
                                break;
                            }

                            map[rowPlayerIndex][colPlayerIndex] = "A";
                            map[rowPlayerIndex][colPlayerIndex + 1] = "-";
                        }

                        else
                        {
                            armor--;
                        }
                        break;

                    case "right":

                        if (isSave(rowPlayerIndex, colPlayerIndex + 1, map))
                        {
                            colPlayerIndex++;
                            armor--;

                            if (map[rowPlayerIndex][colPlayerIndex] == "O")
                            {
                                armor -= 2;
                            }

                            if (map[rowPlayerIndex][colPlayerIndex] == "M")
                            {
                                map[rowPlayerIndex][colPlayerIndex] = "-";
                                map[rowPlayerIndex][colPlayerIndex - 1] = "-";
                                reachedThrone = true;
                                break;
                            }

                            if (armor <= 0)
                            {
                                map[rowPlayerIndex][colPlayerIndex] = "X";
                                map[rowPlayerIndex][colPlayerIndex - 1] = "-";

                                isDied = true;
                                break;
                            }

                            map[rowPlayerIndex][colPlayerIndex] = "A";
                            map[rowPlayerIndex][colPlayerIndex - 1] = "-";
                        }

                        else
                        {
                            armor--;
                        }
                        break;
                }
            }

            if (isDied)
            {
                Console.WriteLine($"The army was defeated at {rowPlayerIndex};{colPlayerIndex}.");
            }
            if (reachedThrone)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
            }

            Print(map);
        }
        public static bool isSave(int rowPlayerIndex, int colPlayerIndex, string[][] map)
        {
            int size = map.GetLength(0);

            if (rowPlayerIndex >= size || rowPlayerIndex < 0 || colPlayerIndex >= size || colPlayerIndex < 0)
            {
                return false;
            }

            return true;
        }

        public static void Print(string[][] map)
        {
            for (int row = 0; row < map.Length; row++)
            {
                for (int col = 0; col < map[row].Length; col++)
                {
                    Console.Write(map[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}