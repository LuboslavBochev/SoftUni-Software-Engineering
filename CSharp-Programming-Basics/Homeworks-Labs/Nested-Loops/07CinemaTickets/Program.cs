using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeTicket = "";
            int student = 0;
            int standard = 0;
            int kid = 0;
            int totalTickets = 0;
            int places = 0;
            int counter = 0;
            bool isFinish = false;

            while (true)
            {
                if (typeTicket == "Finish")
                {
                    isFinish = true;
                    break;
                }

                string movie = Console.ReadLine();

                if (movie == "Finish")
                {
                    isFinish = true;
                    break;
                }
                counter = 0;
                places = int.Parse(Console.ReadLine());
                int leftPlaces = places;

                while (true)
                {
                    if (leftPlaces == 0)
                    {
                        break;
                    }

                    typeTicket = Console.ReadLine();

                    if (typeTicket == "Finish" || typeTicket == "End")
                    {
                        break;
                    }

                    if (typeTicket == "standard")
                    {
                        standard++;
                        leftPlaces--;
                        counter++;
                    }
                    if (typeTicket == "student")
                    {
                        student++;
                        leftPlaces--;
                        counter++;
                    }
                    if (typeTicket == "kid")
                    {
                        kid++;
                        leftPlaces--;
                        counter++;
                    }
                }
                Console.WriteLine($"{movie} - { 1.0 * counter / places * 100:f2}% full.");
                totalTickets += counter;

            }

            if (isFinish)
            {
                Console.WriteLine($"Total tickets: {totalTickets}");
                Console.WriteLine($"{1.0 * student / totalTickets * 100:f2}% student tickets.");
                Console.WriteLine($"{1.0 * standard / totalTickets * 100:f2}% standard tickets.");
                Console.WriteLine($"{1.0 * kid / totalTickets * 100:f2}% kids tickets.");
            }
        }
    }
}