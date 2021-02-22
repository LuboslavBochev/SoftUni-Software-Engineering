using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Final_Fund_Exam_More
{
    class Program
    {
        static void Main(string[] args)
        {

            string givenText = Console.ReadLine();

            string pattern = @"(@{1}|#{1})(?<text>[A-Za-z]{3,})\1\1(?<text2>[A-Za-z]{3,})\1";
            List<string> mirrorWords = new List<string>();

            MatchCollection matchedPairs = Regex.Matches(givenText, pattern);

            if (matchedPairs.Count > 0)
            {
                foreach (Match item in matchedPairs)
                {
                    string firstText = item.Groups["text"].Value;
                    string secondText = item.Groups["text2"].Value;

                    string reversed = ReversedTxt(secondText);

                    if (firstText == reversed)
                    {
                        mirrorWords.Add($"{firstText} <=> {secondText}");
                    }
                }
            }

            else
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }

            Console.WriteLine($"{matchedPairs.Count} word pairs found!");

            if (mirrorWords.Count == 0) Console.WriteLine("No mirror words!");

            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
        }

        static string ReversedTxt(string secondText)
        {
            string reversed = string.Empty;

            for (int i = secondText.Length - 1; i >= 0; i--)
            {
                reversed += secondText[i];
            }
            return reversed;
        }
    }
}