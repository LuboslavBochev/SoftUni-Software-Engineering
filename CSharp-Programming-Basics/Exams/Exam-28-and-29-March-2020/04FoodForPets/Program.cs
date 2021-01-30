using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1:01 min ot predi


            int cDays = int.Parse(Console.ReadLine());
            double quantity = double.Parse(Console.ReadLine());

            double qDogs = 0;
            double qCats = 0;

            double sumConsumed = 0;
            double sumCDog = 0;
            double sumCC = 0;
            double biscuits = 0;
            int counter = 0;

            for (int i = 1; i <= cDays; i++)
            {
                qDogs = int.Parse(Console.ReadLine());
                qCats = int.Parse(Console.ReadLine());
                counter++;
                if (counter % 3 == 0)
                {
                    biscuits += ((double)(qDogs + qCats) / 10);
                }

                sumConsumed += ((double)qDogs + qCats);
                sumCDog += (double)qDogs;
                sumCC += (double)qCats;
            }
            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuits, 0)}gr.");
            Console.WriteLine($"{(sumConsumed / quantity) * 100:f2}% of the food has been eaten.");
            Console.WriteLine($"{(sumCDog / sumConsumed) * 100:f2}% eaten from the dog.");
            Console.WriteLine($"{(sumCC / sumConsumed) * 100:f2}% eaten from the cat.");
        }
    }
}
