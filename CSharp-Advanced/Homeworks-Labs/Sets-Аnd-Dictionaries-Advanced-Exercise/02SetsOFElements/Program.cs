using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            HashSet<int> firstSet = new HashSet<int>(sizes[0]);
            HashSet<int> secondSet = new HashSet<int>(sizes[1]);
            HashSet<int> uniqueElInBoth = new HashSet<int>();

            for (int i = 0; i < sizes[0] + sizes[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (i >= sizes[0])
                {
                    secondSet.Add(num);
                }
                else
                    firstSet.Add(num);
            }

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    uniqueElInBoth.Add(item);
                }
            }
            Console.WriteLine(string.Join(" ", uniqueElInBoth));
        }
    }
}