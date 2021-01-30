using System;

namespace zadachizaizpit
{
    class Program
    {
        static void Main(string[] args)
        {
            // input 2 string // int br setove
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int countSets = int.Parse(Console.ReadLine());
            // double price , total
            double price = 0;
            double total = 0;
            // switch
            switch (fruit)
            {
                case "Watermelon":

                    if (size == "small")
                    {
                        price = 2 * 56;
                        total = price * countSets;

                        if (total >= 400 && total <= 1000)
                        {
                            total = total * 0.85;
                        }
                        else if (total > 1000)
                        {
                            total = total * 0.5;
                        }
                    }
                    else if (size == "big")
                    {
                        price = 5 * 28.70;
                        total = price * countSets;

                        if (total >= 400 && total <= 1000)
                        {
                            total = total * 0.85;
                        }
                        else if (total > 1000)
                        {
                            total = total * 0.5;
                        }
                    }
                    break;
                case "Mango":
                    if (size == "small")
                    {
                        price = 2 * 36.66;
                        total = price * countSets;

                        if (total >= 400 && total <= 1000)
                        {
                            total = total * 0.85;
                        }
                        else if (total > 1000)
                        {
                            total = total * 0.5;
                        }
                    }
                    else if (size == "big")
                    {
                        price = 5 * 19.60;
                        total = price * countSets;

                        if (total >= 400 && total <= 1000)
                        {
                            total = total * 0.85;
                        }
                        else if (total > 1000)
                        {
                            total = total * 0.5;
                        }
                    }
                    break;
                case "Pineapple":
                    if (size == "small")
                    {
                        price = 2 * 42.10;
                        total = price * countSets;

                        if (total >= 400 && total <= 1000)
                        {
                            total = total * 0.85;
                        }
                        else if (total > 1000)
                        {
                            total = total * 0.5;
                        }
                    }
                    else if (size == "big")
                    {
                        price = 5 * 24.80;
                        total = price * countSets;

                        if (total >= 400 && total <= 1000)
                        {
                            total = total * 0.85;
                        }
                        else if (total > 1000)
                        {
                            total = total * 0.5;
                        }
                    }
                    break;

                case "Raspberry":
                    if (size == "small")
                    {
                        price = 2 * 20;
                        total = price * countSets;

                        if (total >= 400 && total <= 1000)
                        {
                            total = total * 0.85;
                        }
                        else if (total > 1000)
                        {
                            total = total * 0.5;
                        }
                    }
                    else if (size == "big")
                    {
                        price = 5 * 15.2;
                        total = price * countSets;

                        if (total >= 400 && total <= 1000)
                        {
                            total = total * 0.85;
                        }
                        else if (total > 1000)
                        {
                            total = total * 0.5;
                        }
                    }
                    break;
            }
            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
