using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            int clients = int.Parse(Console.ReadLine());
            int countBasket = 0;
            int countWreath = 0;
            int countChocolate = 0;
            int wholeCount = 0;

            double price = 0;
            double sum = 0;
            double generalSum = 0;

            for (int i = 1; i <= clients; i++)
            {
                string items = Console.ReadLine();

                while (items != "Finish")
                {

                    if (items == "basket")
                    {
                        price = 1.50;
                        countBasket++;
                    }

                    else if (items == "wreath")
                    {
                        price = 3.80;
                        countWreath++;
                    }

                    else if (items == "chocolate bunny")
                    {
                        price = 7;
                        countChocolate++;
                    }

                    sum += price;
                    wholeCount++;

                    items = Console.ReadLine();
                }
                if (wholeCount % 2 == 0)
                {
                    sum *= 0.8;
                }

                Console.WriteLine($"You purchased {wholeCount} items for {sum:f2} leva.");
                wholeCount = 0;
                generalSum += sum;
                sum = 0;

            }

            double averageSum = generalSum / clients;

            Console.WriteLine($"Average bill per client is: {averageSum:f2} leva.");
        }
    }
}
