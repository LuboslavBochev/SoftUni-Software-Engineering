using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            string someText = Console.ReadLine();

            Dictionary<char, int> occurrences = new Dictionary<char, int>();

            foreach (var item in someText)
            {
                if (!occurrences.ContainsKey(item))
                {
                    occurrences.Add(item, 0);
                }
                occurrences[item]++;
            }

            foreach (var item in occurrences.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}