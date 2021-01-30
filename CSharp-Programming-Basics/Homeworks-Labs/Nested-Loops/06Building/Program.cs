using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            int floor = int.Parse(Console.ReadLine());
            int room = int.Parse(Console.ReadLine());
            string sign = "";

            for (int i = floor; i >= 1; i--)
            {
                for (int j = 0; j < room; j++)
                {
                    if (i == floor)
                    {
                        sign = "L";
                        Console.Write($"{sign}{i}{j}" + " ");
                    }
                    if (i % 2 == 0 && i != floor)
                    {
                        sign = "O";
                        Console.Write($"{sign}{i}{j}" + " ");
                    }
                    if (i % 2 != 0 && i != floor)
                    {
                        sign = "A";
                        Console.Write($"{sign}{i}{j}" + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}