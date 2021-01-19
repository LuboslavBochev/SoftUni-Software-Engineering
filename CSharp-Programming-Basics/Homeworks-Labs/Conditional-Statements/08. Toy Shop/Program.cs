using System;

namespace _08._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            // input variables
            double holidayprice = double.Parse(Console.ReadLine());
            int puzzlesbr = int.Parse(Console.ReadLine());
            int dollsbr = int.Parse(Console.ReadLine());
            int bearsbr = int.Parse(Console.ReadLine());
            int minionsbr = int.Parse(Console.ReadLine());
            int trucksbr = int.Parse(Console.ReadLine());


            double sum = (puzzlesbr * 2.6) + (dollsbr * 3) + (bearsbr * 4.10) + (minionsbr * 8.20) + (trucksbr * 2);
            int brtoys = puzzlesbr + dollsbr + bearsbr + minionsbr + trucksbr;

            if (brtoys >= 50)
            {
                double afterdiscount = sum - (sum * 0.25);
                double result = afterdiscount - (afterdiscount * 0.10);

                if (result >= holidayprice)
                {
                    double holyday = result - holidayprice;
                    Console.WriteLine($"Yes! {Math.Abs(holyday):f2} lv left.");
                }
                else
                {
                    double holyday = result - holidayprice;
                    Console.WriteLine($"Not enough money! {Math.Abs(holyday):f2} lv needed.");
                }
            }
            else if (brtoys < 50)
            {
                double amount = sum - (sum * 0.10);
                if (amount >= holidayprice)
                {
                    double holyday = amount - holidayprice;
                    Console.WriteLine($"Yes! {Math.Abs(holyday):f2} lv left.");
                }

                else
                {
                    double holyday = amount - holidayprice;
                    Console.WriteLine($"Not enough money! {Math.Abs(holyday):f2} lv needed.");
                }

            }
        }
    }
}
