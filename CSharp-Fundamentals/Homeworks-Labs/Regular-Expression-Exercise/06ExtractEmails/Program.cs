using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegularEx_5
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine();

            string emailPattern = @"(?<email>\s(?<or>(?:[A-Za-z0-9]+[-._][A-Za-z0-9]+)|[A-Za-z0-9]+)@([a-z0-9]+(\-[a-z0-9]+)*\.)+[a-z]{2,})";

            MatchCollection matchedEmails = Regex.Matches(text, emailPattern);

            if (matchedEmails.Count > 0)
            {
                foreach (Match email in matchedEmails)
                {
                    Console.WriteLine(email.Value.Trim());
                }
            }
        }
    }
}