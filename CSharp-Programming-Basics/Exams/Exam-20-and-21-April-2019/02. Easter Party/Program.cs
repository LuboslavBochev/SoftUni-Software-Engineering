using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            int cGuests = int.Parse(Console.ReadLine());
            double priceCover = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());


            if (cGuests >= 10 && cGuests <= 15)
            {
                priceCover = priceCover - (priceCover * 0.15);
            }

            else if (cGuests > 15 && cGuests <= 20)
            {
                priceCover = priceCover - (priceCover * 0.2);
            }

            else if (cGuests > 20)
            {
                priceCover = priceCover - (priceCover * 0.25);
            }

            double priceCake = budget * 0.1;

            double wholeSum = priceCake + (priceCover * cGuests);

            if (wholeSum > budget)
            {
                Console.WriteLine($"No party! {wholeSum - budget:f2} leva needed.");
            }

            else
            {
                Console.WriteLine($"It is party time! {budget - wholeSum:f2} leva left.");
            }

        }
    }
}
