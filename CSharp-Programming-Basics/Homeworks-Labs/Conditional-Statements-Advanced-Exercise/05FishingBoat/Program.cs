using System;

namespace morecomplicatedstatements
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishers = int.Parse(Console.ReadLine());
            double rentship = 0.0;
            double total = 0.0;
            switch (season)
            {
                case "Spring":
                    rentship = 3000;

                    if (fishers <= 6)
                    {
                        total = rentship * 0.9;

                    }
                    else if (fishers > 6 && fishers <= 11)
                    {
                        total = rentship * 0.85;
                    }
                    else if (fishers >= 12)
                    {
                        total = rentship * 0.75;
                    }
                    if (fishers % 2 == 0)
                    {
                        total *= 0.95;
                    }
                    break;

                case "Summer":
                    rentship = 4200;

                    if (fishers <= 6)
                    {
                        total = rentship * 0.9;

                    }
                    else if (fishers > 6 && fishers <= 11)
                    {
                        total = rentship * 0.85;
                    }
                    else if (fishers >= 12)
                    {
                        total = rentship * 0.75;
                    }
                    if (fishers % 2 == 0)
                    {
                        total *= 0.95;
                    }
                    break;

                case "Autumn":
                    rentship = 4200;

                    if (fishers <= 6)
                    {
                        total = rentship * 0.9;

                    }
                    else if (fishers > 6 && fishers <= 11)
                    {
                        total = rentship * 0.85;
                    }
                    else if (fishers >= 12)
                    {
                        total = rentship * 0.75;
                    }
                    break;
                case "Winter":
                    rentship = 2600;

                    if (fishers <= 6)
                    {
                        total = rentship * 0.9;

                    }
                    else if (fishers > 6 && fishers <= 11)
                    {
                        total = rentship * 0.85;
                    }
                    else if (fishers >= 12)
                    {
                        total = rentship * 0.75;
                    }
                    if (fishers % 2 == 0)
                    {
                        total *= 0.95;
                    }
                    break;


                default:
                    break;
            }
            if (budget >= total)
            {
                Console.WriteLine($"Yes! You have {budget - total:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {total - budget:f2} leva.");
            }
        }

    }
}
