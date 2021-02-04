using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RegularExM_2
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            string pattern = @"(([^\d]+)(\d+))";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            StringBuilder output = new StringBuilder();

            foreach (Match match in matches)
            {
                string message = match.Groups[2].Value;
                int repeats = int.Parse(match.Groups[3].Value);

                for (int i = 0; i < repeats; i++)
                {
                    output.Append(message.ToUpper());
                }
            }

            int count = output.ToString().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {count}");
            Console.WriteLine(output);
        }
    }
}