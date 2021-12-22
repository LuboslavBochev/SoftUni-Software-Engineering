using System;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] beach = new string[rows][];

            beach = FillTheBeach(beach);

            int collectedTokens = 0;
            int opponentTokens = 0;

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "Gong") break;

                int rowIndex = int.Parse(commands[1]);
                int colIndex = int.Parse(commands[2]);

                switch (command)
                {
                    case "Find":

                        if (isValid(beach, rowIndex, colIndex))
                        {
                            if (beach[rowIndex][colIndex] == "T")
                            {
                                collectedTokens++;
                                beach[rowIndex][colIndex] = "-";
                            }
                        }

                        break;

                    case "Opponent":

                        if (isValid(beach, rowIndex, colIndex))
                        {
                            string direction = commands[3];

                            switch (direction)
                            {
                                case "up":

                                    for (int i = 0; i <= 3; i++)
                                    {
                                        if (isValid(beach, rowIndex - i, colIndex))
                                        {
                                            if (beach[rowIndex - i][colIndex] == "T")
                                            {
                                                opponentTokens++;
                                                beach[rowIndex - i][colIndex] = "-";
                                            }
                                        }
                                        else break;
                                    }

                                    break;

                                case "down":

                                    for (int i = 0; i <= 3; i++)
                                    {
                                        if (isValid(beach, rowIndex + i, colIndex))
                                        {
                                            if (beach[rowIndex + i][colIndex] == "T")
                                            {
                                                opponentTokens++;
                                                beach[rowIndex + i][colIndex] = "-";
                                            }
                                        }
                                        else break;
                                    }

                                    break;

                                case "right":

                                    for (int i = 0; i <= 3; i++)
                                    {
                                        if (isValid(beach, rowIndex, colIndex + i))
                                        {
                                            if (beach[rowIndex][colIndex + i] == "T")
                                            {
                                                opponentTokens++;
                                                beach[rowIndex][colIndex + i] = "-";
                                            }
                                        }
                                        else break;
                                    }

                                    break;

                                case "left":

                                    for (int i = 0; i <= 3; i++)
                                    {
                                        if (isValid(beach, rowIndex, colIndex - i))
                                        {
                                            if (beach[rowIndex][colIndex - i] == "T")
                                            {
                                                opponentTokens++;
                                                beach[rowIndex][colIndex - i] = "-";
                                            }
                                        }
                                        else break;
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }

            Print(x => Console.WriteLine(string.Join(" ", x)), beach);
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        public static bool isValid(string[][] beach, int rowIndex, int colIndex)
        {
            if (rowIndex < 0 || rowIndex >= beach.Length || colIndex < 0 || colIndex >= beach[rowIndex].Length)
            {
                return false;
            }

            return true;
        }

        public static string[][] FillTheBeach(string[][] beach)
        {
            for (int row = 0; row < beach.Length; row++)
            {
                string[] inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                beach[row] = new string[inputRow.Length];

                for (int col = 0; col < beach[row].Length; col++)
                {
                    beach[row][col] = inputRow[col].ToString();
                }
            }
            return beach;
        }

        public static void Print(Action<string[]> print, string[][] beach)
        {
            foreach (var item in beach)
            {
                print(item);
            }
        }
    }
}