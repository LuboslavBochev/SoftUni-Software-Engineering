using System;

namespace loops2
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;


            for (int i = 1; i <= n; i++)
            {
                int nums = int.Parse(Console.ReadLine());

                if (nums % 2 == 0)
                {
                    p1++;
                }
                if (nums % 3 == 0)
                {
                    p2++;
                }
                if (nums % 4 == 0)
                {
                    p3++;
                }

            }

            double prP1 = (1.00 * p1 / n) * 100;
            double prP2 = (1.00 * p2 / n) * 100;
            double prP3 = (1.00 * p3 / n) * 100;

            Console.WriteLine($"{prP1:f2}%");
            Console.WriteLine($"{prP2:f2}%");
            Console.WriteLine($"{prP3:f2}%");
        }
    }
}