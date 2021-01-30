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
            int p4 = 0;
            int p5 = 0;


            for (int i = 1; i <= n; i++)
            {
                int nums = int.Parse(Console.ReadLine());

                if (nums < 200)
                {
                    p1++;
                }
                else if (nums >= 200 && nums <= 399)
                {
                    p2++;
                }
                else if (nums >= 400 && nums <= 599)
                {
                    p3++;
                }
                else if (nums >= 600 && nums <= 799)
                {
                    p4++;
                }
                else if (nums >= 800)
                {
                    p5++;
                }

            }

            double prP1 = (1.00 * p1 / n) * 100;
            double prP2 = (1.00 * p2 / n) * 100;
            double prP3 = (1.00 * p3 / n) * 100;
            double prP4 = (1.00 * p4 / n) * 100;
            double prP5 = (1.00 * p5 / n) * 100;

            Console.WriteLine($"{prP1:f2}%");
            Console.WriteLine($"{prP2:f2}%");
            Console.WriteLine($"{prP3:f2}%");
            Console.WriteLine($"{prP4:f2}%");
            Console.WriteLine($"{prP5:f2}%");
        }
    }
}