using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> sequance = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            double averageValue = sequance.Average();

            List<int> topFive = new List<int>();

            if (sequance.Count == 1)
            {
                Console.WriteLine("No");
                return;
            }

            for (int i = 0; i < sequance.Count + i; i++)
            {
                if (i > 4) break;

                else
                {
                    int max = sequance.Max();
                    int index = sequance.IndexOf(max);

                    if (max > averageValue)
                    {
                        topFive.Add(max);
                        sequance.RemoveAt(index);
                    }
                }
            }

            if (topFive.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }
            else Console.WriteLine(string.Join(" ", topFive));
        }
    }
}