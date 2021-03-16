using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Final_Fund_Exam_More
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine();
            string pattern = @"(\|{1}|\#{1})(?<name>[A-Za-z\s]+)\1(?<expDate>\d{2}\/\d{2}\/\d{2})\1(?<colories>\d+)\1";

            int daysToLast = 0;

            MatchCollection matchedFoods = Regex.Matches(text, pattern);

            if (matchedFoods.Count > 0)
            {
                int totalKcal = 0;

                foreach (Match item in matchedFoods)
                {
                    totalKcal += int.Parse(item.Groups["colories"].Value);
                }

                daysToLast = totalKcal / 2000;

                Console.WriteLine($"You have food to last you for: {daysToLast} days!");

                if (daysToLast > 0)
                {
                    foreach (Match item in matchedFoods)
                    {
                        Console.WriteLine($"Item: {item.Groups["name"]}, Best before: {item.Groups["expDate"]}, Nutrition: {item.Groups["colories"]}");
                    }
                }
            }

            else
            {
                Console.WriteLine($"You have food to last you for: {daysToLast} days!");
            }
        }
    }
}