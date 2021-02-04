using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Regular_More_Ex_2
{
    class Program
    {
        static void Main(string[] args)
        {

            string patern = @"^\%(?<customer>[A-Z][a-z]+)\%[^|$\%.]*<(?<product>\w+)>[^|$\%.]*\|(?<count>\d+)\|[^|$\%.]*?(?<number>(?:\d+(?:\.\d*)?|\.\d+))\$";
            double totalSum = 0.0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of shift") break;

                Match matchedItems = Regex.Match(input, patern);

                if (matchedItems.Success)
                {
                    string customerName = matchedItems.Groups[1].Value;
                    string product = matchedItems.Groups[2].Value;
                    int count = int.Parse(matchedItems.Groups[3].Value);
                    double sum = double.Parse(matchedItems.Groups[4].Value);

                    Console.WriteLine($"{customerName}: {product} - {sum * count:f2}");

                    totalSum += sum * count;
                }
            }
            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}