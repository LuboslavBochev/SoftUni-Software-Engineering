using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Final_Fund_Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"(:{2}|\*{2})(?<text>[A-Z][a-z]{2,})\1";
            string digitPattern = @"\d";

            string inputText = Console.ReadLine();

            List<string> coolEmojis = new List<string>();
            long coolThresholdSum = 1;

            MatchCollection matches = Regex.Matches(inputText, pattern);
            MatchCollection digitMatches = Regex.Matches(inputText, digitPattern);

            foreach (Match digit in digitMatches)
            {
                coolThresholdSum *= long.Parse(digit.Value);
            }

            foreach (Match match in matches)
            {
                string name = match.Groups["text"].Value;
                int sumNameAsDigits = 0;

                foreach (var item in name)
                {
                    sumNameAsDigits += item;
                }

                if (sumNameAsDigits > coolThresholdSum)
                {
                    coolEmojis.Add(match.Value);
                }
            }
            Console.WriteLine($"Cool threshold: {coolThresholdSum}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            Console.WriteLine(string.Join("\n", coolEmojis));
        }
    }
}