using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            // input : int bitCoin, double cChina, double commision
            // double total

            int bitCoint = int.Parse(Console.ReadLine());
            double cChina = double.Parse(Console.ReadLine());
            double commision = double.Parse(Console.ReadLine());

            double total = 0;
            double dis = 0;

            double chinayoan = (cChina * 0.15) * 1.76;

            total = ((bitCoint * 1168 + chinayoan) / 1.95);

            dis = total / 100 * commision;

            total = total - dis;

            Console.WriteLine($"{total:f2}");
        }
    }
}
