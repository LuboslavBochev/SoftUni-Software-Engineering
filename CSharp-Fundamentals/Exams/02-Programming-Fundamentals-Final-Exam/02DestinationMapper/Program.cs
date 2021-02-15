using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Final_Fund_Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            string places = Console.ReadLine();

            string pattern = @"([\=\/])(?<dest>[A-Z][A-Za-z]{2,})\1";
            int length = 0;

            MatchCollection validPlaces = Regex.Matches(places, pattern);

            if (validPlaces.Count > 0)
            {
                Console.Write("Destinations: ");
                Console.WriteLine(string.Join(", ", validPlaces.Select(x => x.Groups["dest"].Value)));

                foreach (Match item in validPlaces)
                {
                    length += item.Groups["dest"].Value.Length;
                }
                Console.WriteLine($"Travel Points: {length}");
            }
            else
            {
                Console.WriteLine("Destinations:");
                Console.WriteLine($"Travel Points: {length}");
            }
        }
    }
}