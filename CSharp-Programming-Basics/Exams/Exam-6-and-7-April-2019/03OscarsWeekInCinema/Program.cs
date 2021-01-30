using System;

namespace Oscars_Week_In_Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string hallType = Console.ReadLine();
            int ticketsSold = int.Parse(Console.ReadLine());

            double ticketPrice = 0;

            if (movie == "A Star Is Born")
            {
                if (hallType == "normal")
                {
                    ticketPrice = 7.50;
                }
                else if (hallType == "luxury")
                {
                    ticketPrice = 10.50;
                }
                else if (hallType == "ultra luxury")
                {
                    ticketPrice = 13.50;
                }
            }
            if (movie == "Bohemian Rhapsody")
            {
                if (hallType == "normal")
                {
                    ticketPrice = 7.35;
                }
                else if (hallType == "luxury")
                {
                    ticketPrice = 9.45;
                }
                else if (hallType == "ultra luxury")
                {
                    ticketPrice = 12.75;
                }
            }
            if (movie == "Green Book")
            {
                if (hallType == "normal")
                {
                    ticketPrice = 8.15;
                }
                else if (hallType == "luxury")
                {
                    ticketPrice = 10.25;
                }
                else if (hallType == "ultra luxury")
                {
                    ticketPrice = 13.25;
                }
            }
            if (movie == "The Favourite")
            {
                if (hallType == "normal")
                {
                    ticketPrice = 8.75;
                }
                else if (hallType == "luxury")
                {
                    ticketPrice = 11.55;
                }
                else if (hallType == "ultra luxury")
                {
                    ticketPrice = 13.95;
                }
            }

            double moneyMade = ticketsSold * ticketPrice;
            Console.WriteLine($"{movie} -> {moneyMade:f2} lv.");
        }
    }
}