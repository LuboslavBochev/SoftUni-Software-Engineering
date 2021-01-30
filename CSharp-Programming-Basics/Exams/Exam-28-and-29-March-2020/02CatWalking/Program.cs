using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {

            int minutesWalking = int.Parse(Console.ReadLine());
            int cWalking = int.Parse(Console.ReadLine());
            int calories = int.Parse(Console.ReadLine());

            int amountMin = minutesWalking * cWalking;

            int amountCal = amountMin * 5;

            if (amountCal >= calories / 2)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {amountCal}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {amountCal}.");
            }
        }
    }
}
