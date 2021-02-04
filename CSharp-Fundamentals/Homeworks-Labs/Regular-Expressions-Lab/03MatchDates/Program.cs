using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Regular_Ex
{
    class Program
    {
        static void Main(string[] args)
        {

            string inputDates = Console.ReadLine();

            string patern = @"\b(\d{2})(?<delimiter>[-.\/])(?<month>[A-Z][a-z]{2})\2(?<year>\d{4})\b";

            MatchCollection matchedDates = Regex.Matches(inputDates, patern);

            foreach (Match matchDate in matchedDates)
            {
                var day = matchDate.Groups[1];
                var month = matchDate.Groups[3];
                var year = matchDate.Groups[4];

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}