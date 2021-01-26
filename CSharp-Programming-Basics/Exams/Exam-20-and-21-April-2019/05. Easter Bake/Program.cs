using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int countKozunaci = int.Parse(Console.ReadLine());
            int sumSugar = 0;
            int sumPowder = 0;
            int maxSugar = 0;
            int maxPowder = 0;

            for (int i = 1; i <= countKozunaci; i++)
            {
                int quantitySugar = int.Parse(Console.ReadLine());
                int quantityPowder = int.Parse(Console.ReadLine());

                sumSugar += quantitySugar;
                sumPowder += quantityPowder;

                if (quantitySugar > maxSugar)
                {
                    maxSugar = quantitySugar;
                }

                if (quantityPowder > maxPowder)
                {
                    maxPowder = quantityPowder;
                }
            }
            double packetsSugar = Math.Ceiling(1.0 * sumSugar / 950);
            double packetsPowder = Math.Ceiling(1.0 * sumPowder / 750);

            Console.WriteLine($"Sugar: {packetsSugar}");
            Console.WriteLine($"Flour: {packetsPowder}");
            Console.WriteLine($"Max used flour is {maxPowder} grams, max used sugar is {maxSugar} grams.");

        }
    }
}
