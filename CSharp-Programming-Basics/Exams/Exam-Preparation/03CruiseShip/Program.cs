using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            string cruise = Console.ReadLine();
            string type = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double price = 0;

            switch (cruise)
            {

                case "Mediterranean":

                    if (type == "standard cabin")
                    {
                        price = 27.50;
                    }

                    else if (type == "cabin with balcony")
                    {
                        price = 30.20;
                    }

                    else if (type == "apartment")
                    {
                        price = 40.50;
                    }

                    break;

                case "Adriatic":

                    if (type == "standard cabin")
                    {
                        price = 22.99;
                    }

                    else if (type == "cabin with balcony")
                    {
                        price = 25.00;
                    }

                    else if (type == "apartment")
                    {
                        price = 34.99;
                    }

                    break;

                case "Aegean":

                    if (type == "standard cabin")
                    {
                        price = 23.00;
                    }

                    else if (type == "cabin with balcony")
                    {
                        price = 26.60;
                    }

                    else if (type == "apartment")
                    {
                        price = 39.80;
                    }

                    break;
            }

            double total = price * 4 * nights;

            if (nights > 7)
            {
                total = total * 0.75;
            }

            Console.WriteLine($"Annie's holiday in the {cruise} sea costs {total:f2} lv.");
        }
    }
}