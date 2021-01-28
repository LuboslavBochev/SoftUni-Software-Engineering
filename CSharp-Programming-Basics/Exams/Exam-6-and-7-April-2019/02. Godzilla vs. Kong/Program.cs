using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double priceStatist = double.Parse(Console.ReadLine());

            double dekor = budget * 0.1;

            if (statists > 150)
            {
                priceStatist = priceStatist - (priceStatist * 0.1);
            }

            double sumDressing = statists * priceStatist;

            double amount = dekor + sumDressing;

            if (budget >= amount)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - amount:f2} leva left.");
            }

            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {amount - budget:f2} leva more.");
            }
        }
    }
}
