using System;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] board = new char[n, n];

            for (int row = 0; row < n; row++) // board filling
            {
                string rows = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    board[row, col] = rows[col];
                }
            }

            // checking
            int numRemovedKnights = 0;
            while (true)
            {
                int maxKnights = int.MinValue;
                int maxRow = int.MinValue;
                int maxCol = int.MinValue;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        int numberAttackKnights = 0;

                        if (board[row, col] == 'K')
                        {
                            numberAttackKnights = CheckInFront(board, row, col, numberAttackKnights);
                            numberAttackKnights = CheckBehind(board, row, col, numberAttackKnights);
                            numberAttackKnights = CheckOnLeft(board, row, col, numberAttackKnights);
                            numberAttackKnights = CheckOnRight(board, row, col, numberAttackKnights);
                        }

                        if (numberAttackKnights > maxKnights)
                        {
                            maxKnights = numberAttackKnights;
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }
                if (maxKnights > 0)
                {
                    board[maxRow, maxCol] = '0';
                    numRemovedKnights++;
                }

                else if (maxKnights == 0)
                {
                    break;
                }
            }
            Console.WriteLine(numRemovedKnights);
        }

        static int CheckOnRight(char[,] board, int row, int col, int numberAttackKnights)
        {
            if (row + 1 < board.GetLength(0) && col + 2 < board.GetLength(1))
            {
                if (board[row + 1, col + 2] == 'K') // on right 
                {
                    numberAttackKnights++;
                }
            }

            if (row - 1 >= 0 && col + 2 < board.GetLength(1))
            {
                if (board[row - 1, col + 2] == 'K')
                {
                    numberAttackKnights++;
                }
            }

            return numberAttackKnights;
        }

        static int CheckOnLeft(char[,] board, int row, int col, int numberAttackKnights)
        {
            if (row + 1 < board.GetLength(0) && col - 2 >= 0)
            {
                if (board[row + 1, col - 2] == 'K') // on left 
                {
                    numberAttackKnights++;
                }
            }

            if (row - 1 >= 0 && col - 2 >= 0)
            {
                if (board[row - 1, col - 2] == 'K')
                {
                    numberAttackKnights++;
                }
            }

            return numberAttackKnights;
        }

        static int CheckBehind(char[,] board, int row, int col, int numberAttackKnights)
        {
            if (row + 2 < board.GetLength(0) && col + 1 < board.GetLength(1))
            {
                if (board[row + 2, col + 1] == 'K') // behind
                {
                    numberAttackKnights++;
                }
            }

            if (row + 2 < board.GetLength(0) && col - 1 >= 0)
            {
                if (board[row + 2, col - 1] == 'K')
                {
                    numberAttackKnights++;
                }
            }
            return numberAttackKnights;
        }

        static int CheckInFront(char[,] board, int row, int col, int numberAttackKnights)
        {
            if (row - 2 >= 0 && col + 1 < board.GetLength(1))
            {
                if (board[row - 2, col + 1] == 'K')
                {
                    numberAttackKnights++;
                }
            }

            if (row - 2 >= 0 && col - 1 >= 0)
            {
                if (board[row - 2, col - 1] == 'K')
                {
                    numberAttackKnights++;
                }
            }

            return numberAttackKnights;
        }
    }
}