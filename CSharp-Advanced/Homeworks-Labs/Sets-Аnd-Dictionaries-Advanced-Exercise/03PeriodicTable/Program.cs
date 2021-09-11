using System;
using System.Collections.Generic;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int numLines = int.Parse(Console.ReadLine());

            SortedSet<string> chemicalElements = new SortedSet<string>();

            for (int i = 0; i < numLines; i++)
            {
                string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in elements)
                {
                    if (!chemicalElements.Contains(element))
                    {
                        chemicalElements.Add(element);
                    }
                }
            }
            foreach (var item in chemicalElements)
            {
                Console.Write(item + " ");
            }
        }
    }
}