using System;

namespace _06._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statistibr = int.Parse(Console.ReadLine());
            double priceObleklostatist = double.Parse(Console.ReadLine());

            if (statistibr > 150)
            {
                priceObleklostatist = priceObleklostatist - (priceObleklostatist * 0.1);
            }
            double sumdekor = budget * 0.1;
            double sumobleklo = statistibr * priceObleklostatist;
            double finalsum = sumdekor + sumobleklo;

            if (finalsum > budget)
            {
                double leftsum = finalsum - budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {leftsum:f2} leva more.");
            }
            else
            {
                double leftsum = budget - finalsum;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {leftsum:f2} leva left.");
            }
        }
    }
}
