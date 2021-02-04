using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace RegularExM_1
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] tickets = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            string pattern = @"(\@{6,}|\${6,}|\^{6,}|\#{6,})";

            for (int i = 0; i < tickets.Length; i++)
            {
                string ticket = tickets[i];

                if (ticket.Length == 20)
                {

                    var leftMatch = Regex.Match(ticket.Substring(0, 10), pattern);
                    var rightMatch = Regex.Match(ticket.Substring(10), pattern);
                    var minLen = Math.Min(leftMatch.Length, rightMatch.Length);

                    var leftPart = leftMatch.Value.Substring(0, minLen);
                    var rightPart = rightMatch.Value.Substring(0, minLen);

                    if (!leftMatch.Success || !rightMatch.Success)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }

                    else if (leftPart.Equals(rightPart))
                    {
                        if (leftMatch.Length + rightMatch.Length == 20)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {leftMatch.Length}{leftMatch.Value.FirstOrDefault()} Jackpot!");
                        }

                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {leftPart.Length}{leftMatch.Value.FirstOrDefault()}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ ticket}\" - no match{Environment.NewLine}");
                    }
                }
                else Console.WriteLine($"invalid ticket");
            }

        }
    }
}