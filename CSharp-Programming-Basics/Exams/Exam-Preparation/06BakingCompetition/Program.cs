using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            int partisipants = int.Parse(Console.ReadLine());
            int allBaked = 0;

            int cookies = 0;
            int cakes = 0;
            int waffles = 0;

            double price = 0;
            double totalSum = 0;


            for (int i = 1; i <= partisipants; i++)
            {
                cakes = 0;
                cookies = 0;
                waffles = 0;

                string name = Console.ReadLine();
                string typeCandy = Console.ReadLine();

                while (typeCandy != "Stop baking!")
                {
                    int coutMeal = int.Parse(Console.ReadLine());

                    if (typeCandy == "cookies")
                    {
                        price = 1.50;
                        cookies += coutMeal;
                    }

                    else if (typeCandy == "cakes")
                    {
                        price = 7.80;
                        cakes += coutMeal;
                    }

                    else if (typeCandy == "waffles")
                    {
                        price = 2.30;
                        waffles += coutMeal;
                    }

                    totalSum += coutMeal * price;
                    allBaked += coutMeal;
                    typeCandy = Console.ReadLine();
                }
                Console.WriteLine($"{name} baked {cookies} cookies, {cakes} cakes and {waffles} waffles.");
            }
            Console.WriteLine($"All bakery sold: {allBaked}");
            Console.WriteLine($"Total sum for charity: {totalSum:f2} lv.");
        }
    }
}
