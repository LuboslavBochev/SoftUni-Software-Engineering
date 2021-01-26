using System;

namespace examTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double priceForTrip = 0;

            switch (destination)
            {
                case "France":

                    if (dates == "21-23")
                    {
                        priceForTrip = 30;
                    }

                    else if (dates == "24-27")
                    {
                        priceForTrip = 35;
                    }

                    else if (dates == "28-31")
                    {
                        priceForTrip = 40;
                    }
                    break;

                case "Germany":

                    if (dates == "21-23")
                    {
                        priceForTrip = 32;
                    }

                    else if (dates == "24-27")
                    {
                        priceForTrip = 37;
                    }

                    else if (dates == "28-31")
                    {
                        priceForTrip = 43;
                    }
                    break;

                case "Italy":

                    if (dates == "21-23")
                    {
                        priceForTrip = 28;
                    }

                    else if (dates == "24-27")
                    {
                        priceForTrip = 32;
                    }

                    else if (dates == "28-31")
                    {
                        priceForTrip = 39;
                    }
                    break;
            }
            Console.WriteLine($"Easter trip to {destination} : {nights * priceForTrip:f2} leva.");
        }
    }
}
