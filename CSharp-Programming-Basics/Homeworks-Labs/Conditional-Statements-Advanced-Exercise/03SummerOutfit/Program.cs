using System;

namespace morecomplicatedstatements
{
    class Program
    {
        static void Main(string[] args)
        {
            //input degrees , partOfDay
            int degrees = int.Parse(Console.ReadLine());
            string partOfDay = Console.ReadLine();
            // two string variables for outfit and shoes
            string outFit = "";
            string shoes = "";
            // checking according degrees in celsium
            switch (partOfDay)
            {
                case "Morning":

                    if (degrees >= 10 && degrees <= 18)
                    {
                        outFit = "Sweatshirt";
                        shoes = "Sneakers";
                    }
                    else if (degrees > 18 && degrees <= 24)
                    {
                        outFit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (degrees >= 25)
                    {
                        outFit = "T-Shirt";
                        shoes = "Sandals";
                    }
                    break;

                case "Afternoon":

                    if (degrees >= 10 && degrees <= 18)
                    {
                        outFit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (degrees > 18 && degrees <= 24)
                    {
                        outFit = "T-Shirt";
                        shoes = "Sandals";
                    }
                    else if (degrees >= 25)
                    {
                        outFit = "Swim Suit";
                        shoes = "Barefoot";
                    }
                    break;

                case "Evening":

                    if (degrees >= 10 && degrees <= 18)
                    {
                        outFit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (degrees > 18 && degrees <= 24)
                    {
                        outFit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (degrees >= 25)
                    {
                        outFit = "Shirt";
                        shoes = "Moccasins";
                    }
                    break;

                default:
                    break;
            }
            Console.WriteLine($"It's {degrees} degrees, get your {outFit} and {shoes}.");


        }

    }
}
