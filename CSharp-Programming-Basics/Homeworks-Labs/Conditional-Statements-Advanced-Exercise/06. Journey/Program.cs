using System;

namespace morecomplicatedstatements
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double total = 0.0;
            string destination = "";
            string restPlace = "";
            switch (season)
            {
                case "summer":

                    if (budget <= 100)
                    {
                        destination = "Bulgaria";
                        restPlace = "Camp";
                        total = budget * 0.7; // left sum budget - total;
                    }
                    else if (budget <= 1000)
                    {
                        destination = "Balkans";
                        restPlace = "Camp";
                        total = budget * 0.6;
                    }
                    else if (budget > 1000)
                    {
                        destination = "Europe";
                        restPlace = "Hotel";
                        total = budget * 0.1;
                    }
                    Console.WriteLine($"Somewhere in {destination}");
                    Console.WriteLine($"{restPlace} - {Math.Abs(total - budget):f2}");
                    break;

                case "winter":

                    if (budget <= 100)
                    {
                        destination = "Bulgaria";
                        restPlace = "Hotel";
                        total = budget * 0.3;
                    }
                    else if (budget <= 1000)
                    {
                        destination = "Balkans";
                        restPlace = "Hotel";
                        total = budget * 0.2;
                    }
                    else if (budget > 1000)
                    {
                        destination = "Europe";
                        restPlace = "Hotel";
                        total = budget * 0.1;
                    }
                    Console.WriteLine($"Somewhere in {destination}");
                    Console.WriteLine($"{restPlace} - {Math.Abs(total - budget):f2}");
                    break;

                default:
                    break;
            }
        }

    }
}
