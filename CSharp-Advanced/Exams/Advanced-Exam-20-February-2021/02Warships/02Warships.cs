using System;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[,] field = new string[size, size];

            string[] commands = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            int playerOneShips = 0;
            int playerTwoShips = 0;
            int totalShipsSunk = 0;

            for (int row = 0; row < size; row++) // input
            {
                string[] input = Console.ReadLine().Split();
                for (int col = 0; col < size; col++)
                {
                    string symbol = input[col];
                    field[row, col] = symbol;

                    if (symbol == "<") playerOneShips++;
                    else if (symbol == ">") playerTwoShips++;
                }
            }

            foreach (var cordinates in commands)
            {
                if (playerOneShips <= 0 || playerTwoShips <= 0)
                {
                    break;
                }

                string[] tokens = cordinates.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int rowCordinate = int.Parse(tokens[0]);
                int colCordinate = int.Parse(tokens[1]);

                if (CheckCordinates(rowCordinate, colCordinate, size))
                {
                    string symbol = field[rowCordinate, colCordinate];

                    if (symbol == "*") continue;

                    if (symbol == "<") // first
                    {
                        field[rowCordinate, colCordinate] = "X";
                        playerOneShips--;
                        totalShipsSunk++;
                    }
                    else if (symbol == ">") // second
                    {
                        field[rowCordinate, colCordinate] = "X";
                        playerTwoShips--;
                        totalShipsSunk++;
                    }
                    else if (symbol == "#")
                    {
                        // up, down, right, left, diagonals
                        field[rowCordinate, colCordinate] = "X";
                        if (CheckCordinates(rowCordinate - 1, colCordinate, size)) // up
                        {
                            if (field[rowCordinate - 1, colCordinate] == "<")
                            {
                                playerOneShips--;
                                totalShipsSunk++;
                            }
                            else if (field[rowCordinate - 1, colCordinate] == ">")
                            {
                                playerTwoShips--;
                                totalShipsSunk++;
                            }
                            field[rowCordinate - 1, colCordinate] = "X";
                        }
                        if (CheckCordinates(rowCordinate + 1, colCordinate, size)) // down
                        {
                            if (field[rowCordinate + 1, colCordinate] == "<")
                            {
                                playerOneShips--;
                                totalShipsSunk++;
                            }
                            else if (field[rowCordinate + 1, colCordinate] == ">")
                            {
                                playerTwoShips--;
                                totalShipsSunk++;
                            }
                            field[rowCordinate + 1, colCordinate] = "X";
                        }
                        if (CheckCordinates(rowCordinate, colCordinate + 1, size)) // right
                        {
                            if (field[rowCordinate, colCordinate + 1] == "<")
                            {
                                playerOneShips--;
                                totalShipsSunk++;
                            }
                            else if (field[rowCordinate, colCordinate + 1] == ">")
                            {
                                playerTwoShips--;
                                totalShipsSunk++;
                            }
                            field[rowCordinate, colCordinate + 1] = "X";
                        }
                        if (CheckCordinates(rowCordinate, colCordinate - 1, size)) // left
                        {
                            if (field[rowCordinate, colCordinate - 1] == "<")
                            {
                                playerOneShips--;
                                totalShipsSunk++;
                            }
                            else if (field[rowCordinate, colCordinate - 1] == ">")
                            {
                                playerTwoShips--;
                                totalShipsSunk++;
                            }
                            field[rowCordinate, colCordinate - 1] = "X";
                        }
                        if (CheckCordinates(rowCordinate - 1, colCordinate - 1, size)) // left diagonal up
                        {
                            if (field[rowCordinate - 1, colCordinate - 1] == "<")
                            {
                                playerOneShips--;
                                totalShipsSunk++;
                            }
                            else if (field[rowCordinate - 1, colCordinate - 1] == ">")
                            {
                                playerTwoShips--;
                                totalShipsSunk++;
                            }
                            field[rowCordinate - 1, colCordinate - 1] = "X";
                        }
                        if (CheckCordinates(rowCordinate + 1, colCordinate - 1, size)) // left diagonal down
                        {
                            if (field[rowCordinate + 1, colCordinate - 1] == "<")
                            {
                                playerOneShips--;
                                totalShipsSunk++;
                            }
                            else if (field[rowCordinate + 1, colCordinate - 1] == ">")
                            {
                                playerTwoShips--;
                                totalShipsSunk++;
                            }
                            field[rowCordinate + 1, colCordinate - 1] = "X";
                        }
                        if (CheckCordinates(rowCordinate - 1, colCordinate + 1, size)) // right diagonal up
                        {
                            if (field[rowCordinate - 1, colCordinate + 1] == "<")
                            {
                                playerOneShips--;
                                totalShipsSunk++;
                            }
                            else if (field[rowCordinate - 1, colCordinate + 1] == ">")
                            {
                                playerTwoShips--;
                                totalShipsSunk++;
                            }
                            field[rowCordinate - 1, colCordinate + 1] = "X";
                        }
                        if (CheckCordinates(rowCordinate + 1, colCordinate + 1, size)) // right diagonal down
                        {
                            if (field[rowCordinate + 1, colCordinate + 1] == "<")
                            {
                                playerOneShips--;
                                totalShipsSunk++;
                            }
                            else if (field[rowCordinate + 1, colCordinate + 1] == ">")
                            {
                                playerTwoShips--;
                                totalShipsSunk++;
                            }
                            field[rowCordinate + 1, colCordinate + 1] = "X";
                        }
                    }
                }
            }
            if (playerOneShips <= 0) // player two won
            {
                Console.WriteLine($"Player Two has won the game! {totalShipsSunk} ships have been sunk in the battle.");
            }
            else if (playerTwoShips <= 0)
            {
                Console.WriteLine($"Player One has won the game! {totalShipsSunk} ships have been sunk in the battle.");
            }
            else // draw
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }
        }

        public static bool CheckCordinates(int rowCordinate, int colCordinate, int size)
        {
            return rowCordinate >= 0 && rowCordinate < size &&
                colCordinate >= 0 && colCordinate < size;
        }
    }
}