using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

            Dictionary<double, int> occurrences = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!occurrences.ContainsKey(input[i]))
                {
                    occurrences.Add(input[i], 0);
                }
                occurrences[input[i]]++;
            }

            foreach (var item in occurrences)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}