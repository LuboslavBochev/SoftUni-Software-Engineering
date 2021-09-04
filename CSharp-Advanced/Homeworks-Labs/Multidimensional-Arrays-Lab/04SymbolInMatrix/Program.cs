using System;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            for (int row = 0; row < n; row++) // input
            {
                char[] inputRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputRow[col].ToString();
                }
            }

            string sign = Console.ReadLine();
            string location = string.Empty;

            bool isThere = false;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    string currentChar = matrix[row, col];

                    if (currentChar == sign)
                    {
                        location = $"({row}, {col})";
                        Console.WriteLine(location);
                        isThere = true;
                        break;
                    }
                }
                if (isThere) break;
            }

            if (!isThere)
            {
                Console.WriteLine($"{sign} does not occur in the matrix");
            }
        }
    }
}