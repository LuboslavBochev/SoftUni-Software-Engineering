using System;

namespace _06._Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogsnum = int.Parse(Console.ReadLine());
            int othernum = int.Parse(Console.ReadLine());

            double sum = (dogsnum * 2.5) + (othernum * 4);
            Console.WriteLine($"{sum:f2} lv.");
        }
    }
}
