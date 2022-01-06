using System;

namespace Selling
{
    class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] bakery = new char[size, size];

            int collectedMoney = 0;

            int rowS = 0;
            int colS = 0;

            bool firstPillar = true;

            int rowFirstPillar = 0;
            int colFirstPillar = 0;

            int rowSecondPillar = 0;
            int colSecondPillar = 0;

            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    char symbol = input[col];
                    if (symbol == 'S')
                    {
                        rowS = row;
                        colS = col;
                    }
                    if (symbol == 'O' && firstPillar)
                    {
                        rowFirstPillar = row;
                        colFirstPillar = col;
                        firstPillar = false;
                    }
                    else if (symbol == 'O' && !firstPillar)
                    {
                        rowSecondPillar = row;
                        colSecondPillar = col;
                    }

                    bakery[row, col] = symbol;
                }
            }

            bool outOfBakery = false;

            while (true)
            {
                if (collectedMoney >= 50) break;

                string command = Console.ReadLine();

                if (command == "up" && CheckIndexes(rowS - 1, colS, bakery))
                {
                    // to coin
                    bakery[rowS, colS] = '-'; // previous

                    if (char.IsDigit(bakery[rowS - 1, colS]))
                    {
                        int amount = bakery[rowS - 1, colS] - 48;
                        collectedMoney += amount;

                        rowS--; // updating
                    }
                    // to pillar
                    else if (bakery[rowS - 1, colS] == 'O')
                    {
                        bakery[rowS - 1, colS] = '-'; // position of the pillar

                        if (rowS - 1 == rowFirstPillar && colS == colFirstPillar) // firstPillar
                        {
                            rowS = rowSecondPillar; // updating
                            colS = colSecondPillar;
                        }
                        else // second
                        {
                            rowS = rowFirstPillar;
                            colS = colFirstPillar;
                        }
                    }
                    else // just move
                    {
                        rowS--;
                    }
                    bakery[rowS, colS] = 'S';
                }
                else if (command == "down" && CheckIndexes(rowS + 1, colS, bakery))
                {
                    bakery[rowS, colS] = '-';

                    if (char.IsDigit(bakery[rowS + 1, colS]))
                    {
                        int amount = bakery[rowS + 1, colS] - 48;
                        collectedMoney += amount;

                        rowS++;
                    }

                    else if (bakery[rowS + 1, colS] == 'O')
                    {
                        bakery[rowS + 1, colS] = '-';

                        if (rowS + 1 == rowFirstPillar && colS == colFirstPillar)
                        {
                            rowS = rowSecondPillar;
                            colS = colSecondPillar;
                        }
                        else
                        {
                            rowS = rowFirstPillar;
                            colS = colFirstPillar;
                        }
                    }
                    else
                    {
                        rowS++;
                    }
                    bakery[rowS, colS] = 'S';
                }
                else if (command == "right" && CheckIndexes(rowS, colS + 1, bakery))
                {
                    bakery[rowS, colS] = '-';

                    if (char.IsDigit(bakery[rowS, colS + 1]))
                    {
                        int amount = bakery[rowS, colS + 1] - 48;
                        collectedMoney += amount;

                        colS++;
                    }
                    // to pillar
                    else if (bakery[rowS, colS + 1] == 'O')
                    {
                        bakery[rowS, colS + 1] = '-';

                        if (rowS == rowFirstPillar && colS + 1 == colFirstPillar)
                        {
                            rowS = rowSecondPillar;
                            colS = colSecondPillar;
                        }
                        else
                        {
                            rowS = rowFirstPillar;
                            colS = colFirstPillar;
                        }
                    }
                    else
                    {
                        colS++;
                    }
                    bakery[rowS, colS] = 'S';
                }
                else if (command == "left" && CheckIndexes(rowS, colS - 1, bakery))
                {
                    bakery[rowS, colS] = '-';

                    if (char.IsDigit(bakery[rowS, colS - 1]))
                    {
                        int amount = bakery[rowS, colS - 1] - 48;
                        collectedMoney += amount;

                        colS--;
                    }

                    else if (bakery[rowS, colS - 1] == 'O')
                    {
                        bakery[rowS, colS - 1] = '-';

                        if (rowS == rowFirstPillar && colS - 1 == colFirstPillar)
                        {
                            rowS = rowSecondPillar;
                            colS = colSecondPillar;
                        }
                        else
                        {
                            rowS = rowFirstPillar;
                            colS = colFirstPillar;
                        }
                    }
                    else
                    {
                        colS--;
                    }
                    bakery[rowS, colS] = 'S';
                }
                else // out of bakery
                {
                    outOfBakery = true;
                    bakery[rowS, colS] = '-';
                    break;
                }
            }

            if (outOfBakery)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {collectedMoney}");
            Print(bakery);
        }

        private static void Print(char[,] bakery)
        {
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    Console.Write(bakery[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool CheckIndexes(int rowS, int colS, char[,] bakery)
        {
            return rowS >= 0 && rowS < bakery.GetLength(0) && colS >= 0 && colS < bakery.GetLength(1);
        }
    }
}