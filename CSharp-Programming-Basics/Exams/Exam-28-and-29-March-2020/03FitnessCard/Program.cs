using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            // 33 min ot predi

            double sum = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double price = 0;
            double total = 0;

            switch (sport)
            {
                case "Gym":

                    if (gender == "m")
                    {
                        price = 42;
                        total = price;

                        if (age <= 19)
                        {
                            total = price * 0.8;
                        }
                    }
                    else if (gender == "f")
                    {
                        price = 35;
                        total = price;
                        if (age <= 19)
                        {
                            total = price * 0.8;
                        }
                    }
                    break;

                case "Boxing":
                    if (gender == "m")
                    {
                        price = 41;
                        total = price;
                        if (age <= 19)
                        {
                            total = price * 0.8;
                        }
                    }
                    else if (gender == "f")
                    {
                        price = 37;
                        total = price;
                        if (age <= 19)
                        {
                            total = price * 0.8;
                        }
                    }

                    break;
                case "Yoga":

                    if (gender == "m")
                    {
                        price = 45;
                        total = price;
                        if (age <= 19)
                        {
                            total = price * 0.8;
                        }
                    }
                    else if (gender == "f")
                    {
                        price = 42;
                        total = price;
                        if (age <= 19)
                        {
                            total = price * 0.8;
                        }
                    }
                    break;

                case "Zumba":
                    if (gender == "m")
                    {
                        price = 34;
                        total = price;
                        if (age <= 19)
                        {
                            total = price * 0.8;
                        }
                    }
                    else if (gender == "f")
                    {
                        price = 31;
                        total = price;
                        if (age <= 19)
                        {
                            total = price * 0.8;
                        }
                    }

                    break;
                case "Dances":

                    if (gender == "m")
                    {
                        price = 51;
                        total = price;
                        if (age <= 19)
                        {
                            total = price * 0.8;
                        }
                    }
                    else if (gender == "f")
                    {
                        price = 53;
                        total = price;
                        if (age <= 19)
                        {
                            total = price * 0.8;
                        }
                    }
                    break;

                case "Pilates":

                    if (gender == "m")
                    {
                        price = 39;
                        total = price;

                        if (age <= 19)
                        {
                            total = price * 0.8;
                        }
                    }
                    else if (gender == "f")
                    {
                        price = 37;
                        total = price;
                        if (age <= 19)
                        {
                            total = price * 0.8;
                        }
                    }
                    break;
            }
            if (sum > total)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }

            else if (sum < total)
            {
                Console.WriteLine($"You don't have enough money! You need ${total - sum:f2} more.");
            }
        }
    }
}
