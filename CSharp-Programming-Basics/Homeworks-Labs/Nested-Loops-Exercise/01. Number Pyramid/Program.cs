using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 1;
            bool end = false;

            for (int rows = 1; rows <= n; rows++)
            {
                for (int col = 1; col <= rows; col++)
                {
                    if (num > n)
                    {
                        end = true;
                        break;
                    }
                    Console.Write(num + " ");
                    num++;
                }
                if (end)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}