using System;

namespace morecomplicatedstatements
{
    class Program
    {
        static void Main(string[] args)
        {

            string fruit = Console.ReadLine();
            string dayofweek = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());


            double price = 0.0;

            switch (dayofweek)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    {
                        if (fruit == "banana") price = 2.5 * quantity;
                        else if (fruit == "apple") price = 1.2 * quantity;
                        else if (fruit == "orange") price = 0.85 * quantity;
                        else if (fruit == "grapefruit") price = 1.45 * quantity;
                        else if (fruit == "kiwi") price = 2.7 * quantity;
                        else if (fruit == "pineapple") price = 5.5 * quantity;
                        else if (fruit == "grapes") price = 3.85 * quantity;
                        if (price == 0) Console.WriteLine("error");
                        else Console.WriteLine($"{price:f2}");
                        break;
                    }

                case "Saturday":
                case "Sunday":
                    {
                        if (fruit == "banana") price = 2.7 * quantity;
                        else if (fruit == "apple") price = 1.25 * quantity;
                        else if (fruit == "orange") price = 0.9 * quantity;
                        else if (fruit == "grapefruit") price = 1.6 * quantity;
                        else if (fruit == "kiwi") price = 3 * quantity;
                        else if (fruit == "pineapple") price = 5.6 * quantity;
                        else if (fruit == "grapes") price = 4.2 * quantity;
                        if (price == 0) Console.WriteLine("error");
                        else Console.WriteLine($"{price:f2}");
                        break;
                    }
                default:
                    Console.WriteLine("error");
                    break;
            }
        }

    }
}
